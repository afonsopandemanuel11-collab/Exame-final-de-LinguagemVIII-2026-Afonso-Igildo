using SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Exceptions;
using SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Models;
using SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.DALL;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Services
{
    public class ServicoDistribuicao
    {
        private readonly GestorCooperativa _gestor = new();
        private readonly CooperativistaRepository _coopRepo = new();
        private readonly DistribuicaoRepository _distRepo = new();

        /// <summary>
        /// Distribui os lucros de uma comercialização por todos os cooperativistas activos.
        /// </summary>
        public void Distribuir(int comercializacaoId, int epocaId)
        {
            _gestor.DistribuirLucros(comercializacaoId, epocaId);
        }

        /// <summary>
        /// Devolve o resumo da distribuição para exibição no relatório.
        /// </summary>
        public IEnumerable<DistribuicaoLucro> ObterResumo(int comercializacaoId)
            => _distRepo.ObterPorComercializacao(comercializacaoId);
    }
    }

