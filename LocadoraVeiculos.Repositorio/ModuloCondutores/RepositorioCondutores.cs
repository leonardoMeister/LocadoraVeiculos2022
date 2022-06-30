using LocadoraVeiculos.Dominio.ModuloCondutores;
using LocadoraVeiculos.Repositorio.shared;
using LocadoraVeiculos.RepositorioProject.shared;

namespace LocadoraVeiculos.RepositorioProject.ModuloCondutores
{
    public class RepositorioCondutores : RepositorioSQL<Condutores>
    {
        public RepositorioCondutores(MapeadorBase<Condutores> mapeador) : base(mapeador)
        {

        }

        protected override string SqlUpdate => throw new System.NotImplementedException();

        protected override string SqlDelete => throw new System.NotImplementedException();

        protected override string SqlInsert => throw new System.NotImplementedException();

        protected override string SqlSelectAll => throw new System.NotImplementedException();

        protected override string SqlSelectId => throw new System.NotImplementedException();

        protected override string SqlExiste => throw new System.NotImplementedException();
    }
}
