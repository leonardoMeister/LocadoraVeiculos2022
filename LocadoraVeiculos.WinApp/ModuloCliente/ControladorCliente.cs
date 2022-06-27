using LocadoraVeiculos.RepositorioProject.ModuloCliente;
using LocadoraVeiculos.WinApp.shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraVeiculos.WinApp.ModuloCliente
{
    internal class ControladorCliente : ICadastravel
    {
        RepositorioCliente repositorioCliente;

        public ControladorCliente()
        {
            repositorioCliente = new RepositorioCliente(new MapeadorCliente());
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
            throw new NotImplementedException();
        }

        public UserControl ObtemListagem()
        {
            throw new NotImplementedException();
        }
    }
}
