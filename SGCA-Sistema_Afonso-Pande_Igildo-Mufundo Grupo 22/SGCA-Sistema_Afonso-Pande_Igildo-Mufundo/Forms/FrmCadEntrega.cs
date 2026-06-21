using SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.DALL;
using SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Exceptions;
using SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Models;
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
    public partial class FrmCadEntrega : Form
    {
        private readonly EntregaRepository _repo = new();
        private readonly CooperativistaRepository _coopRepo = new();
        private readonly ProdutoRepository _prodRepo = new();
        private readonly EpocaRepository _epocaRepo = new();
        private readonly Entrega? _entregaEdicao;

        public FrmCadEntrega()
        {
            InitializeComponent();
        }

        public FrmCadEntrega(Entrega entrega) : this()
        {
            _entregaEdicao = entrega;
        }

        private void FrmCadEntrega_Load(object sender, EventArgs e)
        {
            SGCA_Sistema_Afonso_Pande_Igildo_Mufundo.Utils.Estilo.Aplicar(this);
            
            // Cooperativistas
            var coops = _entregaEdicao != null ? _coopRepo.ObterTodos() : _coopRepo.ObterActivos();
            cmbCooperativista.DataSource = coops.ToList();
            cmbCooperativista.DisplayMember = "Nome";
            cmbCooperativista.ValueMember = "Id";

            // Produtos
            var prods = _entregaEdicao != null ? _prodRepo.ObterTodos() : _prodRepo.ObterActivos();
            cmbProduto.DataSource = prods.ToList();
            cmbProduto.DisplayMember = "Nome";
            cmbProduto.ValueMember = "Id";

            // Épocas
            var epocas = _entregaEdicao != null ? _epocaRepo.ObterTodos() : _epocaRepo.ObterAbertas();
            cmbEpoca.DataSource = epocas.ToList();
            cmbEpoca.DisplayMember = "Nome";
            cmbEpoca.ValueMember = "Id";

            if (_entregaEdicao != null)
            {
                cmbCooperativista.SelectedValue = _entregaEdicao.CooperativistaId;
                cmbProduto.SelectedValue = _entregaEdicao.ProdutoId;
                cmbEpoca.SelectedValue = _entregaEdicao.EpocaId;
                dtpDataEntrega.Value = _entregaEdicao.DataEntrega;
                txtQuantidade.Text = _entregaEdicao.Quantidade.ToString("F2");
                txtObservacoes.Text = _entregaEdicao.Observacoes;
                Text = "Editar Entrega";
                btnSalvar.Text = "Atualizar";
            }
            else
            {
                dtpDataEntrega.Value = DateTime.Today;
                Text = "Registar Entrega";
                btnSalvar.Text = "Salvar";
            }
        }

        private void cmbEpoca_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEpoca.SelectedItem is EpocaAgricola ep)
            {
                lblEpocaStatus.Text = ep.Encerrada ? "ENCERRADA ✖" : "ABERTA ✔";
                lblEpocaStatus.ForeColor = ep.Encerrada ? Color.Red : Color.DarkGreen;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Validador.DestacarCampo(txtQuantidade, false);

            if (!Validador.QuantidadeValida(txtQuantidade.Text, out decimal qtd))
            {
                Validador.DestacarCampo(txtQuantidade, true);
                MessageBox.Show("Quantidade inválida. Deve ser um número maior que zero.",
                    "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var epoca = cmbEpoca.SelectedItem as EpocaAgricola
                    ?? throw new Exception("Seleccione uma época agrícola.");

                // Apenas valida época encerrada para novas ou se alterou a época
                if (epoca.Encerrada && (_entregaEdicao == null || _entregaEdicao.EpocaId != epoca.Id))
                    throw new EpocaEncerradaException(
                        $"A época '{epoca.Nome}' está encerrada. Não é possível registar/alterar entregas nesta época.");

                if (qtd <= 0)
                    throw new QuantidadeInvalidaException(qtd);

                if (_entregaEdicao != null)
                {
                    _entregaEdicao.CooperativistaId = (int)cmbCooperativista.SelectedValue!;
                    _entregaEdicao.ProdutoId = (int)cmbProduto.SelectedValue!;
                    _entregaEdicao.EpocaId = epoca.Id;
                    _entregaEdicao.DataEntrega = dtpDataEntrega.Value.Date;
                    _entregaEdicao.Quantidade = qtd;
                    _entregaEdicao.Observacoes = string.IsNullOrWhiteSpace(txtObservacoes.Text)
                                       ? null : txtObservacoes.Text.Trim();

                    _repo.Actualizar(_entregaEdicao);
                    MessageBox.Show("Entrega actualizada com sucesso!",
                        "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    var entrega = new Entrega
                    {
                        CooperativistaId = (int)cmbCooperativista.SelectedValue!,
                        ProdutoId = (int)cmbProduto.SelectedValue!,
                        EpocaId = epoca.Id,
                        DataEntrega = dtpDataEntrega.Value.Date,
                        Quantidade = qtd,
                        Observacoes = string.IsNullOrWhiteSpace(txtObservacoes.Text)
                                           ? null : txtObservacoes.Text.Trim(),
                    };
                    _repo.Inserir(entrega);
                    MessageBox.Show("Entrega registada com sucesso!",
                        "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (EpocaEncerradaException ex)
            {
                MessageBox.Show(ex.Message, "Época Encerrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (QuantidadeInvalidaException ex)
            {
                Validador.DestacarCampo(txtQuantidade, true);
                MessageBox.Show(ex.Message, "Quantidade Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
