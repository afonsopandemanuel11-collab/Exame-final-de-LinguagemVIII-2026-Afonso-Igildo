namespace SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Vistas
{
    partial class FrmEntregas
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
            cmbFiltroCooperativista = new ComboBox();
            cmbFiltroEpoca = new ComboBox();
            btnNovaEntrega = new Button();
            btnEditarEntrega = new Button();
            btnFiltrar = new Button();
            btnEliminar = new Button();
            btnActualizar = new Button();
            dgvEntregas = new DataGridView();
            lblTotalEntregas = new Label();
            lblFiltroCooperativista = new Label();
            lblFiltroEpoca = new Label();
            txtPesquisar = new TextBox();
            btnExportarCsv = new Button();
            btnExportarPdf = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvEntregas).BeginInit();
            SuspendLayout();
            //
            // cmbFiltroCooperativista
            //
            cmbFiltroCooperativista.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFiltroCooperativista.FormattingEnabled = true;
            cmbFiltroCooperativista.Location = new Point(12, 25);
            cmbFiltroCooperativista.Name = "cmbFiltroCooperativista";
            cmbFiltroCooperativista.Size = new Size(296, 23);
            cmbFiltroCooperativista.TabIndex = 0;
            //
            // cmbFiltroEpoca
            //
            cmbFiltroEpoca.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFiltroEpoca.FormattingEnabled = true;
            cmbFiltroEpoca.Location = new Point(12, 78);
            cmbFiltroEpoca.Name = "cmbFiltroEpoca";
            cmbFiltroEpoca.Size = new Size(296, 23);
            cmbFiltroEpoca.TabIndex = 1;
            //
            // btnNovaEntrega
            //
            btnNovaEntrega.Location = new Point(12, 185);
            btnNovaEntrega.Name = "btnNovaEntrega";
            btnNovaEntrega.Size = new Size(110, 34);
            btnNovaEntrega.TabIndex = 2;
            btnNovaEntrega.Text = "Nova Entrega";
            btnNovaEntrega.UseVisualStyleBackColor = true;
            btnNovaEntrega.Click += btnNovaEntrega_Click;
            //
            // btnEditarEntrega
            //
            btnEditarEntrega.Location = new Point(132, 185);
            btnEditarEntrega.Name = "btnEditarEntrega";
            btnEditarEntrega.Size = new Size(110, 34);
            btnEditarEntrega.TabIndex = 3;
            btnEditarEntrega.Text = "Editar";
            btnEditarEntrega.UseVisualStyleBackColor = true;
            btnEditarEntrega.Click += btnEditarEntrega_Click;
            //
            // btnEliminar
            //
            btnEliminar.Location = new Point(12, 228);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(110, 34);
            btnEliminar.TabIndex = 4;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            //
            // btnFiltrar
            //
            btnFiltrar.Location = new Point(132, 228);
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(110, 34);
            btnFiltrar.TabIndex = 5;
            btnFiltrar.Text = "Filtrar";
            btnFiltrar.UseVisualStyleBackColor = true;
            btnFiltrar.Click += btnFiltrar_Click;
            //
            // btnActualizar
            //
            btnActualizar.Location = new Point(12, 271);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(110, 34);
            btnActualizar.TabIndex = 6;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            //
            // dgvEntregas
            //
            dgvEntregas.AllowUserToAddRows = false;
            dgvEntregas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEntregas.Location = new Point(326, 12);
            dgvEntregas.Name = "dgvEntregas";
            dgvEntregas.ReadOnly = true;
            dgvEntregas.Size = new Size(462, 406);
            dgvEntregas.TabIndex = 7;
            dgvEntregas.DoubleClick += dgvEntregas_DoubleClick;
            //
            // lblTotalEntregas
            //
            lblTotalEntregas.AutoSize = true;
            lblTotalEntregas.Location = new Point(12, 165);
            lblTotalEntregas.Name = "lblTotalEntregas";
            lblTotalEntregas.Size = new Size(92, 15);
            lblTotalEntregas.TabIndex = 8;
            lblTotalEntregas.Text = "Total: 0 entrega(s)";
            //
            // lblFiltroCooperativista
            //
            lblFiltroCooperativista.AutoSize = true;
            lblFiltroCooperativista.Location = new Point(12, 7);
            lblFiltroCooperativista.Name = "lblFiltroCooperativista";
            lblFiltroCooperativista.Size = new Size(113, 15);
            lblFiltroCooperativista.TabIndex = 9;
            lblFiltroCooperativista.Text = "Cooperativista:";
            //
            // lblFiltroEpoca
            //
            lblFiltroEpoca.AutoSize = true;
            lblFiltroEpoca.Location = new Point(12, 60);
            lblFiltroEpoca.Name = "lblFiltroEpoca";
            lblFiltroEpoca.Size = new Size(66, 15);
            lblFiltroEpoca.TabIndex = 10;
            lblFiltroEpoca.Text = "Época Agrícola:";
            //
            // txtPesquisar
            //
            txtPesquisar.Location = new Point(12, 128);
            txtPesquisar.Name = "txtPesquisar";
            txtPesquisar.PlaceholderText = "Pesquisar cooperativista ou produto...";
            txtPesquisar.Size = new Size(296, 23);
            txtPesquisar.TabIndex = 11;
            txtPesquisar.TextChanged += txtPesquisar_TextChanged;
            //
            // btnExportarCsv
            //
            btnExportarCsv.Location = new Point(12, 325);
            btnExportarCsv.Name = "btnExportarCsv";
            btnExportarCsv.Size = new Size(140, 34);
            btnExportarCsv.TabIndex = 12;
            btnExportarCsv.Text = "Exportar CSV";
            btnExportarCsv.UseVisualStyleBackColor = true;
            btnExportarCsv.Click += btnExportarCsv_Click;
            //
            // btnExportarPdf
            //
            btnExportarPdf.Location = new Point(166, 325);
            btnExportarPdf.Name = "btnExportarPdf";
            btnExportarPdf.Size = new Size(140, 34);
            btnExportarPdf.TabIndex = 13;
            btnExportarPdf.Text = "Exportar PDF";
            btnExportarPdf.UseVisualStyleBackColor = true;
            btnExportarPdf.Click += btnExportarPdf_Click;
            //
            // FrmEntregas
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 430);
            Controls.Add(btnExportarPdf);
            Controls.Add(btnExportarCsv);
            Controls.Add(txtPesquisar);
            Controls.Add(lblFiltroEpoca);
            Controls.Add(lblFiltroCooperativista);
            Controls.Add(lblTotalEntregas);
            Controls.Add(dgvEntregas);
            Controls.Add(btnActualizar);
            Controls.Add(btnFiltrar);
            Controls.Add(btnEliminar);
            Controls.Add(btnEditarEntrega);
            Controls.Add(btnNovaEntrega);
            Controls.Add(cmbFiltroEpoca);
            Controls.Add(cmbFiltroCooperativista);
            Name = "FrmEntregas";
            Text = "Entregas";
            Load += FrmEntregas_Load;
            ((System.ComponentModel.ISupportInitialize)dgvEntregas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbFiltroCooperativista;
        private ComboBox cmbFiltroEpoca;
        private Button btnNovaEntrega;
        private Button btnEditarEntrega;
        private Button btnFiltrar;
        private Button btnEliminar;
        private Button btnActualizar;
        private DataGridView dgvEntregas;
        private Label lblTotalEntregas;
        private Label lblFiltroCooperativista;
        private Label lblFiltroEpoca;
        private TextBox txtPesquisar;
        private Button btnExportarCsv;
        private Button btnExportarPdf;
    }
}