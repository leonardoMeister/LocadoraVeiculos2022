using LocadoraVeiculos.Dominio.ModuloVeiculo;
using System;
using FluentValidation.Results;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
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
            AtualizarVeiculo();
            ServicoVeiculo = servicoVeiculo;
            AtualizarCondutores();
            ServicoCondutores = servicoCondutores;
            AtualizarGrupoVeh();
            ServicoGrupoVeh = servicoGrupoVeh;
            AtualizarPlanoCobranca();
            ServicoPlanoCobranca = servicoPlanoCobranca;
            AtualizarTaxas();
            ServicoTaxas = servicoTaxas;
            AtualizarCliente();
            ServicoCliente = servicoCliente;
        }

        private void AtualizarVeiculo()
        {
            var dados = ServicoVeiculo.SelecionarTodos().Value;
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
                cmbCondutores.Items.Add(dado);
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

        private void AtualizarPlanoCobranca()
        {
            var dados = ServicoPlanoCobranca.SelecionarTodos().Value;
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
                cmbTaxas.Items.Add(dado);
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
                CarregarFotoVeiculo();
                txtId.Text = locacao.Id.ToString();
                EnumTanqueInicio.Text = locacao.NivelTanqueEnumInicio;
                textBoxQuilometragemInicial.Text = locacao.QuilometragemInicial.ToString();
                cmbVeiculo.SelectedItem = locacao.Veiculo;
                cmbCondutores.SelectedItem = locacao.Condutores;
                cmbGrupoVeiculo.SelectedItem = locacao.GrupoVeiculos;
                cmbPlanoCobranca.SelectedItem = locacao.PlanoCobranca;
                cmbTaxas.SelectedItem = locacao.ListaTaxas;
            }
        }

        private void CarregarFotoVeiculo()
        {
            MemoryStream memory = new MemoryStream(veiculo.Foto);

            pictureBoxFoto.Image = Image.FromStream(memory);

            bmp = new Bitmap(pictureBoxFoto.Image);
        }

        public Func<Locacao, Result<Locacao>> GravarRegistro { get; internal set; }
        public ServicoVeiculo ServicoVeiculo { get; }
        public ServicoCondutores ServicoCondutores { get; }
        public ServicoCondutores ServicoCliente { get; }
        public ServicoGrupoVeiculos ServicoGrupoVeh { get; }
        public ServicoPlanoCobranca ServicoPlanoCobranca { get; }
        public ServicoTaxas ServicoTaxas { get; }

        private void PegarObjetoTela()
        {
            Guid id = new Guid();

            if (txtId.Text != "")
                id = new Guid(txtId.Text);


            NivelTanqueEnum NivelTanqueEnumInicio = EnumTanqueInicio.Text;
            DateTime dataEstimadaDevolucao = data.Value;

            decimal quilometragemInicial = (textBoxQuilometragemInicial.Text == "") ? 0 : Convert.ToDecimal(textBoxQuilometragemInicial.Text);


            Veiculo veh = null;
            if (cmbVeiculo.SelectedIndex != -1) veh = (Veiculo)cmbVeiculo.SelectedItem;
            Condutores cond = null;
            if (cmbCondutores.SelectedIndex != -1) cond = (Condutores)cmbCondutores.SelectedItem;
            Cliente cli = null;
            if (cmbCliente.SelectedIndex != -1) cli = (Cliente)cmbCliente.SelectedItem;
            GrupoVeiculos grupo = null;
            if (cmbGrupoVeiculo.SelectedIndex != -1) grupo = (GrupoVeiculos)cmbGrupoVeiculo.SelectedItem;
            PlanoCobranca pcobranca = null;
            if (cmbPlanoCobranca.SelectedIndex != -1) pcobranca = (PlanoCobranca)cmbPlanoCobranca.SelectedItem;
            Taxas tax = null;
            if (cmbTaxas.SelectedIndex != -1) tax = (Taxas)cmbTaxas.SelectedItem;

            List<Taxas> taxa = new List<Taxas>();
            taxa.Add(tax);

            locacao = new Locacao(veh, cond, cli, grupo, pcobranca, DateTime.Now, dataEstimadaDevolucao, quilometragemInicial, NivelTanqueEnumInicio,
                                  taxa, true, 0, DateTime.MinValue, NivelTanqueEnum.naoInformado);

            if (id != Guid.Empty)
            locacao.Id = id;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            PegarObjetoTela();

            if (locacao.Foto is null)
            {
                AtualizarRodape("Foto deve ser selecionada");

                DialogResult = DialogResult.None;
                return;
            }

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
    }
}
