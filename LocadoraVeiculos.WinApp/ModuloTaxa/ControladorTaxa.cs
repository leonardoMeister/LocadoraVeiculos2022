using LocadoraVeiculos.RepositorioProject.ModuloTaxas;
using LocadoraVeiculos.WinApp.shared;
using System;
using System.Windows.Forms;

namespace LocadoraVeiculos.WinApp.ModuloTaxa
{
    internal class ControladorTaxa : ICadastravel
    {
        RepositorioTaxas repositorioTaxas;

        TabelaTaxaControl tabelaTaxaControl;

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
            throw new NotImplementedException();
        }

        public UserControl ObtemListagem()
        {
            if (tabelaTaxaControl == null)
                tabelaTaxaControl = new TabelaTaxaControl();

            CarregarTarefas();

            return tabelaTaxaControl;
        }

        private void CarregarTarefas()
        {
            throw new NotImplementedException();
        }
    }
}
