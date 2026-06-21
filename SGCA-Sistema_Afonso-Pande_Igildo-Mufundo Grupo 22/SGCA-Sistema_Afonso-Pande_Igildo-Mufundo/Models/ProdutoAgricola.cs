using System;
using System.Collections.Generic;
using System.Text;

namespace SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Models
{
    public class ProdutoAgricola
    {
        public int Id { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public string UnidadeMedida { get; set; } = "kg";
        public int CategoriaId { get; set; }
        public bool Activo { get; set; } = true;

        // Propriedade de navegação (preenchida pela BLL/DAL)
        public CategoriaProduto? Categoria { get; set; }

        public override string ToString() => $"[{Codigo}] {Nome} ({UnidadeMedida})";
    }
}
