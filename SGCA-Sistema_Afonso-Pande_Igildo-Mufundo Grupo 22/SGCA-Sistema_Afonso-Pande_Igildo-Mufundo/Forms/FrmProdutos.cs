using SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.DALL;
using SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Models;
using SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Utils;

namespace SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Vistas
{
    public partial class FrmProdutos : Form
    {
        private readonly ProdutoRepository _prodRepo = new();
        private readonly CategoriaProdutoRepository _catRepo = new();
        private int _idEditar = 0;

        public FrmProdutos()
        {
            InitializeComponent();
        }

        private void FrmProdutos_Load(object sender, EventArgs e)
        {
           // Estilo.Aplicar(this);
            Text = "Gestão de Produtos";
            btnInactivar.Enabled = Permissoes.PodeDesactivar;
            CarregarCategorias();
            CarregarProdutos();
        }

        private void CarregarCategorias()
        {
            var cats = _catRepo.ObterTodos().ToList();
            cmbCategoria.DataSource = cats;
            cmbCategoria.DisplayMember = "Nome";
            cmbCategoria.ValueMember = "Id";
        }

        private void CarregarProdutos()
        {
            try
            {
                var filtro = txtPesquisar?.Text?.Trim().ToLower() ?? "";
                var lista = _prodRepo.ObterTodos()
                    .Where(p => string.IsNullOrEmpty(filtro) ||
                        p.Nome.ToLower().Contains(filtro) ||
                        p.Codigo.ToLower().Contains(filtro))
                    .ToList();

                dgvProdutos.DataSource = lista;
                if (dgvProdutos.Columns.Count > 0)
                {
                    dgvProdutos.Columns["CategoriaId"].Visible = false;
                    dgvProdutos.Columns["Codigo"].HeaderText = "Código";
                    dgvProdutos.Columns["UnidadeMedida"].HeaderText = "Unidade";
                    dgvProdutos.Columns["Activo"].HeaderText = "Activo";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar produtos:\n{ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btNovo_Click(object sender, EventArgs e)
        {
            _idEditar = 0;
            LimparFormulario();
            grpForm.Visible = true;
            txtNomeProd.Focus();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvProdutos.CurrentRow?.DataBoundItem is not ProdutoAgricola p) return;
            _idEditar = p.Id;
            txtCodigo.Text = p.Codigo;
            txtNomeProd.Text = p.Nome;
            txtUnidade.Text = p.UnidadeMedida;
            foreach (CategoriaProduto cat in cmbCategoria.Items)
                if (cat.Id == p.CategoriaId) { cmbCategoria.SelectedItem = cat; break; }
            grpForm.Visible = true;
            txtNomeProd.Focus();
        }

        private void btnInactivar_Click(object sender, EventArgs e)
        {
            if (!Permissoes.VerificarOperacao(Permissoes.PodeDesactivar, "inactivar produtos"))
                return;

            if (dgvProdutos.CurrentRow?.DataBoundItem is not ProdutoAgricola p) return;
            if (MessageBox.Show($"Inactivar '{p.Nome}'?", "Confirmar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
            try
            {
                _prodRepo.Eliminar(p.Id);
                CarregarProdutos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalvarProd_Click(object sender, EventArgs e)
        {
            if (!Validador.CampoObrigatorio(txtNomeProd.Text) ||
                !Validador.CampoObrigatorio(txtCodigo.Text) ||
                !Validador.CampoObrigatorio(txtUnidade.Text))
            {
                MessageBox.Show("Preencha todos os campos obrigatórios.",
                    "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                var cat = cmbCategoria.SelectedItem as CategoriaProduto;
                if (_idEditar == 0)
                {
                    _prodRepo.Inserir(new ProdutoAgricola
                    {
                        Codigo = txtCodigo.Text.Trim(),
                        Nome = txtNomeProd.Text.Trim(),
                        UnidadeMedida = txtUnidade.Text.Trim(),
                        CategoriaId = cat?.Id ?? 1,
                    });
                }
                else
                {
                    _prodRepo.Actualizar(new ProdutoAgricola
                    {
                        Id = _idEditar,
                        Codigo = txtCodigo.Text.Trim(),
                        Nome = txtNomeProd.Text.Trim(),
                        UnidadeMedida = txtUnidade.Text.Trim(),
                        CategoriaId = cat?.Id ?? 1,
                        Activo = true,
                    });
                }
                grpForm.Visible = false;
                CarregarProdutos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelarProd_Click(object sender, EventArgs e)
        {
            grpForm.Visible = false;
            LimparFormulario();
        }

        private void LimparFormulario()
        {
            txtCodigo.Clear();
            txtNomeProd.Clear();
            txtUnidade.Clear();
        }

        private void btnActualizar_Click(object sender, EventArgs e) => CarregarProdutos();

        private void txtPesquisar_TextChanged(object sender, EventArgs e) => CarregarProdutos();

        private void btnExportarCsv_Click(object sender, EventArgs e)
            => Exportador.ExportarCsv(dgvProdutos, "Produtos.csv");

        private void btnExportarPdf_Click(object sender, EventArgs e)
            => Exportador.ExportarPdf(dgvProdutos, "Listagem de Produtos", "Produtos.pdf");
    }
}
