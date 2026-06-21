using SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Modelos;

namespace SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Utils
{
    public static class Sessao
    {
        public static Utilizador? UtilizadorActual { get; private set; }

        public static bool Autenticado => UtilizadorActual != null;

        public static void Iniciar(Utilizador utilizador)
        {
            UtilizadorActual = utilizador;
        }

        public static void Terminar()
        {
            UtilizadorActual = null;
        }

        public static bool EAdministrador()
        {
            return UtilizadorActual?.Perfil.Equals("Administrador", StringComparison.OrdinalIgnoreCase) == true;
        }
    }
}
