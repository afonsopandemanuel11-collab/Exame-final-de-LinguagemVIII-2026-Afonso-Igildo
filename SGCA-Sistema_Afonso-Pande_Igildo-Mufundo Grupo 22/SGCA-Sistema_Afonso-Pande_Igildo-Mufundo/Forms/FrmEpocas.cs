using SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.DALL;
using SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Enums;
using SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Exceptions;
using SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Models;
using SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Services;
using SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Utils;

namespace SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Vistas
{
    public partial class FrmEpocas : Form
    {
        private readonly EpocaRepository _repo = new();
        private readonly GestorCooperativa _gestor = new();
        private int _idEditar = 0;

        public FrmEpocas()
        {
            InitializeComponent();
        }

        private void FrmEpocas_Load(object sender, EventArgs e)
        {
            //Estilo.Aplicar(this);
            Text = "Gestão de Épocas Agrícolas";
            btnEncerrar.Enabled = Permissoes.PodeEncerrarEpoca;
            cmbTipoEpoca.DataSource = Enum.GetValues(typeof(TipoEpoca));
            grpFormEpoca.Visible = false;
            CarregarEpocas();
        }

        private void CarregarEpocas()
        {
            try
            {
                var filtro = txtPesquisar?.Text?.Trim().ToLower() ?? "";
                var lista = _repo.ObterTodos()
                    .Where(ep => string.IsNullOrEmpty(filtro) ||
                        ep.Nome.ToLower().Contains(filtro) ||
                        ep.Ano.ToString().Contains(filtro))
                    .ToList();
                dgvEpocas.DataSource = lista;
                if (dgvEpocas.Columns.Count > 0)
                {
                    dgvEpocas.Columns["Id"].Visible = false;
                    dgvEpocas.Columns["DataInicio"].HeaderText = "Início";
                    dgvEpocas.Columns["DataFim"].HeaderText = "Fim";
                    dgvEpocas.Columns["Encerrada"].HeaderText = "Encerrada";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNovaEpoca_Click(object sender, EventArgs e)
        {
            _idEditar = 0;
            LimparFormEpoca();
            grpFormEpoca.Visible = true;
            grpFormEpoca.Text = "Nova Época";
        }

        private void btnEditarEpoca_Click(object sender, EventArgs e)
        {
            if (dgvEpocas.CurrentRow?.DataBoundItem is not EpocaAgricola ep) return;
            if (ep.Encerrada)
            {
                MessageBox.Show("Não é possível editar uma época encerrada.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _idEditar = ep.Id;
            txtNomeEpoca.Text = ep.Nome;
            cmbTipoEpoca.SelectedItem = ep.Tipo;
            nudAno.Value = ep.Ano;
            dtpInicio.Value = ep.DataInicio;
            dtpFim.Value = ep.DataFim;
            grpFormEpoca.Visible = true;
            grpFormEpoca.Text = "Editar Época";
        }

        private void btnEncerrar_Click(object sender, EventArgs e)
        {
            if (!Permissoes.VerificarOperacao(Permissoes.PodeEncerrarEpoca, "encerrar épocas"))
                return;

            if (dgvEpocas.CurrentRow?.DataBoundItem is not EpocaAgricola ep) return;
            if (ep.Encerrada)
            {
                MessageBox.Show("Esta época já está encerrada.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show($"Encerrar a época '{ep.Nome}'?\nNão será possível registar mais entregas ou preços.",
                    "Confirmar Encerramento", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
            try
            {
                _gestor.EncerrarEpoca(ep.Id);
                MessageBox.Show("Época encerrada com sucesso.", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                CarregarEpocas();
            }
            catch (EpocaEncerradaException ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalvarEpoca_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNomeEpoca.Text))
            {
                MessageBox.Show("O nome da época é obrigatório.", "Validação",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dtpInicio.Value >= dtpFim.Value)
            {
                MessageBox.Show("A data de início deve ser anterior à data de fim.", "Validação",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                var epoca = new EpocaAgricola
                {
                    Nome = txtNomeEpoca.Text.Trim(),
                    Tipo = (TipoEpoca)cmbTipoEpoca.SelectedItem!,
                    Ano = (int)nudAno.Value,
                    DataInicio = dtpInicio.Value.Date,
                    DataFim = dtpFim.Value.Date,
                    Encerrada = false,
                };

                if (_idEditar == 0)
                    _repo.Inserir(epoca);
                else
                {
                    epoca.Id = _idEditar;
                    _repo.Actualizar(epoca);
                }

                grpFormEpoca.Visible = false;
                CarregarEpocas();
                MessageBox.Show("Época guardada com sucesso.", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelarEpoca_Click(object sender, EventArgs e)
        {
            grpFormEpoca.Visible = false;
            LimparFormEpoca();
        }

        private void btnActualizar_Click(object sender, EventArgs e) => CarregarEpocas();

        private void txtPesquisar_TextChanged(object sender, EventArgs e) => CarregarEpocas();

        private void LimparFormEpoca()
        {
            txtNomeEpoca.Clear();
            nudAno.Value = DateTime.Today.Year;
            dtpInicio.Value = DateTime.Today;
            dtpFim.Value = DateTime.Today.AddMonths(6);
        }

        private void btnExportarCsv_Click(object sender, EventArgs e)
            => Exportador.ExportarCsv(dgvEpocas, "Epocas.csv");

        private void btnExportarPdf_Click(object sender, EventArgs e)
            => Exportador.ExportarPdf(dgvEpocas, "Listagem de Épocas Agrícolas", "Epocas.pdf");
    }
}
