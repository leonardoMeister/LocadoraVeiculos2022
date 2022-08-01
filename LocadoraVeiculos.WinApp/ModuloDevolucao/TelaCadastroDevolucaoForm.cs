using FluentResults;
using LocadoraVeiculos.Dominio.ModuloLocacao;
using LocadoraVeiculos.Dominio.ModuloVeiculo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraVeiculos.WinApp.ModuloLocacao
{
    public partial class TelaCadastroDevolucaoForm : Form
    {
        public Locacao Locacao
        {
            get { return locacao; }
            set { 
                locacao = value;
                txtId.Text = locacao.Id.ToString();
                CarregarFotoVeiculo(locacao.Veiculo);
                CarregarTaxas();
                CarregarCamposTexto();
                AtualizarNivelTanque();
            }
        }

        private void AtualizarNivelTanque()
        {
            cmbNivelTanque.Items.Clear();

            foreach (NivelTanqueEnum tanque in Enum.GetValues(typeof(NivelTanqueEnum)))
            {
                cmbNivelTanque.Items.Add(tanque.ToString());
            }

        }
        private void CarregarCamposTexto()
        {
            laCliente.Text = locacao.Cliente.ToString();
            laCondutor.Text = locacao.Condutores.ToString();
            laGrupoVeiculo.Text = locacao.GrupoVeiculos.ToString();
            laVeiculo.Text = locacao.Veiculo.ToString();
            laPlano.Text = locacao.PlanoCobranca.ToString();

            laDataDevolucao.Text = locacao.DataEstimadaDevolucao.Date.ToString();
            laDataLocacao.Text = locacao.DataLocacao.Date.ToString();
            laValorTotal.Text = locacao.ValorLocacao.ToString();
        }

        private void CarregarTaxas()
        {
            throw new NotImplementedException();
        }

        private Bitmap bmp;
        private Locacao locacao;
        public Func<Locacao, Result<Locacao>> GravarRegistro { get; internal set; }
        public Action<string> AtualizarRodape { get; internal set; }

        public TelaCadastroDevolucaoForm()
        {
            InitializeComponent();
        }
        private void CarregarFotoVeiculo(Veiculo vei)
        {
            MemoryStream memory = new MemoryStream(vei.Foto);

            pictureBoxFoto.Image = Image.FromStream(memory);

            bmp = new Bitmap(pictureBoxFoto.Image);
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            PegarObjetoTela();


            var resultadoValidacao = GravarRegistro(locacao);

            if (resultadoValidacao.IsFailed)
            {
                string erro = resultadoValidacao.Errors[0].Message;

                if (erro.StartsWith("Falha no sistema"))
                {
                    MessageBox.Show(erro,
                    "Inserção Devolução", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    AtualizarRodape(erro);

                    DialogResult = DialogResult.None;
                }
            }
            else this.DialogResult = DialogResult.OK;
        }

        private void PegarObjetoTela()
        {
            throw new NotImplementedException();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            AtualizarRodape("Inserção Cancelada.");
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
