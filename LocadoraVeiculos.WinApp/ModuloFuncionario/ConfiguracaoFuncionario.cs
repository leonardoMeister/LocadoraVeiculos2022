using LocadoraVeiculos.Controladores.ModuloFuncionario;
using LocadoraVeiculos.Dominio.ModuloFuncionario;
using LocadoraVeiculos.WinApp.shared;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculos.WinApp.ModuloFuncionario
{
    public class ConfiguracaoFuncionario : ConfiguracaoBase, ICadastravel
    {
        TabelaFuncionarioControl tabelaFuncionario;
        ControladorFuncionario controlador;
        Action<string> AtualizarRodape;

        public ConfiguracaoFuncionario(Action<string> atualizar)
        {
            AtualizarRodape = atualizar;
            tabelaFuncionario = new TabelaFuncionarioControl();
            controlador = new ControladorFuncionario();
        }

        public void Editar()
        {
            TelaCadastroFuncionario telaCadastroFuncionario = new TelaCadastroFuncionario();

            int id = tabelaFuncionario.ObtemNumeroTarefaSelecionado();
            var registro = controlador.SelecionarPorId(id);

            if (registro != null)
            {
                AtualizarRodape("Tela de Edição Funcionário");
                telaCadastroFuncionario.Funcionario = registro;

                telaCadastroFuncionario.GravarRegistro = controlador.Editar;
                telaCadastroFuncionario.AtualizarRodape = AtualizarRodape;
                telaCadastroFuncionario.ShowDialog();

                if (telaCadastroFuncionario.DialogResult == DialogResult.OK) AtualizarRodape("Edição Funcionário Realizado Com Sucesso");
            }
        }

        public void Excluir()
        {
            int id = tabelaFuncionario.ObtemNumeroTarefaSelecionado();
            try
            {
                controlador.Excluir(id);
               AtualizarRodape("Funcionário Removido com sucesso.");
            }
            catch (Exception ex)
            {
                AtualizarRodape($"Não foi possivel Remover, Mensagem: {ex}");
                return;
            }
        }

        public void Inserir()
        {
            TelaCadastroFuncionario telaCadastroFuncionario = new TelaCadastroFuncionario();

            AtualizarRodape("Tela de Add Funcionário");

            telaCadastroFuncionario.GravarRegistro = controlador.InserirNovo;
            telaCadastroFuncionario.AtualizarRodape = AtualizarRodape;
            telaCadastroFuncionario.ShowDialog();

            if (telaCadastroFuncionario.DialogResult == DialogResult.OK) AtualizarRodape("Cadastro Funcionário Realizado Com Sucesso");

        }

        public ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoTollBoxFuncionario();
        }

        public override UserControl ObtemListagem()
        {
            List<Funcionario> grupoVeiculos = controlador.SelecionarTodos();

            tabelaFuncionario.AtualizarRegistros(grupoVeiculos);

            return tabelaFuncionario;
        }
    }
}
