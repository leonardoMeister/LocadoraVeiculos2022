using LocadoraVeiculos.WinApp.shared;
using System;
using System.Windows.Forms;

namespace LocadoraVeiculos.WinApp.ModuloTarefa
{
    internal class ControladorTarefa : ControladorBase
    {
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
            throw new NotImplementedException();
        }
    }
}
