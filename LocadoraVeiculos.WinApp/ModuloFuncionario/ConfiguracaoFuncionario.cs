using LocadoraVeiculos.Controladores.ModuloFuncionario;
using LocadoraVeiculos.Dominio.ModuloFuncionario;
using LocadoraVeiculos.RepositorioProject.ModuloFuncionario;
using LocadoraVeiculos.WinApp.shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraVeiculos.WinApp.ModuloFuncionario
{
    public class ConfiguracaoFuncionario : ConfiguracaoBase, ICadastravel
    {

        TabelaFuncionarioControl tabelaFuncionario;
        ControladorFuncionario controlador;
        TelaPrincipalForm telaPrincipal;
        public ConfiguracaoFuncionario(TelaPrincipalForm telaPrincipalForm)
        {
            telaPrincipal = telaPrincipalForm;
            tabelaFuncionario = new TabelaFuncionarioControl();
            controlador = new ControladorFuncionario( );
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
            return new ConfiguracaoTollBoxFuncionario();
        }

        public override UserControl ObtemListagem()
        {
            List<Funcionario> grupoVeiculos = controlador.SelecionarTodos();

            tabelaFuncionario.AtualizarRegistros(grupoVeiculos);

            return tabelaFuncionario;
        }
    }
}
