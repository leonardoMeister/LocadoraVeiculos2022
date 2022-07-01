using LocadoraVeiculos.Dominio.ModuloCondutores;
using LocadoraVeiculos.RepositorioProject.shared;
using System;
using System.Collections.Generic;
using System.Data;

namespace LocadoraVeiculos.RepositorioProject.ModuloCondutores
{
    public class MapeadorCondutores : MapeadorBase<Condutores>
    {
        public override Condutores ConverterEmRegistro(IDataReader dataReader)
        {
            throw new NotImplementedException();
        }

        public override Dictionary<string, object> ObtemParametrosRegistro(Condutores registro)
        {
            throw new NotImplementedException();
        }
    }
}
