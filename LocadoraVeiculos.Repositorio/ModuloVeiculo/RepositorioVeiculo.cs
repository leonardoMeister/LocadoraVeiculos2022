using LocadoraVeiculos.Dominio.ModuloVeiculo;
using LocadoraVeiculos.Repositorio.shared;
using LocadoraVeiculos.RepositorioProject.shared;

namespace LocadoraVeiculos.RepositorioProject.ModuloVeiculo
{
    public class RepositorioVeiculo : RepositorioSQL<Veiculo>
    {
        public RepositorioVeiculo(MapeadorBase<Veiculo> mapeador) : base(mapeador)
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
