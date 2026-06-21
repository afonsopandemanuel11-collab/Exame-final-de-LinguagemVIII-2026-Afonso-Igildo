using SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.DALL;
using SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Modelos;
using SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Utils;

namespace SGCA_Sistema_Afonso_Pande_Igildo_Mufundo
{
    public partial class FrmLogin : Form
    {
        // ── Suporte para arrastar a janela sem borda ───────────────────────────
        private bool  _dragging;
        private Point _dragStart;

        public FrmLogin()
        {
            InitializeComponent();

            // Configurações de campo
            txtpassword.PasswordChar     = '●';
            txtusername.PlaceholderText  = "Introduza o seu utilizador";
            txtpassword.PlaceholderText  = "Introduza a sua password";

            // Teclas de atalho
            AcceptButton = button1;
            CancelButton = button2;

            // Botão Cancelar
            button2.Click += button2_Click;

            // ── Arrastar a janela pelo painel esquerdo ────────────────────────
            pnlLeft.MouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Left) { _dragging = true; _dragStart = e.Location; }
            };
            pnlLeft.MouseMove += (s, e) =>
            {
                if (_dragging)
                    Location = Point.Add(Location, new Size(Point.Subtract(e.Location, new Size(_dragStart))));
            };
            pnlLeft.MouseUp += (s, e) => _dragging = false;

            // ── Efeito de foco nos painéis de input ───────────────────────────
            Color focusBg  = Color.FromArgb(237, 248, 242);
            Color normalBg = Color.White;

            txtusername.GotFocus  += (s, e) => pnlUserBox.BackColor = focusBg;
            txtusername.LostFocus += (s, e) => pnlUserBox.BackColor = normalBg;
            txtpassword.GotFocus  += (s, e) => pnlPassBox.BackColor = focusBg;
            txtpassword.LostFocus += (s, e) => pnlPassBox.BackColor = normalBg;
        }

        // ── Botão ENTRAR ──────────────────────────────────────────────────────
        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtusername.Text.Trim();
            string password = txtpassword.Text;

            // Validação
            if (string.IsNullOrEmpty(username))
            {
                MostrarAviso("Por favor, introduza o nome de utilizador.", txtusername);
                return;
            }
            if (string.IsNullOrEmpty(password))
            {
                MostrarAviso("Por favor, introduza a password.", txtpassword);
                return;
            }

            // Feedback visual durante autenticação
            button1.Enabled = false;
            button1.Text    = "A verificar…";

            try
            {
                var repo       = new UtilizadorRepository();
                Utilizador? u  = repo.Autenticar(username, password);

                if (u == null)
                {
                    MessageBox.Show(
                        "Nome de utilizador ou password incorrectos.\nTente novamente.",
                        "Acesso negado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtpassword.Clear();
                    txtpassword.Focus();
                    return;
                }

                Sessao.Iniciar(u);
                // Indica sucesso ao chamador (Program.Main) e fecha o formulário de login.
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao autenticar:\n" + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                button1.Enabled = true;
                button1.Text    = "ENTRAR";
            }
        }

        // ── Botão Cancelar / Fechar (✕) ───────────────────────────────────────
        private void button2_Click(object? sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja sair da aplicação?", "Confirmar saída",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Fecha o diálogo de login com resultado Cancel para que o Program.Main
                // saiba que a autenticação não ocorreu e termine a aplicação.
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }

        // ── Auxiliar ──────────────────────────────────────────────────────────
        private static void MostrarAviso(string mensagem, Control foco)
        {
            MessageBox.Show(mensagem, "Campo obrigatório",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            foco.Focus();
        }
    }
}
