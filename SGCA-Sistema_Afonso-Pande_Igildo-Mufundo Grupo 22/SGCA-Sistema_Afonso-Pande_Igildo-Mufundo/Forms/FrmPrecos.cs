using SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Exceptions;
using SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Models;
using SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Utils;
using SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.DALL;

namespace SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Vistas
{
    public partial class FrmPrecos : Form
    {
        private readonly PrecoRepository _precoRepo = new();
        private readonly EpocaRepository _epocaRepo = new();
        private readonly ProdutoRepository _prodRepo = new();

        public FrmPrecos()
        {
            InitializeComponent();
        }

        private void FrmPrecos_Load(object sender, EventArgs e)
        {
            Estilo.Aplicar(this);
            Text = "Gestão de Preços";
            btnEliminar.Enabled = Permissoes.PodeEliminar;
            CarregarEpocas();
            CarregarProdutosCombo();
            grpFormPreco.Visible = false;
        }

        private void CarregarEpocas()
        {
            cmbEpocaPreco.DataSource = _epocaRepo.ObterTodos().ToList();
            cmbEpocaPreco.DisplayMember = "Nome";
            cmbEpocaPreco.ValueMember = "Id";
        }

        private void CarregarProdutosCombo()
        {
            cmbProdutoPreco.DataSource = _prodRepo.ObterActivos().ToList();
            cmbProdutoPreco.DisplayMember = "Nome";
            cmbProdutoPreco.ValueMember = "Id";
        }

        private void cmbEpocaPreco_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarPrecosDaEpoca();
            if (cmbEpocaPreco.SelectedItem is EpocaAgricola ep)
            {
                lblEpocaPrecoStatus.Text = ep.Encerrada ? "Época ENCERRADA" : "Época ABERTA";
                lblEpocaPrecoStatus.ForeColor = ep.Encerrada
                    ? Color.FromArgb(180, 40, 40)
                    : Color.FromArgb(40, 120, 70);
            }
        }

        private void cmbProdutoPreco_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarPrecosDaEpoca();
        }

        private void CarregarPrecosDaEpoca()
        {
            try
            {
                if (cmbEpocaPreco.SelectedValue is not int epocaId) return;
                var prods = _prodRepo.ObterTodos().ToDictionary(p => p.Id, p => p.Nome);
                var lista = _precoRepo.ObterPorEpoca(epocaId)
                    .Select(p => new
                    {
                        p.Id,
                        Produto = prods.GetValueOrDefault(p.ProdutoId, $"#{p.ProdutoId}"),
                        Preco = Formatador.Moeda(p.PrecoUnitario),
                        Data = Formatador.Data(p.DataDefinicao)
                    })
                    .ToList();
                dgvPrecos.DataSource = lista;
                if (dgvPrecos.Columns.Contains("Id"))
                    dgvPrecos.Columns["Id"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDefinirPreco_Click(object sender, EventArgs e)
        {
            var ep = cmbEpocaPreco.SelectedItem as EpocaAgricola;
            if (ep == null) return;
            if (ep.Encerrada)
            {
                MessageBox.Show($"A época '{ep.Nome}' está encerrada. Não é possível definir preços.",
                    "Época Encerrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            dtpDataDefinicao.Value = DateTime.Today;
            grpFormPreco.Visible = true;
        }

        private void btnSalvarPreco_Click(object sender, EventArgs e)
        {
            Validador.DestacarCampo(txtPrecoUnitario, false);
            if (!Validador.PrecoValido(txtPrecoUnitario.Text, out decimal preco))
            {
                Validador.DestacarCampo(txtPrecoUnitario, true);
                MessageBox.Show("Preço inválido. Deve ser um número maior que zero.",
                    "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                var ep = cmbEpocaPreco.SelectedItem as EpocaAgricola;
                if (ep == null) return;
                if (ep.Encerrada)
                    throw new EpocaEncerradaException($"A época '{ep.Nome}' está encerrada.");

                _precoRepo.Inserir(new PrecoComercializacao
                {
                    ProdutoId = (int)cmbProdutoPreco.SelectedValue!,
                    EpocaId = ep.Id,
                    PrecoUnitario = preco,
                    DataDefinicao = dtpDataDefinicao.Value.Date,
                });

                grpFormPreco.Visible = false;
                CarregarPrecosDaEpoca();
                MessageBox.Show("Preço definido com sucesso!", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (EpocaEncerradaException ex)
            {
                MessageBox.Show(ex.Message, "Época Encerrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelarPreco_Click(object sender, EventArgs e) => grpFormPreco.Visible = false;

        private void btnActualizarPrecos_Click(object sender, EventArgs e) => CarregarPrecosDaEpoca();

        private void btnEliminarPreco_Click(object sender, EventArgs e)
        {
            if (!Permissoes.VerificarOperacao(Permissoes.PodeEliminar, "eliminar preços"))
                return;

            if (dgvPrecos.CurrentRow?.Cells["Id"].Value is not int id) return;
            if (MessageBox.Show("Eliminar este preço?", "Confirmar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
            try
            {
                _precoRepo.Eliminar(id);
                CarregarPrecosDaEpoca();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportarCsv_Click(object sender, EventArgs e)
            => Exportador.ExportarCsv(dgvPrecos, "Precos.csv");

        private void btnExportarPdf_Click(object sender, EventArgs e)
            => Exportador.ExportarPdf(dgvPrecos, "Listagem de Preços",
                "Precos.pdf", new[] { lblEpocaPrecoStatus.Text });
    }
}
