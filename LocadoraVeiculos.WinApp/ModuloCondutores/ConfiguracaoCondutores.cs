using LocadoraVeiculos.Controladores.ModuloCondutores;
using LocadoraVeiculos.Dominio.ModuloCondutores;
using LocadoraVeiculos.WinApp.shared;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculos.WinApp.ModuloCondutores
{
    public class ConfiguracaoCondutores : ConfiguracaoBase, ICadastravel
    {
        Action<string> AtualizarRodape;
        ControladorCondutores controlador;
        TabelaCondutoresControl tabelaCondutoresControl;

        public ConfiguracaoCondutores(Action<string> atualizar)
        {
            AtualizarRodape = atualizar;
            tabelaCondutoresControl = new TabelaCondutoresControl();
            controlador = new ControladorCondutores();
        }


        public void Editar()
        {
            TelaCadastroCondutoresForm telaCadastroCondutores = new();

            int id = tabelaCondutoresControl.ObtemNumeroCondutoresSelecionado();
            var registro = controlador.SelecionarPorId(id);

            if (registro != null)
            {
                AtualizarRodape("Tela de Edição Condutores");
                telaCadastroCondutores.Condutores = registro;

                telaCadastroCondutores.GravarRegistro = controlador.Editar;
                telaCadastroCondutores.AtualizarRodape = AtualizarRodape;
                telaCadastroCondutores.ShowDialog();

                if (telaCadastroCondutores.DialogResult == DialogResult.OK) AtualizarRodape("Edição Condutor Realizada Com Sucesso");
            }
        }

        public void Excluir()
        {
            int id = tabelaCondutoresControl.ObtemNumeroCondutoresSelecionado();
            try
            {
                controlador.Excluir(id);
                AtualizarRodape("Condutores Removido com sucesso.");
            }
            catch (Exception ex)
            {
                AtualizarRodape($"Não foi possivel Remover, Mensagem: {ex}");
                return;
            }
        }

        public void Inserir()
        {
            TelaCadastroCondutoresForm telaCadastroCondutores = new();

            AtualizarRodape("Tela de Adição Condutores");

            telaCadastroCondutores.GravarRegistro = controlador.InserirNovo;
            telaCadastroCondutores.AtualizarRodape = AtualizarRodape;
            telaCadastroCondutores.ShowDialog();

            if (telaCadastroCondutores.DialogResult == DialogResult.OK) AtualizarRodape("Cadastro Condutor Realizado Com Sucesso");
        }

        public ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxCondutores();
        }

        public override UserControl ObtemListagem()
        {
            List<Condutores> condutores = controlador.SelecionarTodos();

            tabelaCondutoresControl.AtualizarRegistros(condutores);

            return tabelaCondutoresControl;
        }
    }
}
