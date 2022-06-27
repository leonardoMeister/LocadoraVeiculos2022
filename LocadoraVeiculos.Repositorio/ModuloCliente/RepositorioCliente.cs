using LocadoraVeiculos.Dominio.ModuloCliente;
using LocadoraVeiculos.Repositorio.shared;
using LocadoraVeiculos.RepositorioProject.shared;

namespace LocadoraVeiculos.RepositorioProject.ModuloCliente
{
    public class RepositorioCliente : RepositorioSQL<Cliente>, IRepositoryCliente
    {
        public RepositorioCliente(MapeadorBase<Cliente> mapeador) : base(mapeador)
        {
        }

        protected override string SqlUpdate =>
                @"UPDATE TB_CLIENTE
                   SET [nome] = @NOME
                      ,[cpf] = @CPF
                      ,[endereco] = @ENDERECO
                      ,[email] = @EMAIL
                      ,[telefone] = @TELEFONE
                      ,[tipoCliente] =	@TIPOCLIENTE
                      ,[cnh] = @CNH
                 WHERE id_cliente = @ID";
        protected override string SqlDelete =>
                @"DELETE FROM TB_CLIENTE
                WHERE id_cliente = @ID";
        protected override string SqlInsert => 
            @"INSERT INTO TB_CLIENTE
                   ([nome]
                   ,[cpf]
                   ,[endereco]
                   ,[email]
                   ,[telefone]
                   ,[tipoCliente]
                   ,[cnh])
                 VALUES
                       (@NOME, @CPF, @ENDERECO, @EMAIL, @TELEFONE, @TIPOCLIENTE, @CNH) ;";
        protected override string SqlSelectAll => @"
                SELECT [id_cliente]
                      ,[nome]
                      ,[cpf]
                      ,[endereco]
                      ,[email]
                      ,[telefone]
                      ,[tipoCliente]
                      ,[cnh]
                  FROM TB_CLIENTE;";
        protected override string SqlSelectId => @"
                SELECT [id_cliente]
                      ,[nome]
                      ,[cpf]
                      ,[endereco]
                      ,[email]
                      ,[telefone]
                      ,[tipoCliente]
                      ,[cnh]
                  FROM TB_CLIENTE
                    where id_cliente = @ID ; ";
        protected override string SqlExiste =>
            @"SELECT
                        COUNT(*)
                    FROM 
                        TB_CLIENTE
                    WHERE id_cliente = @ID;";
    }
}
