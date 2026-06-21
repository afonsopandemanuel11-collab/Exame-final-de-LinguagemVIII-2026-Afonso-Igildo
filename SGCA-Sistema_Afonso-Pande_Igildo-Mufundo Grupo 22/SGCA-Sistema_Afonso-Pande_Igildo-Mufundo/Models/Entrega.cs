using System;
using System.Collections.Generic;
using System.Text;

namespace SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Models
{
    public class Entrega
    {
        public int Id { get; set; }
        public int CooperativistaId { get; set; }
        public int ProdutoId { get; set; }
        public int EpocaId { get; set; }
        public DateTime DataEntrega { get; set; } = DateTime.Today;
        public decimal Quantidade { get; set; }
        public string? Observacoes { get; set; }

        // Propriedades de navegação (preenchidas pela BLL)
        public Cooperativista? Cooperativista { get; set; }
        public ProdutoAgricola? Produto { get; set; }
        public EpocaAgricola? Epoca { get; set; }
    }
}
