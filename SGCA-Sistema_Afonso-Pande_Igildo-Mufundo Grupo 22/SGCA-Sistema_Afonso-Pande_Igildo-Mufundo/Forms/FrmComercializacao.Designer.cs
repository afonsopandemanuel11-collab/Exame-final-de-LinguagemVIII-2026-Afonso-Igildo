namespace SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Vistas
{
    partial class FrmComercializacao
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
            lblTotalApurado = new Label();
            txtPesquisar = new TextBox();
            btnActualizar = new Button();
            btnCalcular = new Button();
            btnDistribuir = new Button();
            dgvEntregasCom = new DataGridView();
            dgvDistribuicao = new DataGridView();
            label1 = new Label();
            cmbEpocaPreco = new ComboBox();
            lblDataVenda = new Label();
            dtpDataVenda = new DateTimePicker();
            lblDescricao = new Label();
            txtDescricao = new TextBox();
            lblEntregas = new Label();
            lblDistribuicao = new Label();
            btnExportarCsv = new Button();
            btnExportarPdf = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvEntregasCom).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDistribuicao).BeginInit();
            SuspendLayout();
            // 
            // lblTotalApurado
            // 
            lblTotalApurado.AutoSize = true;
            lblTotalApurado.Location = new Point(12, 218);
            lblTotalApurado.Name = "lblTotalApurado";
            lblTotalApurado.Size = new Size(110, 15);
            lblTotalApurado.TabIndex = 13;
            lblTotalApurado.Text = "Total apurado: —";
            // 
            // txtPesquisar
            // 
            txtPesquisar.Location = new Point(12, 88);
            txtPesquisar.Name = "txtPesquisar";
            txtPesquisar.PlaceholderText = "Pesquisar cooperativista ou produto...";
            txtPesquisar.Size = new Size(232, 23);
            txtPesquisar.TabIndex = 12;
            txtPesquisar.TextChanged += txtPesquisar_TextChanged;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(12, 248);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(110, 30);
            btnActualizar.TabIndex = 10;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnCalcular
            // 
            btnCalcular.Location = new Point(12, 178);
            btnCalcular.Name = "btnCalcular";
            btnCalcular.Size = new Size(110, 30);
            btnCalcular.TabIndex = 9;
            btnCalcular.Text = "Calcular";
            btnCalcular.UseVisualStyleBackColor = true;
            btnCalcular.Click += btnCalcular_Click;
            // 
            // btnDistribuir
            // 
            btnDistribuir.Location = new Point(134, 178);
            btnDistribuir.Name = "btnDistribuir";
            btnDistribuir.Size = new Size(110, 30);
            btnDistribuir.TabIndex = 8;
            btnDistribuir.Text = "Distribuir";
            btnDistribuir.UseVisualStyleBackColor = true;
            btnDistribuir.Click += btnDistribuir_Click;
            // 
            // dgvEntregasCom
            // 
            dgvEntregasCom.AllowUserToAddRows = false;
            dgvEntregasCom.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEntregasCom.Location = new Point(260, 52);
            dgvEntregasCom.Name = "dgvEntregasCom";
            dgvEntregasCom.ReadOnly = true;
            dgvEntregasCom.Size = new Size(330, 359);
            dgvEntregasCom.TabIndex = 7;
            // 
            // dgvDistribuicao
            // 
            dgvDistribuicao.AllowUserToAddRows = false;
            dgvDistribuicao.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDistribuicao.Location = new Point(606, 52);
            dgvDistribuicao.Name = "dgvDistribuicao";
            dgvDistribuicao.ReadOnly = true;
            dgvDistribuicao.Size = new Size(350, 359);
            dgvDistribuicao.TabIndex = 14;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 20;
            label1.Text = "Época";
            // 
            // cmbEpocaPreco
            // 
            cmbEpocaPreco.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEpocaPreco.FormattingEnabled = true;
            cmbEpocaPreco.Location = new Point(12, 33);
            cmbEpocaPreco.Name = "cmbEpocaPreco";
            cmbEpocaPreco.Size = new Size(232, 23);
            cmbEpocaPreco.TabIndex = 19;
            cmbEpocaPreco.SelectedIndexChanged += cmbEpocaPreco_SelectedIndexChanged;
            // 
            // lblDataVenda
            // 
            lblDataVenda.AutoSize = true;
            lblDataVenda.Location = new Point(12, 118);
            lblDataVenda.Name = "lblDataVenda";
            lblDataVenda.Size = new Size(68, 15);
            lblDataVenda.TabIndex = 21;
            lblDataVenda.Text = "Data Venda";
            // 
            // dtpDataVenda
            // 
            dtpDataVenda.Location = new Point(12, 136);
            dtpDataVenda.Name = "dtpDataVenda";
            dtpDataVenda.Size = new Size(232, 23);
            dtpDataVenda.TabIndex = 22;
            // 
            // lblDescricao
            // 
            lblDescricao.AutoSize = true;
            lblDescricao.Location = new Point(12, 288);
            lblDescricao.Name = "lblDescricao";
            lblDescricao.Size = new Size(58, 15);
            lblDescricao.TabIndex = 23;
            lblDescricao.Text = "Descrição";
            // 
            // txtDescricao
            // 
            txtDescricao.Location = new Point(12, 306);
            txtDescricao.Multiline = true;
            txtDescricao.Name = "txtDescricao";
            txtDescricao.Size = new Size(232, 50);
            txtDescricao.TabIndex = 24;
            // 
            // lblEntregas
            // 
            lblEntregas.AutoSize = true;
            lblEntregas.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEntregas.Location = new Point(260, 30);
            lblEntregas.Name = "lblEntregas";
            lblEntregas.Size = new Size(55, 15);
            lblEntregas.TabIndex = 25;
            lblEntregas.Text = "Entregas";
            // 
            // lblDistribuicao
            // 
            lblDistribuicao.AutoSize = true;
            lblDistribuicao.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDistribuicao.Location = new Point(606, 30);
            lblDistribuicao.Name = "lblDistribuicao";
            lblDistribuicao.Size = new Size(75, 15);
            lblDistribuicao.TabIndex = 26;
            lblDistribuicao.Text = "Distribuição";
            // 
            // btnExportarCsv
            // 
            btnExportarCsv.Location = new Point(134, 248);
            btnExportarCsv.Name = "btnExportarCsv";
            btnExportarCsv.Size = new Size(110, 30);
            btnExportarCsv.TabIndex = 27;
            btnExportarCsv.Text = "Exportar CSV";
            btnExportarCsv.UseVisualStyleBackColor = true;
            btnExportarCsv.Click += btnExportarCsv_Click;
            // 
            // btnExportarPdf
            // 
            btnExportarPdf.Location = new Point(12, 368);
            btnExportarPdf.Name = "btnExportarPdf";
            btnExportarPdf.Size = new Size(232, 30);
            btnExportarPdf.TabIndex = 28;
            btnExportarPdf.Text = "Exportar PDF";
            btnExportarPdf.UseVisualStyleBackColor = true;
            btnExportarPdf.Click += btnExportarPdf_Click;
            // 
            // FrmComercializacao
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(968, 420);
            Controls.Add(btnExportarPdf);
            Controls.Add(btnExportarCsv);
            Controls.Add(lblDistribuicao);
            Controls.Add(lblEntregas);
            Controls.Add(txtDescricao);
            Controls.Add(lblDescricao);
            Controls.Add(dtpDataVenda);
            Controls.Add(lblDataVenda);
            Controls.Add(label1);
            Controls.Add(cmbEpocaPreco);
            Controls.Add(dgvDistribuicao);
            Controls.Add(lblTotalApurado);
            Controls.Add(txtPesquisar);
            Controls.Add(btnActualizar);
            Controls.Add(btnCalcular);
            Controls.Add(btnDistribuir);
            Controls.Add(dgvEntregasCom);
            Name = "FrmComercializacao";
            Text = "Comercialização";
            Load += FrmComercializacao_Load;
            ((System.ComponentModel.ISupportInitialize)dgvEntregasCom).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDistribuicao).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTotalApurado;
        private TextBox txtPesquisar;
        private Button btnActualizar;
        private Button btnCalcular;
        private Button btnDistribuir;
        private DataGridView dgvEntregasCom;
        private DataGridView dgvDistribuicao;
        private Label label1;
        private ComboBox cmbEpocaPreco;
        private Label lblDataVenda;
        private DateTimePicker dtpDataVenda;
        private Label lblDescricao;
        private TextBox txtDescricao;
        private Label lblEntregas;
        private Label lblDistribuicao;
        private Button btnExportarCsv;
        private Button btnExportarPdf;
    }
}
