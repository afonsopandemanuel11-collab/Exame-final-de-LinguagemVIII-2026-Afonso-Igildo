namespace SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Vistas
{
    partial class FrmCadCooperativista
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
            txtNome = new TextBox();
            txtNumeroSocio = new TextBox();
            txtBilheteId = new TextBox();
            txtTelefone = new TextBox();
            txtEmail = new TextBox();
            txtQuota = new TextBox();
            dtpDataAdesao = new DateTimePicker();
            chkActivo = new CheckBox();
            lblQuotaDisponivel = new Label();
            btnSalvar = new Button();
            btnCancelar = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            SuspendLayout();
            // 
            // txtNome
            // 
            txtNome.Location = new Point(12, 45);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(116, 23);
            txtNome.TabIndex = 0;
            // 
            // txtNumeroSocio
            // 
            txtNumeroSocio.Location = new Point(12, 101);
            txtNumeroSocio.Name = "txtNumeroSocio";
            txtNumeroSocio.Size = new Size(116, 23);
            txtNumeroSocio.TabIndex = 1;
            // 
            // txtBilheteId
            // 
            txtBilheteId.Location = new Point(15, 153);
            txtBilheteId.Name = "txtBilheteId";
            txtBilheteId.Size = new Size(116, 23);
            txtBilheteId.TabIndex = 2;
            // 
            // txtTelefone
            // 
            txtTelefone.Location = new Point(14, 212);
            txtTelefone.Name = "txtTelefone";
            txtTelefone.Size = new Size(116, 23);
            txtTelefone.TabIndex = 3;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(162, 45);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(116, 23);
            txtEmail.TabIndex = 4;
            // 
            // txtQuota
            // 
            txtQuota.Location = new Point(162, 95);
            txtQuota.Name = "txtQuota";
            txtQuota.Size = new Size(116, 23);
            txtQuota.TabIndex = 5;
            txtQuota.TextChanged += txtQuota_TextChanged;
            // 
            // dtpDataAdesao
            // 
            dtpDataAdesao.Format = DateTimePickerFormat.Short;
            dtpDataAdesao.Location = new Point(159, 144);
            dtpDataAdesao.Name = "dtpDataAdesao";
            dtpDataAdesao.Size = new Size(200, 23);
            dtpDataAdesao.TabIndex = 6;
            // 
            // chkActivo
            // 
            chkActivo.AutoSize = true;
            chkActivo.Checked = true;
            chkActivo.CheckState = CheckState.Checked;
            chkActivo.Location = new Point(301, 48);
            chkActivo.Name = "chkActivo";
            chkActivo.Size = new Size(60, 19);
            chkActivo.TabIndex = 7;
            chkActivo.Text = "Activo";
            chkActivo.UseVisualStyleBackColor = true;
            // 
            // lblQuotaDisponivel
            // 
            lblQuotaDisponivel.AutoSize = true;
            lblQuotaDisponivel.Location = new Point(162, 183);
            lblQuotaDisponivel.Name = "lblQuotaDisponivel";
            lblQuotaDisponivel.Size = new Size(131, 15);
            lblQuotaDisponivel.TabIndex = 8;
            lblQuotaDisponivel.Text = "Quota disponível: 100%";
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(155, 249);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(99, 23);
            btnSalvar.TabIndex = 9;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(284, 249);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 10;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 27);
            label1.Name = "label1";
            label1.Size = new Size(40, 15);
            label1.TabIndex = 11;
            label1.Text = "Nome";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(11, 83);
            label2.Name = "label2";
            label2.Size = new Size(80, 15);
            label2.TabIndex = 12;
            label2.Text = "NumeroSocio";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 137);
            label3.Name = "label3";
            label3.Size = new Size(53, 15);
            label3.TabIndex = 13;
            label3.Text = "BilheteId";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(11, 197);
            label4.Name = "label4";
            label4.Size = new Size(51, 15);
            label4.TabIndex = 14;
            label4.Text = "Telefone";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(169, 23);
            label5.Name = "label5";
            label5.Size = new Size(36, 15);
            label5.TabIndex = 15;
            label5.Text = "Email";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(162, 80);
            label6.Name = "label6";
            label6.Size = new Size(40, 15);
            label6.TabIndex = 16;
            label6.Text = "Qouta";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(158, 124);
            label7.Name = "label7";
            label7.Size = new Size(70, 15);
            label7.TabIndex = 17;
            label7.Text = "DataAdesao";
            // 
            // FrmCadCooperativista
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnCancelar);
            Controls.Add(btnSalvar);
            Controls.Add(lblQuotaDisponivel);
            Controls.Add(chkActivo);
            Controls.Add(dtpDataAdesao);
            Controls.Add(txtQuota);
            Controls.Add(txtEmail);
            Controls.Add(txtTelefone);
            Controls.Add(txtBilheteId);
            Controls.Add(txtNumeroSocio);
            Controls.Add(txtNome);
            Name = "FrmCadCooperativista";
            Text = "FrmCadCooperativista";
            Load += FrmCadCooperativista_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNome;
        private TextBox txtNumeroSocio;
        private TextBox txtBilheteId;
        private TextBox txtTelefone;
        private TextBox txtEmail;
        private TextBox txtQuota;
        private DateTimePicker dtpDataAdesao;
        private CheckBox chkActivo;
        private Label lblQuotaDisponivel;
        private Button btnSalvar;
        private Button btnCancelar;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
    }
}