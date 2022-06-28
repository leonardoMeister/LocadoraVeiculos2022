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
    public abstract class ConfiguracaoBase<T> where T : EntidadeBase 
    {   
        public abstract UserControl ObtemListagem();
        
    }
}
