using FluentResults;
using LocadoraVeiculos.Controladores.ModuloServicoTaxas;
using LocadoraVeiculos.Dominio.ModuloLocacao;
using LocadoraVeiculos.Dominio.ModuloTaxas;
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
            set
            {
                locacao = value;
                txtId.Text = locacao.Id.ToString();
                CarregarFotoVeiculo(locacao.Veiculo);
                CarregarTaxas();
                CarregarCamposTexto();
                AtualizarNivelTanque();
                cmbNivelTanque.SelectedIndex = 0;
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
            labelKmInicial.Text = locacao.QuilometragemInicial.ToString();
        }
        private NivelTanqueEnum PegarNivelTanque()
        {
            if (cmbNivelTanque.SelectedIndex == -1) return NivelTanqueEnum.naoInformado;

            var nivel = cmbNivelTanque.SelectedItem.ToString();

            NivelTanqueEnum nivelFinal = (NivelTanqueEnum)Enum.Parse(typeof(NivelTanqueEnum), nivel);

            return nivelFinal;
        }
        private void CarregarTaxas()
        {
            foreach (Taxas tax in servicoTaxas.SelecionarTodos().Value)
            {
                bool deveAdd = locacao.ListaTaxas.Contains(tax);

                if (deveAdd) listaTaxas.Items.Add(tax, CheckState.Checked);
                else listaTaxas.Items.Add(tax, CheckState.Unchecked);
            }
        }

        private Bitmap bmp;
        private Locacao locacao;
        public Func<Locacao, Result<Locacao>> GravarRegistro { get; internal set; }
        public Action<string> AtualizarRodape { get; internal set; }

        ServicoTaxas servicoTaxas;
        ValidadorLocacao validador;
        public TelaCadastroDevolucaoForm(ServicoTaxas servicoTaxas, ValidadorLocacao validador)
        {
            InitializeComponent();
            this.validador = validador;
            this.servicoTaxas = servicoTaxas;
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
            List<Taxas> taxas = new List<Taxas>();

            foreach (Taxas tax in listaTaxas.CheckedItems)
            {
                taxas.Add(tax);
            }

            locacao.ListaTaxas = taxas;

            locacao.QuilometragemFinal = (txtQuilometragemFinal.Text != "") ? Convert.ToDecimal(txtQuilometragemFinal.Text) : 0;

            locacao.DataRealDaDevolucao = dataRealDevolucao.Value.Date;

            locacao.NivelTanqueEnumDevolucao = PegarNivelTanque();


            locacao.StatusDevolucao = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            AtualizarRodape("Inserção Cancelada.");
            this.DialogResult = DialogResult.Cancel;
        }

        private void SimularValor_Click(object sender, EventArgs e)
        {

            PegarObjetoTela();
            var validacao = validador.Validate(locacao);
            if (validacao.IsValid)
            {
                try
                {
                    var valor = locacao.GerarValorLocacao();
                    laValorTotal.Text = valor.ToString();
                }
                catch (Exception ex)
                {
                    AtualizarRodape("Para gerar uma simulacao de valor favor alimentar todos os campos antes");
                }
            }
            else
            {
                AtualizarRodape(validacao.Errors[0].ToString());
            }
        }
    }
}
