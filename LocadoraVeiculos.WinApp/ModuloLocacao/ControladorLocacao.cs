using LocadoraVeiculos.Aplicacao.ModuloLocacao;
using LocadoraVeiculos.Controladores.ModuloServicoCliente;
using LocadoraVeiculos.Controladores.ModuloServicoCondutores;
using LocadoraVeiculos.Controladores.ModuloServicoGrupoVeiculos;
using LocadoraVeiculos.Controladores.ModuloServicoPlanoCobranca;
using LocadoraVeiculos.Controladores.ModuloServicoTaxas;
using LocadoraVeiculos.Controladores.ModuloServicoVeiculo;
using LocadoraVeiculos.Dominio.ModuloLocacao;
using LocadoraVeiculos.Infra.Pdf;
using LocadoraVeiculos.WinApp.ModuloVeiculo;
using LocadoraVeiculos.WinApp.shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraVeiculos.WinApp.ModuloLocacao
{
    public class ControladorLocacao : ConfiguracaoBase, ICadastravel
    {
        TabelaLocacaoControl tabelaLocacao;
        ServicoLocacao servicoLocacao;
        ServicoVeiculo servicoVeiculo;
        ServicoCondutores servicoCondutores;
        ServicoCliente servicoCliente;
        ServicoGrupoVeiculos servicoGrupoVeiculos;
        ServicoPlanoCobranca servicoPlanoCobranca;
        ServicoTaxas servicoTaxas;
        Action<string> AtualizarRodape;

        public ControladorLocacao(TabelaLocacaoControl tabelaLocacao, ServicoLocacao servicoLocacao, ServicoVeiculo servicoVeiculo, ServicoCondutores servicoCondutores, ServicoCliente servicoCliente, ServicoGrupoVeiculos servicoGrupoVeiculos, ServicoPlanoCobranca servicoPlanoCobranca, ServicoTaxas servicoTaxas, Action<string> atualizarRodape)
        {
            this.tabelaLocacao = tabelaLocacao;
            this.servicoLocacao = servicoLocacao;
            this.servicoVeiculo = servicoVeiculo;
            this.servicoCondutores = servicoCondutores;
            this.servicoCliente = servicoCliente;
            this.servicoGrupoVeiculos = servicoGrupoVeiculos;
            this.servicoPlanoCobranca = servicoPlanoCobranca;
            this.servicoTaxas = servicoTaxas;
            AtualizarRodape = atualizarRodape;
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
                    "Edição de Locação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultado = servicoLocacao.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                    "Edição de Funcionário", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            TelaCadastroLocacaoForm telaCadastroLocacao = new TelaCadastroLocacaoForm(servicoVeiculo, servicoCondutores, servicoGrupoVeiculos,
                                                                                      servicoPlanoCobranca, servicoTaxas, servicoCliente);

            AtualizarRodape("Tela de Edição de Locação");
            telaCadastroLocacao.Locacao = resultado.Value;

            telaCadastroLocacao.GravarRegistro = servicoLocacao.Editar;
            telaCadastroLocacao.AtualizarRodape = AtualizarRodape;
            telaCadastroLocacao.ShowDialog();

            if (telaCadastroLocacao.DialogResult == DialogResult.OK) AtualizarRodape("Edição de Locação Realizada Com Sucesso");
        }

        public void Excluir()
        {
            var id = tabelaLocacao.ObtemNumeroLocacaoSelecionada();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione uma Locação primeiro",
                    "Exclusão de Locação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoSelecao = servicoVeiculo.SelecionarPorId(id);

            if (resultadoSelecao.IsFailed)
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message,
                    "Exclusão de Locação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var veiculoSelecionado = resultadoSelecao.Value;

            if (MessageBox.Show("Deseja realmente excluir a Locação?", "Exclusão de Locação",
                 MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var resultadoExclusao = servicoVeiculo.Excluir(veiculoSelecionado);

                if (resultadoExclusao.IsSuccess)
                    CarregarLocacoes();
                else
                    MessageBox.Show(resultadoExclusao.Errors[0].Message,
                        "Exclusão de Locação", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarLocacoes()
        {
            var resultado = servicoLocacao.SelecionarTodos();

            if (resultado.IsSuccess)
            {
                List<Locacao> locacoes = resultado.Value;

                tabelaLocacao.AtualizarRegistros(locacoes);

                AtualizarRodape($"Visualizando {locacoes.Count} Locações(s)");
            }
            else
            {
                MessageBox.Show(resultado.Errors[0].Message, "Exclusão de Locação",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Inserir()
        {
            TelaCadastroLocacaoForm telaCadastroVeiculo = new TelaCadastroLocacaoForm(servicoVeiculo, servicoCondutores, servicoGrupoVeiculos, servicoPlanoCobranca,
                                                              servicoTaxas, servicoCliente);

            AtualizarRodape("Tela Adição de Locação");

            telaCadastroVeiculo.locacao = new Locacao();
            telaCadastroVeiculo.GravarRegistro = servicoLocacao.InserirNovo;
            telaCadastroVeiculo.AtualizarRodape = AtualizarRodape;
            telaCadastroVeiculo.ShowDialog();

            if (telaCadastroVeiculo.DialogResult == DialogResult.OK) AtualizarRodape("Cadastro Locação Realizada Com Sucesso");
        }

        public ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxLocacao();
        }

        public override UserControl ObtemListagem()
        {
            List<Locacao> locacoes = servicoLocacao.SelecionarTodos().Value;

            tabelaLocacao.AtualizarRegistros(locacoes);

            return tabelaLocacao;
        }
    }
}
