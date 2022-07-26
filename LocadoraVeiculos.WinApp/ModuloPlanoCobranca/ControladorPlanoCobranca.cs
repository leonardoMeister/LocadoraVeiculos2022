using LocadoraVeiculos.Controladores.ModuloServicoGrupoVeiculos;
using LocadoraVeiculos.Controladores.ModuloServicoPlanoCobranca;
using LocadoraVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraVeiculos.WinApp.shared;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculos.WinApp.ModuloPlanoCobranca
{
    public class ControladorPlanoCobranca : ConfiguracaoBase, ICadastravel
    {
        TabelaPlanoCobranca tabelaPlanoCobranca; 
        ServicoPlanoCobranca servicoPlanoCobranca;
        Action<string> AtualizarRodape;
        ServicoGrupoVeiculos servicoGrupoVeiculos;
        public ControladorPlanoCobranca(Action<string> atualizar, ServicoPlanoCobranca servico, TabelaPlanoCobranca tabela, ServicoGrupoVeiculos servicoGrupoVeiculos)
        {
            AtualizarRodape = atualizar;
            tabelaPlanoCobranca = tabela;
            servicoPlanoCobranca = servico;
            this.servicoGrupoVeiculos = servicoGrupoVeiculos;
        }

        public void Editar()
        {
            var id = tabelaPlanoCobranca.ObtemNumeroPlanoSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um plano cobranca primeiro",
                    "Edição de plano cobranca", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultado = servicoPlanoCobranca.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                    "Edição de plano cobranca", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var funcionarioSelecionado = resultado.Value;

            TelaCadastroPlanoCobranca telaCadastroFuncionario = new TelaCadastroPlanoCobranca(servicoGrupoVeiculos);

            AtualizarRodape("Tela de Edição Funcionário");
            telaCadastroFuncionario.PlanoCobranca = resultado.Value.Clone();

            telaCadastroFuncionario.GravarRegistro = servicoPlanoCobranca.Editar;
            telaCadastroFuncionario.AtualizarRodape = AtualizarRodape;
            telaCadastroFuncionario.ShowDialog();

            if (telaCadastroFuncionario.DialogResult == DialogResult.OK) AtualizarRodape("Edição plano cobranca Realizado Com Sucesso");
        }

        public void Excluir()
        {
            var id = tabelaPlanoCobranca.ObtemNumeroPlanoSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um plano cobranca primeiro",
                    "Exclusão de plano cobranca", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoSelecao = servicoPlanoCobranca.SelecionarPorId(id);

            if (resultadoSelecao.IsFailed)
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message,
                    "Exclusão de plano cobranca", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var planoCobrancaSelecionado = resultadoSelecao.Value;

            if (MessageBox.Show("Deseja realmente excluir o plano de cobranca?", "Exclusão de plano cobranca",
                 MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var resultadoExclusao = servicoPlanoCobranca.Excluir(planoCobrancaSelecionado);

                if (resultadoExclusao.IsSuccess)
                    CarregarFuncionarios();
                else
                    MessageBox.Show(resultadoExclusao.Errors[0].Message,
                        "Exclusão de Plano de cobranca", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarFuncionarios()
        {
            var resultado = servicoPlanoCobranca.SelecionarTodos();

            if (resultado.IsSuccess)
            {
                List<PlanoCobranca> funcionarios = resultado.Value;

                tabelaPlanoCobranca.AtualizarRegistros(funcionarios);

                AtualizarRodape($"Visualizando {funcionarios.Count} Plano(s) de Cobranca(s)");
            }
            else
            {
                MessageBox.Show(resultado.Errors[0].Message, "Exclusão de plano de cobranca",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Inserir()
        {
            TelaCadastroPlanoCobranca telaCadastroPlanoCobranca = new TelaCadastroPlanoCobranca(servicoGrupoVeiculos);

            AtualizarRodape("Tela de Adição Plano de Cobrança");

            telaCadastroPlanoCobranca.GravarRegistro = servicoPlanoCobranca.InserirNovo;
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
            List<PlanoCobranca> grupoVeiculos = servicoPlanoCobranca.SelecionarTodos().Value;

            tabelaPlanoCobranca.AtualizarRegistros(grupoVeiculos);

            return tabelaPlanoCobranca;
        }
    }
}
