using LocadoraVeiculos.Dominio.ModuloFuncionario;
using LocadoraVeiculos.RepositorioProject.shared;
using System;
using System.Collections.Generic;
using System.Data;

namespace LocadoraVeiculos.RepositorioProject.ModuloFuncionario
{
    public class MapeadorFuncionario : MapeadorBase<Funcionario>
    {
        public override Funcionario ConverterEmRegistro(IDataReader dataReader)
        {
            var id = Guid.Parse(dataReader[0].ToString());
            string nome = Convert.ToString(dataReader[1]);
            string login = Convert.ToString(dataReader[2]);
            string senha = Convert.ToString(dataReader[3]);
            decimal salario = Convert.ToDecimal(dataReader[4]);
            DateTime dataAdmicao = Convert.ToDateTime(dataReader[5]);
            string tipoperfil = Convert.ToString(dataReader[6]);

            var funcionario = new Funcionario(nome,login,senha,salario,dataAdmicao,tipoperfil);
            funcionario._id = id;

            return funcionario;
        }

        public override Dictionary<string, object> ObtemParametrosRegistro(Funcionario registro)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", registro._id);
            parametros.Add("NOME", registro.Nome);
            parametros.Add("LOGIN", registro.Login);
            parametros.Add("SENHA", registro.Senha);
            parametros.Add("SALARIO", registro.Salario);
            parametros.Add("DATAADMICAO", registro.DataAdmicao);
            parametros.Add("TIPOPERFIL", registro.TipoPerfil);

            return parametros;
        }
    }
}
