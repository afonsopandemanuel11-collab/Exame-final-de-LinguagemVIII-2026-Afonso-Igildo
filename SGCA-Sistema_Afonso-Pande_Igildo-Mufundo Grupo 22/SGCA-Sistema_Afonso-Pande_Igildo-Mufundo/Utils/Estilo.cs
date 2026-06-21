namespace SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Utils
{
    /// <summary>
    /// Paleta de cores e fontes unificada para toda a aplicação SGCA.
    /// Chame AppTheme.Aplicar(this) no evento Load de cada formulário.
    /// </summary>
    public static class Estilo
    {
        // ── Cores ─────────────────────────────────────────────────────────────
        public static readonly Color Verde          = Color.FromArgb(27,  58,  45);   // primária escura
        public static readonly Color VerdeHover     = Color.FromArgb(40,  82,  62);   // hover botão primário
        public static readonly Color VerdeClaro     = Color.FromArgb(72, 140,  97);   // acento
        public static readonly Color VerdeSuave     = Color.FromArgb(237, 248, 242);  // fundo de foco
        public static readonly Color VerdeTenue     = Color.FromArgb(220, 240, 228);  // fundo de painel secundário
        public static readonly Color BordaGrid      = Color.FromArgb(160, 210, 170);  // borda / header grid
        public static readonly Color BrancoPuro     = Color.White;
        public static readonly Color FundoPagina    = Color.FromArgb(249, 251, 250);  // fundo geral dos forms
        public static readonly Color TextoPrimario  = Color.FromArgb( 20,  20,  20);
        public static readonly Color TextoSecundario= Color.FromArgb( 70,  70,  70);
        public static readonly Color TextoMuted     = Color.FromArgb(140, 140, 140);
        public static readonly Color Perigo         = Color.FromArgb(180,  40,  40);  // botão eliminar/desactivar
        public static readonly Color PerigoHover    = Color.FromArgb(210,  60,  60);
        public static readonly Color Neutro         = Color.FromArgb(100, 130, 110);  // botão secundário (cancelar)
        public static readonly Color NeutroHover    = Color.FromArgb(120, 155, 130);

        // ── Fontes ────────────────────────────────────────────────────────────
        public static readonly Font FonteTitulo  = new Font("Segoe UI", 13F, FontStyle.Bold,   GraphicsUnit.Point, 0);
        public static readonly Font FonteLabel   = new Font("Segoe UI",  8.5F, FontStyle.Bold,   GraphicsUnit.Point, 0);
        public static readonly Font FonteNormal  = new Font("Segoe UI",  9F,   FontStyle.Regular, GraphicsUnit.Point, 0);
        public static readonly Font FonteInput   = new Font("Segoe UI", 10F,   FontStyle.Regular, GraphicsUnit.Point, 0);
        public static readonly Font FonteBotao   = new Font("Segoe UI",  9.5F, FontStyle.Bold,   GraphicsUnit.Point, 0);
        public static readonly Font FonteGrid    = new Font("Segoe UI",  9F,   FontStyle.Regular, GraphicsUnit.Point, 0);
        public static readonly Font FonteMenu    = new Font("Segoe UI",  9.5F, FontStyle.Regular, GraphicsUnit.Point, 0);

        // ── Dimensões de botão padrão ─────────────────────────────────────────
        public static readonly Size TamanhoBotao = new Size(110, 34);

        // ══════════════════════════════════════════════════════════════════════
        // Método principal — aplica o tema a um Form completo
        // ══════════════════════════════════════════════════════════════════════
        public static void Aplicar(Form form)
        {
            form.BackColor = FundoPagina;
            form.Font      = FonteNormal;

            // Cabeçalho visual do form (barra verde no topo)
            AdicionarBannerTopo(form);

            AplicarAControlos(form.Controls, form);
        }

        // ── Aplica recursivamente a todos os controles ────────────────────────
        private static void AplicarAControlos(Control.ControlCollection controles, Form formPai)
        {
            foreach (Control c in controles)
            {
                switch (c)
                {
                    case MenuStrip ms:
                        EstilizarMenuStrip(ms);
                        break;

                    case DataGridView dgv:
                        EstilizarGrid(dgv);
                        break;

                    case Button btn:
                        EstilizarBotao(btn);
                        break;

                    case TextBox txt:
                        EstilizarTextBox(txt);
                        break;

                    case ComboBox cmb:
                        EstilizarComboBox(cmb);
                        break;

                    case Label lbl:
                        EstilizarLabel(lbl);
                        break;

                    case GroupBox grp:
                        EstilizarGroupBox(grp);
                        break;

                    case Panel pnl:
                        // Não sobrescreve painéis que já têm cor personalizada
                        if (pnl.BackColor == SystemColors.Control ||
                            pnl.BackColor == SystemColors.ButtonHighlight ||
                            pnl.BackColor == Color.White)
                            pnl.BackColor = FundoPagina;
                        break;

                    case NumericUpDown nud:
                        EstilizarNumericUpDown(nud);
                        break;

                    case DateTimePicker dtp:
                        EstilizarDateTimePicker(dtp);
                        break;

                    case CheckBox chk:
                        EstilizarCheckBox(chk);
                        break;
                }

                if (c.HasChildren)
                    AplicarAControlos(c.Controls, formPai);
            }
        }

        // ── Banner verde no topo de cada form filho ───────────────────────────
        private static void AdicionarBannerTopo(Form form)
        {
            // Evita duplicar o banner
            if (form.Controls.ContainsKey("__themeBanner")) return;

            // Não adiciona ao form principal MDI nem ao Login
            if (form.IsMdiContainer) return;
            if (form.Name == "FrmLogin" || form.Name == "FrmConectando") return;

            var banner = new Panel
            {
                Name      = "__themeBanner",
                Dock      = DockStyle.Top,
                Height    = 44,
                BackColor = Verde,
                Padding   = new Padding(12, 0, 0, 0),
            };

            var titulo = new Label
            {
                AutoSize  = false,
                Dock      = DockStyle.Fill,
                Text      = form.Text,
                Font      = FonteTitulo,
                ForeColor = BrancoPuro,
                TextAlign = ContentAlignment.MiddleLeft,
            };

            banner.Controls.Add(titulo);
            form.Controls.Add(banner);
            banner.BringToFront();
        }

        // ── MenuStrip ─────────────────────────────────────────────────────────
        private static void EstilizarMenuStrip(MenuStrip ms)
        {
            ms.BackColor = Verde;
            ms.ForeColor = BrancoPuro;
            ms.Font      = FonteMenu;
            ms.Renderer  = new SgcaMenuRenderer();

            foreach (ToolStripItem item in ms.Items)
            {
                item.ForeColor = BrancoPuro;
                item.Font      = FonteMenu;
                item.BackColor = Verde;

                if (item is ToolStripMenuItem menuItem)
                    EstilizarMenuItems(menuItem);
            }
        }

        private static void EstilizarMenuItems(ToolStripMenuItem parent)
        {
            foreach (ToolStripItem child in parent.DropDownItems)
            {
                child.ForeColor = TextoPrimario;
                child.Font      = FonteNormal;
                child.BackColor = BrancoPuro;

                if (child is ToolStripMenuItem sub)
                    EstilizarMenuItems(sub);
            }
        }

        // ── DataGridView ──────────────────────────────────────────────────────
        private static void EstilizarGrid(DataGridView dgv)
        {
            dgv.BackgroundColor             = BrancoPuro;
            dgv.BorderStyle                 = BorderStyle.FixedSingle;
            dgv.GridColor                   = Color.FromArgb(220, 235, 225);
            dgv.Font                        = FonteGrid;
            dgv.RowHeadersVisible           = false;
            dgv.AllowUserToResizeRows       = false;
            dgv.SelectionMode               = DataGridViewSelectionMode.FullRowSelect;
            dgv.CellBorderStyle             = DataGridViewCellBorderStyle.SingleHorizontal;

            // Cabeçalho
            dgv.ColumnHeadersDefaultCellStyle.BackColor  = Verde;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor  = BrancoPuro;
            dgv.ColumnHeadersDefaultCellStyle.Font       = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = VerdeHover;
            dgv.ColumnHeadersDefaultCellStyle.Alignment  = DataGridViewContentAlignment.MiddleLeft;
            dgv.ColumnHeadersDefaultCellStyle.Padding    = new Padding(6, 0, 0, 0);
            dgv.ColumnHeadersBorderStyle                 = DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersHeight                      = 36;
            dgv.EnableHeadersVisualStyles                = false;

            // Linhas
            dgv.DefaultCellStyle.BackColor          = BrancoPuro;
            dgv.DefaultCellStyle.ForeColor          = TextoPrimario;
            dgv.DefaultCellStyle.SelectionBackColor = VerdeSuave;
            dgv.DefaultCellStyle.SelectionForeColor = Verde;
            dgv.DefaultCellStyle.Padding            = new Padding(4, 0, 0, 0);
            dgv.RowTemplate.Height                  = 30;

            // Linhas alternadas
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(244, 250, 247);
        }

        // ── Button ────────────────────────────────────────────────────────────
        private static void EstilizarBotao(Button btn)
        {
            btn.Font      = FonteBotao;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize  = 0;
            btn.Cursor    = Cursors.Hand;
            btn.Size      = new Size(Math.Max(btn.Width, 100), 34);

            string nome = btn.Name.ToLower();

            // Botões de perigo (eliminar, inactivar, desactivar, encerrar)
            if (nome.Contains("elimin") || nome.Contains("inactiv") ||
                nome.Contains("desactiv") || nome.Contains("encerrar"))
            {
                btn.BackColor = Perigo;
                btn.ForeColor = BrancoPuro;
                btn.FlatAppearance.MouseOverBackColor = PerigoHover;
            }
            // Botões de cancelar (neutros)
            else if (nome.Contains("cancel"))
            {
                btn.BackColor = Neutro;
                btn.ForeColor = BrancoPuro;
                btn.FlatAppearance.MouseOverBackColor = NeutroHover;
            }
            // Todos os outros → verde primário
            else
            {
                btn.BackColor = Verde;
                btn.ForeColor = BrancoPuro;
                btn.FlatAppearance.MouseOverBackColor = VerdeHover;
            }
        }

        // ── TextBox ───────────────────────────────────────────────────────────
        private static void EstilizarTextBox(TextBox txt)
        {
            txt.Font        = FonteInput;
            txt.BackColor   = BrancoPuro;
            txt.ForeColor   = TextoPrimario;
            txt.BorderStyle = BorderStyle.FixedSingle;
        }

        // ── ComboBox ──────────────────────────────────────────────────────────
        private static void EstilizarComboBox(ComboBox cmb)
        {
            cmb.Font      = FonteInput;
            cmb.BackColor = BrancoPuro;
            cmb.ForeColor = TextoPrimario;
            cmb.FlatStyle = FlatStyle.Flat;
        }

        // ── Label ─────────────────────────────────────────────────────────────
        private static void EstilizarLabel(Label lbl)
        {
            lbl.Font      = FonteLabel;
            lbl.ForeColor = TextoSecundario;
            lbl.BackColor = Color.Transparent;
        }

        // ── GroupBox ──────────────────────────────────────────────────────────
        private static void EstilizarGroupBox(GroupBox grp)
        {
            grp.Font      = new Font("Segoe UI", 9F, FontStyle.Bold);
            grp.ForeColor = Verde;
            grp.BackColor = VerdeTenue;
        }

        // ── NumericUpDown ─────────────────────────────────────────────────────
        private static void EstilizarNumericUpDown(NumericUpDown nud)
        {
            nud.Font      = FonteInput;
            nud.BackColor = BrancoPuro;
            nud.ForeColor = TextoPrimario;
            nud.BorderStyle = BorderStyle.FixedSingle;
        }

        // ── DateTimePicker ────────────────────────────────────────────────────
        private static void EstilizarDateTimePicker(DateTimePicker dtp)
        {
            dtp.Font      = FonteInput;
            dtp.CalendarMonthBackground = VerdeSuave;
            dtp.CalendarTitleBackColor  = Verde;
            dtp.CalendarTitleForeColor  = BrancoPuro;
            dtp.CalendarForeColor       = TextoPrimario;
        }

        // ── CheckBox ─────────────────────────────────────────────────────────
        private static void EstilizarCheckBox(CheckBox chk)
        {
            chk.Font      = FonteNormal;
            chk.ForeColor = TextoSecundario;
            chk.BackColor = Color.Transparent;
        }
    }

    // ══════════════════════════════════════════════════════════════════════════
    // Renderer personalizado para o MenuStrip
    // ══════════════════════════════════════════════════════════════════════════
    internal class SgcaMenuRenderer : ToolStripProfessionalRenderer
    {
        public SgcaMenuRenderer() : base(new SgcaColorTable()) { }

        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            var item = e.Item;
            var g    = e.Graphics;
            var rect = new Rectangle(Point.Empty, item.Size);

            if (item.IsOnDropDown)
            {
                // Itens do submenu
                Color bg = item.Selected
                    ? Estilo.VerdeSuave
                    : Estilo.BrancoPuro;
                using var brush = new SolidBrush(bg);
                g.FillRectangle(brush, rect);
            }
            else
            {
                // Itens da barra principal
                Color bg = item.Selected || item.Pressed
                    ? Estilo.VerdeHover
                    : Estilo.Verde;
                using var brush = new SolidBrush(bg);
                g.FillRectangle(brush, rect);
            }
        }
    }

    internal class SgcaColorTable : ProfessionalColorTable
    {
        public override Color MenuStripGradientBegin => Estilo.Verde;
        public override Color MenuStripGradientEnd   => Estilo.Verde;
        public override Color MenuBorder             => Estilo.BordaGrid;
        public override Color MenuItemBorder         => Estilo.VerdeClaro;
        public override Color MenuItemSelected       => Estilo.VerdeSuave;
        public override Color MenuItemSelectedGradientBegin => Estilo.VerdeSuave;
        public override Color MenuItemSelectedGradientEnd   => Estilo.VerdeSuave;
        public override Color ToolStripDropDownBackground   => Estilo.BrancoPuro;
        public override Color ImageMarginGradientBegin => Estilo.VerdeTenue;
        public override Color ImageMarginGradientMiddle=> Estilo.VerdeTenue;
        public override Color ImageMarginGradientEnd   => Estilo.VerdeTenue;
        public override Color SeparatorDark  => Estilo.BordaGrid;
        public override Color SeparatorLight => Estilo.VerdeSuave;
    }
}
