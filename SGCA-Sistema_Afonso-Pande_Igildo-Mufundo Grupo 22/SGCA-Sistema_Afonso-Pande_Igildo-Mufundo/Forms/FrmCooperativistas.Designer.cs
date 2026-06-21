namespace SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Vistas
{
    partial class FrmCooperativistas
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
            dgvCooperativistas = new DataGridView();
            btnEditar = new Button();
            btnNovo = new Button();
            btnAtualizar = new Button();
            btnDesactivar = new Button();
            txtPesquisar = new TextBox();
            lblSomaQuotas = new Label();
            btnExportarCsv = new Button();
            btnExportarPdf = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCooperativistas).BeginInit();
            SuspendLayout();
            // 
            // dgvCooperativistas
            // 
            dgvCooperativistas.AllowUserToAddRows = false;
            dgvCooperativistas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCooperativistas.Dock = DockStyle.Bottom;
            dgvCooperativistas.Location = new Point(0, 103);
            dgvCooperativistas.Name = "dgvCooperativistas";
            dgvCooperativistas.ReadOnly = true;
            dgvCooperativistas.Size = new Size(800, 347);
            dgvCooperativistas.TabIndex = 0;
            dgvCooperativistas.DoubleClick += dgvCooperativistas_DoubleClick;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(127, 74);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(75, 23);
            btnEditar.TabIndex = 1;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnNovo
            // 
            btnNovo.Location = new Point(12, 74);
            btnNovo.Name = "btnNovo";
            btnNovo.Size = new Size(75, 23);
            btnNovo.TabIndex = 2;
            btnNovo.Text = "Novo";
            btnNovo.UseVisualStyleBackColor = true;
            btnNovo.Click += btnNovo_Click;
            // 
            // btnAtualizar
            // 
            btnAtualizar.Location = new Point(236, 74);
            btnAtualizar.Name = "btnAtualizar";
            btnAtualizar.Size = new Size(75, 23);
            btnAtualizar.TabIndex = 3;
            btnAtualizar.Text = "Atualizar";
            btnAtualizar.UseVisualStyleBackColor = true;
            btnAtualizar.Click += btnAtualizar_Click;
            // 
            // btnDesactivar
            // 
            btnDesactivar.Location = new Point(330, 74);
            btnDesactivar.Name = "btnDesactivar";
            btnDesactivar.Size = new Size(75, 23);
            btnDesactivar.TabIndex = 4;
            btnDesactivar.Text = "Desactivar";
            btnDesactivar.UseVisualStyleBackColor = true;
            btnDesactivar.Click += btnDesactivar_Click;
            // 
            // txtPesquisar
            // 
            txtPesquisar.Location = new Point(458, 74);
            txtPesquisar.Name = "txtPesquisar";
            txtPesquisar.PlaceholderText = "Pesquisar...";
            txtPesquisar.Size = new Size(293, 23);
            txtPesquisar.TabIndex = 5;
            txtPesquisar.TextChanged += txtPesquisar_TextChanged;
            // 
            // lblSomaQuotas
            // 
            lblSomaQuotas.AutoSize = true;
            lblSomaQuotas.Location = new Point(12, 9);
            lblSomaQuotas.Name = "lblSomaQuotas";
            lblSomaQuotas.Size = new Size(114, 15);
            lblSomaQuotas.TabIndex = 6;
            lblSomaQuotas.Text = "Soma de quotas activas: 0%";
            // 
            // btnExportarCsv
            // 
            btnExportarCsv.Location = new Point(458, 45);
            btnExportarCsv.Name = "btnExportarCsv";
            btnExportarCsv.Size = new Size(100, 23);
            btnExportarCsv.TabIndex = 7;
            btnExportarCsv.Text = "Exportar CSV";
            btnExportarCsv.UseVisualStyleBackColor = true;
            btnExportarCsv.Click += btnExportarCsv_Click;
            // 
            // btnExportarPdf
            // 
            btnExportarPdf.Location = new Point(564, 45);
            btnExportarPdf.Name = "btnExportarPdf";
            btnExportarPdf.Size = new Size(100, 23);
            btnExportarPdf.TabIndex = 8;
            btnExportarPdf.Text = "Exportar PDF";
            btnExportarPdf.UseVisualStyleBackColor = true;
            btnExportarPdf.Click += btnExportarPdf_Click;
            // 
            // FrmCooperativistas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnExportarPdf);
            Controls.Add(btnExportarCsv);
            Controls.Add(lblSomaQuotas);
            Controls.Add(txtPesquisar);
            Controls.Add(btnDesactivar);
            Controls.Add(btnAtualizar);
            Controls.Add(btnNovo);
            Controls.Add(btnEditar);
            Controls.Add(dgvCooperativistas);
            Name = "FrmCooperativistas";
            Text = "Cooperativistas";
            Load += FrmCooperativistas_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCooperativistas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvCooperativistas;
        private Button btnEditar;
        private Button btnNovo;
        private Button btnAtualizar;
        private Button btnDesactivar;
        private TextBox txtPesquisar;
        private Label lblSomaQuotas;
        private Button btnExportarCsv;
        private Button btnExportarPdf;
    }
}