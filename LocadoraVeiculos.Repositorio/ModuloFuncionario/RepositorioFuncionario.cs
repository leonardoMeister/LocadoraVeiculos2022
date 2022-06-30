using LocadoraVeiculos.Dominio.ModuloFuncionario;
using LocadoraVeiculos.Repositorio.shared;
using LocadoraVeiculos.RepositorioProject.shared;

namespace LocadoraVeiculos.RepositorioProject.ModuloFuncionario
{
    public class RepositorioFuncionario : RepositorioSQL<Funcionario>
    {
        public RepositorioFuncionario(MapeadorBase<Funcionario> mapeador) : base(mapeador)
        {

        }
        protected string SqlUsuario = "SELECT * FROM TB_FUNCIONARIO WHERE [login] = @LOGIN";
        public Funcionario SelecionarPorUsuario(string login)
        {
            return SelecionarPorParametro(SqlUsuario, Mapeador.AdicionarParametro("LOGIN", login));

        }
        public Funcionario SelecionarPorNome(string nome)
        {
            return SelecionarPorParametro(SqlNome, Mapeador.AdicionarParametro("NOME", nome));
        }

        protected string SqlNome = "SELECT * FROM TB_FUNCIONARIO WHERE [nome] = @NOME";


        protected override string SqlUpdate =>
                @"UPDATE TB_FUNCIONARIO
                   SET [nome] = @NOME
                      ,[login] = @LOGIN
                      ,[senha] = @SENHA
                      ,[salario] = @SALARIO
                      ,[dataAdmicao] = @DATAADMICAO
                      ,[tipoPerfil] = @TIPOPERFIL
                   WHERE id_funcionario = @ID ; ";

        protected override string SqlDelete =>
                @"DELETE FROM TB_FUNCIONARIO
                    WHERE id_funcionario = @ID";

        protected override string SqlInsert => 
            @"INSERT INTO TB_FUNCIONARIO
                   ([nome],[login],[senha],[salario],[dataAdmicao],[tipoPerfil])
             VALUES
                (@NOME, @LOGIN, @SENHA, @SALARIO, @DATAADMICAO, @TIPOPERFIL);";

        protected override string SqlSelectAll =>
                @"SELECT * FROM TB_FUNCIONARIO;";

        protected override string SqlSelectId =>
                @"SELECT * FROM TB_FUNCIONARIO WHERE id_funcionario = @ID";

        protected override string SqlExiste =>
            @"SELECT
                        COUNT(*)
                    FROM 
                        TB_FUNCIONARIO
                    WHERE id_funcionario = @ID ;";
    }
}
