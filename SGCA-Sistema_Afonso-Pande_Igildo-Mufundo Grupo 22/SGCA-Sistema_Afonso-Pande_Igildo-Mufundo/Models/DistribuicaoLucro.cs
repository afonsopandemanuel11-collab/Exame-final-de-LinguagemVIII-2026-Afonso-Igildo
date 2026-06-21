using System;
using System.Collections.Generic;
using System.Text;

namespace SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Models
{
  public class DistribuicaoLucro
    {
        public int Id { get; set; }
        public int CooperativistaId { get; set; }
        public int ComercializacaoId { get; set; }
        public decimal ValorApurado { get; set; }
        public decimal ValorLucro { get; set; }
        public decimal QuotaAplicada { get; set; }
        public DateTime DataDistribuicao { get; set; } = DateTime.Today;

        // Propriedades de navegação
        public Cooperativista? Cooperativista { get; set; }
        public Comercializacao? Comercializacao { get; set; }
    }
}
