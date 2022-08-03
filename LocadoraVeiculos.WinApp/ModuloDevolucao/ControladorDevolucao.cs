using LocadoraVeiculos.Aplicacao.ModuloLocacao;
using LocadoraVeiculos.Controladores.ModuloServicoTaxas;
using LocadoraVeiculos.Dominio.ModuloLocacao;
using LocadoraVeiculos.WinApp.ModuloLocacao;
using LocadoraVeiculos.WinApp.shared;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculos.WinApp.ModuloDevolucao
{
    public class ControladorDevolucao : ConfiguracaoBase, ICadastravel
    {
        TabelaLocacaoControl tabelaLocacao;
        ServicoLocacao servicoLocacao;
        Action<string> AtualizarRodape;
        ServicoTaxas servicoTaxas;
        public ControladorDevolucao(TabelaLocacaoControl tabelaLocacao, ServicoLocacao servicoLocacao, Action<string> atualizarRodape,ServicoTaxas servicoTaxas)
        {
            this.tabelaLocacao = tabelaLocacao;
            this.servicoLocacao = servicoLocacao;
            AtualizarRodape = atualizarRodape;
            this.servicoTaxas = servicoTaxas;
        }

        public void Editar()
        {
            var id = tabelaLocacao.ObtemNumeroLocacaoSelecionada();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione uma Locação primeiro",
                    "Cadastro Devolução", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultado = servicoLocacao.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                    "Cadastro Devolução", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var funcionarioSelecionado = resultado.Value;

            TelaCadastroDevolucaoForm telaCadastroDevolucao = new TelaCadastroDevolucaoForm(servicoTaxas);

            AtualizarRodape("Tela de Cadastro de Devolução");
            telaCadastroDevolucao.Locacao = resultado.Value;

            telaCadastroDevolucao.GravarRegistro = servicoLocacao.Editar;
            telaCadastroDevolucao.AtualizarRodape = AtualizarRodape;
            telaCadastroDevolucao.ShowDialog();

            if (telaCadastroDevolucao.DialogResult == DialogResult.OK) AtualizarRodape("Cadastro de Devolução Realizada Com Sucesso");
        }

        public void Excluir()
        {            
        }

        public void Inserir()
        {
            
        }

        public ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxDevolucao();
        }

        public override UserControl ObtemListagem()
        {
            List<Locacao> locacoes = servicoLocacao.SelecionarTodos().Value;

            tabelaLocacao.AtualizarRegistros(locacoes);

            return tabelaLocacao;
        }
    }
}
