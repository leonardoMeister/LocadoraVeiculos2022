using LocadoraVeiculos.Dominio.ModuloTaxas;
using LocadoraVeiculos.RepositorioProject.shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace LocadoraVeiculos.RepositorioProject.ModuloTaxas
{
    public class MapeadorTaxas : MapeadorBase<Taxas>
    {
        public override Taxas ConverterEmRegistro(IDataReader dataReader)
        {
            var id = Convert.ToInt32(dataReader["ID"]);
            var descricao = Convert.ToString(dataReader["DESCRICAO"]);
            var valor = Convert.ToDecimal(dataReader["VALOR"]);

            return new Taxas
            {
                _id = id,
                Descricao = descricao,
                Valor = valor
            };
        }

        public override Dictionary<string, object> ObtemParametrosRegistro(Taxas taxas)
        {
            return new Dictionary<string, object>
            {
                {"ID", taxas._id },
                {"DESCRICAO", taxas.Descricao },
                {"VALOR", taxas.Valor }

            };
        }
    }
}
