using System;
using System.Collections.Generic;
using System.Text;

namespace SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Exceptions
{
    public class QuantidadeInvalidaException:Exception
    {
        public decimal QuantidadeInformada { get; }

        public QuantidadeInvalidaException(decimal quantidade)
            : base($"Quantidade inválida: {quantidade}. A quantidade deve ser maior que zero.")
        {
            QuantidadeInformada = quantidade;
        }
    }
}
