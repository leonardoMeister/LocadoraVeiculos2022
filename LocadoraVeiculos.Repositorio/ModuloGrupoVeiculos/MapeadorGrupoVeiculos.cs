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
            var id = Guid.Parse(dataReader["IDGRUPO"].ToString());
            string nomeGrupo = Convert.ToString(dataReader["NOMEGRUPO"]);

            var gveiculos = new GrupoVeiculos(nomeGrupo);
            gveiculos.Id = id;

            return gveiculos;
        }

        public override Dictionary<string, object> ObtemParametrosRegistro(GrupoVeiculos grupoVeiculos)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", grupoVeiculos.Id);
            parametros.Add("NOMEGRUPO", grupoVeiculos.NomeGrupo);

            return parametros;
        }
    }
}