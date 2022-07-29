using LocadoraVeiculos.Aplicacao.ModuloLocacao;
using LocadoraVeiculos.Controladores.ModuloServicoCliente;
using LocadoraVeiculos.Controladores.ModuloServicoCondutores;
using LocadoraVeiculos.Controladores.ModuloServicoGrupoVeiculos;
using LocadoraVeiculos.Controladores.ModuloServicoPlanoCobranca;
using LocadoraVeiculos.Controladores.ModuloServicoTaxas;
using LocadoraVeiculos.Controladores.ModuloServicoVeiculo;
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


        public void Editar()
        {
            var id = tabelaLocacao.ObtemNumeroVeiculoSelecionado();

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

            var funcionarioSelecionado = resultado.Value;

            TelaCadastroLocacaoForm telaCadastroLocacao = new TelaCadastroLocacaoForm(servicoVeiculo, servicoCondutores, servicoGrupoVeiculos,
                                                                                      servicoPlanoCobranca, servicoTaxas, servicoCliente);

            AtualizarRodape("Tela de Edição de Locação");
            telaCadastroLocacao.Locacao = resultado.Value.Clone();

            telaCadastroLocacao.GravarRegistro = servicoLocacao.Editar;
            telaCadastroLocacao.AtualizarRodape = AtualizarRodape;
            telaCadastroLocacao.ShowDialog();

            if (telaCadastroLocacao.DialogResult == DialogResult.OK) AtualizarRodape("Edição de Locação Realizada Com Sucesso");
        }

        public void Excluir()
        {
            throw new NotImplementedException();
        }

        public void Inserir()
        {
            throw new NotImplementedException();
        }

        public ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            throw new NotImplementedException();
        }

        public override UserControl ObtemListagem()
        {
            throw new NotImplementedException();
        }
    }
}
