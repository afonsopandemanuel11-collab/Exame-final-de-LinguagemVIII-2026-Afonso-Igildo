using SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Exceptions;
using SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.DALL;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Services
{
    public class ServicoApuramento
    {
        private readonly EntregaRepository _entregaRepo = new();
        private readonly PrecoRepository _precoRepo = new();

        /// <summary>
        /// Calcula o valor apurado total de uma época, agrupado por cooperativista.
        /// Demonstra uso de List&lt;T&gt; e Dictionary&lt;K,V&gt;.
        /// </summary>
        /// <returns>Lista de objectos anónimos com cooperativistaId e valorApurado.</returns>
        public List<(int CooperativistaId, decimal ValorApurado)> ApurarPorEpoca(int epocaId)
        {
            var entregas = _entregaRepo.ObterPorEpoca(epocaId).ToList();
            var mapa = new Dictionary<int, decimal>();

            foreach (var e in entregas)
            {
                var preco = _precoRepo.ObterPreco(e.ProdutoId, epocaId)
                    ?? throw new PrecoNaoDefinidoException(e.ProdutoId, epocaId);

                if (!mapa.ContainsKey(e.CooperativistaId))
                    mapa[e.CooperativistaId] = 0m;

                mapa[e.CooperativistaId] += e.Quantidade * preco.PrecoUnitario;
            }

            return mapa.Select(kv => (kv.Key, kv.Value)).ToList();
        }

        /// <summary>Valor total apurado de toda a época (soma de todos os cooperativistas).</summary>
        public decimal TotalApuradoEpoca(int epocaId)
            => ApurarPorEpoca(epocaId).Sum(x => x.ValorApurado);
    }
}
