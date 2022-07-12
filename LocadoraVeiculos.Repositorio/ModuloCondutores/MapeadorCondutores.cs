using LocadoraVeiculos.Dominio.ModuloCondutores;
using LocadoraVeiculos.RepositorioProject.shared;
using System;
using System.Collections.Generic;
using System.Data;

namespace LocadoraVeiculos.RepositorioProject.ModuloCondutores
{
    public class MapeadorCondutores : MapeadorBase<Condutores>
    {
        public override Condutores ConverterEmRegistro(IDataReader dataReader)
        {
            var id = Guid.Parse(dataReader["CONDUTOR_ID"].ToString());
            string nome = Convert.ToString(dataReader[1]);
            string cpf = Convert.ToString(dataReader[2]);
            string endereco = Convert.ToString(dataReader[3]);
            string email = Convert.ToString(dataReader[4]);
            string telefone = Convert.ToString(dataReader[5]);
            string cnh = Convert.ToString(dataReader[6]);
            string validadecnh = Convert.ToString(dataReader[7]);

            var condutores = new Condutores(nome, cpf, endereco, email, telefone, cnh, validadecnh);
            condutores._id = id;

            return condutores;
        }
        public override Dictionary<string, object> ObtemParametrosRegistro(Condutores registro)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", registro._id);
            parametros.Add("NOME", registro.Nome);
            parametros.Add("CPF", registro.Cpf);
            parametros.Add("ENDERECO", registro.Endereco);
            parametros.Add("EMAIL", registro.Email);
            parametros.Add("TELEFONE", registro.Telefone);
            parametros.Add("CNH", registro.Cnh);
            parametros.Add("VALIDADECNH", registro.ValidadeCnh);

            return parametros;
        }
    }
}
