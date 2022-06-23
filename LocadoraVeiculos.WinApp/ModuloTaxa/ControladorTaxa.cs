using LocadoraVeiculos.RepositorioProject.ModuloTaxas;
using LocadoraVeiculos.WinApp.shared;
using System;
using System.Windows.Forms;

namespace LocadoraVeiculos.WinApp.ModuloTaxa
{
    internal class ControladorTaxa : ControladorBase
    {
        RepositorioTaxas repositorioTaxas;

        TabelaTaxaControl tabelaTaxaControl;

        public ControladorTaxa()
        {
            repositorioTaxas = new RepositorioTaxas();
        }

        public override void Editar()
        {
            throw new NotImplementedException();
        }

        public override void Excluir()
        {
            throw new NotImplementedException();
        }

        public override void Inserir()
        {
            throw new NotImplementedException();
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxTaxa();
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaTaxaControl == null)
                tabelaTaxaControl = new TabelaTaxaControl();

            CarregarTarefas();

            return tabelaTaxaControl;
        }

        private void CarregarTarefas()
        {
            repositorioTaxas.
        }
    }
}
