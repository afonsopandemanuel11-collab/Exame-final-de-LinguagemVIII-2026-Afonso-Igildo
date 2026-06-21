using SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.DALL;
using SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Exceptions;
using SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Models;
using SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Services;
using SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Vistas
{
    public partial class FrmCadCooperativista : Form
    {
        private readonly CooperativistaRepository _repo = new();
        private readonly GestorCooperativa _gestor = new();
        private Cooperativista? _cooperativistaEditar;

        public FrmCadCooperativista()
        {
            InitializeComponent();
            this.Text = "Novo Cooperativista";
        }
        public FrmCadCooperativista(Cooperativista coop)
        {
            InitializeComponent();
            _cooperativistaEditar = coop;
            this.Text = $"Editar – {coop.Nome}";
        }
        private void FrmCadCooperativista_Load(object sender, EventArgs e)
        {
            SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Utils.Estilo.Aplicar(this);
            // Mostrar quota ainda disponível
            int excluirId = _cooperativistaEditar?.Id ?? 0;
            decimal somaActual = _repo.SomaQuotasActivas(excluirId);
            decimal disponivel = 100m - somaActual;
            lblQuotaDisponivel.Text = $"Quota disponível: {Formatador.Percentagem(disponivel)}";

            // Preencher campos no modo edição
            if (_cooperativistaEditar != null)
            {
                txtNome.Text = _cooperativistaEditar.Nome;
                txtNumeroSocio.Text = _cooperativistaEditar.NumeroSocio;
                txtBilheteId.Text = _cooperativistaEditar.BilheteId;
                txtTelefone.Text = _cooperativistaEditar.Telefone ?? "";
                txtEmail.Text = _cooperativistaEditar.Email ?? "";
                txtQuota.Text = _cooperativistaEditar.QuotaPercent.ToString("N2");
                dtpDataAdesao.Value = _cooperativistaEditar.DataAdesao;
                chkActivo.Checked = _cooperativistaEditar.Activo;
            }
            else
            {
                dtpDataAdesao.Value = DateTime.Today;
                chkActivo.Checked = true;
            }

        }
        // ── Actualizar quota disponível em tempo real ─────────────────────────
        private void txtQuota_TextChanged(object sender, EventArgs e)
        {
            int excluirId = _cooperativistaEditar?.Id ?? 0;
            decimal somaActual = _repo.SomaQuotasActivas(excluirId);
            if (decimal.TryParse(txtQuota.Text.Replace(',', '.'),
                System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture, out decimal q))
            {
                decimal resto = 100m - somaActual - q;
                lblQuotaDisponivel.Text = $"Restará disponível: {Formatador.Percentagem(resto)}";
                lblQuotaDisponivel.ForeColor = resto < 0 ? Color.Red : Color.DarkGreen;
            }
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Validador.DestacarCampo(txtNome, false);
            Validador.DestacarCampo(txtNumeroSocio, false);
            Validador.DestacarCampo(txtBilheteId, false);
            Validador.DestacarCampo(txtQuota, false);

            // Validar campos obrigatórios
            bool valido = true;
            if (!Validador.CampoObrigatorio(txtNome.Text))
            { Validador.DestacarCampo(txtNome, true); valido = false; }
            if (!Validador.CampoObrigatorio(txtNumeroSocio.Text))
            { Validador.DestacarCampo(txtNumeroSocio, true); valido = false; }
            if (!Validador.CampoObrigatorio(txtBilheteId.Text))
            { Validador.DestacarCampo(txtBilheteId, true); valido = false; }
            if (!Validador.QuotaValida(txtQuota.Text, out decimal quota))
            { Validador.DestacarCampo(txtQuota, true); valido = false; }

            if (!valido)
            {
                MessageBox.Show("Preencha todos os campos obrigatórios correctamente.",
                    "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int excluirId = _cooperativistaEditar?.Id ?? 0;

                // Verificar número de sócio duplicado
                if (_repo.NumeroSocioExiste(txtNumeroSocio.Text.Trim(), excluirId))
                    throw new Exception($"O número de sócio '{txtNumeroSocio.Text.Trim()}' já está em uso.");

                // Validar quota
                _gestor.ValidarQuota(quota, excluirId);

                if (_cooperativistaEditar == null)
                {
                    // Inserir novo
                    var novo = new Cooperativista
                    {
                        Nome = txtNome.Text.Trim(),
                        NumeroSocio = txtNumeroSocio.Text.Trim(),
                        BilheteId = txtBilheteId.Text.Trim(),
                        Telefone = string.IsNullOrWhiteSpace(txtTelefone.Text) ? null : txtTelefone.Text.Trim(),
                        Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim(),
                        QuotaPercent = quota,
                        DataAdesao = dtpDataAdesao.Value.Date,
                        Activo = true,
                    };
                    _repo.Inserir(novo);
                    MessageBox.Show("Cooperativista registado com sucesso!",
                        "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Actualizar existente
                    _cooperativistaEditar.Nome = txtNome.Text.Trim();
                    _cooperativistaEditar.NumeroSocio = txtNumeroSocio.Text.Trim();
                    _cooperativistaEditar.BilheteId = txtBilheteId.Text.Trim();
                    _cooperativistaEditar.Telefone = string.IsNullOrWhiteSpace(txtTelefone.Text) ? null : txtTelefone.Text.Trim();
                    _cooperativistaEditar.Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim();
                    _cooperativistaEditar.QuotaPercent = quota;
                    _cooperativistaEditar.DataAdesao = dtpDataAdesao.Value.Date;
                    _cooperativistaEditar.Activo = chkActivo.Checked;
                    _repo.Actualizar(_cooperativistaEditar);
                    MessageBox.Show("Cooperativista actualizado com sucesso!",
                        "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (QuotaInvalidaException ex)
            {
                Validador.DestacarCampo(txtQuota, true);
                MessageBox.Show(ex.Message, "Quota Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}

