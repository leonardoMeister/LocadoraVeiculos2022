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
    public class ConfiguracaoTaxa : ConfiguracaoBase<Taxas>, ICadastravel
    {
        TabelaTaxaControl tabelaTaxa; 
        ControladorTaxas controlador;
        public ConfiguracaoTaxa()
        {
            tabelaTaxa = new TabelaTaxaControl();
            controlador = new ControladorTaxas(new ValidadorTaxas(), new RepositorioTaxas(new MapeadorTaxas()));

        }

        public void Editar()
        {
            throw new NotImplementedException();
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
