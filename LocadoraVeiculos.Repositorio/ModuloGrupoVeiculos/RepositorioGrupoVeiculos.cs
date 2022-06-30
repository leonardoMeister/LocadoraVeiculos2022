using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraVeiculos.Repositorio.shared;
using LocadoraVeiculos.RepositorioProject.shared;
using System;

namespace LocadoraVeiculos.RepositorioProject.ModuloGrupoVeiculos
{
    public class RepositorioGrupoVeiculos : RepositorioSQL<GrupoVeiculos>
    {
        public RepositorioGrupoVeiculos(MapeadorBase<GrupoVeiculos> mapeador) : base(mapeador)
        {

        }

        protected override string SqlUpdate =>
                @"UPDATE TB_GRUPOVEICULOS
                   SET [nomeGrupo] = @NOMEGRUPO
                 WHERE id_grupoveiculos = @ID";

        protected override string SqlDelete =>
                        @"DELETE FROM TB_GRUPOVEICULOS
                WHERE id_grupoveiculos = @ID";

        protected override string SqlInsert =>
            @"INSERT INTO TB_GRUPOVEICULOS
                   (nomeGrupo)
                 VALUES
                       (@NOMEGRUPO) ;";

        protected override string SqlSelectAll => @"
                SELECT [id_grupoveiculos],
                       [nomeGrupo]
                  FROM TB_GRUPOVEICULOS;";

        protected override string SqlSelectId => @"
                SELECT [id_grupoveiculos],
                       [nomeGrupo]
                  FROM TB_GRUPOVEICULOS
                    where id_grupoveiculos = @ID ; ";

        protected override string SqlExiste =>
            @"SELECT
                        COUNT(*)
                    FROM 
                        TB_GRUPOVEICULOS
                    WHERE id_grupoveiculos = @ID;";
    }
}