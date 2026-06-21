namespace SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Vistas
{
    partial class FrmEpocas
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
            dgvEpocas = new DataGridView();
            btnNovaEpoca = new Button();
            btnEncerrar = new Button();
            btnActualizar = new Button();
            grpFormEpoca = new GroupBox();
            txtNomeEpoca = new TextBox();
            cmbTipoEpoca = new ComboBox();
            nudAno = new NumericUpDown();
            dtpInicio = new DateTimePicker();
            dtpFim = new DateTimePicker();
            btnSalvarEpoca = new Button();
            btnCancelarEpoca = new Button();
            btnEditarEpoca = new Button();
            txtPesquisar = new TextBox();
            btnExportarCsv = new Button();
            btnExportarPdf = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvEpocas).BeginInit();
            grpFormEpoca.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudAno).BeginInit();
            SuspendLayout();
            // 
            // dgvEpocas
            // 
            dgvEpocas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEpocas.Location = new Point(457, 78);
            dgvEpocas.Name = "dgvEpocas";
            dgvEpocas.Size = new Size(331, 313);
            dgvEpocas.TabIndex = 0;
            // 
            // btnNovaEpoca
            // 
            btnNovaEpoca.Location = new Point(28, 37);
            btnNovaEpoca.Name = "btnNovaEpoca";
            btnNovaEpoca.Size = new Size(75, 23);
            btnNovaEpoca.TabIndex = 1;
            btnNovaEpoca.Text = "NovaEpoca";
            btnNovaEpoca.UseVisualStyleBackColor = true;
            btnNovaEpoca.Click += btnNovaEpoca_Click;
            // 
            // btnEncerrar
            // 
            btnEncerrar.Location = new Point(123, 37);
            btnEncerrar.Name = "btnEncerrar";
            btnEncerrar.Size = new Size(75, 23);
            btnEncerrar.TabIndex = 2;
            btnEncerrar.Text = "Encerrar";
            btnEncerrar.UseVisualStyleBackColor = true;
            btnEncerrar.Click += btnEncerrar_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(216, 37);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(75, 23);
            btnActualizar.TabIndex = 3;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // grpFormEpoca
            // 
            grpFormEpoca.Controls.Add(txtNomeEpoca);
            grpFormEpoca.Location = new Point(29, 105);
            grpFormEpoca.Name = "grpFormEpoca";
            grpFormEpoca.Size = new Size(218, 100);
            grpFormEpoca.TabIndex = 4;
            grpFormEpoca.TabStop = false;
            grpFormEpoca.Text = "Text=Nova Época, Visible=False";
            // 
            // txtNomeEpoca
            // 
            txtNomeEpoca.Location = new Point(6, 31);
            txtNomeEpoca.Name = "txtNomeEpoca";
            txtNomeEpoca.Size = new Size(134, 23);
            txtNomeEpoca.TabIndex = 0;
            // 
            // cmbTipoEpoca
            // 
            cmbTipoEpoca.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoEpoca.FormattingEnabled = true;
            cmbTipoEpoca.Location = new Point(316, 37);
            cmbTipoEpoca.Name = "cmbTipoEpoca";
            cmbTipoEpoca.Size = new Size(121, 23);
            cmbTipoEpoca.TabIndex = 5;
            // 
            // nudAno
            // 
            nudAno.Location = new Point(266, 136);
            nudAno.Maximum = new decimal(new int[] { 2100, 0, 0, 0 });
            nudAno.Minimum = new decimal(new int[] { 2000, 0, 0, 0 });
            nudAno.Name = "nudAno";
            nudAno.Size = new Size(120, 23);
            nudAno.TabIndex = 6;
            nudAno.Value = new decimal(new int[] { 2000, 0, 0, 0 });
            // 
            // dtpInicio
            // 
            dtpInicio.Location = new Point(8, 255);
            dtpInicio.Name = "dtpInicio";
            dtpInicio.Size = new Size(200, 23);
            dtpInicio.TabIndex = 7;
            // 
            // dtpFim
            // 
            dtpFim.Location = new Point(8, 315);
            dtpFim.Name = "dtpFim";
            dtpFim.Size = new Size(200, 23);
            dtpFim.TabIndex = 8;
            // 
            // btnSalvarEpoca
            // 
            btnSalvarEpoca.Location = new Point(15, 393);
            btnSalvarEpoca.Name = "btnSalvarEpoca";
            btnSalvarEpoca.Size = new Size(75, 23);
            btnSalvarEpoca.TabIndex = 9;
            btnSalvarEpoca.Text = "SalvarEpoca";
            btnSalvarEpoca.UseVisualStyleBackColor = true;
            btnSalvarEpoca.Click += btnSalvarEpoca_Click;
            // 
            // btnCancelarEpoca
            // 
            btnCancelarEpoca.Location = new Point(216, 392);
            btnCancelarEpoca.Name = "btnCancelarEpoca";
            btnCancelarEpoca.Size = new Size(75, 23);
            btnCancelarEpoca.TabIndex = 10;
            btnCancelarEpoca.Text = "btnCancelarEpoca";
            btnCancelarEpoca.UseVisualStyleBackColor = true;
            btnCancelarEpoca.Click += btnCancelarEpoca_Click;
            // 
            // btnEditarEpoca
            // 
            btnEditarEpoca.Location = new Point(317, 37);
            btnEditarEpoca.Name = "btnEditarEpoca";
            btnEditarEpoca.Size = new Size(75, 23);
            btnEditarEpoca.TabIndex = 11;
            btnEditarEpoca.Text = "Editar";
            btnEditarEpoca.UseVisualStyleBackColor = true;
            btnEditarEpoca.Click += btnEditarEpoca_Click;
            // 
            // txtPesquisar
            // 
            txtPesquisar.Location = new Point(29, 70);
            txtPesquisar.Name = "txtPesquisar";
            txtPesquisar.PlaceholderText = "Pesquisar época...";
            txtPesquisar.Size = new Size(262, 23);
            txtPesquisar.TabIndex = 12;
            txtPesquisar.TextChanged += txtPesquisar_TextChanged;
            // 
            // btnExportarCsv
            // 
            btnExportarCsv.Location = new Point(457, 37);
            btnExportarCsv.Name = "btnExportarCsv";
            btnExportarCsv.Size = new Size(100, 23);
            btnExportarCsv.TabIndex = 13;
            btnExportarCsv.Text = "Exportar CSV";
            btnExportarCsv.UseVisualStyleBackColor = true;
            btnExportarCsv.Click += btnExportarCsv_Click;
            // 
            // btnExportarPdf
            // 
            btnExportarPdf.Location = new Point(563, 37);
            btnExportarPdf.Name = "btnExportarPdf";
            btnExportarPdf.Size = new Size(100, 23);
            btnExportarPdf.TabIndex = 14;
            btnExportarPdf.Text = "Exportar PDF";
            btnExportarPdf.UseVisualStyleBackColor = true;
            btnExportarPdf.Click += btnExportarPdf_Click;
            // 
            // FrmEpocas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnExportarPdf);
            Controls.Add(btnExportarCsv);
            Controls.Add(txtPesquisar);
            Controls.Add(btnEditarEpoca);
            Controls.Add(btnCancelarEpoca);
            Controls.Add(nudAno);
            Controls.Add(btnSalvarEpoca);
            Controls.Add(dtpFim);
            Controls.Add(dtpInicio);
            Controls.Add(cmbTipoEpoca);
            Controls.Add(grpFormEpoca);
            Controls.Add(btnActualizar);
            Controls.Add(btnEncerrar);
            Controls.Add(btnNovaEpoca);
            Controls.Add(dgvEpocas);
            Name = "FrmEpocas";
            Text = "Épocas Agrícolas";
            Load += FrmEpocas_Load;
            ((System.ComponentModel.ISupportInitialize)dgvEpocas).EndInit();
            grpFormEpoca.ResumeLayout(false);
            grpFormEpoca.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudAno).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvEpocas;
        private Button btnNovaEpoca;
        private Button btnEncerrar;
        private Button btnActualizar;
        private GroupBox grpFormEpoca;
        private TextBox txtNomeEpoca;
        private ComboBox cmbTipoEpoca;
        private NumericUpDown nudAno;
        private DateTimePicker dtpInicio;
        private DateTimePicker dtpFim;
        private Button btnSalvarEpoca;
        private Button btnCancelarEpoca;
        private Button btnEditarEpoca;
        private TextBox txtPesquisar;
        private Button btnExportarCsv;
        private Button btnExportarPdf;
    }
}