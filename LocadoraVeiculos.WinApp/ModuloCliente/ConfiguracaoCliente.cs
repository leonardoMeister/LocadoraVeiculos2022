using LocadoraVeiculos.Controladores.ModuloControladorCliente;
using LocadoraVeiculos.Dominio.ModuloCliente;
using LocadoraVeiculos.WinApp.shared;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculos.WinApp.ModuloCliente
{
    public class ConfiguracaoCliente : ConfiguracaoBase, ICadastravel
    {
        Action<string> AtualizarRodape;
        ControladorCliente controlador;
        TabelaClienteControl tabelaClienteControl;

        public ConfiguracaoCliente(Action<string> atualizar)
        {
            AtualizarRodape = atualizar;
            tabelaClienteControl = new TabelaClienteControl();
            controlador = new ControladorCliente();
        }


        public void Editar()
        {
            TelaCadastroClienteForm telaCadastroCliente = new();

            Guid id = tabelaClienteControl.ObtemNumeroClienteSelecionado();
            var registro = controlador.SelecionarPorId(id);

            if (registro != null)
            {
                AtualizarRodape("Tela de Edição Cliente");
                telaCadastroCliente.Cliente = registro;

                telaCadastroCliente.GravarRegistro = controlador.Editar;
                telaCadastroCliente.AtualizarRodape = AtualizarRodape;
                telaCadastroCliente.ShowDialog();

                if (telaCadastroCliente.DialogResult == DialogResult.OK) AtualizarRodape("Edição Cliente Realizada Com Sucesso");
            }
        }

        public void Excluir()
        {
            Guid id = tabelaClienteControl.ObtemNumeroClienteSelecionado();
            try
            {
                controlador.Excluir(id);
                AtualizarRodape("Cliente Removido com sucesso.");
            }
            catch (Exception ex)
            {
                AtualizarRodape($"Não foi possivel Remover, Mensagem: {ex}");
                return;
            }
        }

        public void Inserir()
        {
            TelaCadastroClienteForm telaCadastroCliente = new();

            AtualizarRodape("Tela de Adição Cliente");

            telaCadastroCliente.GravarRegistro = controlador.InserirNovo;
            telaCadastroCliente.AtualizarRodape = AtualizarRodape;
            telaCadastroCliente.ShowDialog();

            if (telaCadastroCliente.DialogResult == DialogResult.OK) AtualizarRodape("Cadastro Cliente Realizado Com Sucesso");
        }

        public ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxCliente();
        }

        public override UserControl ObtemListagem()
        {
            List<Cliente> clientes = controlador.SelecionarTodos();

            tabelaClienteControl.AtualizarRegistros(clientes);

            return tabelaClienteControl;
        }
    }
}
