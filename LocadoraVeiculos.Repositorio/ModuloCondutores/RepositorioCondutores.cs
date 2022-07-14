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

        public Condutores SelecionarPorCpf(string Cpf)
        {
            return SelecionarPorParametro(SqlCpf, Mapeador.AdicionarParametro("CPF", Cpf));
        }

        protected string SqlCpf = "SELECT * FROM TB_CONDUTORES WHERE [cpf] = @CPF";

        protected override string SqlUpdate =>
                @"UPDATE TB_CONDUTORES
                   SET [nome] = @NOME
                      ,[cpf] = @CPF
                      ,[endereco] = @ENDERECO
                      ,[email] = @EMAIL
                      ,[telefone] = @TELEFONE
                      ,[cnh] =	@CNH
                      ,[validadeCnh] = @VALIDADECNH
                 WHERE id_condutores = @ID";
        protected override string SqlDelete =>
                @"DELETE FROM TB_CONDUTORES
                WHERE id_condutores = @ID";
        protected override string SqlInsert =>
            @"INSERT INTO TB_CONDUTORES
                   ([id_condutores]
                   ,[nome]
                   ,[cpf]
                   ,[endereco]
                   ,[email]
                   ,[telefone]
                   ,[cnh]
                   ,[validadeCnh])
                 VALUES
                       (@ID, @NOME, @CPF, @ENDERECO, @EMAIL, @TELEFONE, @CNH, @VALIDADECNH) ;";
        protected override string SqlSelectAll => @"
                SELECT [id_condutores]
                      ,[nome]
                      ,[cpf]
                      ,[endereco]
                      ,[email]
                      ,[telefone]
                      ,[cnh]
                      ,[validadeCnh]
                  FROM TB_CONDUTORES;";
        protected override string SqlSelectId => @"
                SELECT [id_condutores]
                      ,[nome]
                      ,[cpf]
                      ,[endereco]
                      ,[email]
                      ,[telefone]
                      ,[cnh]
                      ,[validadeCnh]
                  FROM TB_CONDUTORES
                    where id_condutores = @ID ; ";
        protected override string SqlExiste =>
            @"SELECT
                        COUNT(*)
                    FROM 
                        TB_CONDUTORES
                    WHERE id_condutores = @ID;";
    }
}
