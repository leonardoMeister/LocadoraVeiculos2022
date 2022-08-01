using LocadoraVeiculos.Controladores.ModuloServicoTaxas;
using LocadoraVeiculos.Dominio.ModuloTaxas;
using LocadoraVeiculos.WinApp.shared;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculos.WinApp.ModuloTaxa
{
    public class ControladorTaxa : ConfiguracaoBase, ICadastravel
    {
        TabelaTaxaControl tabelaTaxa;
        ServicoTaxas servicoTaxas;
        Action<string> AtualizarRodape;
        public ControladorTaxa(Action<string> atualizar, ServicoTaxas servico,TabelaTaxaControl tabela)
        {
            tabelaTaxa = tabela;
            servicoTaxas = servico;
            AtualizarRodape = atualizar;
        }

        public void Inserir()
        {
            TelaCadastroTaxaForm telaCadastrotaxa = new TelaCadastroTaxaForm();

            AtualizarRodape("Tela de Adição Taxa");
            telaCadastrotaxa.taxa = new Taxas();

            telaCadastrotaxa.GravarRegistro = servicoTaxas.InserirNovo;
            telaCadastrotaxa.AtualizarRodape = AtualizarRodape;
            telaCadastrotaxa.ShowDialog();

            if (telaCadastrotaxa.DialogResult == DialogResult.OK) AtualizarRodape("Cadastro Taxa Realizado Com Sucesso");
        }

        public void Editar()
        {
            var id = tabelaTaxa.ObtemNumeroTaxaSelecionada();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione uma taxa primeiro",
                    "Edição de Taxas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultado = servicoTaxas.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                    "Edição de Taxas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var taxaSelecionada = resultado.Value;

            TelaCadastroTaxaForm telaCadastroTaxa = new TelaCadastroTaxaForm();

            AtualizarRodape("Tela de Edição Taxa");
            telaCadastroTaxa.Taxa = resultado.Value;

            telaCadastroTaxa.GravarRegistro = servicoTaxas.Editar;
            telaCadastroTaxa.AtualizarRodape = AtualizarRodape;
            telaCadastroTaxa.ShowDialog();

            if (telaCadastroTaxa.DialogResult == DialogResult.OK) AtualizarRodape("Edição Taxa Realizada Com Sucesso");
        }

        public void Excluir()
        {
            var id = tabelaTaxa.ObtemNumeroTaxaSelecionada();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione uma Taxa primeiro",
                    "Exclusão de Taxas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoSelecao = servicoTaxas.SelecionarPorId(id);

            if (resultadoSelecao.IsFailed)
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message,
                    "Exclusão de Taxa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var funcionarioSelecionado = resultadoSelecao.Value;

            if (MessageBox.Show("Deseja realmente excluir a taxa?", "Exclusão de Taxas",
                 MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var resultadoExclusao = servicoTaxas.Excluir(funcionarioSelecionado);

                if (resultadoExclusao.IsSuccess)
                    CarregarTaxas();
                else
                    MessageBox.Show(resultadoExclusao.Errors[0].Message,
                        "Exclusão de Taxas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxTaxa();
        }

        public override UserControl ObtemListagem()
        {
            List<Taxas> grupoVeiculos = servicoTaxas.SelecionarTodos().Value;

            tabelaTaxa.AtualizarRegistros(grupoVeiculos);

            return tabelaTaxa;
        }

        #region Métodos Privados

        private void CarregarTaxas()
        {
            var resultado = servicoTaxas.SelecionarTodos();

            if (resultado.IsSuccess)
            {
                List<Taxas> funcionarios = resultado.Value;

                tabelaTaxa.AtualizarRegistros(funcionarios);

                AtualizarRodape($"Visualizando {funcionarios.Count} taxa(s)");
            }
            else
            {
                MessageBox.Show(resultado.Errors[0].Message, "Exclusão de Taxas",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
