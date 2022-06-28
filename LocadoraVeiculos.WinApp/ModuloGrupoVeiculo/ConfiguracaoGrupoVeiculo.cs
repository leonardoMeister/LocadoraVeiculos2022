using LocadoraVeiculos.Controladores.ModuloControladorGrupoVeiculos;
using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraVeiculos.Repositorio.shared;
using LocadoraVeiculos.RepositorioProject.ModuloGrupoVeiculos;
using LocadoraVeiculos.WinApp.shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraVeiculos.WinApp.ModuloGrupoVeiculo
{
    public class ConfiguracaoGrupoVeiculo : ConfiguracaoBase<GrupoVeiculos>, ICadastravel
    {
        TabelaGrupoVeiculo tabelaGrupoVeiculos;
        ControladorGrupoVeiculos controlador;

        public ConfiguracaoGrupoVeiculo()
        {
            tabelaGrupoVeiculos = new TabelaGrupoVeiculo();
            controlador = new ControladorGrupoVeiculos(new ValidadorGrupoVeiculos(), new RepositorioGrupoVeiculos(new MapeadorGrupoVeiculos()));

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
            Console.WriteLine("Aqui");
        }

        public ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxGrupoVeiculo();
        }

        public override UserControl ObtemListagem()
        {
            List<GrupoVeiculos> grupoVeiculos = controlador.SelecionarTodos();

            tabelaGrupoVeiculos.AtualizarRegistros(grupoVeiculos);

            return tabelaGrupoVeiculos;
        }

    }
}
