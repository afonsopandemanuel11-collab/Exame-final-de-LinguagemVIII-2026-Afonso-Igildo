using System;
using System.Collections.Generic;
using System.Text;

namespace SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Exceptions
{
    public class PrecoNaoDefinidoException:Exception
    {
        public int ProdutoId { get; }
        public int EpocaId { get; }
        public PrecoNaoDefinidoException(int produtoId, int epocaId)
            : base($"Preço não definido para o produto ID {produtoId} " +
                   $"na época ID {epocaId}. Defina o preço antes de calcular.")
        {
            ProdutoId = produtoId;
            EpocaId = epocaId;
        }
    }
}
