using LocadoraVeiculos.Dominio.ModuloTaxas;
using LocadoraVeiculos.RepositorioProject.shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.RepositorioProject.ModuloTaxas
{
    public class MapeadorTaxas : MapeadorBase<Taxas>
    {
        public override Taxas ConverterEmRegistro(IDataReader dataReader)
        {
            throw new NotImplementedException();
        }

        public override Dictionary<string, object> ObtemParametrosRegistro(Taxas registro)
        {
            throw new NotImplementedException();
        }
    }
}
