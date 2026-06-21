using System;
using System.Collections.Generic;
using System.Text;

namespace SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Exceptions
{
  public class EpocaEncerradaException:Exception
    {
        public EpocaEncerradaException(string nomeEpoca)
            : base($"A época '{nomeEpoca}' está encerrada e não aceita novas operações.") { }

        public EpocaEncerradaException(string message, Exception inner)
            : base(message, inner) { }
    }
}
