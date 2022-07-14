using LocadoraVeiculos.Dominio.ModuloCliente;
using LocadoraVeiculos.Repositorio.shared;
using LocadoraVeiculos.RepositorioProject.shared;

namespace LocadoraVeiculos.RepositorioProject.ModuloCliente
{
    public class RepositorioCliente : RepositorioSQL<Cliente>
    {
        public RepositorioCliente(MapeadorBase<Cliente> mapeador) : base(mapeador)
        {

        }

        public Cliente SelecionarPorCpf(string Cpf)
        {
            return SelecionarPorParametro(SqlCpf, Mapeador.AdicionarParametro("CPF", Cpf));
        }

        protected string SqlCpf = "SELECT * FROM TB_CLIENTE WHERE [cpf] = @CPF";

        public Cliente SelecionarPorCnpj(string Cnpj)
        {
            return SelecionarPorParametro(SqlCnpj, Mapeador.AdicionarParametro("CNPJ", Cnpj));
        }

        protected string SqlCnpj = "SELECT * FROM TB_CLIENTE WHERE [cnpj] = @CNPJ";

        protected override string SqlUpdate =>
                @"UPDATE TB_CLIENTE
                   SET [nome] = @NOME
                      ,[cpf] = @CPF
                      ,[endereco] = @ENDERECO
                      ,[email] = @EMAIL
                      ,[telefone] = @TELEFONE
                      ,[tipoCliente] =	@TIPOCLIENTE
                      ,[cnpj] = @CNPJ
                 WHERE id_cliente = @ID";
        protected override string SqlDelete =>
                @"DELETE FROM TB_CLIENTE
                WHERE id_cliente = @ID";
        protected override string SqlInsert =>
            @"INSERT INTO TB_CLIENTE
                  (
                   [id_cliente],
                   [nome],
                   [cpf],
                   [endereco],
                   [email],
                   [telefone],
                   [tipoCliente],
                   [cnpj]
                  )
                 VALUES
                       (@ID, @NOME, @CPF, @ENDERECO, @EMAIL, @TELEFONE, @TIPOCLIENTE, @CNPJ);";
        protected override string SqlSelectAll => @"
                SELECT [id_cliente]
                      ,[nome]
                      ,[cpf]
                      ,[endereco]
                      ,[email]
                      ,[telefone]
                      ,[tipoCliente]
                      ,[cnpj]
                  FROM TB_CLIENTE;";
        protected override string SqlSelectId => @"
                SELECT [id_cliente]
                      ,[nome]
                      ,[cpf]
                      ,[endereco]
                      ,[email]
                      ,[telefone]
                      ,[tipoCliente]
                      ,[cnpj]
                  FROM TB_CLIENTE
                    where id_cliente = @ID; ";
        protected override string SqlExiste =>
            @"SELECT
                        COUNT(*)
                    FROM 
                        TB_CLIENTE
                    WHERE id_cliente = @ID;";
    }
}
