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
        TabelaGrupoVeiculo tabelaGrupoVeiculos;
        ServicoGrupoVeiculos servicoGrupoVeiculos;
        Action<string> AtualizarRodape;
        public ControladorGrupoVeiculo(Action<string> atualizar)
        {
            tabelaGrupoVeiculos = new TabelaGrupoVeiculo();
            servicoGrupoVeiculos = new ServicoGrupoVeiculos();
            AtualizarRodape = atualizar;
        }

        public void Editar()
        {
            TelaCadastroGrupoVeiculo telaCadastroGrupoVeiculo = new TelaCadastroGrupoVeiculo();

            Guid id = tabelaGrupoVeiculos.ObtemNumeroTarefaSelecionado();
            var registro = servicoGrupoVeiculos.SelecionarPorId(id);

            if (registro != null)
            {
                AtualizarRodape("Tela de Edição Grupo Veiculo");
                telaCadastroGrupoVeiculo.GrupoVeiculos = registro;

                telaCadastroGrupoVeiculo.GravarRegistro = servicoGrupoVeiculos.Editar;
                telaCadastroGrupoVeiculo.AtualizarRodape = AtualizarRodape;
                telaCadastroGrupoVeiculo.ShowDialog();

                if (telaCadastroGrupoVeiculo.DialogResult == DialogResult.OK) AtualizarRodape("Edição Grupo Veiculo Realizada Com Sucesso");
            }
        }

        public void Excluir()
        {
            Guid id = tabelaGrupoVeiculos.ObtemNumeroTarefaSelecionado();
            try
            {
                servicoGrupoVeiculos.Excluir(id);
                AtualizarRodape("Grupo de Veiculos Removido com sucesso.");
            }
            catch (Exception ex)
            {
                AtualizarRodape($"Não foi possivel Remover, Mensagem: {ex}");
                return;
            }

        }

        public void Inserir()
        {
            TelaCadastroGrupoVeiculo telaCadastroGrupoVeiculo = new TelaCadastroGrupoVeiculo();

            AtualizarRodape("Tela de Adição Grupo Veiculo");

            telaCadastroGrupoVeiculo.GravarRegistro = servicoGrupoVeiculos.InserirNovo;
            telaCadastroGrupoVeiculo.AtualizarRodape = AtualizarRodape;
            telaCadastroGrupoVeiculo.ShowDialog();

            if (telaCadastroGrupoVeiculo.DialogResult == DialogResult.OK) AtualizarRodape("Cadastro Grupo Veiculo Realizado Com Sucesso");
        }

        public ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxGrupoVeiculo();
        }

        public override UserControl ObtemListagem()
        {
            List<GrupoVeiculos> grupoVeiculos = servicoGrupoVeiculos.SelecionarTodos();

            tabelaGrupoVeiculos.AtualizarRegistros(grupoVeiculos);

            return tabelaGrupoVeiculos;
        }
    }
}