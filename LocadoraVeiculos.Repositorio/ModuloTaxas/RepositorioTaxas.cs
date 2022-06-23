using LocadoraVeiculos.Dominio.ModuloTaxas;
using LocadoraVeiculos.Repositorio.shared;
using LocadoraVeiculos.RepositorioProject.shared;
using System;

namespace LocadoraVeiculos.RepositorioProject.ModuloTaxas
{
    public class RepositorioTaxas : RepositorioSQL<Taxas>
    {
        public RepositorioTaxas(MapeadorBase<Taxas> mapeador) : base(mapeador)
        {
        }

        protected override string SqlUpdate => throw new NotImplementedException();

        protected override string SqlDelete => throw new NotImplementedException();

        protected override string SqlInsert => throw new NotImplementedException();

        protected override string SqlSelectAll => throw new NotImplementedException();

        protected override string SqlSelectId => throw new NotImplementedException();

        protected override string SqlExiste => throw new NotImplementedException();
    }
}
