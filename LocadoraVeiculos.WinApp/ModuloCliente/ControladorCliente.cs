using LocadoraVeiculos.Controladores.ModuloServicoCliente;
using LocadoraVeiculos.Dominio.ModuloCliente;
using LocadoraVeiculos.WinApp.shared;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculos.WinApp.ModuloCliente
{
    public class ControladorCliente : ConfiguracaoBase, ICadastravel
    {
        Action<string> AtualizarRodape;
        ServicoCliente servicoCliente;
        TabelaClienteControl tabelaClienteControl;

        public ControladorCliente(Action<string> atualizar)
        {
            AtualizarRodape = atualizar;
            tabelaClienteControl = new TabelaClienteControl();
            servicoCliente = new ServicoCliente();
        }


        public void Editar()
        {
            TelaCadastroClienteForm telaCadastroCliente = new();

            Guid id = tabelaClienteControl.ObtemNumeroClienteSelecionado();
            var registro = servicoCliente.SelecionarPorId(id);

            if (registro != null)
            {
                AtualizarRodape("Tela de Edição Cliente");
                telaCadastroCliente.Cliente = registro;

                telaCadastroCliente.GravarRegistro = servicoCliente.Editar;
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
                servicoCliente.Excluir(id);
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

            telaCadastroCliente.GravarRegistro = servicoCliente.InserirNovo;
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
            List<Cliente> clientes = servicoCliente.SelecionarTodos();

            tabelaClienteControl.AtualizarRegistros(clientes);

            return tabelaClienteControl;
        }
    }
}
