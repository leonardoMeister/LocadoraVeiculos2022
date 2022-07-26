using LocadoraVeiculos.Controladores.ModuloServicoGrupoVeiculos;
using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraVeiculos.WinApp.shared;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculos.WinApp.ModuloGrupoVeiculo
{
    public class ControladorGrupoVeiculo : ConfiguracaoBase, ICadastravel
    {
        TabelaGrupoVeiculoControl tabelaGrupoVeiculos;
        ServicoGrupoVeiculos servicoGrupoVeiculos;
        Action<string> AtualizarRodape;
        public ControladorGrupoVeiculo(Action<string> atualizar, ServicoGrupoVeiculos servico, TabelaGrupoVeiculoControl tabela)
        {
            tabelaGrupoVeiculos = tabela;
            servicoGrupoVeiculos = servico;
            AtualizarRodape = atualizar;
        }

        public void Inserir()
        {
            TelaCadastroGrupoVeiculo telaCadastroGrupoVeiculo = new TelaCadastroGrupoVeiculo();

            AtualizarRodape("Tela de Adição Grupo de Veiculos");

            telaCadastroGrupoVeiculo.GravarRegistro = servicoGrupoVeiculos.InserirNovo;
            telaCadastroGrupoVeiculo.AtualizarRodape = AtualizarRodape;
            telaCadastroGrupoVeiculo.ShowDialog();

            if (telaCadastroGrupoVeiculo.DialogResult == DialogResult.OK) AtualizarRodape("Cadastro Grupo Veiculo Realizado Com Sucesso");
        }

        public void Editar()
        {
            var id = tabelaGrupoVeiculos.ObtemNumeroGrupoVeiculosSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um Grupo de Veiculo primeiro",
                    "Edição Grupo de Veiculos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultado = servicoGrupoVeiculos.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                    "Edição de Grupo de Veiculo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var funcionarioSelecionado = resultado.Value;

            TelaCadastroGrupoVeiculo telaCadastroGrupoVeiculo = new TelaCadastroGrupoVeiculo();

            AtualizarRodape("Tela de Edição Grupo de Veiculos");
            telaCadastroGrupoVeiculo.GrupoVeiculos = resultado.Value.Clone();

            telaCadastroGrupoVeiculo.GravarRegistro = servicoGrupoVeiculos.Editar;
            telaCadastroGrupoVeiculo.AtualizarRodape = AtualizarRodape;
            telaCadastroGrupoVeiculo.ShowDialog();

            if (telaCadastroGrupoVeiculo.DialogResult == DialogResult.OK) AtualizarRodape("Edição Grupo de Veiculo Realizado Com Sucesso");
        }

        public void Excluir()
        {
            var id = tabelaGrupoVeiculos.ObtemNumeroGrupoVeiculosSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um Grupo de Veiculos primeiro",
                    "Exclusão Grupo de Veiculos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoSelecao = servicoGrupoVeiculos.SelecionarPorId(id);

            if (resultadoSelecao.IsFailed)
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message,
                    "Exclusão Grupo de Veiculos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var funcionarioSelecionado = resultadoSelecao.Value;

            if (MessageBox.Show("Deseja realmente excluir o Grupo de Veiculo?", "Exclusão Grupo de Veiculos",
                 MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var resultadoExclusao = servicoGrupoVeiculos.Excluir(funcionarioSelecionado);

                if (resultadoExclusao.IsSuccess)
                    CarregarGrupoVeiculos();
                else
                    MessageBox.Show(resultadoExclusao.Errors[0].Message,
                        "Exclusão Grupo de Veiculos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarGrupoVeiculos()
        {
            var resultado = servicoGrupoVeiculos.SelecionarTodos();

            if (resultado.IsSuccess)
            {
                List<GrupoVeiculos> funcionarios = resultado.Value;

                tabelaGrupoVeiculos.AtualizarRegistros(funcionarios);

                AtualizarRodape($"Visualizando {funcionarios.Count} Grupos de Veiculo(s)");
            }
            else
            {
                MessageBox.Show(resultado.Errors[0].Message, "Exclusão de Grupos de Veiculos",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxGrupoVeiculo();
        }

        public override UserControl ObtemListagem()
        {
            List<GrupoVeiculos> grupoVeiculos = servicoGrupoVeiculos.SelecionarTodos().Value;

            tabelaGrupoVeiculos.AtualizarRegistros(grupoVeiculos);

            return tabelaGrupoVeiculos;
        }
    }
}