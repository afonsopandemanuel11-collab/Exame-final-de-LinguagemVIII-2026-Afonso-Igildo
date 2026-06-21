using System;
using System.Collections.Generic;
using System.Text;

namespace SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Utils
{
    public static class Formatador
    {
        public static string Moeda(decimal valor) => $"{valor:N2} AOA";
        public static string Percentagem(decimal valor) => $"{valor:N2}%";
        public static string Data(DateTime data) => data.ToString("dd/MM/yyyy");
        public static string Quantidade(decimal qtd, string unidade) => $"{qtd:N2} {unidade}";
    }
}
