using System;
using System.Collections.Generic;
using System.Text;

namespace SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Models
{
    public class Comercializacao
    {
        public int Id { get; set; }
        public int EpocaId { get; set; }
        public DateTime DataVenda { get; set; } = DateTime.Today;
        public string? Descricao { get; set; }
        public decimal TotalApurado { get; set; } // calculado pela BLL / view BD

        // Propriedades de navegação
        public EpocaAgricola? Epoca { get; set; }
        public List<Entrega> Entregas { get; set; } = new();
    }
}
