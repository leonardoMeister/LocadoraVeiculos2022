using LocadoraVeiculos.Controladores.ModuloServicoVeiculo;
using LocadoraVeiculos.Dominio.ModuloVeiculo;
using LocadoraVeiculos.WinApp.shared;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculos.WinApp.ModuloVeiculo
{
    public class ControladorVeiculo : ConfiguracaoBase, ICadastravel
    {
        TabelaVeiculoControl tabelaVeiculo;
        ServicoVeiculo servicoVeiculo;
        Action<string> AtualizarRodape;
        public ControladorVeiculo(Action<string> atualizar, ServicoVeiculo servico, TabelaVeiculoControl tabela)
        {
            AtualizarRodape = atualizar;
            servicoVeiculo = servico;
            tabelaVeiculo = tabela;
        }

        public void Editar()
        {
            var id = tabelaVeiculo.ObtemNumeroVeiculoSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um Veiculo primeiro",
                    "Edição de Veiculo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultado = servicoVeiculo.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                    "Edição de Funcionário", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var funcionarioSelecionado = resultado.Value;

            TelaCadastroVeiculo telaCadastroFuncionario = new TelaCadastroVeiculo();

            AtualizarRodape("Tela de Edição Funcionário");
            telaCadastroFuncionario.Veiculo = resultado.Value.Clone();

            telaCadastroFuncionario.GravarRegistro = servicoVeiculo.Editar;
            telaCadastroFuncionario.AtualizarRodape = AtualizarRodape;
            telaCadastroFuncionario.ShowDialog();

            if (telaCadastroFuncionario.DialogResult == DialogResult.OK) AtualizarRodape("Edição Veiculo Realizado Com Sucesso");

        }

        public void Excluir()
        {
            var id = tabelaVeiculo.ObtemNumeroVeiculoSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um Veiculo primeiro",
                    "Exclusão de veiculo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoSelecao = servicoVeiculo.SelecionarPorId(id);

            if (resultadoSelecao.IsFailed)
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message,
                    "Exclusão de Veiculo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var veiculoSelecionado = resultadoSelecao.Value;

            if (MessageBox.Show("Deseja realmente excluir o Veiculo?", "Exclusão de Veiculo",
                 MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var resultadoExclusao = servicoVeiculo.Excluir(veiculoSelecionado);

                if (resultadoExclusao.IsSuccess)
                    CarregarFuncionarios();
                else
                    MessageBox.Show(resultadoExclusao.Errors[0].Message,
                        "Exclusão de Funcionário", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarFuncionarios()
        {
            var resultado = servicoVeiculo.SelecionarTodos();

            if (resultado.IsSuccess)
            {
                List<Veiculo> funcionarios = resultado.Value;

                tabelaVeiculo.AtualizarRegistros(funcionarios);

                AtualizarRodape($"Visualizando {funcionarios.Count} Veiculo(s)");
            }
            else
            {
                MessageBox.Show(resultado.Errors[0].Message, "Exclusão de Funcionário",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Inserir()
        {
            TelaCadastroVeiculo telaCadastroVeiculo = new();

            AtualizarRodape("Tela de Adição Veiculo");

            telaCadastroVeiculo.GravarRegistro = servicoVeiculo.InserirNovo;
            telaCadastroVeiculo.AtualizarRodape = AtualizarRodape;
            telaCadastroVeiculo.ShowDialog();

            if (telaCadastroVeiculo.DialogResult == DialogResult.OK) AtualizarRodape("Cadastro Veiculo Realizado Com Sucesso");
        }

        public ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxVeiculo();
        }

        public override UserControl ObtemListagem()
        {
            List<Veiculo> veiculos = servicoVeiculo.SelecionarTodos().Value;

            tabelaVeiculo.AtualizarRegistros(veiculos);

            return tabelaVeiculo;
        }
    }
}
