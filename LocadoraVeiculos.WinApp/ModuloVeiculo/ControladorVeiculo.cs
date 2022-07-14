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
        ServicoVeiculo ServicoVeiculo;
        Action<string> AtualizarRodape;
        public ControladorVeiculo(Action<string> atualizar)
        {
            AtualizarRodape = atualizar;
            ServicoVeiculo = new();
            tabelaVeiculo = new();
        }

        public void Editar()
        {
            TelaCadastroVeiculo telaCadastroVeiculo = new();

            Guid id = tabelaVeiculo.ObtemNumeroVeiculoSelecionado();
            var registro = ServicoVeiculo.SelecionarPorId(id).Value;

            if (registro != null)
            {
                AtualizarRodape("Tela de Edição Veiculo");
                telaCadastroVeiculo.Veiculo = registro;

                telaCadastroVeiculo.GravarRegistro = ServicoVeiculo.Editar;
                telaCadastroVeiculo.AtualizarRodape = AtualizarRodape;
                telaCadastroVeiculo.ShowDialog();

                if (telaCadastroVeiculo.DialogResult == DialogResult.OK) AtualizarRodape("Edição Veiculo Realizada Com Sucesso");
            }
        }

        public void Excluir()
        {
            Guid id = tabelaVeiculo.ObtemNumeroVeiculoSelecionado();
            try
            {
                ServicoVeiculo.Excluir(ServicoVeiculo.SelecionarPorId(id).Value);
                AtualizarRodape("Veiculo Removido com sucesso.");
            }
            catch (Exception ex)
            {
                AtualizarRodape($"Não foi possivel Remover, Mensagem: {ex}");
                return;
            }
        }

        public void Inserir()
        {
            TelaCadastroVeiculo telaCadastroVeiculo = new();

            AtualizarRodape("Tela de Adição Veiculo");

            telaCadastroVeiculo.GravarRegistro = ServicoVeiculo.InserirNovo;
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
            List<Veiculo> veiculos = ServicoVeiculo.SelecionarTodos().Value;

            tabelaVeiculo.AtualizarRegistros(veiculos);

            return tabelaVeiculo;
        }
    }
}
