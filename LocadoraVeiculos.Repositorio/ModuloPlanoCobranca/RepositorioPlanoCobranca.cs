using LocadoraVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraVeiculos.Repositorio.shared;
using LocadoraVeiculos.RepositorioProject.shared;

namespace LocadoraVeiculos.RepositorioProject.ModuloPlanoCobranca
{
    public class RepositorioPlanoCobranca : RepositorioSQL<PlanoCobranca>
    {
        public RepositorioPlanoCobranca(MapeadorBase<PlanoCobranca> mapeador) : base(mapeador)
        {

        }

        protected override string SqlUpdate =>
                    @"UPDATE TB_PLANOCOBRANCA
                       SET [tipo_plano] = @TIPOPLANO
                          ,[valor_por_diario] = @VALORPORDIA
                          ,[limite_de_kilometragem] = @LIMITEKM
                          ,[valor_por_km] =  @VALORKM
                          ,[grupo_veiculo_id] = @GRUPOVEICULOID
                     WHERE id_plano = @ID";

        protected override string SqlDelete =>
                @"DELETE FROM TB_PLANOCOBRANCA
                    WHERE id_plano = @ID";
        protected override string SqlInsert =>
                    @"INSERT INTO TB_PLANOCOBRANCA
                           (
                            [id_plano]
                           ,[tipo_plano]
                           ,[valor_por_diario]
                           ,[limite_de_kilometragem]
                           ,[valor_por_km]
                           ,[grupo_veiculo_id])
                     VALUES
                           (@ID, @TIPOPLANO , @VALORPORDIA , @LIMITEKM , @VALORKM , @GRUPOVEICULOID )";

        protected override string SqlSelectAll =>
                    @"SELECT [id_plano] IDPLANO
                          ,[tipo_plano] TIPOPLANO
                          ,[valor_por_diario] VALORPLANO
                          ,[limite_de_kilometragem] LIMITEDEKILOMETRAGEM
                          ,[valor_por_km] VALORPORKM
                          ,[grupo_veiculo_id] GRUPOID
						  ,[id_grupoveiculos] IDGRUPO
						  ,[nomeGrupo] NOMEGRUPO
                      FROM TB_PLANOCOBRANCA TBPLANO
					  
					  inner join TB_GRUPOVEICULOS TBGRUPO
					  on TBPLANO.grupo_veiculo_id = TBGRUPO.id_grupoveiculos";

        protected override string SqlSelectId =>
                        @"SELECT [id_plano] IDPLANO
                          ,[tipo_plano] TIPOPLANO
                          ,[valor_por_diario] VALORPLANO
                          ,[limite_de_kilometragem] LIMITEDEKILOMETRAGEM
                          ,[valor_por_km] VALORPORKM
                          ,[grupo_veiculo_id] GRUPOID
						  ,[id_grupoveiculos] IDGRUPO
						  ,[nomeGrupo] NOMEGRUPO
                      FROM TB_PLANOCOBRANCA TBPLANO
					  
					  inner join TB_GRUPOVEICULOS TBGRUPO
					  on TBPLANO.grupo_veiculo_id = TBGRUPO.id_grupoveiculos

                          WHERE id_plano = @ID";

        protected override string SqlExiste =>
                  @"SELECT
                        COUNT(*)
                    FROM 
                        TB_PLANOCOBRANCA
                    WHERE id_plano = @ID";
    }
}
