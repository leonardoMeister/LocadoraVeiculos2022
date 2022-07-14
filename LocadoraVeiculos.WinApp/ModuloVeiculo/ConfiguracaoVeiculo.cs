using LocadoraVeiculos.Controladores.ModuloVeiculo;
using LocadoraVeiculos.Dominio.ModuloVeiculo;
using LocadoraVeiculos.WinApp.shared;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculos.WinApp.ModuloVeiculo
{
    public class ConfiguracaoVeiculo : ConfiguracaoBase, ICadastravel
    {
        TabelaVeiculoControl tabelaVeiculo;
        ControladorVeiculo ControladorVeiculo;
        Action<string> AtualizarRodape;
        public ConfiguracaoVeiculo(Action<string> atualizar)
        {
            AtualizarRodape = atualizar;
            ControladorVeiculo = new();
            tabelaVeiculo = new();
        }

        public void Editar()
        {
            TelaCadastroVeiculo telaCadastroVeiculo = new();

            Guid id = tabelaVeiculo.ObtemNumeroVeiculoSelecionado();
            var registro = ControladorVeiculo.SelecionarPorId(id);

            if (registro != null)
            {
                AtualizarRodape("Tela de Edição Veiculo");
                telaCadastroVeiculo.Veiculo = registro;

                telaCadastroVeiculo.GravarRegistro = ControladorVeiculo.Editar;
                telaCadastroVeiculo.AtualizarRodape = AtualizarRodape;
                telaCadastroVeiculo.ShowDialog();

                if (telaCadastroVeiculo.DialogResult == DialogResult.OK) AtualizarRodape("Edição Veiculo Realizada Com Sucesso");
            }
        }

        public void Excluir()
        {
            var id = tabelaVeiculo.ObtemNumeroVeiculoSelecionado();
            try
            {
                ControladorVeiculo.Excluir(id);
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

            telaCadastroVeiculo.GravarRegistro = ControladorVeiculo.InserirNovo;
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
            List<Veiculo> veiculos = ControladorVeiculo.SelecionarTodos();

            tabelaVeiculo.AtualizarRegistros(veiculos);

            return tabelaVeiculo;
        }
    }
}
