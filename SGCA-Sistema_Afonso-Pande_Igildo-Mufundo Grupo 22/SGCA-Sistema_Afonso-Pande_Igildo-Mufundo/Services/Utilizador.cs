using System;
using System.Collections.Generic;
using System.Text;

namespace SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Modelos
{
    public class Utilizador
    {
        public int  Id { get; set; }
        public string Nome { get; set; }=string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; }=string.Empty;
        public string Perfil { get; set; } = "Operador";
    }
}
