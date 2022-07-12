using LocadoraVeiculos.Dominio.ModuloVeiculo;
using System;
using FluentValidation.Results;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

namespace LocadoraVeiculos.WinApp.ModuloVeiculo
{
    public partial class TelaCadastroVeiculo : Form
    {
        public TelaCadastroVeiculo()
        {
            InitializeComponent();
        }

        private Bitmap bmp;
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

            MemoryStream memory = new MemoryStream();
            bmp.Save(memory, ImageFormat.Bmp);

            Veiculo.Modelo = textBoxModelo.Text;
            Veiculo.Placa = textBoxPlacas.Text;
            Veiculo.Marca = textBoxMarca.Text;
            Veiculo.Cor = textBoxCor.Text;
            Veiculo.TipoCombustivel = comboBoxTipoCombustivel.Text;
            Veiculo.CapacidadeTanque = Convert.ToDecimal(textBoxCapacidadeTanque.Text);
            Veiculo.Ano = Convert.ToDateTime(textBoxAno.Text);
            Veiculo.Quilometragem = Convert.ToDecimal(textBoxQuilometragem.Text);
            Veiculo.Foto = memory.ToArray();
            return true;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            AtualizarRodape("Inserção Cancelada.");
            this.DialogResult = DialogResult.Cancel;
        }

        private void buttonCarregarFoto_Click(object sender, EventArgs e)
        {
            if(openFileDialogFoto.ShowDialog() == DialogResult.OK)
            {
                string nome = openFileDialogFoto.FileName;

                bmp = new Bitmap(nome);

                pictureBoxFoto.Image = bmp;
            }
        }
    }
}