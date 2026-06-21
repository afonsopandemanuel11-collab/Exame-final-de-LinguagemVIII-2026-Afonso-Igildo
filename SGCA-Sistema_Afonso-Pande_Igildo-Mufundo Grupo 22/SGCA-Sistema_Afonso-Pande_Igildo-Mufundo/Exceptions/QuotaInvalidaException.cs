using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System;

namespace SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Exceptions
{
    public class QuotaInvalidaException : Exception
    {
        public decimal? QuotaInformada { get; }

        // Construtor com decimal (quota específica inválida)
        public QuotaInvalidaException(decimal quota)
            : base($"Quota inválida: {quota}%. A quota deve ser maior que 0 " +
                   $"e a soma total dos cooperativistas não pode exceder 100%.")
        {
            QuotaInformada = quota;
        }

        // Construtor com mensagem personalizada (ex: soma ≠ 100%)
        public QuotaInvalidaException(string mensagem)
            : base(mensagem)
        {
            QuotaInformada = null;
        }
    }
}
