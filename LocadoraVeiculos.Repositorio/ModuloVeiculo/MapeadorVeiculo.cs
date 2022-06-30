using LocadoraVeiculos.Dominio.ModuloVeiculo;
using LocadoraVeiculos.RepositorioProject.shared;
using System;
using System.Collections.Generic;
using System.Data;

namespace LocadoraVeiculos.RepositorioProject.ModuloVeiculo
{
    public class MapeadorVeiculo : MapeadorBase<Veiculo>
    {
        public override Veiculo ConverterEmRegistro(IDataReader dataReader)
        {
            throw new NotImplementedException();
        }

        public override Dictionary<string, object> ObtemParametrosRegistro(Veiculo registro)
        {
            throw new NotImplementedException();
        }
    }
}
