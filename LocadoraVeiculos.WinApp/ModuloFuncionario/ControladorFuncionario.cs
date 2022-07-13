using LocadoraVeiculos.Controladores.ModuloServicoFuncionario;
using LocadoraVeiculos.Dominio.ModuloFuncionario;
using LocadoraVeiculos.WinApp.shared;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculos.WinApp.ModuloFuncionario
{
    public class ControladorFuncionario : ConfiguracaoBase, ICadastravel
    {
        TabelaFuncionarioControl tabelaFuncionario;
        ServicoFuncionario servicoFuncionario;
        Action<string> AtualizarRodape;

        public ControladorFuncionario(Action<string> atualizar)
        {
            AtualizarRodape = atualizar;
            tabelaFuncionario = new TabelaFuncionarioControl();
            servicoFuncionario = new ServicoFuncionario();
        }

        public void Editar()
        {
            TelaCadastroFuncionario telaCadastroFuncionario = new TelaCadastroFuncionario();

            Guid id = tabelaFuncionario.ObtemNumeroTarefaSelecionado();
            var registro = servicoFuncionario.SelecionarPorId(id);

            if (registro != null)
            {
                AtualizarRodape("Tela de Edição Funcionário");
                telaCadastroFuncionario.Funcionario = registro;

                telaCadastroFuncionario.GravarRegistro = servicoFuncionario.Editar;
                telaCadastroFuncionario.AtualizarRodape = AtualizarRodape;
                telaCadastroFuncionario.ShowDialog();

                if (telaCadastroFuncionario.DialogResult == DialogResult.OK) AtualizarRodape("Edição Funcionário Realizado Com Sucesso");
            }
        }

        public void Excluir()
        {
            Guid id = tabelaFuncionario.ObtemNumeroTarefaSelecionado();
            try
            {
                servicoFuncionario.Excluir(id);
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

            telaCadastroFuncionario.GravarRegistro = servicoFuncionario.InserirNovo;
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
            List<Funcionario> grupoVeiculos = servicoFuncionario.SelecionarTodos();

            tabelaFuncionario.AtualizarRegistros(grupoVeiculos);

            return tabelaFuncionario;
        }
    }
}
