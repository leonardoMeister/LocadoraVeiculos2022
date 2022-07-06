using LocadoraVeiculos.Dominio.shared;
using LocadoraVeiculos.WinApp.ModuloCliente;
using LocadoraVeiculos.WinApp.ModuloCondutores;
using LocadoraVeiculos.WinApp.ModuloFuncionario;
using LocadoraVeiculos.WinApp.ModuloGrupoVeiculo;
using LocadoraVeiculos.WinApp.ModuloPlanoCobranca;
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
        public ConfiguracaoCondutores configuracaoCondutores;
        public ConfiguracaoPlanoCobranca configuracaoPlanoCobranca;

        public ICadastravel telaSelecionada;

        public TelaPrincipalForm()
        {
            InitializeComponent();

            labelRodape.Text = string.Empty;
            labelTipoCadastro.Text = string.Empty;

            this.configuracaoGrupoVeiculos = new ConfiguracaoGrupoVeiculo(this.AtualizarRodape);
            this.configuracaoTaxa = new ConfiguracaoTaxa(this.AtualizarRodape);
            this.configuracaoCliente = new ConfiguracaoCliente(this.AtualizarRodape);
            this.configuracaoFuncionario = new ConfiguracaoFuncionario(this.AtualizarRodape);
            this.configuracaoCondutores = new ConfiguracaoCondutores(this.AtualizarRodape);
            this.configuracaoPlanoCobranca = new ConfiguracaoPlanoCobranca(this.AtualizarRodape);
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
        private void GrupoVeiculosMenuItem_Click(object sender, EventArgs e) //alterar o nome do botão
        {
            telaSelecionada = configuracaoGrupoVeiculos;
            ConfigurarTelaPrincipal(configuracaoGrupoVeiculos);
        }
        private void TaxasMenuItem_Click(object sender, EventArgs e)
        {
            telaSelecionada = configuracaoTaxa;
            ConfigurarTelaPrincipal(configuracaoTaxa);
        }
        private void ClienteMenuItem_Click(object sender, EventArgs e)
        {
            telaSelecionada = configuracaoCliente;
            ConfigurarTelaPrincipal(configuracaoCliente);
        }
        private void FuncionarioMenuItem_Click(object sender, EventArgs e)
        {
            telaSelecionada = configuracaoFuncionario;
            ConfigurarTelaPrincipal(configuracaoFuncionario);
        }
        private void condutoresMenuItem_Click(object sender, EventArgs e)
        {
            telaSelecionada = configuracaoCondutores;
            ConfigurarTelaPrincipal(configuracaoCondutores);
        }
        private void planoDeCobrancaMenuItem_Click(object sender, EventArgs e)
        {
            telaSelecionada = configuracaoPlanoCobranca;
            ConfigurarTelaPrincipal(configuracaoPlanoCobranca);

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
