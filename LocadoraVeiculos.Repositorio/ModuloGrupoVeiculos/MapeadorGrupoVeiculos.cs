using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraVeiculos.RepositorioProject.shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace LocadoraVeiculos.RepositorioProject.ModuloGrupoVeiculos
{
    public class MapeadorGrupoVeiculos : MapeadorBase<GrupoVeiculos>
    {
        public override GrupoVeiculos ConverterEmRegistro(IDataReader dataReader)
        {
            var id = Convert.ToInt32(dataReader["ID"]);
            var nomeGrupo = Convert.ToString(dataReader["NOME_GRUPO"]);

            return new GrupoVeiculos
            {
                _id = id,
                NomeGrupo = nomeGrupo
            };
        }

        public override Dictionary<string, object> ObtemParametrosRegistro(GrupoVeiculos grupoVeiculos)
        {
            return new Dictionary<string, object>
            {
                {"ID", grupoVeiculos._id },
                {"NOME_GRUPO", grupoVeiculos.NomeGrupo }

            };
        }
    }
}