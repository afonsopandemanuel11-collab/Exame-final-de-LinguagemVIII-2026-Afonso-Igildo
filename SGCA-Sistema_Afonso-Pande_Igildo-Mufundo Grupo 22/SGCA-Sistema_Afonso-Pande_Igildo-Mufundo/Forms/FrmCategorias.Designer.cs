namespace SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Vistas
{
    partial class FrmCategorias
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
            dgvCategorias = new DataGridView();
            txtPesquisar = new TextBox();
            btnNova = new Button();
            btnEditar = new Button();
            btnEliminar = new Button();
            btnActualizar = new Button();
            lblTotal = new Label();
            btnExportarCsv = new Button();
            btnExportarPdf = new Button();
            grpFormCategoria = new GroupBox();
            lblNomeCategoria = new Label();
            txtNomeCategoria = new TextBox();
            lblDescricaoCategoria = new Label();
            txtDescricaoCategoria = new TextBox();
            btnSalvar = new Button();
            btnCancelar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCategorias).BeginInit();
            grpFormCategoria.SuspendLayout();
            SuspendLayout();
            //
            // dgvCategorias
            //
            dgvCategorias.AllowUserToAddRows = false;
            dgvCategorias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCategorias.Dock = DockStyle.Bottom;
            dgvCategorias.Location = new Point(0, 180);
            dgvCategorias.Name = "dgvCategorias";
            dgvCategorias.ReadOnly = true;
            dgvCategorias.Size = new Size(800, 270);
            dgvCategorias.TabIndex = 0;
            dgvCategorias.DoubleClick += dgvCategorias_DoubleClick;
            //
            // txtPesquisar
            //
            txtPesquisar.Location = new Point(12, 46);
            txtPesquisar.Name = "txtPesquisar";
            txtPesquisar.PlaceholderText = "Pesquisar por nome...";
            txtPesquisar.Size = new Size(300, 23);
            txtPesquisar.TabIndex = 1;
            txtPesquisar.TextChanged += txtPesquisar_TextChanged;
            //
            // btnNova
            //
            btnNova.Location = new Point(12, 80);
            btnNova.Name = "btnNova";
            btnNova.Size = new Size(110, 34);
            btnNova.TabIndex = 2;
            btnNova.Text = "Nova";
            btnNova.UseVisualStyleBackColor = true;
            btnNova.Click += btnNova_Click;
            //
            // btnEditar
            //
            btnEditar.Location = new Point(132, 80);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(110, 34);
            btnEditar.TabIndex = 3;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            //
            // btnEliminar
            //
            btnEliminar.Location = new Point(252, 80);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(110, 34);
            btnEliminar.TabIndex = 4;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            //
            // btnActualizar
            //
            btnActualizar.Location = new Point(372, 80);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(110, 34);
            btnActualizar.TabIndex = 5;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            //
            // lblTotal
            //
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(12, 12);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(100, 15);
            lblTotal.TabIndex = 6;
            lblTotal.Text = "Total: 0 categoria(s)";
            //
            // btnExportarCsv
            //
            btnExportarCsv.Location = new Point(590, 80);
            btnExportarCsv.Name = "btnExportarCsv";
            btnExportarCsv.Size = new Size(100, 34);
            btnExportarCsv.TabIndex = 7;
            btnExportarCsv.Text = "Exportar CSV";
            btnExportarCsv.UseVisualStyleBackColor = true;
            btnExportarCsv.Click += btnExportarCsv_Click;
            //
            // btnExportarPdf
            //
            btnExportarPdf.Location = new Point(696, 80);
            btnExportarPdf.Name = "btnExportarPdf";
            btnExportarPdf.Size = new Size(100, 34);
            btnExportarPdf.TabIndex = 8;
            btnExportarPdf.Text = "Exportar PDF";
            btnExportarPdf.UseVisualStyleBackColor = true;
            btnExportarPdf.Click += btnExportarPdf_Click;
            //
            // grpFormCategoria
            //
            grpFormCategoria.Controls.Add(lblNomeCategoria);
            grpFormCategoria.Controls.Add(txtNomeCategoria);
            grpFormCategoria.Controls.Add(lblDescricaoCategoria);
            grpFormCategoria.Controls.Add(txtDescricaoCategoria);
            grpFormCategoria.Controls.Add(btnSalvar);
            grpFormCategoria.Controls.Add(btnCancelar);
            grpFormCategoria.Location = new Point(420, 8);
            grpFormCategoria.Name = "grpFormCategoria";
            grpFormCategoria.Size = new Size(368, 160);
            grpFormCategoria.TabIndex = 9;
            grpFormCategoria.TabStop = false;
            grpFormCategoria.Text = "Nova Categoria";
            grpFormCategoria.Visible = false;
            //
            // lblNomeCategoria
            //
            lblNomeCategoria.AutoSize = true;
            lblNomeCategoria.Location = new Point(12, 24);
            lblNomeCategoria.Name = "lblNomeCategoria";
            lblNomeCategoria.Size = new Size(45, 15);
            lblNomeCategoria.TabIndex = 0;
            lblNomeCategoria.Text = "Nome *";
            //
            // txtNomeCategoria
            //
            txtNomeCategoria.Location = new Point(12, 42);
            txtNomeCategoria.Name = "txtNomeCategoria";
            txtNomeCategoria.Size = new Size(340, 23);
            txtNomeCategoria.TabIndex = 1;
            //
            // lblDescricaoCategoria
            //
            lblDescricaoCategoria.AutoSize = true;
            lblDescricaoCategoria.Location = new Point(12, 74);
            lblDescricaoCategoria.Name = "lblDescricaoCategoria";
            lblDescricaoCategoria.Size = new Size(60, 15);
            lblDescricaoCategoria.TabIndex = 2;
            lblDescricaoCategoria.Text = "Descrição";
            //
            // txtDescricaoCategoria
            //
            txtDescricaoCategoria.Location = new Point(12, 92);
            txtDescricaoCategoria.Name = "txtDescricaoCategoria";
            txtDescricaoCategoria.Size = new Size(340, 23);
            txtDescricaoCategoria.TabIndex = 3;
            //
            // btnSalvar
            //
            btnSalvar.Location = new Point(168, 126);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(90, 28);
            btnSalvar.TabIndex = 4;
            btnSalvar.Text = "Guardar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            //
            // btnCancelar
            //
            btnCancelar.Location = new Point(264, 126);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(90, 28);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            //
            // FrmCategorias
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(grpFormCategoria);
            Controls.Add(btnExportarPdf);
            Controls.Add(btnExportarCsv);
            Controls.Add(lblTotal);
            Controls.Add(btnActualizar);
            Controls.Add(btnEliminar);
            Controls.Add(btnEditar);
            Controls.Add(btnNova);
            Controls.Add(txtPesquisar);
            Controls.Add(dgvCategorias);
            Name = "FrmCategorias";
            Text = "Categorias de Produto";
            Load += FrmCategorias_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCategorias).EndInit();
            grpFormCategoria.ResumeLayout(false);
            grpFormCategoria.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvCategorias;
        private TextBox txtPesquisar;
        private Button btnNova;
        private Button btnEditar;
        private Button btnEliminar;
        private Button btnActualizar;
        private Label lblTotal;
        private Button btnExportarCsv;
        private Button btnExportarPdf;
        private GroupBox grpFormCategoria;
        private Label lblNomeCategoria;
        private TextBox txtNomeCategoria;
        private Label lblDescricaoCategoria;
        private TextBox txtDescricaoCategoria;
        private Button btnSalvar;
        private Button btnCancelar;
    }
}
