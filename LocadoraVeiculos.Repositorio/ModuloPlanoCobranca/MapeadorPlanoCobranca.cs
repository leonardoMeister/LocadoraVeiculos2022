using LocadoraVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraVeiculos.RepositorioProject.shared;
using System;
using System.Collections.Generic;
using System.Data;

namespace LocadoraVeiculos.RepositorioProject.ModuloPlanoCobranca
{
    public class MapeadorPlanoCobranca : MapeadorBase<PlanoCobranca>
    {
        public override PlanoCobranca ConverterEmRegistro(IDataReader dataReader)
        {
            throw new NotImplementedException();
        }

        public override Dictionary<string, object> ObtemParametrosRegistro(PlanoCobranca registro)
        {
            throw new NotImplementedException();
        }
    }
}
