using SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Enums;
using SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Models
{
    public class EpocaAgricola
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public TipoEpoca Tipo { get; set; }
        public int Ano { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public bool Encerrada { get; set; }

        /// <summary>
        /// Encerra a época, impedindo novos registos de entregas e preços.
        /// </summary>
        public void Encerrar()
        {
            if (Encerrada)
                throw new EpocaEncerradaException($"A época '{Nome}' já se encontra encerrada.");
            Encerrada = true;
        }
    }
}
