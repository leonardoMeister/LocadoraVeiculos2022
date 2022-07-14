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

        protected override string SqlUpdate =>
                        @"UPDATE [dbo].[TB_VEICULO]
                           SET [modelo] = @MODELO
                              ,[placa] = @PLACA
                              ,[marca] = @MARCA
                              ,[cor] = @COR
                              ,[tipo_combustivel] = @TIPOCOMBUSTIVEL
                              ,[capacidade_tanque] = @CAPACIDADETANQUE
                              ,[ano_carro] = @ANO
                              ,[quilometragem] = @QUILOMETRAGEM
                              ,[foto_carro] =  @FOTOCARRO
                              ,[grupo_veiculo_id] = @GRUPOID
                         WHERE id_veiculo = @ID";

        protected override string SqlDelete =>
                         @"DELETE FROM [dbo].[TB_VEICULO]
                            WHERE id_veiculo = @ID";

        protected override string SqlInsert =>
                        @"INSERT INTO [dbo].[TB_VEICULO]
                               ([id_veiculo]
                               ,[modelo]
                               ,[placa]
                               ,[marca]
                               ,[cor]
                               ,[tipo_combustivel]
                               ,[capacidade_tanque]
                               ,[ano_carro]
                               ,[quilometragem]
                               ,[foto_carro]
                               ,[grupo_veiculo_id])
                         VALUES
                               (@ID, @MODELO ,@PLACA ,@MARCA ,@COR ,@TIPOCOMBUSTIVEL ,@CAPACIDADETANQUE ,@ANO ,@QUILOMETRAGEM ,@FOTOCARRO ,@GRUPOID )";

        protected override string SqlSelectAll =>
                         @"SELECT [id_veiculo] as ID
                              ,[modelo] AS MODELO
                              ,[placa] AS PLACA
                              ,[marca] AS MARCA
                              ,[cor] AS COR
                              ,[tipo_combustivel] AS TIPOCOMBUSTIVEL
                              ,[capacidade_tanque] AS CAPACIDADETANQUE
                              ,[ano_carro] AS ANO
                              ,[quilometragem] AS QUILOMETRAGEM
                              ,[foto_carro] AS FOTO
                              ,[grupo_veiculo_id] GRUPOID
							  ,[id_grupoveiculos] IDGRUPO
							  ,[nomeGrupo] NOMEGRUPO
                          FROM [dbo].[TB_VEICULO]
						  inner join TB_GRUPOVEICULOS
						  on id_grupoveiculos = grupo_veiculo_id
";

        protected override string SqlSelectId =>
                         @"SELECT [id_veiculo] as ID
                              ,[modelo] AS MODELO
                              ,[placa] AS PLACA
                              ,[marca] AS MARCA
                              ,[cor] AS COR
                              ,[tipo_combustivel] AS TIPOCOMBUSTIVEL
                              ,[capacidade_tanque] AS CAPACIDADETANQUE
                              ,[ano_carro] AS ANO
                              ,[quilometragem] AS QUILOMETRAGEM
                              ,[foto_carro] AS FOTO
                              ,[grupo_veiculo_id] GRUPOID
							  ,[id_grupoveiculos] IDGRUPO
							  ,[nomeGrupo] NOMEGRUPO
                          FROM [dbo].[TB_VEICULO]
						  inner join TB_GRUPOVEICULOS
						  on id_grupoveiculos = grupo_veiculo_id
                          where id_veiculo = @ID";

        protected override string SqlExiste =>
                        @"SELECT
                            COUNT(*)
                        FROM 
                            TB_VEICULO
                        WHERE id_veiculo = @ID";
    }
}
