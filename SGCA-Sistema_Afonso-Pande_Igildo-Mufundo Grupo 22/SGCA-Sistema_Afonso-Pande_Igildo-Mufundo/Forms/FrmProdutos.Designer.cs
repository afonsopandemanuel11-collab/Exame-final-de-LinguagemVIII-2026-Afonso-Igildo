namespace SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Vistas
{
    partial class FrmProdutos
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
            dgvProdutos = new DataGridView();
            cmbCategoria = new ComboBox();
            btNovo = new Button();
            btnEditar = new Button();
            btnInactivar = new Button();
            btnActualizar = new Button();
            txtPesquisar = new TextBox();
            btnExportarCsv = new Button();
            btnExportarPdf = new Button();
            grpForm = new GroupBox();
            btnCancelarProd = new Button();
            btnSalvarProd = new Button();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            comboBox1 = new ComboBox();
            txtUnidade = new TextBox();
            txtCodigo = new TextBox();
            txtNomeProd = new TextBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvProdutos).BeginInit();
            grpForm.SuspendLayout();
            SuspendLayout();
            // 
            // dgvProdutos
            // 
            dgvProdutos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProdutos.Location = new Point(434, 28);
            dgvProdutos.Name = "dgvProdutos";
            dgvProdutos.Size = new Size(356, 340);
            dgvProdutos.TabIndex = 0;
            // 
            // cmbCategoria
            // 
            cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategoria.FormattingEnabled = true;
            cmbCategoria.Location = new Point(12, 28);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(121, 23);
            cmbCategoria.TabIndex = 1;
            // 
            // btNovo
            // 
            btNovo.Location = new Point(164, 27);
            btNovo.Name = "btNovo";
            btNovo.Size = new Size(75, 23);
            btNovo.TabIndex = 2;
            btNovo.Text = "Novo";
            btNovo.UseVisualStyleBackColor = true;
            btNovo.Click += btNovo_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(265, 28);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(75, 23);
            btnEditar.TabIndex = 3;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnInactivar
            // 
            btnInactivar.Location = new Point(164, 68);
            btnInactivar.Name = "btnInactivar";
            btnInactivar.Size = new Size(75, 23);
            btnInactivar.TabIndex = 4;
            btnInactivar.Text = "Inactivar";
            btnInactivar.UseVisualStyleBackColor = true;
            btnInactivar.Click += btnInactivar_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(353, 28);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(75, 23);
            btnActualizar.TabIndex = 5;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // txtPesquisar
            // 
            txtPesquisar.Location = new Point(164, 68);
            txtPesquisar.Name = "txtPesquisar";
            txtPesquisar.PlaceholderText = "Pesquisar produto...";
            txtPesquisar.Size = new Size(176, 23);
            txtPesquisar.TabIndex = 8;
            txtPesquisar.TextChanged += txtPesquisar_TextChanged;
            // 
            // btnExportarCsv
            // 
            btnExportarCsv.Location = new Point(12, 250);
            btnExportarCsv.Name = "btnExportarCsv";
            btnExportarCsv.Size = new Size(120, 28);
            btnExportarCsv.TabIndex = 9;
            btnExportarCsv.Text = "Exportar CSV";
            btnExportarCsv.UseVisualStyleBackColor = true;
            btnExportarCsv.Click += btnExportarCsv_Click;
            // 
            // btnExportarPdf
            // 
            btnExportarPdf.Location = new Point(138, 250);
            btnExportarPdf.Name = "btnExportarPdf";
            btnExportarPdf.Size = new Size(120, 28);
            btnExportarPdf.TabIndex = 10;
            btnExportarPdf.Text = "Exportar PDF";
            btnExportarPdf.UseVisualStyleBackColor = true;
            btnExportarPdf.Click += btnExportarPdf_Click;
            // 
            // grpForm
            // 
            grpForm.Controls.Add(btnCancelarProd);
            grpForm.Controls.Add(btnSalvarProd);
            grpForm.Controls.Add(label4);
            grpForm.Controls.Add(label3);
            grpForm.Controls.Add(label2);
            grpForm.Controls.Add(comboBox1);
            grpForm.Controls.Add(txtUnidade);
            grpForm.Controls.Add(txtCodigo);
            grpForm.Controls.Add(txtNomeProd);
            grpForm.Location = new Point(12, 97);
            grpForm.Name = "grpForm";
            grpForm.Size = new Size(401, 136);
            grpForm.TabIndex = 6;
            grpForm.TabStop = false;
            grpForm.Text = "Novo/Editar Produto";
            grpForm.Visible = false;
            // 
            // btnCancelarProd
            // 
            btnCancelarProd.Location = new Point(279, 94);
            btnCancelarProd.Name = "btnCancelarProd";
            btnCancelarProd.Size = new Size(75, 23);
            btnCancelarProd.TabIndex = 8;
            btnCancelarProd.Text = "Cancelar";
            btnCancelarProd.UseVisualStyleBackColor = true;
            btnCancelarProd.Click += btnCancelarProd_Click;
            // 
            // btnSalvarProd
            // 
            btnSalvarProd.Location = new Point(152, 94);
            btnSalvarProd.Name = "btnSalvarProd";
            btnSalvarProd.Size = new Size(75, 23);
            btnSalvarProd.TabIndex = 7;
            btnSalvarProd.Text = "Salvar";
            btnSalvarProd.UseVisualStyleBackColor = true;
            btnSalvarProd.Click += btnSalvarProd_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 77);
            label4.Name = "label4";
            label4.Size = new Size(46, 15);
            label4.TabIndex = 6;
            label4.Text = "Codigo";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(8, 15);
            label3.Name = "label3";
            label3.Size = new Size(83, 15);
            label3.TabIndex = 5;
            label3.Text = "NomeProduto";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(152, 17);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 4;
            label2.Text = "Unidade";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(280, 38);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 3;
            // 
            // txtUnidade
            // 
            txtUnidade.Location = new Point(152, 38);
            txtUnidade.Name = "txtUnidade";
            txtUnidade.Size = new Size(100, 23);
            txtUnidade.TabIndex = 2;
            // 
            // txtCodigo
            // 
            txtCodigo.Location = new Point(6, 95);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(100, 23);
            txtCodigo.TabIndex = 1;
            // 
            // txtNomeProd
            // 
            txtNomeProd.Location = new Point(6, 38);
            txtNomeProd.Name = "txtNomeProd";
            txtNomeProd.Size = new Size(100, 23);
            txtNomeProd.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 7);
            label1.Name = "label1";
            label1.Size = new Size(58, 15);
            label1.TabIndex = 7;
            label1.Text = "Categoria";
            // 
            // FrmProdutos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnExportarPdf);
            Controls.Add(btnExportarCsv);
            Controls.Add(txtPesquisar);
            Controls.Add(label1);
            Controls.Add(grpForm);
            Controls.Add(btnActualizar);
            Controls.Add(btnInactivar);
            Controls.Add(btnEditar);
            Controls.Add(btNovo);
            Controls.Add(cmbCategoria);
            Controls.Add(dgvProdutos);
            Name = "FrmProdutos";
            Text = "Produtos";
            Load += FrmProdutos_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProdutos).EndInit();
            grpForm.ResumeLayout(false);
            grpForm.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvProdutos;
        private ComboBox cmbCategoria;
        private Button btNovo;
        private Button btnEditar;
        private Button btnInactivar;
        private Button btnActualizar;
        private GroupBox grpForm;
        private ComboBox comboBox1;
        private TextBox txtUnidade;
        private TextBox txtCodigo;
        private TextBox txtNomeProd;
        private Label label1;
        private Label label3;
        private Label label2;
        private Label label4;
        private Button btnSalvarProd;
        private Button btnCancelarProd;
        private TextBox txtPesquisar;
        private Button btnExportarCsv;
        private Button btnExportarPdf;
    }
}