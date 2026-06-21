namespace SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Utils
{
    public static class Permissoes
    {
        public static bool PodeEliminar => Sessao.EAdministrador();

        public static bool PodeDesactivar => Sessao.EAdministrador();

        public static bool PodeEncerrarEpoca => Sessao.EAdministrador();

        public static bool PodeDistribuirLucros => Sessao.Autenticado;

        public static bool PodeGerirCadastros => Sessao.Autenticado;

        public static bool VerificarOperacao(bool permitido, string operacao)
        {
            if (permitido) return true;
            MessageBox.Show(
                $"Não tem permissão para {operacao}.\nContacte o administrador do sistema.",
                "Acesso Restrito",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            return false;
        }
    }
}
