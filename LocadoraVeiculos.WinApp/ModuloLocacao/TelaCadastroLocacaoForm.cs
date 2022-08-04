using LocadoraVeiculos.Dominio.ModuloVeiculo;
using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using LocadoraVeiculos.Controladores.ModuloServicoGrupoVeiculos;
using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using FluentResults;
using LocadoraVeiculos.Dominio.ModuloLocacao;
using LocadoraVeiculos.Dominio.ModuloCondutores;
using LocadoraVeiculos.Dominio.ModuloCliente;
using LocadoraVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraVeiculos.Dominio.ModuloTaxas;
using System.Collections.Generic;
using LocadoraVeiculos.Controladores.ModuloServicoTaxas;
using LocadoraVeiculos.Controladores.ModuloServicoPlanoCobranca;
using LocadoraVeiculos.Controladores.ModuloServicoCondutores;
using LocadoraVeiculos.Controladores.ModuloServicoVeiculo;
using LocadoraVeiculos.Controladores.ModuloServicoCliente;

namespace LocadoraVeiculos.WinApp.ModuloLocacao
{
    public partial class TelaCadastroLocacaoForm : Form
    {
        public TelaCadastroLocacaoForm(ServicoVeiculo servicoVeiculo, ServicoCondutores servicoCondutores, ServicoGrupoVeiculos servicoGrupoVeh,
                                       ServicoPlanoCobranca servicoPlanoCobranca, ServicoTaxas servicoTaxas, ServicoCliente servicoCliente)
        {
            InitializeComponent();
            ServicoTaxas = servicoTaxas;
            ServicoCliente = servicoCliente;
            ServicoVeiculo = servicoVeiculo;
            ServicoCondutores = servicoCondutores;
            ServicoGrupoVeh = servicoGrupoVeh;
            ServicoPlanoCobranca = servicoPlanoCobranca;

            AtualizarCondutores();
            AtualizarCliente();
            AtualizarGrupoVeh();
            AtualizarTaxas();
            AtualizarNivelTanque();
        }

        private void AtualizarNivelTanque()
        {
            cmbNivelTanque.Items.Clear();

            foreach (NivelTanqueEnum tanque in Enum.GetValues(typeof(NivelTanqueEnum)))
            {
                cmbNivelTanque.Items.Add(tanque.ToString());
            }

        }

        private void SelecionarUmGrupoDeVeiculosNaTela(object sender, EventArgs e)
        {

            if (cmbGrupoVeiculo.SelectedItem == null) return;

            GrupoVeiculos grupoVeiculo = (GrupoVeiculos)cmbGrupoVeiculo.SelectedItem;


            AtualizarVeiculo(grupoVeiculo);

            AtualizarPlanoCobranca(grupoVeiculo);
        }
        private void AtualizarVeiculo(GrupoVeiculos grupoVeiculo)
        {
            var dados = ServicoVeiculo.SelecionarVeiculosPorGrupoVeiculos(grupoVeiculo).Value;
            foreach (var dado in dados)
            {
                cmbVeiculo.Items.Add(dado);
            }
        }
        private void AtualizarCondutores()
        {
            var dados = ServicoCondutores.SelecionarTodos().Value;
            foreach (var dado in dados)
            {
                cmbCondutor.Items.Add(dado);
            }
        }
        private void AtualizarCliente()
        {
            var dados = ServicoCliente.SelecionarTodos().Value;
            foreach (var dado in dados)
            {
                cmbCliente.Items.Add(dado);
            }
        }
        private void AtualizarGrupoVeh()
        {
            var dados = ServicoGrupoVeh.SelecionarTodos().Value;
            foreach (var dado in dados)
            {
                cmbGrupoVeiculo.Items.Add(dado);
            }
        }
        private void AtualizarPlanoCobranca(GrupoVeiculos grupoVeiculo)
        {
            var dados = ServicoPlanoCobranca.SelecionarPlanoCobrancaPorGrupoVeiculo(grupoVeiculo).Value;
            foreach (var dado in dados)
            {
                cmbPlanoCobranca.Items.Add(dado);
            }
        }
        private void AtualizarTaxas()
        {
            var dados = ServicoTaxas.SelecionarTodos().Value;
            foreach (var dado in dados)
            {
                listaTaxas.Items.Add(dado);
            }
        }



        private Bitmap bmp;
        public Action<string> AtualizarRodape { get; set; }

        public Locacao locacao;
        public Locacao Locacao
        {
            get { return locacao; }
            set
            {
                locacao = value;
                txtId.Text = locacao.Id.ToString();
                cmbCondutor.SelectedItem = locacao.Condutores;
                cmbCliente.SelectedItem = locacao.Cliente;
                cmbGrupoVeiculo.SelectedItem = locacao.GrupoVeiculos;
                cmbVeiculo.SelectedItem = locacao.Veiculo;
                dataDevolucao.Value = locacao.DataEstimadaDevolucao;
                cmbPlanoCobranca.SelectedItem = locacao.PlanoCobranca;

                CarregarFotoVeiculo(locacao.Veiculo);
                CarregarTaxasSelecionadas();
                AtualizarValorEstimadoLocacao();
            }
        }

