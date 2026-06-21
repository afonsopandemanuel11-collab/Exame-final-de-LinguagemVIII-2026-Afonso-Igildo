using System;
using System.Collections.Generic;
using System.Text;

namespace SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Models
{
   public class Cooperativista
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string NumeroSocio { get; set; } = string.Empty;
        public string BilheteId { get; set; } = string.Empty;
        public string? Telefone { get; set; }
        public string? Email { get; set; }

        /// <summary>Percentagem de participação. Deve ser > 0 e a soma total = 100%.</summary>
        public decimal QuotaPercent { get; set; }

        public DateTime DataAdesao { get; set; } = DateTime.Today;
        public bool Activo { get; set; } = true;

        public override string ToString() => $"{NumeroSocio} – {Nome} ({QuotaPercent}%)";
    }
}
