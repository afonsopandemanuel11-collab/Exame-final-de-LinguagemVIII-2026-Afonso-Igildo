using System;
using System.Collections.Generic;
using System.Text;

namespace SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Exceptions
{
    public class CooperativistaNaoEncontradaException:Exception
    {
        public int IdProcurado { get; }

        public CooperativistaNaoEncontradaException(int id)
            : base($"Cooperativista com ID {id} não foi encontrado.")
        {
            IdProcurado = id;
        }

        public CooperativistaNaoEncontradaException(string mensagem)
            : base(mensagem) { }
    }
}
