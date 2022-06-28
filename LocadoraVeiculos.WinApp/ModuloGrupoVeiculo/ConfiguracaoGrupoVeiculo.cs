using LocadoraVeiculos.Controladores.ModuloControladorGrupoVeiculos;
using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraVeiculos.Repositorio.shared;
using LocadoraVeiculos.WinApp.shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraVeiculos.WinApp.ModuloGrupoVeiculo
{
    public class ConfiguracaoGrupoVeiculo : ConfiguracaoBase<GrupoVeiculos>
    {
        TabelaGrupoVeiculo tabelaGrupoVeiculos;

        public ConfiguracaoGrupoVeiculo(ControladorGrupoVeiculos controlador) : base(controlador)
        {
            tabelaGrupoVeiculos = new TabelaGrupoVeiculo();

        }

        public override UserControl ObtemListagem()
        {
            List<GrupoVeiculos> grupoVeiculos = Controlador.SelecionarTodos();

            tabelaGrupoVeiculos.AtualizarRegistros(grupoVeiculos);

            return tabelaGrupoVeiculos;
        }

        public override ConfiguracaoToolboxBase ObterConfiguracao()
        {
            return new ConfiguracaoToolBoxGrupoVeiculo();
        }
    }
}
