using LocadoraVeiculos.Controladores.ModuloServicoCliente;
using LocadoraVeiculos.Controladores.ModuloServicoCondutores;
using LocadoraVeiculos.Dominio.ModuloCondutores;
using LocadoraVeiculos.WinApp.shared;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculos.WinApp.ModuloCondutores
{
    public class ControladorCondutores : ConfiguracaoBase, ICadastravel
    {
        Action<string> AtualizarRodape;
        ServicoCondutores servicoCondutores;
        TabelaCondutoresControl tabelaCondutoresControl;
        ServicoCliente servicoCliente;
        public ControladorCondutores(Action<string> atualizar,ServicoCondutores servico, TabelaCondutoresControl tabela, ServicoCliente servicoCliente)
        {
            AtualizarRodape = atualizar;
            tabelaCondutoresControl = tabela;
            servicoCondutores = servico;
            this.servicoCliente = servicoCliente;
        }


        public void Editar()
        {
            var id = tabelaCondutoresControl.ObtemNumeroCondutorSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um Condutor primeiro",
                    "Edição de Condutores", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultado = servicoCondutores.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                    "Edição de Condutor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var condutorSelecionado = resultado.Value;

            TelaCadastroCondutoresForm telaCadastroFuncionario = new TelaCadastroCondutoresForm(servicoCliente);

            AtualizarRodape("Tela de Edição Condutores");
            telaCadastroFuncionario.Condutores = resultado.Value;

            telaCadastroFuncionario.GravarRegistro = servicoCondutores.Editar;
            telaCadastroFuncionario.AtualizarRodape = AtualizarRodape;
            telaCadastroFuncionario.ShowDialog();

            if (telaCadastroFuncionario.DialogResult == DialogResult.OK) AtualizarRodape("Edição Condutor Realizado Com Sucesso");
        }

        public void Excluir()
        {
            var id = tabelaCondutoresControl.ObtemNumeroCondutorSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um funcionário primeiro",
                    "Exclusão de Funcionário", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoSelecao = servicoCondutores.SelecionarPorId(id);

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
                var resultadoExclusao = servicoCondutores.Excluir(funcionarioSelecionado);

                if (resultadoExclusao.IsSuccess)
                    CarregarFuncionarios();
                else
                    MessageBox.Show(resultadoExclusao.Errors[0].Message,
                        "Exclusão de Funcionário", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarFuncionarios()
        {
            var resultado = servicoCondutores.SelecionarTodos();

            if (resultado.IsSuccess)
            {
                List<Condutores> funcionarios = resultado.Value;

                tabelaCondutoresControl.AtualizarRegistros(funcionarios);

                AtualizarRodape($"Visualizando {funcionarios.Count} Condutor(es)");
            }
            else
            {
                MessageBox.Show(resultado.Errors[0].Message, "Exclusão de Condutor",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Inserir()
        {
            TelaCadastroCondutoresForm telaCadastroCondutores = new(servicoCliente);

            AtualizarRodape("Tela de Adição Condutores");

            telaCadastroCondutores.GravarRegistro = servicoCondutores.InserirNovo;
            telaCadastroCondutores.AtualizarRodape = AtualizarRodape;
            telaCadastroCondutores.ShowDialog();

            if (telaCadastroCondutores.DialogResult == DialogResult.OK) AtualizarRodape("Cadastro Condutor Realizado Com Sucesso");
        }

        public ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxCondutores();
        }

        public override UserControl ObtemListagem()
        {
            List<Condutores> condutores = servicoCondutores.SelecionarTodos().Value;

            tabelaCondutoresControl.AtualizarRegistros(condutores);

            return tabelaCondutoresControl;
        }
    }
}
