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
    public class ConfiguracaoCliente : ConfiguracaoBase, ICadastravel
    {
        TabelaClienteControl tabelaCliente;
        ControladorCliente controlador;
        TelaPrincipalForm telaPrincipal;
        public ConfiguracaoCliente(TelaPrincipalForm telaPrincipalForm)
        {
            telaPrincipal = telaPrincipalForm;
            tabelaCliente = new TabelaClienteControl();
            controlador = new ControladorCliente();
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
