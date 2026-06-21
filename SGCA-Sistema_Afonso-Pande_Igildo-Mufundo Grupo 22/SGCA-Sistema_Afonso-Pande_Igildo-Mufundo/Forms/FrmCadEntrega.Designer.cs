namespace SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Vistas
{
    partial class FrmCadEntrega
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
            lblEpocaStatus = new Label();
            dgvEntregas = new DataGridView();
            btnCancelar = new Button();
            btnSalvar = new Button();
            cmbProduto = new ComboBox();
            cmbCooperativista = new ComboBox();
            label3 = new Label();
            cmbEpoca = new ComboBox();
            dtpDataEntrega = new DateTimePicker();
            txtQuantidade = new TextBox();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            txtObservacoes = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvEntregas).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 73);
            label2.Name = "label2";
            label2.Size = new Size(50, 15);
            label2.TabIndex = 19;
            label2.Text = "Produto";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 20);
            label1.Name = "label1";
            label1.Size = new Size(83, 15);
            label1.TabIndex = 18;
            label1.Text = "Cooperativista";
            // 
            // lblEpocaStatus
            // 
            lblEpocaStatus.AutoSize = true;
            lblEpocaStatus.Location = new Point(17, 360);
            lblEpocaStatus.Name = "lblEpocaStatus";
            lblEpocaStatus.Size = new Size(92, 15);
            lblEpocaStatus.TabIndex = 17;
            lblEpocaStatus.Text = "Total: 0 entregas";
            // 
            // dgvEntregas
            // 
            dgvEntregas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEntregas.Location = new Point(351, 38);
            dgvEntregas.Name = "dgvEntregas";
            dgvEntregas.Size = new Size(442, 392);
            dgvEntregas.TabIndex = 16;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(117, 307);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 15;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(17, 307);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(75, 23);
            btnSalvar.TabIndex = 12;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // cmbProduto
            // 
            cmbProduto.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProduto.FormattingEnabled = true;
            cmbProduto.Location = new Point(17, 91);
            cmbProduto.Name = "cmbProduto";
            cmbProduto.Size = new Size(296, 23);
            cmbProduto.TabIndex = 11;
            // 
            // cmbCooperativista
            // 
            cmbCooperativista.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCooperativista.FormattingEnabled = true;
            cmbCooperativista.Location = new Point(17, 38);
            cmbCooperativista.Name = "cmbCooperativista";
            cmbCooperativista.Size = new Size(296, 23);
            cmbCooperativista.TabIndex = 10;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 129);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 21;
            label3.Text = "Epoca";
            // 
            // cmbEpoca
            // 
            cmbEpoca.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEpoca.FormattingEnabled = true;
            cmbEpoca.Location = new Point(15, 147);
            cmbEpoca.Name = "cmbEpoca";
            cmbEpoca.Size = new Size(296, 23);
            cmbEpoca.TabIndex = 20;
            cmbEpoca.SelectedIndexChanged += cmbEpoca_SelectedIndexChanged;
            // 
            // dtpDataEntrega
            // 
            dtpDataEntrega.Location = new Point(12, 194);
            dtpDataEntrega.Name = "dtpDataEntrega";
            dtpDataEntrega.Size = new Size(133, 23);
            dtpDataEntrega.TabIndex = 22;
            // 
            // txtQuantidade
            // 
            txtQuantidade.Location = new Point(209, 194);
            txtQuantidade.Name = "txtQuantidade";
            txtQuantidade.Size = new Size(100, 23);
            txtQuantidade.TabIndex = 23;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(15, 176);
            label4.Name = "label4";
            label4.Size = new Size(69, 15);
            label4.TabIndex = 24;
            label4.Text = "Quantidade";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(209, 174);
            label5.Name = "label5";
            label5.Size = new Size(69, 15);
            label5.TabIndex = 25;
            label5.Text = "Quantidade";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 227);
            label6.Name = "label6";
            label6.Size = new Size(74, 15);
            label6.TabIndex = 27;
            label6.Text = "Observacoes";
            // 
            // txtObservacoes
            // 
            txtObservacoes.Location = new Point(12, 247);
            txtObservacoes.Multiline = true;
            txtObservacoes.Name = "txtObservacoes";
            txtObservacoes.Size = new Size(299, 54);
            txtObservacoes.TabIndex = 26;
            // 
            // FrmCadEntrega
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label6);
            Controls.Add(txtObservacoes);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(txtQuantidade);
            Controls.Add(dtpDataEntrega);
            Controls.Add(label3);
            Controls.Add(cmbEpoca);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblEpocaStatus);
            Controls.Add(dgvEntregas);
            Controls.Add(btnCancelar);
            Controls.Add(btnSalvar);
            Controls.Add(cmbProduto);
            Controls.Add(cmbCooperativista);
            Name = "FrmCadEntrega";
            Text = "FrmCadEntrega";
            Load += FrmCadEntrega_Load;
            ((System.ComponentModel.ISupportInitialize)dgvEntregas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private Label label1;
        private Label lblEpocaStatus;
        private DataGridView dgvEntregas;
        private Button btnCancelar;
        private Button btnSalvar;
        private ComboBox cmbProduto;
        private ComboBox cmbCooperativista;
        private Label label3;
        private ComboBox cmbEpoca;
        private DateTimePicker dtpDataEntrega;
        private TextBox txtQuantidade;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox txtObservacoes;
    }
}