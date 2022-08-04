using LocadoraVeiculos.Aplicacao.ModuloLocacao;
using LocadoraVeiculos.Controladores.ModuloServicoTaxas;
using LocadoraVeiculos.Dominio.ModuloLocacao;
using LocadoraVeiculos.Infra.Pdf;
using LocadoraVeiculos.WinApp.ModuloLocacao;
using LocadoraVeiculos.WinApp.shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LocadoraVeiculos.WinApp.ModuloDevolucao
{
    public class ControladorDevolucao : ConfiguracaoBase, ICadastravel
    {
        TabelaLocacaoControl tabelaLocacao;
        ServicoLocacao servicoLocacao;
        Action<string> AtualizarRodape;
        ServicoTaxas servicoTaxas;
        ValidadorLocacao validadorLocacao;
        public ControladorDevolucao(ValidadorLocacao validador,TabelaLocacaoControl tabelaLocacao, ServicoLocacao servicoLocacao, Action<string> atualizarRodape,ServicoTaxas servicoTaxas)
        {
            this.tabelaLocacao = tabelaLocacao;
            this.servicoLocacao = servicoLocacao;
            AtualizarRodape = atualizarRodape;
            this.servicoTaxas = servicoTaxas;
            validadorLocacao = validador;
        }
        public void PDF()
        {
            var id = tabelaLocacao.ObtemNumeroLocacaoSelecionada();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione uma Locação primeiro",
                    "Edição de Locação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var locacao = servicoLocacao.SelecionarPorId(id).Value;

            FolderBrowserDialog vSalvar = new FolderBrowserDialog();

            if (vSalvar.ShowDialog() == DialogResult.Cancel) return;
            var nomeLocalParaSalvar = vSalvar.SelectedPath + "\\" + "LocacaoPdf" + ".pdf";

            try
            {
                GeradorRelatorioLocacao geraPdf = new GeradorRelatorioLocacao();

                geraPdf.GerarRelatorioPdf(locacao, nomeLocalParaSalvar);
            }

            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Gerar arquivo !!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

            var locacao = resultado.Value;
            if (locacao.StatusDevolucao)
            {
                MessageBox.Show("Não pode cadastrar uma devolução já realizada", "Selecionar Locacao", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            TelaCadastroDevolucaoForm telaCadastroDevolucao = new TelaCadastroDevolucaoForm(servicoTaxas, validadorLocacao);

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

            locacoes = locacoes.OrderBy(x => x.StatusDevolucao).ToList();
            tabelaLocacao.AtualizarRegistros(locacoes);

            return tabelaLocacao;
        }
    }
}
