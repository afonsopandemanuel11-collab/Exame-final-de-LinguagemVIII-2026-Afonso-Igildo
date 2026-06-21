using SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.DALL;
using SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Models;
using SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Utils;

namespace SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Vistas
{
    public partial class FrmCategorias : Form
    {
        private readonly CategoriaProdutoRepository _repo = new();
        private int _idEditar = 0;

        public FrmCategorias()
        {
            InitializeComponent();
        }

        private void FrmCategorias_Load(object sender, EventArgs e)
        {
            Estilo.Aplicar(this);
            Text = "Gestão de Categorias de Produto";
            grpFormCategoria.Visible = false;
            CarregarCategorias();
        }

        private void CarregarCategorias()
        {
            try
            {
                var filtro = txtPesquisar.Text.Trim().ToLower();
                var lista = _repo.ObterTodos()
                    .Where(c => string.IsNullOrEmpty(filtro) ||
                        c.Nome.ToLower().Contains(filtro))
                    .ToList();

                dgvCategorias.DataSource = lista;

                if (dgvCategorias.Columns.Count > 0)
                {
                    if (dgvCategorias.Columns.Contains("Id"))
                        dgvCategorias.Columns["Id"].Visible = false;
                    if (dgvCategorias.Columns.Contains("Nome"))
                        dgvCategorias.Columns["Nome"].HeaderText = "Categoria";
                    if (dgvCategorias.Columns.Contains("Descricao"))
                        dgvCategorias.Columns["Descricao"].HeaderText = "Descrição";
                }

                lblTotal.Text = $"Total: {lista.Count} categoria(s)";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar categorias:\n{ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNova_Click(object sender, EventArgs e)
        {
            _idEditar = 0;
            LimparFormulario();
            grpFormCategoria.Visible = true;
            grpFormCategoria.Text = "Nova Categoria";
            txtNomeCategoria.Focus();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvCategorias.CurrentRow?.DataBoundItem is not CategoriaProduto cat) return;

            _idEditar = cat.Id;
            txtNomeCategoria.Text = cat.Nome;
            txtDescricaoCategoria.Text = cat.Descricao ?? "";
            grpFormCategoria.Visible = true;
            grpFormCategoria.Text = $"Editar — {cat.Nome}";
            txtNomeCategoria.Focus();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!Permissoes.VerificarOperacao(Permissoes.PodeEliminar, "eliminar categorias"))
                return;

            if (dgvCategorias.CurrentRow?.DataBoundItem is not CategoriaProduto cat) return;

            if (MessageBox.Show(
                    $"Eliminar a categoria '{cat.Nome}'?\nOs produtos associados ficarão sem categoria.",
                    "Confirmar Eliminação",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            try
            {
                _repo.Eliminar(cat.Id);
                CarregarCategorias();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao eliminar:\n{ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!Validador.CampoObrigatorio(txtNomeCategoria.Text))
            {
                Validador.DestacarCampo(txtNomeCategoria, true);
                MessageBox.Show("O nome da categoria é obrigatório.",
                    "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Validador.DestacarCampo(txtNomeCategoria, false);

            try
            {
                var cat = new CategoriaProduto
                {
                    Nome = txtNomeCategoria.Text.Trim(),
                    Descricao = string.IsNullOrWhiteSpace(txtDescricaoCategoria.Text)
                        ? null
                        : txtDescricaoCategoria.Text.Trim()
                };

                if (_idEditar == 0)
                {
                    _repo.Inserir(cat);
                    MessageBox.Show("Categoria criada com sucesso.",
                        "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    cat.Id = _idEditar;
                    _repo.Actualizar(cat);
                    MessageBox.Show("Categoria actualizada com sucesso.",
                        "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                grpFormCategoria.Visible = false;
                LimparFormulario();
                CarregarCategorias();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            grpFormCategoria.Visible = false;
            LimparFormulario();
        }

        private void LimparFormulario()
        {
            txtNomeCategoria.Clear();
            txtDescricaoCategoria.Clear();
            _idEditar = 0;
        }

        private void btnActualizar_Click(object sender, EventArgs e) => CarregarCategorias();

        private void txtPesquisar_TextChanged(object sender, EventArgs e) => CarregarCategorias();

        private void dgvCategorias_DoubleClick(object sender, EventArgs e) => btnEditar_Click(sender, e);

        private void btnExportarCsv_Click(object sender, EventArgs e)
            => Exportador.ExportarCsv(dgvCategorias, "Categorias.csv");

        private void btnExportarPdf_Click(object sender, EventArgs e)
            => Exportador.ExportarPdf(dgvCategorias, "Listagem de Categorias de Produto",
                "Categorias.pdf", new[] { lblTotal.Text });
    }
}
