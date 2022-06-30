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

        public Taxas SelecionarPorDescricao(string descricao)
        {
            return SelecionarPorParametro(SqlDescricao, Mapeador.AdicionarParametro("DESCRICAO", descricao));

        }

        protected string SqlDescricao = "SELECT * FROM TB_TAXAS WHERE [descricao] = @DESCRICAO";

        protected override string SqlUpdate =>
                @"UPDATE TB_TAXAS
                   SET [descricao] = @DESCRICAO,
                       [valor] = @VALOR
                 WHERE id_taxas = @ID";

        protected override string SqlDelete =>
                @"DELETE FROM TB_TAXAS
                WHERE id_taxas = @ID";

        protected override string SqlInsert =>
            @"INSERT INTO TB_TAXAS
                   ([descricao],
                    [valor])
                 VALUES
                       (@DESCRICAO, @VALOR) ;";

        protected override string SqlSelectAll => @"
                SELECT [id_taxas],
                       [descricao],
                       [valor]
                  FROM TB_TAXAS;";

        protected override string SqlSelectId => @"
                SELECT [id_taxas],
                       [descricao],
                       [valor]
                  FROM TB_TAXAS
                    where id_taxas = @ID ; ";

        protected override string SqlExiste =>
            @"SELECT
                        COUNT(*)
                    FROM 
                        TB_TAXAS
                    WHERE id_taxas = @ID;";

    }
}
