namespace SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Vistas
{
    partial class FrmRelatorio
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvRelatorio = new DataGridView();
            cmbEpoca = new ComboBox();
            btnGerarRelatorio = new Button();
            btnExportar = new Button();
            btnExportarPdf = new Button();
            lblTotalApuradoRel = new Label();
            lblTotalLucroRel = new Label();
            lblTotalCoopRel = new Label();
            lblInfoRelatorio = new Label();
            lblEpoca = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvRelatorio).BeginInit();
            SuspendLayout();
            // 
            // dgvRelatorio
            // 
            dgvRelatorio.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRelatorio.Location = new Point(339, 41);
            dgvRelatorio.Name = "dgvRelatorio";
            dgvRelatorio.Size = new Size(449, 397);
            dgvRelatorio.TabIndex = 0;
            // 
            // cmbEpoca
            // 
            cmbEpoca.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEpoca.FormattingEnabled = true;
            cmbEpoca.Location = new Point(12, 27);
            cmbEpoca.Name = "cmbEpoca";
            cmbEpoca.Size = new Size(324, 23);
            cmbEpoca.TabIndex = 1;
            // 
            // btnGerarRelatorio
            // 
            btnGerarRelatorio.Location = new Point(26, 272);
            btnGerarRelatorio.Name = "btnGerarRelatorio";
            btnGerarRelatorio.Size = new Size(104, 36);
            btnGerarRelatorio.TabIndex = 2;
            btnGerarRelatorio.Text = "Gerar Relatorio";
            btnGerarRelatorio.UseVisualStyleBackColor = true;
            btnGerarRelatorio.Click += btnGerarRelatorio_Click;
            // 
            // btnExportar
            // 
            btnExportar.Location = new Point(162, 272);
            btnExportar.Name = "btnExportar";
            btnExportar.Size = new Size(146, 36);
            btnExportar.TabIndex = 3;
            btnExportar.Text = "Exportar CSV";
            btnExportar.UseVisualStyleBackColor = true;
            btnExportar.Click += btnExportar_Click;
            // 
            // btnExportarPdf
            // 
            btnExportarPdf.Location = new Point(162, 320);
            btnExportarPdf.Name = "btnExportarPdf";
            btnExportarPdf.Size = new Size(146, 36);
            btnExportarPdf.TabIndex = 8;
            btnExportarPdf.Text = "Exportar PDF";
            btnExportarPdf.UseVisualStyleBackColor = true;
            btnExportarPdf.Click += btnExportarPdf_Click;
            // 
            // lblTotalApuradoRel
            // 
            lblTotalApuradoRel.AutoSize = true;
            lblTotalApuradoRel.Location = new Point(26, 112);
            lblTotalApuradoRel.Name = "lblTotalApuradoRel";
            lblTotalApuradoRel.Size = new Size(97, 15);
            lblTotalApuradoRel.TabIndex = 4;
            lblTotalApuradoRel.Text = "Total Apurado: --";
            // 
            // lblTotalLucroRel
            // 
            lblTotalLucroRel.AutoSize = true;
            lblTotalLucroRel.Location = new Point(27, 155);
            lblTotalLucroRel.Name = "lblTotalLucroRel";
            lblTotalLucroRel.Size = new Size(86, 15);
            lblTotalLucroRel.TabIndex = 5;
            lblTotalLucroRel.Text = "Total Lucros: --";
            // 
            // lblTotalCoopRel
            // 
            lblTotalCoopRel.AutoSize = true;
            lblTotalCoopRel.Location = new Point(26, 197);
            lblTotalCoopRel.Name = "lblTotalCoopRel";
            lblTotalCoopRel.Size = new Size(104, 15);
            lblTotalCoopRel.TabIndex = 6;
            lblTotalCoopRel.Text = "Cooperativistas: --";
            // 
            // lblInfoRelatorio
            // 
            lblInfoRelatorio.AutoSize = true;
            lblInfoRelatorio.Location = new Point(26, 230);
            lblInfoRelatorio.Name = "lblInfoRelatorio";
            lblInfoRelatorio.Size = new Size(10, 15);
            lblInfoRelatorio.TabIndex = 9;
            lblInfoRelatorio.Text = "—";
            // 
            // lblEpoca
            // 
            lblEpoca.AutoSize = true;
            lblEpoca.Location = new Point(12, 9);
            lblEpoca.Name = "lblEpoca";
            lblEpoca.Size = new Size(86, 15);
            lblEpoca.TabIndex = 7;
            lblEpoca.Text = "Época Agrícola:";
            // 
            // FrmRelatorio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblInfoRelatorio);
            Controls.Add(lblEpoca);
            Controls.Add(lblTotalCoopRel);
            Controls.Add(lblTotalLucroRel);
            Controls.Add(lblTotalApuradoRel);
            Controls.Add(btnExportarPdf);
            Controls.Add(btnExportar);
            Controls.Add(btnGerarRelatorio);
            Controls.Add(cmbEpoca);
            Controls.Add(dgvRelatorio);
            Name = "FrmRelatorio";
            Text = "Relatório";
            Load += FrmRelatorio_Load;
            ((System.ComponentModel.ISupportInitialize)dgvRelatorio).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvRelatorio;
        private ComboBox cmbEpoca;
        private Button btnGerarRelatorio;
        private Button btnExportar;
        private Label lblTotalApuradoRel;
        private Label lblTotalLucroRel;
        private Label lblTotalCoopRel;
        private Label lblInfoRelatorio;
        private Label lblEpoca;
        private Button btnExportarPdf;
    }
}