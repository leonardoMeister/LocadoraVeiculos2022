using LocadoraVeiculos.Controladores.ModuloServicoTaxas;
using LocadoraVeiculos.Dominio.ModuloTaxas;
using LocadoraVeiculos.WinApp.shared;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculos.WinApp.ModuloTaxa
{
    public class ConfiguracaoTaxa : ConfiguracaoBase, ICadastravel
    {
        TabelaTaxaControl tabelaTaxa;
        ServicoTaxas controlador;
        Action<string> AtualizarRodape;
        public ConfiguracaoTaxa(Action<string> atualizar)
        {
            tabelaTaxa = new TabelaTaxaControl();
            controlador = new ServicoTaxas();
            AtualizarRodape = atualizar;
        }

        public void Editar()
        {
            TelaCadastroTaxaForm telaCadastroTaxa = new TelaCadastroTaxaForm();

            Guid id = tabelaTaxa.ObtemNumeroTarefaSelecionado();
            var registro = controlador.SelecionarPorId(id);

            if (registro != null)
            {
                AtualizarRodape("Tela de Edição Taxa");
                telaCadastroTaxa.Taxa = registro;

                telaCadastroTaxa.GravarRegistro = controlador.Editar;
                telaCadastroTaxa.AtualizarRodape = AtualizarRodape;
                telaCadastroTaxa.ShowDialog();

                if (telaCadastroTaxa.DialogResult == DialogResult.OK) AtualizarRodape("Edição Taxa Realizada Com Sucesso");
            }
        }

        public void Excluir()
        {
            Guid id = tabelaTaxa.ObtemNumeroTarefaSelecionado();
            try
            {
                controlador.Excluir(id);
                AtualizarRodape("Taxa Removida com sucesso.");
            }
            catch (Exception ex)
            {
                AtualizarRodape($"Não foi possivel Remover, Mensagem: {ex}");
                return;
            }
        }

        public void Inserir()
        {
            TelaCadastroTaxaForm telaCadastroGrupoVeiculo = new TelaCadastroTaxaForm();

            AtualizarRodape("Tela de Adição Taxa");

            telaCadastroGrupoVeiculo.GravarRegistro = controlador.InserirNovo;
            telaCadastroGrupoVeiculo.AtualizarRodape = AtualizarRodape;
            telaCadastroGrupoVeiculo.ShowDialog();

            if (telaCadastroGrupoVeiculo.DialogResult == DialogResult.OK) AtualizarRodape("Cadastro Taxa Realizado Com Sucesso");
        }

        public ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxTaxa();
        }

        public override UserControl ObtemListagem()
        {
            List<Taxas> grupoVeiculos = controlador.SelecionarTodos();

            tabelaTaxa.AtualizarRegistros(grupoVeiculos);

            return tabelaTaxa;
        }

    }
}
