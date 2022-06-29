using LocadoraVeiculos.Dominio.shared;
using LocadoraVeiculos.WinApp.ModuloCliente;
using LocadoraVeiculos.WinApp.ModuloFuncionario;
using LocadoraVeiculos.WinApp.ModuloGrupoVeiculo;
using LocadoraVeiculos.WinApp.ModuloTaxa;
using LocadoraVeiculos.WinApp.shared;
using System;
using System.Windows.Forms;

namespace LocadoraVeiculos.WinApp
{
    public partial class TelaPrincipalForm : Form
    {        
        public ConfiguracaoGrupoVeiculo configuracaoGrupoVeiculos;
        public ConfiguracaoTaxa configuracaoTaxa;
        public ConfiguracaoCliente configuracaoCliente;
        public ConfiguracaoFuncionario configuracaoFuncionario;

        public ICadastravel telaSelecionada;

        public TelaPrincipalForm()
        {
            InitializeComponent();

            labelRodape.Text = string.Empty;
            labelTipoCadastro.Text = string.Empty;

            this.configuracaoGrupoVeiculos = new ConfiguracaoGrupoVeiculo(this.AtualizarRodape);
            this.configuracaoTaxa = new ConfiguracaoTaxa(this.AtualizarRodape);
            this.configuracaoCliente = new ConfiguracaoCliente(this);
            this.configuracaoFuncionario = new ConfiguracaoFuncionario(this.AtualizarRodape);
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
        private void ConfigurarToolbox()
        {
            ConfiguracaoToolboxBase configuracaoToolBox = telaSelecionada.ObtemConfiguracaoToolbox();

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
            ConfigurarToolbox();

            ConfigurarListagem(configuracao);
        }

        #endregion

        #region OPCOES DO MENU
        private void grupoVeiculosMenuItem_Click(object sender, EventArgs e) //alterar o nome do botão
        {
            telaSelecionada = configuracaoGrupoVeiculos;
            ConfigurarTelaPrincipal(configuracaoGrupoVeiculos);
        }
        private void taxasMenuItem_Click(object sender, EventArgs e)
        {
            telaSelecionada = configuracaoTaxa;
            ConfigurarTelaPrincipal(configuracaoTaxa);
        }
        private void clienteMenuItem_Click(object sender, EventArgs e)
        {
            telaSelecionada = configuracaoCliente;
            ConfigurarTelaPrincipal(configuracaoCliente);
        }
        private void funcionarioMenuItem_Click(object sender, EventArgs e)
        {
            telaSelecionada = configuracaoFuncionario;
            ConfigurarTelaPrincipal(configuracaoFuncionario);
        }
        #endregion


        #region BOTÕES DE AÇÕES DO USUARIO
        private void btnInserir_Click(object sender, EventArgs e)
        {
            if (telaSelecionada != null)
            {
                telaSelecionada.Inserir();

                ConfigurarListagem((ConfiguracaoBase)telaSelecionada);
            }
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (telaSelecionada != null)
            {
                telaSelecionada.Editar();

                ConfigurarListagem((ConfiguracaoBase)telaSelecionada);
            }
        }
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (telaSelecionada != null)
            {
                telaSelecionada.Excluir();

                ConfigurarListagem((ConfiguracaoBase)telaSelecionada);
            }
        }
        private void btnAdicionarItens_Click(object sender, EventArgs e)
        {
            if (telaSelecionada != null)
            {
                telaSelecionada.AdicionarItens();

                ConfigurarListagem((ConfiguracaoBase)telaSelecionada);
            }
        }
        private void btnAtualizarItens_Click(object sender, EventArgs e)
        {
            if (telaSelecionada != null)
            {
                telaSelecionada.AtualizarItens();

                ConfigurarListagem((ConfiguracaoBase)telaSelecionada);
            }
        }
        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (telaSelecionada != null)
            {
                telaSelecionada.Filtrar();

                ConfigurarListagem((ConfiguracaoBase)telaSelecionada);
            }
        }
        private void btnAgrupar_Click(object sender, EventArgs e)
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
