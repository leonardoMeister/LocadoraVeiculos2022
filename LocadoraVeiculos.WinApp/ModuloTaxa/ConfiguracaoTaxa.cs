using LocadoraVeiculos.Controladores.ModuloControladorTaxas;
using LocadoraVeiculos.Dominio.ModuloTaxas;
using LocadoraVeiculos.RepositorioProject.ModuloTaxas;
using LocadoraVeiculos.WinApp.shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraVeiculos.WinApp.ModuloTaxa
{
    public class ConfiguracaoTaxa : ConfiguracaoBase, ICadastravel
    {
        TabelaTaxaControl tabelaTaxa;
        ControladorTaxas controlador;
        TelaPrincipalForm telaPrincipal;
        TelaCadastroTaxaForm telaCadastroTaxaForm;

        public ConfiguracaoTaxa(TelaPrincipalForm telaPrincipalForm)
        {
            telaPrincipal = telaPrincipalForm;
            tabelaTaxa = new TabelaTaxaControl();
            controlador = new ControladorTaxas();


        }

        public void Editar()
        {
            telaCadastroTaxaForm = new TelaCadastroTaxaForm(telaPrincipal);

            int id = tabelaTaxa.ObtemNumeroTarefaSelecionado();
            var registro = controlador.SelecionarPorId(id);
            telaCadastroTaxaForm.Taxa = registro;

            if (telaCadastroTaxaForm.ShowDialog() == DialogResult.OK)
            {
                var grupo = telaCadastroTaxaForm.Taxa;
                controlador.Editar(grupo._id, grupo);

                telaPrincipal.AtualizarRodape("Edição Taxa Realizada Com Sucesso");
            }
        }

        public void Excluir()
        {
            int id = tabelaTaxa.ObtemNumeroTarefaSelecionado();
            try
            {
                controlador.Excluir(id);
                telaPrincipal.AtualizarRodape("Taxa Removida com sucesso.");
            }
            catch (Exception ex)
            {
                telaPrincipal.AtualizarRodape($"Não foi possivel Remover, Mensagem: {ex}");
                return;
            }
        }

        public void Inserir()
        {
            telaCadastroTaxaForm = new TelaCadastroTaxaForm(telaPrincipal);

            if (telaCadastroTaxaForm.ShowDialog() == DialogResult.OK)
            {
                var taxa = telaCadastroTaxaForm.Taxa;
                controlador.InserirNovo(taxa); 

                telaPrincipal.AtualizarRodape("Cadastro Taxa Realizada Com Sucesso");
            }
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
