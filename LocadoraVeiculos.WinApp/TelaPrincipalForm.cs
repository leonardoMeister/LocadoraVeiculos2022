using LocadoraVeiculos.WinApp.ModuloCliente;
using LocadoraVeiculos.WinApp.ModuloCondutores;
using LocadoraVeiculos.WinApp.ModuloFuncionario;
using LocadoraVeiculos.WinApp.ModuloGrupoVeiculo;
using LocadoraVeiculos.WinApp.ModuloPlanoCobranca;
using LocadoraVeiculos.WinApp.ModuloTaxa;
using LocadoraVeiculos.WinApp.ModuloVeiculo;
using LocadoraVeiculos.WinApp.ServiceLocator;
using LocadoraVeiculos.WinApp.shared;
using System;
using System.Windows.Forms;

namespace LocadoraVeiculos.WinApp
{
    public partial class TelaPrincipalForm : Form
    {

        ServiceLocatorManual serviceLocatorManual;        

        public ICadastravel telaSelecionada;

        public TelaPrincipalForm()
        {
            InitializeComponent();
            serviceLocatorManual = new ServiceLocatorManual(this.AtualizarRodape);

            labelRodape.Text = string.Empty;
            labelTipoCadastro.Text = string.Empty;            
        }

        public void AtualizarRodape(string mensagem)
        {
            labelRodape.Text = mensagem;
        }

        #region CONFIGURACOES DE TELA
        private void ConfigurarListagem(ConfiguracaoBase configuracao)
        {

            var listagemControl = configuracao.ObtemListagem();

            panelRegistros.Controls.Clear();

            listagemControl.Dock = DockStyle.Fill;

            panelRegistros.Controls.Add(listagemControl);
        }
        private void ConfigurarToolbox(ConfiguracaoBase configuracao)
        {            
            ConfiguracaoToolboxBase configuracaoToolBox = ((ICadastravel)configuracao).ObtemConfiguracaoToolbox();

            if (configuracaoToolBox != null)
            {
                toolbox.Enabled = true;

                labelTipoCadastro.Text = configuracaoToolBox.TipoCadastro;

                ConfigurarTooltips(configuracaoToolBox);

                ConfigurarBotoes(configuracaoToolBox);
            }
        }
        private void ConfigurarBotoes(ConfiguracaoToolboxBase configuracao)
        {
            btnInserir.Enabled = configuracao.InserirHabilitado;
            btnEditar.Enabled = configuracao.EditarHabilitado;
            btnExcluir.Enabled = configuracao.ExcluirHabilitado;
            btnAdicionarItens.Enabled = configuracao.AdicionarItensHabilitado;
            btnAtualizarItens.Enabled = configuracao.AtualizarItensHabilitado;
            btnFiltrar.Enabled = configuracao.FiltrarHabilitado;
            btnAgrupar.Enabled = configuracao.AgruparHabilitado;
        }
        private void ConfigurarTooltips(ConfiguracaoToolboxBase configuracao)
        {
            btnInserir.ToolTipText = configuracao.TooltipInserir;
            btnEditar.ToolTipText = configuracao.TooltipEditar;
            btnExcluir.ToolTipText = configuracao.TooltipExcluir;
            btnAdicionarItens.ToolTipText = configuracao.TooltipAdicionarItens;
            btnAtualizarItens.ToolTipText = configuracao.TooltipAtualizarItens;
            btnFiltrar.ToolTipText = configuracao.TooltipFiltrar;
            btnAgrupar.ToolTipText = configuracao.TooltipAgrupar;
        }
        private void ConfigurarTelaPrincipal(ConfiguracaoBase configuracao)
        {
            telaSelecionada = (ICadastravel)configuracao;

            ConfigurarToolbox(configuracao);

            ConfigurarListagem(configuracao);
        }

        #endregion

        #region OPCOES DO MENU
        private void GrupoVeiculosMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(serviceLocatorManual.Get<ControladorGrupoVeiculo>());
        }
        private void TaxasMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(serviceLocatorManual.Get<ControladorTaxa>());
        }
        private void ClienteMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(serviceLocatorManual.Get<ControladorCliente>());
        }
        private void FuncionarioMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(serviceLocatorManual.Get<ControladorFuncionario>());
        }
        private void CondutoresMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(serviceLocatorManual.Get<ControladorCondutores>());
        }
        private void PlanoDeCobrancaMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(serviceLocatorManual.Get<ControladorPlanoCobranca>());

        }
        private void VeiculoMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(serviceLocatorManual.Get<ControladorVeiculo>());

        }
        #endregion

        #region BOTÕES DE AÇÕES DO USUARIO
        private void BtnInserir_Click(object sender, EventArgs e)
        {
            if (telaSelecionada != null)
            {
                telaSelecionada.Inserir();

                ConfigurarListagem((ConfiguracaoBase)telaSelecionada);
            }
        }
        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (telaSelecionada != null)
            {
                telaSelecionada.Editar();

                ConfigurarListagem((ConfiguracaoBase)telaSelecionada);
            }
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            if (telaSelecionada != null)
            {
                telaSelecionada.Excluir();

                ConfigurarListagem((ConfiguracaoBase)telaSelecionada);
            }
        }
        private void BtnAdicionarItens_Click(object sender, EventArgs e)
        {
            if (telaSelecionada != null)
            {
                telaSelecionada.AdicionarItens();

                ConfigurarListagem((ConfiguracaoBase)telaSelecionada);
            }
        }
        private void BtnAtualizarItens_Click(object sender, EventArgs e)
        {
            if (telaSelecionada != null)
            {
                telaSelecionada.AtualizarItens();

                ConfigurarListagem((ConfiguracaoBase)telaSelecionada);
            }
        }
        private void BtnFiltrar_Click(object sender, EventArgs e)
        {
            if (telaSelecionada != null)
            {
                telaSelecionada.Filtrar();

                ConfigurarListagem((ConfiguracaoBase)telaSelecionada);
            }
        }
        private void BtnAgrupar_Click(object sender, EventArgs e)
        {
            if (telaSelecionada != null)
            {
                telaSelecionada.Agrupar();

                ConfigurarListagem((ConfiguracaoBase)telaSelecionada);
            }
        }

        #endregion
        
    }
}
