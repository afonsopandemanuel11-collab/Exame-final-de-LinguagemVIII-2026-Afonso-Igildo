using SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.DALL;
using SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Services;
using SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Utils;

namespace SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Vistas
{
    public partial class FrmRelatorio : Form
    {
        private readonly EpocaRepository _epocaRepo = new();
        private readonly GestorCooperativa _gestor = new();

        public FrmRelatorio()
        {
            InitializeComponent();
        }

        private void FrmRelatorio_Load(object sender, EventArgs e)
        {
            Estilo.Aplicar(this);
            Text = "Relatório de Distribuição de Lucros";
            CarregarEpocas();
        }

        private void CarregarEpocas()
        {
            try
            {
                cmbEpoca.DataSource = _epocaRepo.ObterTodos().ToList();
                cmbEpoca.DisplayMember = "Nome";
                cmbEpoca.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar épocas:\n{ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGerarRelatorio_Click(object sender, EventArgs e)
        {
            if (cmbEpoca.SelectedValue is not int epocaId || epocaId <= 0)
            {
                MessageBox.Show("Por favor, seleccione uma época agrícola válida.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var resultado = _gestor.ObterRelatorioEpoca(epocaId).ToList();

                if (resultado.Count == 0)
                {
                    MessageBox.Show(
                        "Não existem dados de distribuição para esta época.\nExecute a comercialização e distribuição de lucros primeiro.",
                        "Sem Dados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvRelatorio.DataSource = null;
                    return;
                }

                var dados = resultado.Select(r => new
                {
                    Cooperativista = r.Cooperativista?.Nome ?? $"Cooperativista #{r.CooperativistaId}",
                    Quota = Formatador.Percentagem(r.QuotaAplicada),
                    ValorApurado = Formatador.Moeda(r.ValorApurado),
                    ValorLucro = Formatador.Moeda(r.ValorLucro),
                    DataDistribuicao = Formatador.Data(r.DataDistribuicao)
                }).ToList();

                dgvRelatorio.DataSource = dados;

                if (dgvRelatorio.Columns.Count > 0)
                {
                    dgvRelatorio.Columns["Cooperativista"].HeaderText = "Cooperativista";
                    dgvRelatorio.Columns["Quota"].HeaderText = "Quota";
                    dgvRelatorio.Columns["ValorApurado"].HeaderText = "Valor Apurado";
                    dgvRelatorio.Columns["ValorLucro"].HeaderText = "Valor Lucro";
                    dgvRelatorio.Columns["DataDistribuicao"].HeaderText = "Data Distribuição";
                }

                decimal totalApurado = resultado.Sum(r => r.ValorApurado);
                decimal totalLucro = resultado.Sum(r => r.ValorLucro);
                int totalCoops = resultado.Select(r => r.CooperativistaId).Distinct().Count();

                lblTotalApuradoRel.Text = $"Total Apurado: {Formatador.Moeda(totalApurado)}";
                lblTotalLucroRel.Text = $"Total Lucros: {Formatador.Moeda(totalLucro)}";
                lblTotalCoopRel.Text = $"Cooperativistas: {totalCoops}";
                lblInfoRelatorio.Text = $"Época: {cmbEpoca.Text}  |  Gerado: {DateTime.Now:dd/MM/yyyy HH:mm}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao gerar relatório:\n{ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            Exportador.ExportarCsv(dgvRelatorio,
                $"Relatorio_{cmbEpoca.Text.Replace(" ", "_")}.csv");
        }

        private void btnExportarPdf_Click(object sender, EventArgs e)
        {
            Exportador.ExportarPdf(dgvRelatorio,
                $"Relatório de Distribuição — {cmbEpoca.Text}",
                $"Relatorio_{cmbEpoca.Text.Replace(" ", "_")}.pdf",
                new[]
                {
                    lblTotalApuradoRel.Text,
                    lblTotalLucroRel.Text,
                    lblTotalCoopRel.Text
                });
        }
    }
}
