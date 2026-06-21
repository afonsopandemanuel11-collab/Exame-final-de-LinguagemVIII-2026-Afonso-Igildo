using SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.DALL;
using SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Enums;
using SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Exceptions;
using SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Models;
using SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Services;
using SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Utils;

namespace SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Vistas
{
    public partial class FrmComercializacao : Form
    {
        private readonly EpocaRepository _epocaRepo = new();
        private readonly EntregaRepository _entregaRepo = new();
        private readonly CooperativistaRepository _coopRepo = new();
        private readonly ProdutoRepository _prodRepo = new();
        private readonly ComercializacaoRepository _comRepo = new();
        private readonly GestorCooperativa _gestor = new();
        private readonly ServicoApuramento _apuramento = new();

        private List<Entrega> _entregasEpoca = new();

        public FrmComercializacao()
        {
            InitializeComponent();
        }

        private void FrmComercializacao_Load(object sender, EventArgs e)
        {
            Estilo.Aplicar(this);
            Text = "Comercialização e Distribuição de Lucros";
            dtpDataVenda.Value = DateTime.Today;
            CarregarEpocas();
        }

        private void CarregarEpocas()
        {
            var epocas = _epocaRepo.ObterAbertas().ToList();
            if (epocas.Count == 0)
            {
                epocas = _epocaRepo.ObterTodos().Where(e => !e.Encerrada).ToList();
            }
            cmbEpocaPreco.DataSource = epocas;
            cmbEpocaPreco.DisplayMember = "Nome";
            cmbEpocaPreco.ValueMember = "Id";
        }

        private void cmbEpocaPreco_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEpocaPreco.SelectedValue is int epocaId && epocaId > 0)
                CarregarEntregas(epocaId);
        }

        private void CarregarEntregas(int epocaId)
        {
            try
            {
                _entregasEpoca = _entregaRepo.ObterPorEpoca(epocaId).ToList();
                var coops = _coopRepo.ObterTodos().ToDictionary(c => c.Id, c => c.Nome);
                var prods = _prodRepo.ObterTodos().ToDictionary(p => p.Id, p => p.Nome);

                var texto = txtPesquisar.Text.Trim().ToLower();
                var dados = _entregasEpoca
                    .Where(e =>
                        string.IsNullOrEmpty(texto) ||
                        (coops.GetValueOrDefault(e.CooperativistaId)?.ToLower().Contains(texto) ?? false) ||
                        (prods.GetValueOrDefault(e.ProdutoId)?.ToLower().Contains(texto) ?? false))
                    .Select(e => new
                    {
                        Cooperativista = coops.GetValueOrDefault(e.CooperativistaId, $"#{e.CooperativistaId}"),
                        Produto = prods.GetValueOrDefault(e.ProdutoId, $"#{e.ProdutoId}"),
                        Data = Formatador.Data(e.DataEntrega),
                        Quantidade = e.Quantidade.ToString("N2")
                    })
                    .ToList();

                dgvEntregasCom.DataSource = dados;
                lblTotalApurado.Text = "Total apurado: — (clique em Calcular)";
                dgvDistribuicao.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (cmbEpocaPreco.SelectedValue is not int epocaId || epocaId <= 0)
            {
                MessageBox.Show("Seleccione uma época agrícola.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                decimal total = _apuramento.TotalApuradoEpoca(epocaId);
                lblTotalApurado.Text = $"Total apurado da época: {Formatador.Moeda(total)}";
                lblTotalApurado.ForeColor = Color.FromArgb(40, 120, 70);
            }
            catch (PrecoNaoDefinidoException ex)
            {
                MessageBox.Show($"Atenção: {ex.Message}\nDefina o preço antes de calcular.",
                    "Preço Não Definido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDistribuir_Click(object sender, EventArgs e)
        {
            if (!Permissoes.VerificarOperacao(Permissoes.PodeDistribuirLucros, "distribuir lucros"))
                return;

            if (cmbEpocaPreco.SelectedValue is not int epocaId || epocaId <= 0)
            {
                MessageBox.Show("Seleccione uma época agrícola.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_entregasEpoca.Count == 0)
            {
                MessageBox.Show("Não existem entregas registadas para esta época.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show(
                    "Distribuir lucros para todos os cooperativistas activos?\nEsta acção criará os registos de distribuição.",
                    "Confirmar Distribuição", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                var com = new Comercializacao
                {
                    EpocaId = epocaId,
                    DataVenda = dtpDataVenda.Value.Date,
                    Descricao = string.IsNullOrWhiteSpace(txtDescricao.Text)
                        ? null : txtDescricao.Text.Trim(),
                };
                _comRepo.Inserir(com);

                foreach (var ent in _entregasEpoca)
                    _comRepo.AssociarEntrega(com.Id, ent.Id);

                _gestor.DistribuirLucros(com.Id, epocaId);

                var resultado = _gestor.ObterRelatorioEpoca(epocaId).ToList();
                dgvDistribuicao.DataSource = resultado.Select(r => new
                {
                    Cooperativista = r.Cooperativista?.Nome ?? $"#{r.CooperativistaId}",
                    Quota = Formatador.Percentagem(r.QuotaAplicada),
                    ValorApurado = Formatador.Moeda(r.ValorApurado),
                    ValorLucro = Formatador.Moeda(r.ValorLucro),
                    Data = Formatador.Data(r.DataDistribuicao)
                }).ToList();

                MessageBox.Show("Lucros distribuídos com sucesso!",
                    "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (QuotaInvalidaException ex)
            {
                MessageBox.Show(ex.Message, "Quota Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (PrecoNaoDefinidoException ex)
            {
                MessageBox.Show($"Erro de preço: {ex.Message}", "Preço Não Definido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (cmbEpocaPreco.SelectedValue is int epocaId && epocaId > 0)
                CarregarEntregas(epocaId);
        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            if (cmbEpocaPreco.SelectedValue is int epocaId && epocaId > 0)
                CarregarEntregas(epocaId);
        }

        private void btnExportarCsv_Click(object sender, EventArgs e)
        {
            if (dgvDistribuicao.Rows.Count > 0)
                Exportador.ExportarCsv(dgvDistribuicao, "Distribuicao_Lucros.csv");
            else
                Exportador.ExportarCsv(dgvEntregasCom, "Entregas_Comercializacao.csv");
        }

        private void btnExportarPdf_Click(object sender, EventArgs e)
        {
            if (dgvDistribuicao.Rows.Count > 0)
                Exportador.ExportarPdf(dgvDistribuicao, "Relatório de Distribuição de Lucros",
                    "Distribuicao_Lucros.pdf", new[] { lblTotalApurado.Text });
            else
                Exportador.ExportarPdf(dgvEntregasCom, "Entregas da Época",
                    "Entregas_Comercializacao.pdf", new[] { lblTotalApurado.Text });
        }
    }
}
