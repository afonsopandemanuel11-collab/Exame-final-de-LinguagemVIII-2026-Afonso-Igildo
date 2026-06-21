namespace SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Vistas
{
    partial class FrmPrecos
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
            label2 = new Label();
            label1 = new Label();
            lblEpocaPrecoStatus = new Label();
            dgvPrecos = new DataGridView();
            btnEliminar = new Button();
            btnFiltrar = new Button();
            btnDefinirPreco = new Button();
            cmbProdutoPreco = new ComboBox();
            cmbEpocaPreco = new ComboBox();
            grpFormPreco = new GroupBox();
            dtpDataDefinicao = new DateTimePicker();
            label3 = new Label();
            btnSalvarPreco = new Button();
            btnCancelarPreco = new Button();
            txtPrecoUnitario = new TextBox();
            label4 = new Label();
            btnExportarCsv = new Button();
            btnExportarPdf = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPrecos).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 73);
            label2.Name = "label2";
            label2.Size = new Size(83, 15);
            label2.TabIndex = 19;
            label2.Text = "Produto Preco";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 20);
            label1.Name = "label1";
            label1.Size = new Size(72, 15);
            label1.TabIndex = 18;
            label1.Text = "Epoca Preco";
            // 
            // lblEpocaPrecoStatus
            // 
            lblEpocaPrecoStatus.AutoSize = true;
            lblEpocaPrecoStatus.Location = new Point(16, 372);
            lblEpocaPrecoStatus.Name = "lblEpocaPrecoStatus";
            lblEpocaPrecoStatus.Size = new Size(53, 15);
            lblEpocaPrecoStatus.TabIndex = 17;
            lblEpocaPrecoStatus.Text = "Total: ---";
            // 
            // dgvPrecos
            // 
            dgvPrecos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPrecos.Location = new Point(351, 38);
            dgvPrecos.Name = "dgvPrecos";
            dgvPrecos.Size = new Size(442, 392);
            dgvPrecos.TabIndex = 16;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(258, 287);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 14;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminarPreco_Click;
            // 
            // btnFiltrar
            // 
            btnFiltrar.Location = new Point(132, 287);
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(107, 23);
            btnFiltrar.TabIndex = 13;
            btnFiltrar.Text = "Actualizar Precos";
            btnFiltrar.UseVisualStyleBackColor = true;
            btnFiltrar.Click += btnActualizarPrecos_Click;
            // 
            // btnDefinirPreco
            // 
            btnDefinirPreco.Location = new Point(14, 287);
            btnDefinirPreco.Name = "btnDefinirPreco";
            btnDefinirPreco.Size = new Size(97, 23);
            btnDefinirPreco.TabIndex = 12;
            btnDefinirPreco.Text = "Definir Preço";
            btnDefinirPreco.UseVisualStyleBackColor = true;
            btnDefinirPreco.Click += btnDefinirPreco_Click;
            // 
            // cmbProdutoPreco
            // 
            cmbProdutoPreco.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProdutoPreco.FormattingEnabled = true;
            cmbProdutoPreco.Location = new Point(17, 91);
            cmbProdutoPreco.Name = "cmbProdutoPreco";
            cmbProdutoPreco.Size = new Size(296, 23);
            cmbProdutoPreco.TabIndex = 11;
            cmbProdutoPreco.SelectedIndexChanged += cmbProdutoPreco_SelectedIndexChanged;
            // 
            // cmbEpocaPreco
            // 
            cmbEpocaPreco.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEpocaPreco.FormattingEnabled = true;
            cmbEpocaPreco.Location = new Point(17, 38);
            cmbEpocaPreco.Name = "cmbEpocaPreco";
            cmbEpocaPreco.Size = new Size(296, 23);
            cmbEpocaPreco.TabIndex = 10;
            cmbEpocaPreco.SelectedIndexChanged += cmbEpocaPreco_SelectedIndexChanged;
            // 
            // grpFormPreco
            // 
            grpFormPreco.Location = new Point(15, 147);
            grpFormPreco.Name = "grpFormPreco";
            grpFormPreco.Size = new Size(293, 48);
            grpFormPreco.TabIndex = 20;
            grpFormPreco.TabStop = false;
            grpFormPreco.Text = "Definir Preço";
            grpFormPreco.Visible = false;
            // 
            // dtpDataDefinicao
            // 
            dtpDataDefinicao.Location = new Point(16, 258);
            dtpDataDefinicao.Name = "dtpDataDefinicao";
            dtpDataDefinicao.Size = new Size(200, 23);
            dtpDataDefinicao.TabIndex = 21;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(19, 239);
            label3.Name = "label3";
            label3.Size = new Size(84, 15);
            label3.TabIndex = 22;
            label3.Text = "Data Definicao";
            // 
            // btnSalvarPreco
            // 
            btnSalvarPreco.Location = new Point(16, 339);
            btnSalvarPreco.Name = "btnSalvarPreco";
            btnSalvarPreco.Size = new Size(142, 23);
            btnSalvarPreco.TabIndex = 23;
            btnSalvarPreco.Text = "SalvarPreco";
            btnSalvarPreco.UseVisualStyleBackColor = true;
            btnSalvarPreco.Click += btnSalvarPreco_Click;
            // 
            // btnCancelarPreco
            // 
            btnCancelarPreco.Location = new Point(190, 339);
            btnCancelarPreco.Name = "btnCancelarPreco";
            btnCancelarPreco.Size = new Size(143, 23);
            btnCancelarPreco.TabIndex = 24;
            btnCancelarPreco.Text = "Cancelar Preco";
            btnCancelarPreco.UseVisualStyleBackColor = true;
            btnCancelarPreco.Click += btnCancelarPreco_Click;
            // 
            // txtPrecoUnitario
            // 
            txtPrecoUnitario.Location = new Point(12, 213);
            txtPrecoUnitario.Name = "txtPrecoUnitario";
            txtPrecoUnitario.Size = new Size(288, 23);
            txtPrecoUnitario.TabIndex = 25;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(19, 194);
            label4.Name = "label4";
            label4.Size = new Size(79, 15);
            label4.TabIndex = 26;
            label4.Text = "Preço Unitário (AOA)";
            // 
            // btnExportarCsv
            // 
            btnExportarCsv.Location = new Point(351, 8);
            btnExportarCsv.Name = "btnExportarCsv";
            btnExportarCsv.Size = new Size(100, 23);
            btnExportarCsv.TabIndex = 27;
            btnExportarCsv.Text = "Exportar CSV";
            btnExportarCsv.UseVisualStyleBackColor = true;
            btnExportarCsv.Click += btnExportarCsv_Click;
            // 
            // btnExportarPdf
            // 
            btnExportarPdf.Location = new Point(457, 8);
            btnExportarPdf.Name = "btnExportarPdf";
            btnExportarPdf.Size = new Size(100, 23);
            btnExportarPdf.TabIndex = 28;
            btnExportarPdf.Text = "Exportar PDF";
            btnExportarPdf.UseVisualStyleBackColor = true;
            btnExportarPdf.Click += btnExportarPdf_Click;
            // 
            // FrmPrecos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnExportarPdf);
            Controls.Add(btnExportarCsv);
            Controls.Add(label4);
            Controls.Add(txtPrecoUnitario);
            Controls.Add(btnCancelarPreco);
            Controls.Add(btnSalvarPreco);
            Controls.Add(label3);
            Controls.Add(dtpDataDefinicao);
            Controls.Add(grpFormPreco);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblEpocaPrecoStatus);
            Controls.Add(dgvPrecos);
            Controls.Add(btnEliminar);
            Controls.Add(btnFiltrar);
            Controls.Add(btnDefinirPreco);
            Controls.Add(cmbProdutoPreco);
            Controls.Add(cmbEpocaPreco);
            Name = "FrmPrecos";
            Text = "Preços";
            Load += FrmPrecos_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPrecos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private Label label1;
        private Label lblEpocaPrecoStatus;
        private DataGridView dgvPrecos;
        private Button btnEliminar;
        private Button btnFiltrar;
        private Button btnDefinirPreco;
        private ComboBox cmbProdutoPreco;
        private ComboBox cmbEpocaPreco;
        private GroupBox grpFormPreco;
        private DateTimePicker dtpDataDefinicao;
        private Label label3;
        private Button btnSalvarPreco;
        private Button btnCancelarPreco;
        private TextBox txtPrecoUnitario;
        private Label label4;
        private Button btnExportarCsv;
        private Button btnExportarPdf;
    }
}