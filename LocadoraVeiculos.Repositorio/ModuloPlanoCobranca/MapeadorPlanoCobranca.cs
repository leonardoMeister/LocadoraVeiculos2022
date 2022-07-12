using LocadoraVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraVeiculos.RepositorioProject.ModuloGrupoVeiculos;
using LocadoraVeiculos.RepositorioProject.shared;
using System;
using System.Collections.Generic;
using System.Data;

namespace LocadoraVeiculos.RepositorioProject.ModuloPlanoCobranca
{
    public class MapeadorPlanoCobranca : MapeadorBase<PlanoCobranca>
    {
        readonly MapeadorGrupoVeiculos mapeadorGrupoVeiculos;

        public MapeadorPlanoCobranca()
        {
            this.mapeadorGrupoVeiculos = new MapeadorGrupoVeiculos();
        }

        public override PlanoCobranca ConverterEmRegistro(IDataReader dataReader)
        {
            var id = Guid.Parse(dataReader["IDPLANO"].ToString());
            string tipo = Convert.ToString(dataReader["TIPOPLANO"]);
            decimal valorDia = Convert.ToDecimal(dataReader["VALORPLANO"]);
            decimal limite = Convert.ToDecimal(dataReader["LIMITEDEKILOMETRAGEM"]);
            decimal valorKm = Convert.ToDecimal(dataReader["VALORPORKM"]);           
                                  
            var grupo = mapeadorGrupoVeiculos.ConverterEmRegistro(dataReader);

            var planoCobranca = new PlanoCobranca(tipo, valorDia, limite, valorKm, grupo)
            {
                _id = id
            };

            return planoCobranca;
        }

        public override Dictionary<string, object> ObtemParametrosRegistro(PlanoCobranca registro)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", registro._id);
            parametros.Add("@TIPOPLANO", registro.TipoPlano);
            parametros.Add("@VALORPORDIA", registro.ValorDia);
            parametros.Add("@LIMITEKM", registro.LimiteKM);
            parametros.Add("@VALORKM", registro.ValorKM);
            parametros.Add("@GRUPOVEICULOID", registro.GrupoVeiculos._id);

            return parametros;
        }
    }
}
