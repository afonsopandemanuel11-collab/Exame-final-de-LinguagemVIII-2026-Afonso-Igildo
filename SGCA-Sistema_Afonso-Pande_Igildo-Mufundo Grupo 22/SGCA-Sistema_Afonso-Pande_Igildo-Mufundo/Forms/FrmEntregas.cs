using SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.DALL;
using SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Models;
using SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Utils;

namespace SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Vistas
{
    public partial class FrmEntregas : Form
    {
        private readonly EntregaRepository _repo = new();
        private readonly CooperativistaRepository _coopRepo = new();
        private readonly EpocaRepository _epocaRepo = new();
        private readonly ProdutoRepository _prodRepo = new();

        public FrmEntregas()
        {
            InitializeComponent();
        }

        private void FrmEntregas_Load(object sender, EventArgs e)
        {
            Estilo.Aplicar(this);
            Text = "Gestão de Entregas";
            btnEliminar.Enabled = Permissoes.PodeEliminar;
            CarregarFiltros();
            CarregarEntregas();
        }

        private void CarregarFiltros()
        {
            var coops = _coopRepo.ObterActivos().ToList();
            coops.Insert(0, new Cooperativista { Id = 0, Nome = "-- Todos --" });
            cmbFiltroCooperativista.DataSource = coops;
            cmbFiltroCooperativista.DisplayMember = "Nome";
            cmbFiltroCooperativista.ValueMember = "Id";

            var epocas = _epocaRepo.ObterTodos().ToList();
            epocas.Insert(0, new EpocaAgricola { Id = 0, Nome = "-- Todas --" });
            cmbFiltroEpoca.DataSource = epocas;
            cmbFiltroEpoca.DisplayMember = "Nome";
            cmbFiltroEpoca.ValueMember = "Id";
        }

        private void CarregarEntregas()
        {
            try
            {
                int coopId = (int)cmbFiltroCooperativista.SelectedValue!;
                int epocaId = (int)cmbFiltroEpoca.SelectedValue!;

                IEnumerable<Entrega> lista;
                if (coopId > 0 && epocaId > 0)
                    lista = _repo.ObterPorCooperativistaEEpoca(coopId, epocaId);
                else if (epocaId > 0)
                    lista = _repo.ObterPorEpoca(epocaId);
                else if (coopId > 0)
                    lista = _repo.ObterTodos().Where(e => e.CooperativistaId == coopId);
                else
                    lista = _repo.ObterTodos();

                var coops = _coopRepo.ObterTodos().ToDictionary(c => c.Id, c => c.Nome);
                var prods = _prodRepo.ObterTodos().ToDictionary(p => p.Id, p => p.Nome);
                var epocas = _epocaRepo.ObterTodos().ToDictionary(e => e.Id, e => e.Nome);

                var filtro = txtPesquisar?.Text?.Trim().ToLower() ?? "";
                var dados = lista
                    .Select(e => new
                    {
                        e.Id,
                        Cooperativista = coops.GetValueOrDefault(e.CooperativistaId, $"#{e.CooperativistaId}"),
                        Produto = prods.GetValueOrDefault(e.ProdutoId, $"#{e.ProdutoId}"),
                        Epoca = epocas.GetValueOrDefault(e.EpocaId, $"#{e.EpocaId}"),
                        Data = Formatador.Data(e.DataEntrega),
                        Quantidade = e.Quantidade.ToString("N2"),
                        e.Observacoes
                    })
                    .Where(d => string.IsNullOrEmpty(filtro) ||
                        d.Cooperativista.ToLower().Contains(filtro) ||
                        d.Produto.ToLower().Contains(filtro))
                    .ToList();

                dgvEntregas.DataSource = dados;
                if (dgvEntregas.Columns.Contains("Id"))
                    dgvEntregas.Columns["Id"].Visible = false;

                lblTotalEntregas.Text = $"Total: {dados.Count} entrega(s)";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNovaEntrega_Click(object sender, EventArgs e)
        {
            using var frm = new FrmCadEntrega();
            if (frm.ShowDialog() == DialogResult.OK)
                CarregarEntregas();
        }

        private void btnEditarEntrega_Click(object sender, EventArgs e)
        {
            if (dgvEntregas.CurrentRow?.Cells["Id"].Value is not int id || id <= 0) return;
            var entrega = _repo.ObterPorId(id);
            if (entrega == null) return;
            using var frm = new FrmCadEntrega(entrega);
            if (frm.ShowDialog() == DialogResult.OK)
                CarregarEntregas();
        }

        private void dgvEntregas_DoubleClick(object sender, EventArgs e)
            => btnEditarEntrega_Click(sender, e);

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!Permissoes.VerificarOperacao(Permissoes.PodeEliminar, "eliminar entregas"))
                return;

            if (dgvEntregas.CurrentRow?.Cells["Id"].Value is not int id) return;
            if (MessageBox.Show("Eliminar esta entrega?", "Confirmar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
            try
            {
                _repo.Eliminar(id);
                CarregarEntregas();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e) => CarregarEntregas();
        private void btnActualizar_Click(object sender, EventArgs e) => CarregarEntregas();

        private void txtPesquisar_TextChanged(object sender, EventArgs e) => CarregarEntregas();

        private void btnExportarCsv_Click(object sender, EventArgs e)
            => Exportador.ExportarCsv(dgvEntregas, "Entregas.csv");

        private void btnExportarPdf_Click(object sender, EventArgs e)
            => Exportador.ExportarPdf(dgvEntregas, "Listagem de Entregas",
                "Entregas.pdf", new[] { lblTotalEntregas.Text });
    }
}
