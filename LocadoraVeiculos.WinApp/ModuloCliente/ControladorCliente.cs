using LocadoraVeiculos.Controladores.ModuloServicoCliente;
using LocadoraVeiculos.Dominio.ModuloCliente;
using LocadoraVeiculos.WinApp.shared;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculos.WinApp.ModuloCliente
{
    public class ControladorCliente : ConfiguracaoBase, ICadastravel
    {
        Action<string> atualizarRodape;
        ServicoCliente servicoCliente;
        TabelaClienteControl tabelaClienteControl;

        public ControladorCliente(Action<string> atualizar, ServicoCliente servico, TabelaClienteControl tabela)
        {
            atualizarRodape = atualizar;            
            servicoCliente = servico;
            tabelaClienteControl = tabela;
        }


        public void Editar()
        {
            var id = tabelaClienteControl.ObtemNumeroClienteSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um Cliente primeiro",
                    "Edição de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultado = servicoCliente.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                    "Edição de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var clienteSelecionado = resultado.Value;

            TelaCadastroClienteForm telaCadastroFuncionario = new TelaCadastroClienteForm();

            atualizarRodape("Tela de Edição Funcionário");
            telaCadastroFuncionario.Cliente = resultado.Value.Clone();

            telaCadastroFuncionario.GravarRegistro = servicoCliente.Editar;
            telaCadastroFuncionario.AtualizarRodape = atualizarRodape;
            telaCadastroFuncionario.ShowDialog();

            if (telaCadastroFuncionario.DialogResult == DialogResult.OK) atualizarRodape("Edição Funcionário Realizado Com Sucesso");
        }

        public void Excluir()
        {
            var id = tabelaClienteControl.ObtemNumeroClienteSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um Cliente primeiro",
                    "Exclusão de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoSelecao = servicoCliente.SelecionarPorId(id);

            if (resultadoSelecao.IsFailed)
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message,
                    "Exclusão de Funcionário", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var funcionarioSelecionado = resultadoSelecao.Value;

            if (MessageBox.Show("Deseja realmente excluir o funcionário?", "Exclusão de Funcionário",
                 MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var resultadoExclusao = servicoCliente.Excluir(funcionarioSelecionado);

                if (resultadoExclusao.IsSuccess)
                    CarregarClientes();
                else
                    MessageBox.Show(resultadoExclusao.Errors[0].Message,
                        "Exclusão de Funcionário", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarClientes()
        {
            var resultado = servicoCliente.SelecionarTodos();

            if (resultado.IsSuccess)
            {
                List<Cliente> funcionarios = resultado.Value;

                tabelaClienteControl.AtualizarRegistros(funcionarios);

                atualizarRodape($"Visualizando {funcionarios.Count} Cliente(s)");
            }
            else
            {
                MessageBox.Show(resultado.Errors[0].Message, "Exclusão de Cliente",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Inserir()
        {
            TelaCadastroClienteForm telaCadastroCliente = new();

            atualizarRodape("Tela de Adição Cliente");

            telaCadastroCliente.GravarRegistro = servicoCliente.InserirNovo;
            telaCadastroCliente.AtualizarRodape = atualizarRodape;
            telaCadastroCliente.ShowDialog();

            if (telaCadastroCliente.DialogResult == DialogResult.OK) atualizarRodape("Cadastro Cliente Realizado Com Sucesso");
        }

        public ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxCliente();
        }

        public override UserControl ObtemListagem()
        {
            List<Cliente> clientes = servicoCliente.SelecionarTodos().Value;

            tabelaClienteControl.AtualizarRegistros(clientes);

            return tabelaClienteControl;
        }
    }
}
