using SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.DALL;
using SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Models;
using SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Utils;

namespace SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Vistas
{
    public partial class FrmCooperativistas : Form
    {
        private readonly CooperativistaRepository _repo = new();

        public FrmCooperativistas()
        {
            InitializeComponent();
        }

        private void FrmCooperativistas_Load(object sender, EventArgs e)
        {
            Estilo.Aplicar(this);
            Text = "Gestão de Cooperativistas";
            btnDesactivar.Enabled = Permissoes.PodeDesactivar;
            CarregarDados();
        }

        private void CarregarDados(string? filtro = null)
        {
            try
            {
                var lista = _repo.ObterTodos().ToList();
                if (!string.IsNullOrWhiteSpace(filtro))
                {
                    var t = filtro.ToLower();
                    lista = lista.Where(c =>
                        c.Nome.ToLower().Contains(t) ||
                        c.NumeroSocio.ToLower().Contains(t) ||
                        c.BilheteId.ToLower().Contains(t)).ToList();
                }

                dgvCooperativistas.DataSource = lista;

                if (dgvCooperativistas.Columns.Count > 0)
                {
                    dgvCooperativistas.Columns["Id"].Visible = false;
                    dgvCooperativistas.Columns["NumeroSocio"].HeaderText = "Nº Sócio";
                    dgvCooperativistas.Columns["QuotaPercent"].HeaderText = "Quota (%)";
                    dgvCooperativistas.Columns["DataAdesao"].HeaderText = "Data Adesão";
                    dgvCooperativistas.Columns["Activo"].HeaderText = "Activo";
                    dgvCooperativistas.Columns["BilheteId"].HeaderText = "Bilhete ID";
                }

                decimal soma = lista.Where(c => c.Activo).Sum(c => c.QuotaPercent);
                lblSomaQuotas.Text = $"Soma de quotas activas: {Formatador.Percentagem(soma)}";
                lblSomaQuotas.ForeColor = soma == 100m
                    ? Color.FromArgb(40, 120, 70)
                    : Color.FromArgb(180, 40, 40);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar cooperativistas:\n{ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            using var frm = new FrmCadCooperativista();
            if (frm.ShowDialog() == DialogResult.OK)
                CarregarDados(txtPesquisar.Text);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvCooperativistas.CurrentRow?.DataBoundItem is not Cooperativista coop) return;
            using var frm = new FrmCadCooperativista(coop);
            if (frm.ShowDialog() == DialogResult.OK)
                CarregarDados(txtPesquisar.Text);
        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            if (!Permissoes.VerificarOperacao(Permissoes.PodeDesactivar, "desactivar cooperativistas"))
                return;

            if (dgvCooperativistas.CurrentRow?.DataBoundItem is not Cooperativista coop) return;

            if (MessageBox.Show($"Desactivar '{coop.Nome}'?", "Confirmar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
            try
            {
                _repo.Eliminar(coop.Id);
                CarregarDados(txtPesquisar.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
            => CarregarDados(txtPesquisar.Text);

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
            => CarregarDados(txtPesquisar.Text);

        private void dgvCooperativistas_DoubleClick(object sender, EventArgs e)
            => btnEditar_Click(sender, e);

        private void btnExportarCsv_Click(object sender, EventArgs e)
            => Exportador.ExportarCsv(dgvCooperativistas, "Cooperativistas.csv");

        private void btnExportarPdf_Click(object sender, EventArgs e)
            => Exportador.ExportarPdf(dgvCooperativistas, "Listagem de Cooperativistas",
                "Cooperativistas.pdf", new[] { lblSomaQuotas.Text });
    }
}
