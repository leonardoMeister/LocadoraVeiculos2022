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
        public ConfiguracaoGrupoVeiculo(ControladorGrupoVeiculos controlador) : base(controlador)
        {
            
        }

        public override UserControl ObtemListagem()
        {
            throw new NotImplementedException();
        }

        public override ConfiguracaoToolboxBase ObterConfiguracao()
        {
            throw new NotImplementedException();
        }
    }
}
