using LocadoraVeiculos.Controladores.ModuloServicoPlanoCobranca;
using LocadoraVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraVeiculos.WinApp.shared;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculos.WinApp.ModuloPlanoCobranca
{
    public class ConfiguracaoPlanoCobranca : ConfiguracaoBase, ICadastravel
    {
        TabelaPlanoCobranca tabelaPlanoCobranca; 
        ServicoPlanoCobranca controlador;
        Action<string> AtualizarRodape;

        public ConfiguracaoPlanoCobranca(Action<string> atualizar)
        {
            AtualizarRodape = atualizar;
            tabelaPlanoCobranca = new TabelaPlanoCobranca();
            controlador = new ServicoPlanoCobranca();
        }

        public void Editar()
        {
            TelaCadastroPlanoCobranca telaCadastroPlanoCobranca = new TelaCadastroPlanoCobranca();

            Guid id = tabelaPlanoCobranca.ObtemNumeroPlanoSelecionado();
            var registro = controlador.SelecionarPorId(id);

            if (registro != null)
            {
                AtualizarRodape("Tela de Edição Plano de Cobrança");
                telaCadastroPlanoCobranca.PlanoCobranca = registro;

                telaCadastroPlanoCobranca.GravarRegistro = controlador.Editar;
                telaCadastroPlanoCobranca.AtualizarRodape = AtualizarRodape;
                telaCadastroPlanoCobranca.ShowDialog();

                if (telaCadastroPlanoCobranca.DialogResult == DialogResult.OK) AtualizarRodape("Edição Plano de Cobrança Realizado Com Sucesso");
            }
        }

        public void Excluir()
        {
            Guid id = tabelaPlanoCobranca.ObtemNumeroPlanoSelecionado();
            try
            {
                controlador.Excluir(id);
                AtualizarRodape("Plano de Cobrança Removido com sucesso.");
            }
            catch (Exception ex)
            {
                AtualizarRodape($"Não foi possivel Remover, Mensagem: {ex}");
                return;
            }
        }

        public void Inserir()
        {
            TelaCadastroPlanoCobranca telaCadastroPlanoCobranca = new TelaCadastroPlanoCobranca();

            AtualizarRodape("Tela de Adição Plano de Cobrança");

            telaCadastroPlanoCobranca.GravarRegistro = controlador.InserirNovo;
            telaCadastroPlanoCobranca.AtualizarRodape = AtualizarRodape;
            telaCadastroPlanoCobranca.ShowDialog();

            if (telaCadastroPlanoCobranca.DialogResult == DialogResult.OK) AtualizarRodape("Cadastro Plano de Cobrança Realizado Com Sucesso");
        }

        public ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxPlanoCobranca();
        }

        public override UserControl ObtemListagem()
        {
            List<PlanoCobranca> grupoVeiculos = controlador.SelecionarTodos();

            tabelaPlanoCobranca.AtualizarRegistros(grupoVeiculos);

            return tabelaPlanoCobranca;
        }
    }
}
