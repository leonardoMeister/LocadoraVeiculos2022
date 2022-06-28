using LocadoraVeiculos.Controladores.ModuloControladorCliente;
using LocadoraVeiculos.Dominio.ModuloCliente;
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
    public class ConfiguracaoCliente : ConfiguracaoBase<Cliente>, ICadastravel
    {
        TabelaClienteControl tabelaCliente;
        ControladorCliente controlador;

        public ConfiguracaoCliente()
        {
            tabelaCliente = new TabelaClienteControl();
            controlador = new ControladorCliente(new ValidadorCliente(), new RepositorioCliente(new MapeadorCliente()));
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
            return new ConfiguracaoToolBoxCliente();
        }

        public override UserControl ObtemListagem()
        {
            List<Cliente> grupoVeiculos = controlador.SelecionarTodos();

            tabelaCliente.AtualizarRegistros(grupoVeiculos);

            return tabelaCliente;
        }
    }
}
