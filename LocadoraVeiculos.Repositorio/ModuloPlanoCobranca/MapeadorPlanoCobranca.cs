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
            var id = Guid.Parse(dataReader[0].ToString());
            string tipo = Convert.ToString(dataReader[1]);
            decimal valorDia = Convert.ToDecimal(dataReader[2]);
            decimal limite = Convert.ToDecimal(dataReader[3]);
            decimal valorKm = Convert.ToDecimal(dataReader[4]);
                                  
            var grupo = mapeadorGrupoVeiculos.ConverterEmRegistro(dataReader);

            var planoCobranca = new PlanoCobranca(tipo, valorDia, limite, valorKm, grupo);
            planoCobranca._id = id;

            return planoCobranca;
        }

        public override Dictionary<string, object> ObtemParametrosRegistro(PlanoCobranca registro)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", registro._id);
            parametros.Add("TIPOPLANO", registro.TipoPlano);
            parametros.Add("VALORPORDIA", registro.ValorDia);
            parametros.Add("LIMITEKM", registro.LimiteKM);
            parametros.Add("VALORKM", registro.ValorKM);
            parametros.Add("GRUPOVEICULOID", registro.GrupoVeiculos._id);

            return parametros;
        }
    }
}
