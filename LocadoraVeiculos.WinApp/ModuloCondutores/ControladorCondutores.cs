using LocadoraVeiculos.Controladores.ModuloServicoCondutores;
using LocadoraVeiculos.Dominio.ModuloCondutores;
using LocadoraVeiculos.WinApp.shared;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculos.WinApp.ModuloCondutores
{
    public class ControladorCondutores : ConfiguracaoBase, ICadastravel
    {
        Action<string> AtualizarRodape;
        ServicoCondutores servicoCondutores;
        TabelaCondutoresControl tabelaCondutoresControl;

        public ControladorCondutores(Action<string> atualizar)
        {
            AtualizarRodape = atualizar;
            tabelaCondutoresControl = new TabelaCondutoresControl();
            servicoCondutores = new ServicoCondutores();
        }


        public void Editar()
        {
            TelaCadastroCondutoresForm telaCadastroCondutores = new();

            Guid id = tabelaCondutoresControl.ObtemNumeroCondutoresSelecionado();
            var registro = servicoCondutores.SelecionarPorId(id);

            if (registro != null)
            {
                AtualizarRodape("Tela de Edição Condutores");
                telaCadastroCondutores.Condutores = registro;

                telaCadastroCondutores.GravarRegistro = servicoCondutores.Editar;
                telaCadastroCondutores.AtualizarRodape = AtualizarRodape;
                telaCadastroCondutores.ShowDialog();

                if (telaCadastroCondutores.DialogResult == DialogResult.OK) AtualizarRodape("Edição Condutor Realizada Com Sucesso");
            }
        }

        public void Excluir()
        {
            Guid id = tabelaCondutoresControl.ObtemNumeroCondutoresSelecionado();
            try
            {
                servicoCondutores.Excluir(id);
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

            telaCadastroCondutores.GravarRegistro = servicoCondutores.InserirNovo;
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
            List<Condutores> condutores = servicoCondutores.SelecionarTodos();

            tabelaCondutoresControl.AtualizarRegistros(condutores);

            return tabelaCondutoresControl;
        }
    }
}
