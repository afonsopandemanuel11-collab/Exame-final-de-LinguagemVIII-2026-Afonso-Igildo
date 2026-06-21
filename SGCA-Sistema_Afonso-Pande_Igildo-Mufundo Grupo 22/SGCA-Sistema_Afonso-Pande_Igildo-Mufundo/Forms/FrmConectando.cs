using SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.DALL;
namespace SGCA_Sistema_Afonso_Pande_Igildo_Mufundo;

public partial class FrmConectando : Form
{
    private Label lblStatus; private ProgressBar progressBar;
    private System.Windows.Forms.Timer timer; private int progresso = 0;
    public bool Conectado { get; private set; } = false;
    public FrmConectando()
    {
        this.FormBorderStyle = FormBorderStyle.None;
        this.StartPosition = FormStartPosition.CenterScreen;
        this.Size = new Size(420, 160);
        this.BackColor = Color.FromArgb(31, 58, 110);
        var lblTitulo = new Label
        {
            Text = "🌾 SGCA — Cooperativa Agrícola",
            ForeColor = Color.White,
            Font = new Font(" Arial", 11, FontStyle.Bold),
            Size = new Size(400, 30),
            Location = new Point(10, 15),
            TextAlign = ContentAlignment.MiddleCenter
        };
        // Status<br/>
        lblStatus = new Label
        {
            Text = " A iniciar...",
            ForeColor = Color.LightSkyBlue,
            Font = new Font(" Arial", 9),
            Size = new Size(400, 22),
            Location = new Point(10, 50),
            TextAlign = ContentAlignment.MiddleCenter
        };
        // ProgressBar
        progressBar = new ProgressBar
        {
            Minimum = 0,
            Maximum = 100,
            Value = 0,
            Style = ProgressBarStyle.Continuous,
            Size = new Size(380, 22),
            Location = new Point(20, 80),
            ForeColor = Color.LimeGreen
        };
        var lblVersao = new Label
        {
            Text = "v1.0 — IPUKV 2025/2026",
            ForeColor = Color.Gray,
            Font = new Font(" rial", 7),
            Size = new Size(400, 18),
            Location = new Point(10, 132),
            TextAlign = ContentAlignment.MiddleCenter
        };
        this.Controls.AddRange(new Control[]
        { lblTitulo, lblStatus, progressBar, lblVersao });
        // Timer que avança a barra
        timer = new System.Windows.Forms.Timer
        {
            Interval = 30
        };
        timer.Tick += Timer_Tick;
    }

    // Chamado pelo Program.cs para iniciar o processo<br/>

    public void IniciarConexao() { timer.Start(); }
    private void Timer_Tick(object sender, EventArgs e)
    {
        progresso += 2;
        progressBar.Value = Math.Min(progresso, 100);
        // Mensagens conforme o progresso<br/>
        if (progresso < 20)
            lblStatus.Text = " A carregar componentes..";

        else if (progresso < 50)
            lblStatus.Text = " A ligar à base de dados MySQL...";
        else if (progresso < 75)
            lblStatus.Text = "A verificar tabelas...";
        else if (progresso < 95)
            lblStatus.Text = "A preparar interface...";
        else
        { // Chegou a 100 — testa a conexão de verdade<br/>
            timer.Stop();
            lblStatus.Text = "A verificar ligação...t";
            progressBar.Value = 100;
            Application.DoEvents();
            Conectado = ConexaoBD.TestarConexao();
            if (Conectado)
                lblStatus.Text = "✅ Ligação estabelecida!";
            else
                lblStatus.Text = "❌ Falha na ligação!";
            Application.DoEvents(); Thread.Sleep(600);

            //Pausa para o utilizador ver o resultado<br/>
            this.Close();
        }
    }

    private void FrmConectando_Load(object sender, EventArgs e)
    {

    }
}