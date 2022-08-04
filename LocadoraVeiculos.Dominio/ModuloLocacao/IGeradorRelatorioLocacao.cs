using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Dominio.ModuloLocacao
{
    public interface IGeradorRelatorioLocacao
    {
        void GerarRelatorioPdf(Locacao locacao, string caminhoArquivo);
    }
}
