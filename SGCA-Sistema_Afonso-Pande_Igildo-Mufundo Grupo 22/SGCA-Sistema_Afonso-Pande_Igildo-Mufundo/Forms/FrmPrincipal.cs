using SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.DALL;
using SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Utils;

namespace SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Vistas
{
    public partial class FrmPrincipal : Form
    {
        private readonly EstatisticasRepository _statsRepo = new();
        private System.Windows.Forms.Timer? _timerRelogio;

        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            Estilo.Aplicar(this);
            ActualizarBarraEstado();
            ActualizarDashboard();
            IniciarRelogio();
        }

        private void IniciarRelogio()
        {
            _timerRelogio = new System.Windows.Forms.Timer { Interval = 1000 };
            _timerRelogio.Tick += (_, _) => ActualizarBarraEstado();
            _timerRelogio.Start();
        }

        private void ActualizarBarraEstado()
        {
            var u = Sessao.UtilizadorActual;
            tsslUtilizador.Text = u != null
                ? $"Utilizador: {u.Nome} ({u.Perfil})"
                : "Utilizador: —";
            tsslDataHora.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void ActualizarDashboard()
        {
            try
            {
                var s = _statsRepo.ObterEstatisticas();
                lblValorCoops.Text = s.TotalCooperativistasActivos.ToString();
                lblValorProdutos.Text = s.TotalProdutosActivos.ToString();
                lblValorEntregas.Text = s.TotalEntregas.ToString();
                lblValorEpocas.Text = s.EpocasAbertas.ToString();
                lblValorComercializacoes.Text = s.TotalComercializacoes.ToString();
                lblValorLucros.Text = Formatador.Moeda(s.TotalLucrosDistribuidos);

                lblResumoOperacional.Text =
                    $"Entregas este mês: {s.EntregasMesActual}  |  Épocas registadas: {s.TotalEpocas}";
                lblEpocaActual.Text = string.IsNullOrEmpty(s.EpocaActual)
                    ? "Época actual: nenhuma época aberta"
                    : $"Época actual: {s.EpocaActual}";
                lblQuotasResumo.Text = $"Soma de quotas activas: {Formatador.Percentagem(s.SomaQuotasActivas)}";
                lblQuotasResumo.ForeColor = s.SomaQuotasActivas == 100m
                    ? Color.FromArgb(40, 120, 70)
                    : Color.FromArgb(180, 40, 40);

                dgvActividades.DataSource = s.ActividadesRecentes.Select(a => new
                {
                    a.Tipo,
                    Data = Formatador.Data(a.Data),
                    Descrição = a.Descricao
                }).ToList();

                if (dgvActividades.Columns.Count > 0)
                {
                    dgvActividades.Columns["Tipo"].Width = 120;
                    dgvActividades.Columns["Data"].Width = 100;
                    dgvActividades.Columns["Descrição"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                lblResumoOperacional.Text = "Não foi possível carregar estatísticas.";
                MessageBox.Show($"Erro ao actualizar painel:\n{ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnActualizarDashboard_Click(object sender, EventArgs e) => ActualizarDashboard();

        private void btnAtalhoCoops_Click(object sender, EventArgs e)
            => AbrirFormularioFilho(new FrmCooperativistas());

        private void btnAtalhoEntregas_Click(object sender, EventArgs e)
            => AbrirFormularioFilho(new FrmEntregas());

        private void btnAtalhoPrecos_Click(object sender, EventArgs e)
            => AbrirFormularioFilho(new FrmPrecos());

        private void btnAtalhoComercializacao_Click(object sender, EventArgs e)
            => AbrirFormularioFilho(new FrmComercializacao());

        private void btnAtalhoRelatorio_Click(object sender, EventArgs e)
            => AbrirFormularioFilho(new FrmRelatorio());

        private void tsmiCooperativistas_Click(object? sender, EventArgs e)
            => AbrirFormularioFilho(new FrmCooperativistas());

        private void tsmiCategorias_Click(object? sender, EventArgs e)
            => AbrirFormularioFilho(new FrmCategorias());

        private void tsmiProdutos_Click(object? sender, EventArgs e)
            => AbrirFormularioFilho(new FrmProdutos());

        private void tsmiEpocas_Click(object? sender, EventArgs e)
            => AbrirFormularioFilho(new FrmEpocas());

        private void tsmiEntregas_Click(object? sender, EventArgs e)
            => AbrirFormularioFilho(new FrmEntregas());

        private void tsmiPrecos_Click(object? sender, EventArgs e)
            => AbrirFormularioFilho(new FrmPrecos());

        private void tsmiComercializacao_Click(object? sender, EventArgs e)
            => AbrirFormularioFilho(new FrmComercializacao());

        private void tsmiRelatorio_Click(object? sender, EventArgs e)
            => AbrirFormularioFilho(new FrmRelatorio());

        private void tsmiTerminarSessao_Click(object? sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja terminar a sessão actual?", "Terminar Sessão",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            Sessao.Terminar();
            foreach (Form f in MdiChildren)
                f.Close();

            var login = new FrmLogin();
            login.Show();
            login.FormClosed += (_, _) =>
            {
                if (!Sessao.Autenticado)
                    Application.Exit();
            };
            Close();
        }

        private void tsmiSair_Click(object? sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja sair da aplicação?", "Confirmar Saída",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Sessao.Terminar();
                Application.Exit();
            }
        }

        private void AbrirFormularioFilho(Form filho)
        {
            foreach (Form f in MdiChildren)
            {
                if (f.GetType() == filho.GetType())
                {
                    f.Activate();
                    filho.Dispose();
                    pnlDashboard.Visible = false;
                    return;
                }
            }
            pnlDashboard.Visible = false;
            filho.MdiParent = this;
            filho.Show();
            filho.FormClosed += (sender, _) =>
            {
                ActualizarDashboard();
                
                bool temOutrosFilhos = false;
                foreach (Form f in MdiChildren)
                {
                    if (f != sender && !f.IsDisposed && f.Visible)
                    {
                        temOutrosFilhos = true;
                        break;
                    }
                }
                
                if (!temOutrosFilhos)
                {
                    pnlDashboard.Visible = true;
                }
            };
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _timerRelogio?.Stop();
            _timerRelogio?.Dispose();
            base.OnFormClosed(e);
        }
    }
}
