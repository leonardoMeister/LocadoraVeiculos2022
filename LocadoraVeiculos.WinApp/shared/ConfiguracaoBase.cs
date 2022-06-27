using LocadoraVeiculos.Dominio.shared;
using LocadoraVeiculos.Repositorio.shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraVeiculos.WinApp.shared
{
    public abstract class ConfiguracaoBase<T> : ICadastravel where T : EntidadeBase 
    {
        public Controlador<T> Controlador;

        public ConfiguracaoBase(Controlador<T> controlador)
        {
            Controlador = controlador;
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

        public abstract UserControl ObtemListagem();

        public abstract ConfiguracaoToolboxBase ObterConfiguracao();
    }
}
