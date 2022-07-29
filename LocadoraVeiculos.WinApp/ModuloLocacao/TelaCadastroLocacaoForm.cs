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
            throw new NotImplementedException();
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

        Locacao locacao;
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
                CarregarFotoVeiculo(locacao.Veiculo);
                cmbPlanoCobranca.SelectedItem = locacao.PlanoCobranca;
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
            throw new NotImplementedException();
        }

        private void CarregarTaxasSelecionadas()
        {
            throw new NotImplementedException();
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

            NivelTanqueEnum NivelTanqueEnumInicio = PegarNivelTanque();
            DateTime dataEstimadaDevolucao = this.dataDevolucao.Value;

            decimal quilometragemInicial = (txtKmInicial.Text == "")? 0: Convert.ToDecimal(txtKmInicial.Text);


            Veiculo veh = null;
            if (cmbVeiculo.SelectedIndex != -1) veh = (Veiculo)cmbVeiculo.SelectedItem;
            Condutores cond = null;
            if (cmbCondutor.SelectedIndex != -1) cond = (Condutores)cmbCondutor.SelectedItem;
            Cliente cli = null;
            if (cmbCliente.SelectedIndex != -1) cli = (Cliente)cmbCliente.SelectedItem;
            GrupoVeiculos grupo = null;
            if (cmbGrupoVeiculo.SelectedIndex != -1) grupo = (GrupoVeiculos)cmbGrupoVeiculo.SelectedItem;
            PlanoCobranca pcobranca = null;
            if (cmbPlanoCobranca.SelectedIndex != -1) pcobranca = (PlanoCobranca)cmbPlanoCobranca.SelectedItem;
            
            List<Taxas> taxas = new List<Taxas>();
            
            foreach(Taxas tax in listaTaxas.Items)
            {
                taxas.Add(tax);
            }

            locacao = new Locacao(veh, cond, cli, grupo, pcobranca, DateTime.Now, dataEstimadaDevolucao, quilometragemInicial, NivelTanqueEnumInicio,
                                  taxas, true, 0, DateTime.MinValue, NivelTanqueEnum.naoInformado);            
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

            Veiculo vei = (Veiculo)cmbVeiculo.SelectedItem ;

            CarregarFotoVeiculo(vei);
        }
        
    }
}
