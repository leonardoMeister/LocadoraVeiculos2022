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
        TelaPrincipalForm telaPrincipal;
        public ConfiguracaoFuncionario(TelaPrincipalForm telaPrincipalForm)
        {
            telaPrincipal = telaPrincipalForm;
            tabelaFuncionario = new TabelaFuncionarioControl();
            controlador = new ControladorFuncionario( );
        }

        public void Editar()
        {
            TelaCadastroFuncionario telaCadastroFuncionario = new TelaCadastroFuncionario(telaPrincipal);

            int id = tabelaFuncionario.ObtemNumeroTarefaSelecionado();            
            var registro = controlador.SelecionarPorId(id);
            telaCadastroFuncionario.Funcionario = registro;

            if (telaCadastroFuncionario.ShowDialog() == DialogResult.OK)
            {
                var grupo = telaCadastroFuncionario.Funcionario;
                controlador.Editar(grupo._id, grupo);

                telaPrincipal.AtualizarRodape("Edição Funcionário Realizado Com Sucesso");
            }
        }

        public void Excluir()
        {
            int id = tabelaFuncionario.ObtemNumeroTarefaSelecionado();
            try
            {
                controlador.Excluir(id);
                telaPrincipal.AtualizarRodape("Funcionário Removido com sucesso.");
            }
            catch (Exception ex)
            {
                telaPrincipal.AtualizarRodape($"Não foi possivel Remover, Mensagem: {ex}");
                return;
            }
        }

        public void Inserir()
        {
            TelaCadastroFuncionario telaCadastroFuncionario = new TelaCadastroFuncionario(telaPrincipal);

            telaCadastroFuncionario = new TelaCadastroFuncionario(telaPrincipal);

            if (telaCadastroFuncionario.ShowDialog() == DialogResult.OK)
            {
                var funcionario = telaCadastroFuncionario.Funcionario;
                controlador.InserirNovo(funcionario);

                telaPrincipal.AtualizarRodape("Cadastro Funcionário Realizado Com Sucesso");
            }
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
