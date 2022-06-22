using LocadoraVeiculos.Dominio.ModuloTaxas;
using LocadoraVeiculos.RepositorioProject.shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.RepositorioProject.ModuloTaxas
{
    public class RepositorioTaxas : Repositorio<Taxas, ValidadorTaxas, MapeadorTaxas>
    {
        protected override string SqlUpdate => throw new NotImplementedException();

        protected override string SqlDelete => throw new NotImplementedException();

        protected override string SqlInsert => throw new NotImplementedException();

        protected override string SqlSelectAll => throw new NotImplementedException();

        protected override string SqlSelectId => throw new NotImplementedException();

        protected override string SqlExiste => throw new NotImplementedException();
    }
}
