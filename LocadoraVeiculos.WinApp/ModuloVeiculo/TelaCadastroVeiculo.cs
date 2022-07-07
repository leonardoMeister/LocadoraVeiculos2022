using LocadoraVeiculos.Dominio.ModuloVeiculo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using FluentValidation.Results;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraVeiculos.WinApp.ModuloVeiculo
{
    public partial class TelaCadastroVeiculo : Form
    {
        public TelaCadastroVeiculo()
        {
            InitializeComponent();
        }

        public Action<string> AtualizarRodape { get; set; }

        public Veiculo Veiculo;

        public Func<Veiculo, ValidationResult> GravarRegistro { get; internal set; }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            if (!PegarObjetoTela()) return;

            var resultadoValidacao = GravarRegistro(Veiculo);

            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

                AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
            else
            {
                DialogResult = DialogResult.OK;
            }
        }

        private bool PegarObjetoTela()
        {
            if (
                textBoxModelo.Text == "" ||
                textBoxPlacas.Text == "" ||
                textBoxMarca.Text == "" ||
                textBoxCor.Text == "" ||
                comboBoxTipoCombustivel.Text == null ||
                textBoxCapacidadeTanque.Text == "" ||
                textBoxAno.Text == "" ||
                textBoxQuilometragem.Text == ""
                )
            {
                AtualizarRodape("Favor Preencher todos os campos.");
                return false;
            }

            Veiculo.Modelo = textBoxModelo.Text;
            Veiculo.Placa = textBoxPlacas.Text;
            Veiculo.Marca = textBoxMarca.Text;
            Veiculo.Cor = textBoxCor.Text;
            Veiculo.TipoCombustivel = comboBoxTipoCombustivel.Text;
            Veiculo.CapacidadeTanque = textBoxCapacidadeTanque.Text;
            Veiculo.Ano = textBoxAno.Text;
            Veiculo.Quilometragem = textBoxQuilometragem.Text;

            return true;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            AtualizarRodape("Inserção Cancelada.");
            this.DialogResult = DialogResult.Cancel;
        }
    }
}