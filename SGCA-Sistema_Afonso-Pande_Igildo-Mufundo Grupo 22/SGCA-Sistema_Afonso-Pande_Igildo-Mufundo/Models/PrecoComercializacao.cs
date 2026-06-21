using System;
using System.Collections.Generic;
using System.Text;

namespace SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Models
{
    public class PrecoComercializacao
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public int EpocaId { get; set; }
        public decimal PrecoUnitario { get; set; }
        public DateTime DataDefinicao { get; set; } = DateTime.Today;

        // Propriedades de navegação
        public ProdutoAgricola? Produto { get; set; }
        public EpocaAgricola? Epoca { get; set; }
    }
}
