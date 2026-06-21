namespace SGCA_Sistema_Afonso_Pande_Igildo_Mufundo
{
    partial class FrmLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources =
                new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));

            // Instantiate all controls
            pnlLeft         = new Panel();
            picLogo         = new PictureBox();
            lblSistema      = new Label();
            lblSubtitulo    = new Label();
            lblCopyright    = new Label();
            pnlRight        = new Panel();
            btnClose        = new Button();
            lblBemVindo     = new Label();
            lblInstructions = new Label();
            label1          = new Label();
            pnlUserBox      = new Panel();
            txtusername     = new TextBox();
            label2          = new Label();
            pnlPassBox      = new Panel();
            txtpassword     = new TextBox();
            button1         = new Button();
            button2         = new Button();

            pnlLeft.SuspendLayout();
            pnlRight.SuspendLayout();
            pnlUserBox.SuspendLayout();
            pnlPassBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            SuspendLayout();

            // ─────────────────────────────────────────────────────────────────
            // pnlLeft  (painel verde-escuro da esquerda)
            // ─────────────────────────────────────────────────────────────────
            pnlLeft.BackColor = Color.FromArgb(27, 58, 45);
            pnlLeft.Dock      = DockStyle.Left;
            pnlLeft.Width     = 280;
            pnlLeft.Name      = "pnlLeft";
            pnlLeft.Controls.Add(picLogo);
            pnlLeft.Controls.Add(lblSistema);
            pnlLeft.Controls.Add(lblSubtitulo);
            pnlLeft.Controls.Add(lblCopyright);

            // ─────────────────────────────────────────────────────────────────
            // picLogo  (imagem existente do resx)
            // ─────────────────────────────────────────────────────────────────
            picLogo.Image    = (Image)resources.GetObject("pictureBox1.Image");
            picLogo.Location = new Point(65, 56);
            picLogo.Name     = "picLogo";
            picLogo.Size     = new Size(150, 125);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.BackColor = Color.Transparent;
            picLogo.TabStop  = false;

            // ─────────────────────────────────────────────────────────────────
            // lblSistema  ("SGCA")
            // ─────────────────────────────────────────────────────────────────
            lblSistema.AutoSize  = false;
            lblSistema.Font      = new Font("Segoe UI", 26F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSistema.ForeColor = Color.White;
            lblSistema.Location  = new Point(0, 198);
            lblSistema.Name      = "lblSistema";
            lblSistema.Size      = new Size(280, 46);
            lblSistema.TextAlign = ContentAlignment.MiddleCenter;
            lblSistema.Text      = "SGCA";

            // ─────────────────────────────────────────────────────────────────
            // lblSubtitulo
            // ─────────────────────────────────────────────────────────────────
            lblSubtitulo.AutoSize  = false;
            lblSubtitulo.Font      = new Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSubtitulo.ForeColor = Color.FromArgb(160, 210, 170);
            lblSubtitulo.Location  = new Point(10, 246);
            lblSubtitulo.Name      = "lblSubtitulo";
            lblSubtitulo.Size      = new Size(260, 46);
            lblSubtitulo.TextAlign = ContentAlignment.TopCenter;
            lblSubtitulo.Text      = "Sistema de Gestão de\nCooperativa Agrícola";

            // ─────────────────────────────────────────────────────────────────
            // lblCopyright  (rodapé do painel esquerdo)
            // ─────────────────────────────────────────────────────────────────
            lblCopyright.AutoSize  = false;
            lblCopyright.Font      = new Font("Segoe UI", 7F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblCopyright.ForeColor = Color.FromArgb(90, 140, 100);
            lblCopyright.Location  = new Point(5, 396);
            lblCopyright.Name      = "lblCopyright";
            lblCopyright.Size      = new Size(270, 20);
            lblCopyright.TextAlign = ContentAlignment.MiddleCenter;
            lblCopyright.Text      = "© 2025  Afonso · Pande · Igildo · Mufundo";

            // ─────────────────────────────────────────────────────────────────
            // pnlRight  (painel branco da direita)
            // ─────────────────────────────────────────────────────────────────
            pnlRight.BackColor = Color.White;
            pnlRight.Dock      = DockStyle.Fill;
            pnlRight.Name      = "pnlRight";
            pnlRight.Controls.Add(btnClose);
            pnlRight.Controls.Add(lblBemVindo);
            pnlRight.Controls.Add(lblInstructions);
            pnlRight.Controls.Add(label1);
            pnlRight.Controls.Add(pnlUserBox);
            pnlRight.Controls.Add(label2);
            pnlRight.Controls.Add(pnlPassBox);
            pnlRight.Controls.Add(button1);
            pnlRight.Controls.Add(button2);

            // ─────────────────────────────────────────────────────────────────
            // btnClose  (✕ no canto superior direito)
            // ─────────────────────────────────────────────────────────────────
            btnClose.Anchor    = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize         = 0;
            btnClose.FlatAppearance.MouseOverBackColor = Color.FromArgb(235, 235, 235);
            btnClose.Font      = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnClose.ForeColor = Color.FromArgb(150, 150, 150);
            btnClose.BackColor = Color.Transparent;
            btnClose.Location  = new Point(396, 8);
            btnClose.Name      = "btnClose";
            btnClose.Size      = new Size(36, 32);
            btnClose.TabStop   = false;
            btnClose.Text      = "✕";
            btnClose.Cursor    = Cursors.Hand;
            btnClose.Click    += button2_Click;

            // ─────────────────────────────────────────────────────────────────
            // lblBemVindo
            // ─────────────────────────────────────────────────────────────────
            lblBemVindo.AutoSize  = false;
            lblBemVindo.Font      = new Font("Segoe UI", 17F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBemVindo.ForeColor = Color.FromArgb(20, 20, 20);
            lblBemVindo.Location  = new Point(40, 66);
            lblBemVindo.Name      = "lblBemVindo";
            lblBemVindo.Size      = new Size(368, 38);
            lblBemVindo.Text      = "Bem-vindo de volta!";

            // ─────────────────────────────────────────────────────────────────
            // lblInstructions
            // ─────────────────────────────────────────────────────────────────
            lblInstructions.AutoSize  = false;
            lblInstructions.Font      = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblInstructions.ForeColor = Color.Gray;
            lblInstructions.Location  = new Point(40, 107);
            lblInstructions.Name      = "lblInstructions";
            lblInstructions.Size      = new Size(368, 22);
            lblInstructions.Text      = "Inicie sessão na sua conta para continuar";

            // ─────────────────────────────────────────────────────────────────
            // label1  ("UTILIZADOR")
            // ─────────────────────────────────────────────────────────────────
            label1.AutoSize  = true;
            label1.Font      = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(80, 80, 80);
            label1.Location  = new Point(40, 152);
            label1.Name      = "label1";
            label1.Text      = "UTILIZADOR";

            // ─────────────────────────────────────────────────────────────────
            // pnlUserBox  (caixa de entrada do utilizador)
            // ─────────────────────────────────────────────────────────────────
            pnlUserBox.BackColor   = Color.White;
            pnlUserBox.BorderStyle = BorderStyle.FixedSingle;
            pnlUserBox.Location    = new Point(40, 172);
            pnlUserBox.Name        = "pnlUserBox";
            pnlUserBox.Size        = new Size(358, 42);
            pnlUserBox.Controls.Add(txtusername);

            // ─────────────────────────────────────────────────────────────────
            // txtusername
            // ─────────────────────────────────────────────────────────────────
            txtusername.BorderStyle = BorderStyle.None;
            txtusername.Font        = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtusername.Location    = new Point(10, 10);
            txtusername.Name        = "txtusername";
            txtusername.Size        = new Size(334, 22);
            txtusername.TabIndex    = 0;

            // ─────────────────────────────────────────────────────────────────
            // label2  ("PASSWORD")
            // ─────────────────────────────────────────────────────────────────
            label2.AutoSize  = true;
            label2.Font      = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(80, 80, 80);
            label2.Location  = new Point(40, 230);
            label2.Name      = "label2";
            label2.Text      = "PASSWORD";

            // ─────────────────────────────────────────────────────────────────
            // pnlPassBox  (caixa de entrada da password)
            // ─────────────────────────────────────────────────────────────────
            pnlPassBox.BackColor   = Color.White;
            pnlPassBox.BorderStyle = BorderStyle.FixedSingle;
            pnlPassBox.Location    = new Point(40, 250);
            pnlPassBox.Name        = "pnlPassBox";
            pnlPassBox.Size        = new Size(358, 42);
            pnlPassBox.Controls.Add(txtpassword);

            // ─────────────────────────────────────────────────────────────────
            // txtpassword
            // ─────────────────────────────────────────────────────────────────
            txtpassword.BorderStyle = BorderStyle.None;
            txtpassword.Font        = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtpassword.Location    = new Point(10, 10);
            txtpassword.Name        = "txtpassword";
            txtpassword.Size        = new Size(334, 22);
            txtpassword.TabIndex    = 1;

            // ─────────────────────────────────────────────────────────────────
            // button1  ("ENTRAR")
            // ─────────────────────────────────────────────────────────────────
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize         = 0;
            button1.FlatAppearance.MouseOverBackColor = Color.FromArgb(40, 82, 62);
            button1.BackColor = Color.FromArgb(27, 58, 45);
            button1.ForeColor = Color.White;
            button1.Font      = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location  = new Point(40, 314);
            button1.Name      = "button1";
            button1.Size      = new Size(358, 48);
            button1.TabIndex  = 2;
            button1.Text      = "ENTRAR";
            button1.Cursor    = Cursors.Hand;
            button1.Click    += button1_Click;

            // ─────────────────────────────────────────────────────────────────
            // button2  ("Cancelar e sair")
            // ─────────────────────────────────────────────────────────────────
            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderSize         = 0;
            button2.FlatAppearance.MouseOverBackColor = Color.FromArgb(245, 245, 245);
            button2.BackColor = Color.Transparent;
            button2.ForeColor = Color.FromArgb(150, 150, 150);
            button2.Font      = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.Location  = new Point(40, 372);
            button2.Name      = "button2";
            button2.Size      = new Size(358, 30);
            button2.TabIndex  = 3;
            button2.Text      = "Cancelar e sair";
            button2.Cursor    = Cursors.Hand;

            // ─────────────────────────────────────────────────────────────────
            // Formulário
            // ─────────────────────────────────────────────────────────────────
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode       = AutoScaleMode.Font;
            BackColor           = Color.White;
            ClientSize          = new Size(720, 440);
            FormBorderStyle     = FormBorderStyle.None;
            Name                = "FrmLogin";
            StartPosition       = FormStartPosition.CenterScreen;
            Text                = "SGCA — Login";
            Controls.Add(pnlRight);
            Controls.Add(pnlLeft);

            pnlLeft.ResumeLayout(false);
            pnlLeft.PerformLayout();
            pnlRight.ResumeLayout(false);
            pnlRight.PerformLayout();
            pnlUserBox.ResumeLayout(false);
            pnlUserBox.PerformLayout();
            pnlPassBox.ResumeLayout(false);
            pnlPassBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        // ── Declaração de campos ──────────────────────────────────────────────
        private Panel      pnlLeft;
        private PictureBox picLogo;
        private Label      lblSistema;
        private Label      lblSubtitulo;
        private Label      lblCopyright;
        private Panel      pnlRight;
        private Button     btnClose;
        private Label      lblBemVindo;
        private Label      lblInstructions;
        private Label      label1;
        private Panel      pnlUserBox;
        private TextBox    txtusername;
        private Label      label2;
        private Panel      pnlPassBox;
        private TextBox    txtpassword;
        private Button     button1;
        private Button     button2;
    }
}
