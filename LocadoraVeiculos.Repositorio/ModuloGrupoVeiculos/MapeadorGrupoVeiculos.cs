using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraVeiculos.RepositorioProject.shared;
using System;
using System.Collections.Generic;
using System.Data;

namespace LocadoraVeiculos.RepositorioProject.ModuloGrupoVeiculos
{
    public class MapeadorGrupoVeiculos : MapeadorBase<GrupoVeiculos>
    {
        public override GrupoVeiculos ConverterEmRegistro(IDataReader dataReader)
        {
            int id = Convert.ToInt32(dataReader["IDGRUPO"]);
            string nomeGrupo = Convert.ToString(dataReader["NOMEGRUPO"]);

            var gveiculos = new GrupoVeiculos(nomeGrupo);
            gveiculos._id = id;

            return gveiculos;
        }

        public override Dictionary<string, object> ObtemParametrosRegistro(GrupoVeiculos grupoVeiculos)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", grupoVeiculos._id);
            parametros.Add("NOMEGRUPO", grupoVeiculos.NomeGrupo);

            return parametros;
        }
    }
}