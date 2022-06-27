using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraVeiculos.Repositorio.shared;
using LocadoraVeiculos.RepositorioProject.shared;
using System;

namespace LocadoraVeiculos.RepositorioProject.ModuloGrupoVeiculos
{
    public class RepositorioGrupoVeiculos : RepositorioSQL<GrupoVeiculos>, IRepositoryGrupoVeiculos
    {
        public RepositorioGrupoVeiculos(MapeadorBase<GrupoVeiculos> mapeador) : base(mapeador)
        {

        }

        protected override string SqlUpdate =>
            @"UPDATE TB_TAXAS
                   SET [nomeGrupo] = @NOME_GRUPO
                 WHERE id_taxas = @ID";

        protected override string SqlDelete => throw new NotImplementedException();

        protected override string SqlInsert => throw new NotImplementedException();

        protected override string SqlSelectAll => throw new NotImplementedException();

        protected override string SqlSelectId => throw new NotImplementedException();

        protected override string SqlExiste => throw new NotImplementedException();
    }
}