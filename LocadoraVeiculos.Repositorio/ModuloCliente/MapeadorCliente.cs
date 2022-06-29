using LocadoraVeiculos.Dominio.ModuloCliente;
using LocadoraVeiculos.RepositorioProject.shared;
using System;
using System.Collections.Generic;
using System.Data;

namespace LocadoraVeiculos.RepositorioProject.ModuloCliente
{
    public class MapeadorCliente : MapeadorBase<Cliente>
    {
        public override Cliente ConverterEmRegistro(IDataReader dataReader)
        {
            int id = Convert.ToInt32(dataReader[0]);
            string nome = Convert.ToString(dataReader[1]);
            string cpf = Convert.ToString(dataReader[2]);
            string endereco = Convert.ToString(dataReader[3]);
            string email = Convert.ToString(dataReader[4]);
            string telefone = Convert.ToString(dataReader[5]);
            string tipoCliente = Convert.ToString(dataReader[6]);
            string cnh = Convert.ToString(dataReader[7]);

            var cliente = new Cliente(nome,cpf,endereco,email,telefone,tipoCliente,cnh);
            cliente._id = id;

            return cliente;
        }
        public override Dictionary<string, object> ObtemParametrosRegistro(Cliente registro)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", registro._id);
            parametros.Add("NOME", registro.Nome);
            parametros.Add("CPF", registro.Cpf);
            parametros.Add("ENDERECO", registro.Endereco);
            parametros.Add("EMAIL", registro.Email);
            parametros.Add("TELEFONE", registro.Telefone);
            parametros.Add("TIPOCLIENTE", registro.TipoCliente);
            parametros.Add("CNH", registro.Cnh);

            return parametros;
        }
    }
}
