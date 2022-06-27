using LocadoraVeiculos.Controladores.ModuloControladorGrupoVeiculos;
using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraVeiculos.Dominio.shared;
using LocadoraVeiculos.Repositorio.shared;
using LocadoraVeiculos.RepositorioProject.ModuloGrupoVeiculos;
using LocadoraVeiculos.WinApp.ModuloTaxa;
using LocadoraVeiculos.WinApp.shared;
using System;
using System.Windows.Forms;

namespace LocadoraVeiculos.WinApp
{
    public partial class TelaPrincipalForm : Form
    {
        public IRepositoryGrupoVeiculos RepositorioGrupoVeiculos { get; }
        public ControladorGrupoVeiculos ControladorGrupoVeiculos { get; }
        public ConfiguracaoBase<GrupoVeiculos> ConfiguracaoGrupoVeiculos { get; }

        public TelaPrincipalForm(ConfiguracaoBase<GrupoVeiculos> configuracaoGrupoVeiculos)
        {
            InitializeComponent();

            labelRodape.Text = string.Empty;
            labelTipoCadastro.Text = string.Empty;
            ConfiguracaoGrupoVeiculos = configuracaoGrupoVeiculos;
        }

        public void AtualizarRodape(string mensagem)
        {
            
        }

        private void ConfigurarListagem<T>(ConfiguracaoBase<T> configuracao) where T : EntidadeBase
        {
            AtualizarRodape("");

            var listagemControl = configuracao.ObtemListagem();

            panelRegistros.Controls.Clear();

            listagemControl.Dock = DockStyle.Fill;

            panelRegistros.Controls.Add(listagemControl);
        }

        private void ConfigurarToolbox<T>(ConfiguracaoBase<T> configuracao) where T : EntidadeBase
        {
            ConfiguracaoToolboxBase configuracaoToolBox = configuracao.ObterConfiguracao();

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

        private void taxasMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void grupoVeiculosMenuItem_Click(object sender, EventArgs e) //alterar o nome do botão
        {
            ConfigurarTelaPrincipal(ConfiguracaoGrupoVeiculos);
        }

        private void ConfigurarTelaPrincipal<T>(ConfiguracaoBase<T> configuracao) where T : EntidadeBase
        {
            ConfigurarToolbox(configuracao);

            ConfigurarListagem(configuracao);
        }

        private void compromissosMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void despesasMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            
        }
    }
}
