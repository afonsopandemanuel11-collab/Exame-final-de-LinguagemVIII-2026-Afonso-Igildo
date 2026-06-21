using SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.DALL;
using SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Vistas;

namespace SGCA_Sistema_Afonso_Pande_Igildo_Mufundo
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
           Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            using var splash = new FrmConectando();
            splash.Show();
            Application.DoEvents();
            splash.IniciarConexao();
            /*bool conectado=DALL.Conexao.TestarConexao();
            splash.Close();
            splash.Dispose();*/

            while (splash.Visible)
            {
                Application.DoEvents();
                Thread.Sleep(10);

            }
            if (!splash.Conectado) {
                MessageBox.Show(
                    "Não possivel liar a base de dados! \n"+"Verifique a conexao ao Mysql, se esta ativa","Erro de ligação",
                MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            
            }
            
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            // ApplicationConfiguration.Initialize();

            // Abrir o formulário de login como diálogo. Se o utilizador autenticar com sucesso
            // o login devolve DialogResult.OK e a aplicação arranca o FrmPrincipal como formulário
            // principal da aplicação. Isto evita ter o FrmLogin escondido a correr como form
            // principal e a causar problemas de foco/controle dos restantes formulários.
            using var login = new FrmLogin();
            if (login.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new Vistas.FrmPrincipal());
            }
        }
    }
}