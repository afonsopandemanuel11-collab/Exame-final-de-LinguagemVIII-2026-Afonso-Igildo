namespace SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Vistas
{
    partial class FrmPrincipal
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            tsmiCadastros = new ToolStripMenuItem();
            tsmiCooperativistas = new ToolStripMenuItem();
            tsmiProdutos = new ToolStripMenuItem();
            tsmiCategorias = new ToolStripMenuItem();
            tsmiEpocas = new ToolStripMenuItem();
            operaçõesToolStripMenuItem = new ToolStripMenuItem();
            tsmiEntregasToolStripMenuItem = new ToolStripMenuItem();
            tsmiPrecos = new ToolStripMenuItem();
            tsmiComercializacao = new ToolStripMenuItem();
            tsmiRelatorios = new ToolStripMenuItem();
            tsmiRelatorio = new ToolStripMenuItem();
            tsmiDistribuicaoLucros = new ToolStripMenuItem();
            tsmiSistema = new ToolStripMenuItem();
            tsmiTerminarSessao = new ToolStripMenuItem();
            tsmiSair = new ToolStripMenuItem();
            pnlDashboard = new Panel();
            lblTituloPrincipal = new Label();
            lblSubtitulo = new Label();
            grpIndicadores = new GroupBox();
            pnlCardCoops = new Panel();
            lblValorCoops = new Label();
            lblTituloCoops = new Label();
            pnlCardProdutos = new Panel();
            lblValorProdutos = new Label();
            lblTituloProdutos = new Label();
            pnlCardEntregas = new Panel();
            lblValorEntregas = new Label();
            lblTituloEntregas = new Label();
            pnlCardEpocas = new Panel();
            lblValorEpocas = new Label();
            lblTituloEpocas = new Label();
            pnlCardComercializacoes = new Panel();
            lblValorComercializacoes = new Label();
            lblTituloComercializacoes = new Label();
            pnlCardLucros = new Panel();
            lblValorLucros = new Label();
            lblTituloLucros = new Label();
            grpAtalhos = new GroupBox();
            btnAtalhoCoops = new Button();
            btnAtalhoEntregas = new Button();
            btnAtalhoPrecos = new Button();
            btnAtalhoComercializacao = new Button();
            btnAtalhoRelatorio = new Button();
            btnActualizarDashboard = new Button();
            lblResumoOperacional = new Label();
            lblEpocaActual = new Label();
            lblQuotasResumo = new Label();
            statusStrip1 = new StatusStrip();
            tsslUtilizador = new ToolStripStatusLabel();
            tsslSeparador = new ToolStripStatusLabel();
            tsslDataHora = new ToolStripStatusLabel();
            grpActividades = new GroupBox();
            dgvActividades = new DataGridView();
            menuStrip1.SuspendLayout();
            pnlDashboard.SuspendLayout();
            grpIndicadores.SuspendLayout();
            pnlCardCoops.SuspendLayout();
            pnlCardProdutos.SuspendLayout();
            pnlCardEntregas.SuspendLayout();
            pnlCardEpocas.SuspendLayout();
            grpAtalhos.SuspendLayout();
            grpActividades.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvActividades).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { tsmiCadastros, operaçõesToolStripMenuItem, tsmiRelatorios, tsmiSistema });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1024, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // tsmiCadastros
            // 
            tsmiCadastros.DropDownItems.AddRange(new ToolStripItem[] { tsmiCooperativistas, tsmiProdutos, tsmiCategorias, tsmiEpocas });
            tsmiCadastros.Name = "tsmiCadastros";
            tsmiCadastros.Size = new Size(71, 20);
            tsmiCadastros.Text = "Cadastros";
            // 
            // tsmiCooperativistas
            // 
            tsmiCooperativistas.Name = "tsmiCooperativistas";
            tsmiCooperativistas.Size = new Size(150, 22);
            tsmiCooperativistas.Text = "Cooperativistas";
            tsmiCooperativistas.Click += tsmiCooperativistas_Click;
            // 
            // tsmiProdutos
            // 
            tsmiProdutos.Name = "tsmiProdutos";
            tsmiProdutos.Size = new Size(150, 22);
            tsmiProdutos.Text = "Produtos";
            tsmiProdutos.Click += tsmiProdutos_Click;
            // 
            // tsmiCategorias
            // 
            tsmiCategorias.Name = "tsmiCategorias";
            tsmiCategorias.Size = new Size(150, 22);
            tsmiCategorias.Text = "Categorias";
            tsmiCategorias.Click += tsmiCategorias_Click;
            // 
            // tsmiEpocas
            // 
            tsmiEpocas.Name = "tsmiEpocas";
            tsmiEpocas.Size = new Size(150, 22);
            tsmiEpocas.Text = "Épocas Agrícolas";
            tsmiEpocas.Click += tsmiEpocas_Click;
            // 
            // operaçõesToolStripMenuItem
            // 
            operaçõesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { tsmiEntregasToolStripMenuItem, tsmiPrecos, tsmiComercializacao });
            operaçõesToolStripMenuItem.Name = "operaçõesToolStripMenuItem";
            operaçõesToolStripMenuItem.Size = new Size(75, 20);
            operaçõesToolStripMenuItem.Text = "Operações";
            // 
            // tsmiEntregasToolStripMenuItem
            // 
            tsmiEntregasToolStripMenuItem.Name = "tsmiEntregasToolStripMenuItem";
            tsmiEntregasToolStripMenuItem.Size = new Size(160, 22);
            tsmiEntregasToolStripMenuItem.Text = "Entregas";
            tsmiEntregasToolStripMenuItem.Click += tsmiEntregas_Click;
            // 
            // tsmiPrecos
            // 
            tsmiPrecos.Name = "tsmiPrecos";
            tsmiPrecos.Size = new Size(160, 22);
            tsmiPrecos.Text = "Preços";
            tsmiPrecos.Click += tsmiPrecos_Click;
            // 
            // tsmiComercializacao
            // 
            tsmiComercializacao.Name = "tsmiComercializacao";
            tsmiComercializacao.Size = new Size(160, 22);
            tsmiComercializacao.Text = "Comercialização";
            tsmiComercializacao.Click += tsmiComercializacao_Click;
            // 
            // tsmiRelatorios
            // 
            tsmiRelatorios.DropDownItems.AddRange(new ToolStripItem[] { tsmiRelatorio, tsmiDistribuicaoLucros });
            tsmiRelatorios.Name = "tsmiRelatorios";
            tsmiRelatorios.Size = new Size(71, 20);
            tsmiRelatorios.Text = "Relatórios";
            // 
            // tsmiRelatorio
            // 
            tsmiRelatorio.Name = "tsmiRelatorio";
            tsmiRelatorio.Size = new Size(180, 22);
            tsmiRelatorio.Text = "Relatório de Distribuição";
            tsmiRelatorio.Click += tsmiRelatorio_Click;
            // 
            // tsmiDistribuicaoLucros
            // 
            tsmiDistribuicaoLucros.Name = "tsmiDistribuicaoLucros";
            tsmiDistribuicaoLucros.Size = new Size(180, 22);
            tsmiDistribuicaoLucros.Text = "Comercialização e Lucros";
            tsmiDistribuicaoLucros.Click += tsmiComercializacao_Click;
            // 
            // tsmiSistema
            // 
            tsmiSistema.DropDownItems.AddRange(new ToolStripItem[] { tsmiTerminarSessao, tsmiSair });
            tsmiSistema.Name = "tsmiSistema";
            tsmiSistema.Size = new Size(61, 20);
            tsmiSistema.Text = "Sistema";
            // 
            // tsmiTerminarSessao
            // 
            tsmiTerminarSessao.Name = "tsmiTerminarSessao";
            tsmiTerminarSessao.Size = new Size(170, 22);
            tsmiTerminarSessao.Text = "Terminar Sessão";
            tsmiTerminarSessao.Click += tsmiTerminarSessao_Click;
            // 
            // tsmiSair
            // 
            tsmiSair.Name = "tsmiSair";
            tsmiSair.Size = new Size(170, 22);
            tsmiSair.Text = "Sair";
            tsmiSair.Click += tsmiSair_Click;
            // 
            // pnlDashboard
            // 
            pnlDashboard.BackColor = Color.FromArgb(249, 251, 250);
            pnlDashboard.Controls.Add(lblResumoOperacional);
            pnlDashboard.Controls.Add(lblEpocaActual);
            pnlDashboard.Controls.Add(lblQuotasResumo);
            pnlDashboard.Controls.Add(btnActualizarDashboard);
            pnlDashboard.Controls.Add(grpActividades);
            pnlDashboard.Controls.Add(grpAtalhos);
            pnlDashboard.Controls.Add(grpIndicadores);
            pnlDashboard.Controls.Add(lblSubtitulo);
            pnlDashboard.Controls.Add(lblTituloPrincipal);
            pnlDashboard.Dock = DockStyle.Fill;
            pnlDashboard.Location = new Point(0, 24);
            pnlDashboard.Name = "pnlDashboard";
            pnlDashboard.Padding = new Padding(24);
            pnlDashboard.Size = new Size(1024, 722);
            pnlDashboard.TabIndex = 1;
            // 
            // lblTituloPrincipal
            // 
            lblTituloPrincipal.AutoSize = true;
            lblTituloPrincipal.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTituloPrincipal.ForeColor = Color.FromArgb(27, 58, 45);
            lblTituloPrincipal.Location = new Point(24, 20);
            lblTituloPrincipal.Name = "lblTituloPrincipal";
            lblTituloPrincipal.Size = new Size(520, 32);
            lblTituloPrincipal.TabIndex = 0;
            lblTituloPrincipal.Text = "SGCA — Gestão de Cooperativa Agrícola";
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Font = new Font("Segoe UI", 10F);
            lblSubtitulo.ForeColor = Color.FromArgb(70, 70, 70);
            lblSubtitulo.Location = new Point(27, 58);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(280, 19);
            lblSubtitulo.TabIndex = 1;
            lblSubtitulo.Text = "Painel de controlo operacional — IPUKV";
            // 
            // grpIndicadores
            // 
            grpIndicadores.Controls.Add(pnlCardCoops);
            grpIndicadores.Controls.Add(pnlCardProdutos);
            grpIndicadores.Controls.Add(pnlCardEntregas);
            grpIndicadores.Controls.Add(pnlCardEpocas);
            grpIndicadores.Controls.Add(pnlCardComercializacoes);
            grpIndicadores.Controls.Add(pnlCardLucros);
            grpIndicadores.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            grpIndicadores.ForeColor = Color.FromArgb(27, 58, 45);
            grpIndicadores.Location = new Point(24, 95);
            grpIndicadores.Name = "grpIndicadores";
            grpIndicadores.Size = new Size(960, 225);
            grpIndicadores.TabIndex = 2;
            grpIndicadores.TabStop = false;
            grpIndicadores.Text = "Indicadores Principais";
            // 
            // pnlCardCoops
            // 
            pnlCardCoops.BackColor = Color.FromArgb(237, 248, 242);
            pnlCardCoops.BorderStyle = BorderStyle.FixedSingle;
            pnlCardCoops.Controls.Add(lblValorCoops);
            pnlCardCoops.Controls.Add(lblTituloCoops);
            pnlCardCoops.Location = new Point(16, 28);
            pnlCardCoops.Name = "pnlCardCoops";
            pnlCardCoops.Size = new Size(300, 85);
            pnlCardCoops.TabIndex = 0;
            // 
            // lblValorCoops
            // 
            lblValorCoops.Dock = DockStyle.Bottom;
            lblValorCoops.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblValorCoops.ForeColor = Color.FromArgb(27, 58, 45);
            lblValorCoops.Location = new Point(0, 35);
            lblValorCoops.Name = "lblValorCoops";
            lblValorCoops.Size = new Size(298, 48);
            lblValorCoops.TabIndex = 1;
            lblValorCoops.Text = "0";
            lblValorCoops.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTituloCoops
            // 
            lblTituloCoops.Dock = DockStyle.Top;
            lblTituloCoops.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTituloCoops.ForeColor = Color.FromArgb(70, 70, 70);
            lblTituloCoops.Location = new Point(0, 0);
            lblTituloCoops.Name = "lblTituloCoops";
            lblTituloCoops.Size = new Size(298, 35);
            lblTituloCoops.TabIndex = 0;
            lblTituloCoops.Text = "Cooperativistas Activos";
            lblTituloCoops.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlCardProdutos
            // 
            pnlCardProdutos.BackColor = Color.FromArgb(237, 248, 242);
            pnlCardProdutos.BorderStyle = BorderStyle.FixedSingle;
            pnlCardProdutos.Controls.Add(lblValorProdutos);
            pnlCardProdutos.Controls.Add(lblTituloProdutos);
            pnlCardProdutos.Location = new Point(330, 28);
            pnlCardProdutos.Name = "pnlCardProdutos";
            pnlCardProdutos.Size = new Size(300, 85);
            pnlCardProdutos.TabIndex = 1;
            // 
            // lblValorProdutos
            // 
            lblValorProdutos.Dock = DockStyle.Bottom;
            lblValorProdutos.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblValorProdutos.ForeColor = Color.FromArgb(27, 58, 45);
            lblValorProdutos.Location = new Point(0, 35);
            lblValorProdutos.Name = "lblValorProdutos";
            lblValorProdutos.Size = new Size(298, 48);
            lblValorProdutos.TabIndex = 1;
            lblValorProdutos.Text = "0";
            lblValorProdutos.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTituloProdutos
            // 
            lblTituloProdutos.Dock = DockStyle.Top;
            lblTituloProdutos.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTituloProdutos.ForeColor = Color.FromArgb(70, 70, 70);
            lblTituloProdutos.Location = new Point(0, 0);
            lblTituloProdutos.Name = "lblTituloProdutos";
            lblTituloProdutos.Size = new Size(298, 35);
            lblTituloProdutos.TabIndex = 0;
            lblTituloProdutos.Text = "Produtos Activos";
            lblTituloProdutos.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlCardEntregas
            // 
            pnlCardEntregas.BackColor = Color.FromArgb(237, 248, 242);
            pnlCardEntregas.BorderStyle = BorderStyle.FixedSingle;
            pnlCardEntregas.Controls.Add(lblValorEntregas);
            pnlCardEntregas.Controls.Add(lblTituloEntregas);
            pnlCardEntregas.Location = new Point(644, 28);
            pnlCardEntregas.Name = "pnlCardEntregas";
            pnlCardEntregas.Size = new Size(300, 85);
            pnlCardEntregas.TabIndex = 2;
            // 
            // lblValorEntregas
            // 
            lblValorEntregas.Dock = DockStyle.Bottom;
            lblValorEntregas.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblValorEntregas.ForeColor = Color.FromArgb(27, 58, 45);
            lblValorEntregas.Location = new Point(0, 35);
            lblValorEntregas.Name = "lblValorEntregas";
            lblValorEntregas.Size = new Size(298, 48);
            lblValorEntregas.TabIndex = 1;
            lblValorEntregas.Text = "0";
            lblValorEntregas.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTituloEntregas
            // 
            lblTituloEntregas.Dock = DockStyle.Top;
            lblTituloEntregas.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTituloEntregas.ForeColor = Color.FromArgb(70, 70, 70);
            lblTituloEntregas.Location = new Point(0, 0);
            lblTituloEntregas.Name = "lblTituloEntregas";
            lblTituloEntregas.Size = new Size(298, 35);
            lblTituloEntregas.TabIndex = 0;
            lblTituloEntregas.Text = "Total de Entregas";
            lblTituloEntregas.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlCardEpocas
            // 
            pnlCardEpocas.BackColor = Color.FromArgb(237, 248, 242);
            pnlCardEpocas.BorderStyle = BorderStyle.FixedSingle;
            pnlCardEpocas.Controls.Add(lblValorEpocas);
            pnlCardEpocas.Controls.Add(lblTituloEpocas);
            pnlCardEpocas.Location = new Point(16, 125);
            pnlCardEpocas.Name = "pnlCardEpocas";
            pnlCardEpocas.Size = new Size(300, 85);
            pnlCardEpocas.TabIndex = 3;
            // 
            // lblValorEpocas
            // 
            lblValorEpocas.Dock = DockStyle.Bottom;
            lblValorEpocas.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblValorEpocas.ForeColor = Color.FromArgb(27, 58, 45);
            lblValorEpocas.Location = new Point(0, 35);
            lblValorEpocas.Name = "lblValorEpocas";
            lblValorEpocas.Size = new Size(298, 48);
            lblValorEpocas.TabIndex = 1;
            lblValorEpocas.Text = "0";
            lblValorEpocas.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTituloEpocas
            // 
            lblTituloEpocas.Dock = DockStyle.Top;
            lblTituloEpocas.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTituloEpocas.ForeColor = Color.FromArgb(70, 70, 70);
            lblTituloEpocas.Location = new Point(0, 0);
            lblTituloEpocas.Name = "lblTituloEpocas";
            lblTituloEpocas.Size = new Size(298, 35);
            lblTituloEpocas.TabIndex = 0;
            lblTituloEpocas.Text = "Épocas Abertas";
            lblTituloEpocas.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlCardComercializacoes
            // 
            pnlCardComercializacoes.BackColor = Color.FromArgb(237, 248, 242);
            pnlCardComercializacoes.BorderStyle = BorderStyle.FixedSingle;
            pnlCardComercializacoes.Controls.Add(lblValorComercializacoes);
            pnlCardComercializacoes.Controls.Add(lblTituloComercializacoes);
            pnlCardComercializacoes.Location = new Point(330, 125);
            pnlCardComercializacoes.Name = "pnlCardComercializacoes";
            pnlCardComercializacoes.Size = new Size(300, 85);
            pnlCardComercializacoes.TabIndex = 4;
            // 
            // lblValorComercializacoes
            // 
            lblValorComercializacoes.Dock = DockStyle.Bottom;
            lblValorComercializacoes.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblValorComercializacoes.ForeColor = Color.FromArgb(27, 58, 45);
            lblValorComercializacoes.Location = new Point(0, 35);
            lblValorComercializacoes.Name = "lblValorComercializacoes";
            lblValorComercializacoes.Size = new Size(298, 48);
            lblValorComercializacoes.TabIndex = 1;
            lblValorComercializacoes.Text = "0";
            lblValorComercializacoes.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTituloComercializacoes
            // 
            lblTituloComercializacoes.Dock = DockStyle.Top;
            lblTituloComercializacoes.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTituloComercializacoes.ForeColor = Color.FromArgb(70, 70, 70);
            lblTituloComercializacoes.Location = new Point(0, 0);
            lblTituloComercializacoes.Name = "lblTituloComercializacoes";
            lblTituloComercializacoes.Size = new Size(298, 35);
            lblTituloComercializacoes.TabIndex = 0;
            lblTituloComercializacoes.Text = "Total Comercializações";
            lblTituloComercializacoes.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlCardLucros
            // 
            pnlCardLucros.BackColor = Color.FromArgb(237, 248, 242);
            pnlCardLucros.BorderStyle = BorderStyle.FixedSingle;
            pnlCardLucros.Controls.Add(lblValorLucros);
            pnlCardLucros.Controls.Add(lblTituloLucros);
            pnlCardLucros.Location = new Point(644, 125);
            pnlCardLucros.Name = "pnlCardLucros";
            pnlCardLucros.Size = new Size(300, 85);
            pnlCardLucros.TabIndex = 5;
            // 
            // lblValorLucros
            // 
            lblValorLucros.Dock = DockStyle.Bottom;
            lblValorLucros.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblValorLucros.ForeColor = Color.FromArgb(27, 58, 45);
            lblValorLucros.Location = new Point(0, 35);
            lblValorLucros.Name = "lblValorLucros";
            lblValorLucros.Size = new Size(298, 48);
            lblValorLucros.TabIndex = 1;
            lblValorLucros.Text = "0,00 AOA";
            lblValorLucros.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTituloLucros
            // 
            lblTituloLucros.Dock = DockStyle.Top;
            lblTituloLucros.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTituloLucros.ForeColor = Color.FromArgb(70, 70, 70);
            lblTituloLucros.Location = new Point(0, 0);
            lblTituloLucros.Name = "lblTituloLucros";
            lblTituloLucros.Size = new Size(298, 35);
            lblTituloLucros.TabIndex = 0;
            lblTituloLucros.Text = "Total Lucros Distribuídos";
            lblTituloLucros.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // grpAtalhos
            // 
            grpAtalhos.Controls.Add(btnAtalhoCoops);
            grpAtalhos.Controls.Add(btnAtalhoEntregas);
            grpAtalhos.Controls.Add(btnAtalhoPrecos);
            grpAtalhos.Controls.Add(btnAtalhoComercializacao);
            grpAtalhos.Controls.Add(btnAtalhoRelatorio);
            grpAtalhos.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            grpAtalhos.ForeColor = Color.FromArgb(27, 58, 45);
            grpAtalhos.Location = new Point(24, 340);
            grpAtalhos.Name = "grpAtalhos";
            grpAtalhos.Size = new Size(960, 90);
            grpAtalhos.TabIndex = 3;
            grpAtalhos.TabStop = false;
            grpAtalhos.Text = "Atalhos Rápidos";
            // 
            // btnAtalhoCoops
            // 
            btnAtalhoCoops.Location = new Point(16, 32);
            btnAtalhoCoops.Name = "btnAtalhoCoops";
            btnAtalhoCoops.Size = new Size(220, 40);
            btnAtalhoCoops.TabIndex = 0;
            btnAtalhoCoops.Text = "Cooperativistas";
            btnAtalhoCoops.UseVisualStyleBackColor = true;
            btnAtalhoCoops.Click += btnAtalhoCoops_Click;
            // 
            // btnAtalhoEntregas
            // 
            btnAtalhoEntregas.Location = new Point(252, 32);
            btnAtalhoEntregas.Name = "btnAtalhoEntregas";
            btnAtalhoEntregas.Size = new Size(220, 40);
            btnAtalhoEntregas.TabIndex = 1;
            btnAtalhoEntregas.Text = "Registar Entrega";
            btnAtalhoEntregas.UseVisualStyleBackColor = true;
            btnAtalhoEntregas.Click += btnAtalhoEntregas_Click;
            // 
            // btnAtalhoPrecos
            // 
            btnAtalhoPrecos.Location = new Point(488, 32);
            btnAtalhoPrecos.Name = "btnAtalhoPrecos";
            btnAtalhoPrecos.Size = new Size(200, 40);
            btnAtalhoPrecos.TabIndex = 2;
            btnAtalhoPrecos.Text = "Definir Preços";
            btnAtalhoPrecos.UseVisualStyleBackColor = true;
            btnAtalhoPrecos.Click += btnAtalhoPrecos_Click;
            // 
            // btnAtalhoComercializacao
            // 
            btnAtalhoComercializacao.Location = new Point(700, 32);
            btnAtalhoComercializacao.Name = "btnAtalhoComercializacao";
            btnAtalhoComercializacao.Size = new Size(200, 40);
            btnAtalhoComercializacao.TabIndex = 3;
            btnAtalhoComercializacao.Text = "Comercialização";
            btnAtalhoComercializacao.UseVisualStyleBackColor = true;
            btnAtalhoComercializacao.Click += btnAtalhoComercializacao_Click;
            // 
            // btnAtalhoRelatorio
            // 
            btnAtalhoRelatorio.Location = new Point(912, 32);
            btnAtalhoRelatorio.Name = "btnAtalhoRelatorio";
            btnAtalhoRelatorio.Size = new Size(200, 40);
            btnAtalhoRelatorio.TabIndex = 4;
            btnAtalhoRelatorio.Text = "Relatórios";
            btnAtalhoRelatorio.UseVisualStyleBackColor = true;
            btnAtalhoRelatorio.Click += btnAtalhoRelatorio_Click;
            // 
            // btnActualizarDashboard
            // 
            btnActualizarDashboard.Location = new Point(824, 635);
            btnActualizarDashboard.Name = "btnActualizarDashboard";
            btnActualizarDashboard.Size = new Size(160, 34);
            btnActualizarDashboard.TabIndex = 4;
            btnActualizarDashboard.Text = "Actualizar Painel";
            btnActualizarDashboard.UseVisualStyleBackColor = true;
            btnActualizarDashboard.Click += btnActualizarDashboard_Click;
            // 
            // grpActividades
            // 
            grpActividades.Controls.Add(dgvActividades);
            grpActividades.Location = new Point(24, 445);
            grpActividades.Name = "grpActividades";
            grpActividades.Size = new Size(960, 175);
            grpActividades.TabIndex = 8;
            grpActividades.TabStop = false;
            grpActividades.Text = "Últimas Actividades";
            // 
            // dgvActividades
            // 
            dgvActividades.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvActividades.Location = new Point(16, 24);
            dgvActividades.Name = "dgvActividades";
            dgvActividades.Size = new Size(928, 135);
            dgvActividades.TabIndex = 0;
            // 
            // lblResumoOperacional
            // 
            lblResumoOperacional.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblResumoOperacional.ForeColor = Color.FromArgb(27, 58, 45);
            lblResumoOperacional.Location = new Point(24, 635);
            lblResumoOperacional.Name = "lblResumoOperacional";
            lblResumoOperacional.Size = new Size(780, 22);
            lblResumoOperacional.TabIndex = 5;
            lblResumoOperacional.Text = "Resumo operacional";
            // 
            // lblEpocaActual
            // 
            lblEpocaActual.Font = new Font("Segoe UI", 9.5F);
            lblEpocaActual.ForeColor = Color.FromArgb(70, 70, 70);
            lblEpocaActual.Location = new Point(24, 660);
            lblEpocaActual.Name = "lblEpocaActual";
            lblEpocaActual.Size = new Size(780, 22);
            lblEpocaActual.TabIndex = 6;
            lblEpocaActual.Text = "Época actual: —";
            // 
            // lblQuotasResumo
            // 
            lblQuotasResumo.Font = new Font("Segoe UI", 9.5F);
            lblQuotasResumo.ForeColor = Color.FromArgb(70, 70, 70);
            lblQuotasResumo.Location = new Point(24, 685);
            lblQuotasResumo.Name = "lblQuotasResumo";
            lblQuotasResumo.Size = new Size(780, 22);
            lblQuotasResumo.TabIndex = 7;
            lblQuotasResumo.Text = "Soma de quotas activas: —";
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { tsslUtilizador, tsslSeparador, tsslDataHora });
            statusStrip1.Location = new Point(0, 746);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1024, 22);
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "statusStrip1";
            // 
            // tsslUtilizador
            // 
            tsslUtilizador.Name = "tsslUtilizador";
            tsslUtilizador.Size = new Size(120, 17);
            tsslUtilizador.Text = "Utilizador: —";
            // 
            // tsslSeparador
            // 
            tsslSeparador.Name = "tsslSeparador";
            tsslSeparador.Size = new Size(10, 17);
            tsslSeparador.Text = "|";
            // 
            // tsslDataHora
            // 
            tsslDataHora.Name = "tsslDataHora";
            tsslDataHora.Size = new Size(120, 17);
            tsslDataHora.Text = "—";
            // 
            // FrmPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1024, 768);
            Controls.Add(pnlDashboard);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(900, 600);
            Name = "FrmPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SGCA — Painel Principal";
            Load += FrmPrincipal_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            pnlDashboard.ResumeLayout(false);
            pnlDashboard.PerformLayout();
            grpIndicadores.ResumeLayout(false);
            pnlCardCoops.ResumeLayout(false);
            pnlCardProdutos.ResumeLayout(false);
            pnlCardEntregas.ResumeLayout(false);
            pnlCardEpocas.ResumeLayout(false);
            grpAtalhos.ResumeLayout(false);
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem tsmiCadastros;
        private ToolStripMenuItem tsmiCooperativistas;
        private ToolStripMenuItem tsmiProdutos;
        private ToolStripMenuItem tsmiCategorias;
        private ToolStripMenuItem tsmiEpocas;
        private ToolStripMenuItem operaçõesToolStripMenuItem;
        private ToolStripMenuItem tsmiEntregasToolStripMenuItem;
        private ToolStripMenuItem tsmiPrecos;
        private ToolStripMenuItem tsmiComercializacao;
        private ToolStripMenuItem tsmiRelatorios;
        private ToolStripMenuItem tsmiRelatorio;
        private ToolStripMenuItem tsmiDistribuicaoLucros;
        private ToolStripMenuItem tsmiSistema;
        private ToolStripMenuItem tsmiTerminarSessao;
        private ToolStripMenuItem tsmiSair;
        private Panel pnlDashboard;
        private Label lblTituloPrincipal;
        private Label lblSubtitulo;
        private GroupBox grpIndicadores;
        private Panel pnlCardCoops;
        private Label lblValorCoops;
        private Label lblTituloCoops;
        private Panel pnlCardProdutos;
        private Label lblValorProdutos;
        private Label lblTituloProdutos;
        private Panel pnlCardEntregas;
        private Label lblValorEntregas;
        private Label lblTituloEntregas;
        private Panel pnlCardEpocas;
        private Label lblValorEpocas;
        private Label lblTituloEpocas;
        private Panel pnlCardComercializacoes;
        private Label lblValorComercializacoes;
        private Label lblTituloComercializacoes;
        private Panel pnlCardLucros;
        private Label lblValorLucros;
        private Label lblTituloLucros;
        private GroupBox grpAtalhos;
        private Button btnAtalhoCoops;
        private Button btnAtalhoEntregas;
        private Button btnAtalhoPrecos;
        private Button btnAtalhoComercializacao;
        private Button btnAtalhoRelatorio;
        private Button btnActualizarDashboard;
        private Label lblResumoOperacional;
        private Label lblEpocaActual;
        private Label lblQuotasResumo;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel tsslUtilizador;
        private ToolStripStatusLabel tsslSeparador;
        private ToolStripStatusLabel tsslDataHora;
        private GroupBox grpActividades;
        private DataGridView dgvActividades;
    }
}