        private void AtualizarValorEstimadoLocacao()
        {
            throw new NotImplementedException();
        }

        private NivelTanqueEnum PegarNivelTanque()
        {
            if (cmbNivelTanque.SelectedIndex == -1) return NivelTanqueEnum.naoInformado;

            var nivel = cmbNivelTanque.SelectedItem.ToString();

            NivelTanqueEnum nivelFinal = (NivelTanqueEnum)Enum.Parse(typeof(NivelTanqueEnum), nivel);

            return nivelFinal;
        }

        private void CarregarTaxasSelecionadas()
        {
            listaTaxas.Items.Clear();

            foreach (Taxas tax in ServicoTaxas.SelecionarTodos().Value)
            {
                bool marcar = locacao.ListaTaxas.Contains(tax);

                if (marcar) listaTaxas.Items.Add(tax, CheckState.Checked);
                else listaTaxas.Items.Add(tax, CheckState.Unchecked);
            }

        }

        private void CarregarFotoVeiculo(Veiculo vei)
        {
            MemoryStream memory = new MemoryStream(vei.Foto);

            pictureBoxFoto.Image = Image.FromStream(memory);

            bmp = new Bitmap(pictureBoxFoto.Image);
        }

        public Func<Locacao, Result<Locacao>> GravarRegistro { get; internal set; }
        public ServicoVeiculo ServicoVeiculo { get; }
        public ServicoCondutores ServicoCondutores { get; }
        public ServicoCliente ServicoCliente { get; }
        public ServicoGrupoVeiculos ServicoGrupoVeh { get; }
        public ServicoPlanoCobranca ServicoPlanoCobranca { get; }
        public ServicoTaxas ServicoTaxas { get; }

        private void PegarObjetoTela()
        {
            locacao.NivelTanqueEnumInicio= PegarNivelTanque();
            locacao.DataEstimadaDevolucao = this.dataDevolucao.Value;
            locacao.QuilometragemInicial = (txtKmInicial.Text == "") ? 0 : Convert.ToDecimal(txtKmInicial.Text);

            locacao.Veiculo = null;
            if (cmbVeiculo.SelectedIndex != -1) locacao.Veiculo = (Veiculo)cmbVeiculo.SelectedItem;
            locacao.Condutores = null;
            if (cmbCondutor.SelectedIndex != -1) locacao.Condutores = (Condutores)cmbCondutor.SelectedItem;
            locacao.Cliente = null;
            if (cmbCliente.SelectedIndex != -1) locacao.Cliente = (Cliente)cmbCliente.SelectedItem;
            locacao.GrupoVeiculos = null;
            if (cmbGrupoVeiculo.SelectedIndex != -1) locacao.GrupoVeiculos = (GrupoVeiculos)cmbGrupoVeiculo.SelectedItem;
            locacao.PlanoCobranca = null;
            if (cmbPlanoCobranca.SelectedIndex != -1) locacao.PlanoCobranca = (PlanoCobranca)cmbPlanoCobranca.SelectedItem;
            List<Taxas> taxas = new List<Taxas>();
            foreach (Taxas tax in listaTaxas.CheckedItems) taxas.Add(tax);
            locacao.ListaTaxas = taxas;
            locacao.DataLocacao = DateTime.Now;

            locacao.DataRealDaDevolucao = DateTime.MinValue;
            locacao.NivelTanqueEnumDevolucao = NivelTanqueEnum.naoInformado;
            locacao.StatusDevolucao = false;
            locacao.QuilometragemFinal = 0;
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
                    "Inserção Locação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    AtualizarRodape(erro);

                    DialogResult = DialogResult.None;
                }
            }
            else this.DialogResult = DialogResult.OK;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            AtualizarRodape("Inserção Cancelada.");
            this.DialogResult = DialogResult.Cancel;
        }
        private void cmbVeiculo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbVeiculo.SelectedItem == null) return;

            Veiculo vei = (Veiculo)cmbVeiculo.SelectedItem;

            CarregarFotoVeiculo(vei);
        }

        private void SimularValorLocacaoClick(object sender, EventArgs e)
        {
            PegarObjetoTela();
            try
            {
                var valor = locacao.GerarValorLocacao();
                labelValor.Text = valor.ToString();
            }catch (Exception ex)
            {
                AtualizarRodape("Para gerar uma simulacao de valor favor alimentar todos os campos antes");
            }
        }
    }
}
