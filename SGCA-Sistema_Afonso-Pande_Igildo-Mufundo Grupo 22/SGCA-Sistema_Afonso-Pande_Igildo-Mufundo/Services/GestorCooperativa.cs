using SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Exceptions;
using SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Interfaces;
using SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Models;
using SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.DALL;

namespace SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Services
{
    public class GestorCooperativa : ICalculavelLucro
    {
        // ── Repositórios (injecção por composição) ────────────────────────────
        private readonly CooperativistaRepository _coopRepo = new();
        private readonly EntregaRepository _entregaRepo = new();
        private readonly PrecoRepository _precoRepo = new();
        private readonly DistribuicaoRepository _distRepo = new();
        private readonly EpocaRepository _epocaRepo = new();
        private readonly ComercializacaoRepository _comRepo = new();

        // ── ICalculavelLucro ──────────────────────────────────────────────────
        /// <summary>
        /// Calcula o lucro proporcional (valor_apurado × quota / 100).
        /// </summary>
        public decimal CalcularLucro(decimal valorApurado, decimal quotaPercent)
            => Math.Round(valorApurado * quotaPercent / 100m, 2);

        // ── Calcular valor apurado por cooperativista numa época ──────────────
        public decimal CalcularValorApurado(int cooperativistaId, int epocaId)
        {
            var entregas = _entregaRepo
                .ObterPorCooperativistaEEpoca(cooperativistaId, epocaId)
                .ToList();

            decimal total = 0m;
            foreach (var e in entregas)
            {
                var preco = _precoRepo.ObterPreco(e.ProdutoId, epocaId)
                    ?? throw new PrecoNaoDefinidoException(e.ProdutoId, epocaId);
                total += e.Quantidade * preco.PrecoUnitario;
            }
            return total;
        }

        // ── Distribuir lucros para uma comercialização ────────────────────────
        public void DistribuirLucros(int comercializacaoId, int epocaId)
        {
            var cooperativistas = _coopRepo.ObterActivos().ToList();

            // Verificar soma de quotas = 100% antes de distribuir
            decimal somaQuotas = cooperativistas.Sum(c => c.QuotaPercent);
            if (somaQuotas != 100m)
                throw new QuotaInvalidaException(
                    $"A soma das quotas ({somaQuotas}%) deve ser exactamente 100% antes de distribuir lucros.");

            foreach (var coop in cooperativistas)
            {
                decimal apurado = CalcularValorApurado(coop.Id, epocaId);
                decimal lucro = CalcularLucro(apurado, coop.QuotaPercent);

                var dist = new DistribuicaoLucro
                {
                    CooperativistaId = coop.Id,
                    ComercializacaoId = comercializacaoId,
                    ValorApurado = apurado,
                    ValorLucro = lucro,
                    QuotaAplicada = coop.QuotaPercent,
                    DataDistribuicao = DateTime.Today,
                };
                _distRepo.Inserir(dist);
            }
        }

        // ── Validar quota antes de inserir/actualizar cooperativista ──────────
        public void ValidarQuota(decimal novaQuota, int excluirId = 0)
        {
            if (novaQuota <= 0)
                throw new QuotaInvalidaException(novaQuota);

            decimal somaActual = _coopRepo.SomaQuotasActivas(excluirId);
            if (somaActual + novaQuota > 100m)
                throw new QuotaInvalidaException(novaQuota);
        }

        // ── Encerrar época ────────────────────────────────────────────────────
        public void EncerrarEpoca(int epocaId)
        {
            var epoca = _epocaRepo.ObterPorId(epocaId)
                ?? throw new Exception($"Época ID {epocaId} não encontrada.");

            if (epoca.Encerrada)
                throw new EpocaEncerradaException($"A época '{epoca.Nome}' já está encerrada.");

            _epocaRepo.EncerrarEpoca(epocaId);
        }

        // ── Obter relatório de distribuição por época ─────────────────────────
        public IEnumerable<DistribuicaoLucro> ObterRelatorioEpoca(int epocaId)
        {
            // Obter comercializações da época
            var comercializacoes = _comRepo.ObterTodos()
                .Where(c => c.EpocaId == epocaId)
                .ToList();

            var resultado = new List<DistribuicaoLucro>();
            foreach (var com in comercializacoes)
                resultado.AddRange(_distRepo.ObterPorComercializacao(com.Id));

            return resultado;
        }

        // ── Calcular apuramento geral da época (Dictionary<cooperativista, total>) ──
        public Dictionary<int, decimal> CalcularApuramentoPorEpoca(int epocaId)
        {
            var entregas = _entregaRepo.ObterPorEpoca(epocaId).ToList();
            var apuramentos = new Dictionary<int, decimal>();

            foreach (var e in entregas)
            {
                var preco = _precoRepo.ObterPreco(e.ProdutoId, epocaId);
                if (preco == null) continue; // produto sem preço é ignorado no cálculo resumo

                if (!apuramentos.ContainsKey(e.CooperativistaId))
                    apuramentos[e.CooperativistaId] = 0m;

                apuramentos[e.CooperativistaId] += e.Quantidade * preco.PrecoUnitario;
            }
            return apuramentos;
        }
    }
}
