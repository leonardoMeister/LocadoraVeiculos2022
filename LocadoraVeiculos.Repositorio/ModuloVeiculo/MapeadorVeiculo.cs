using LocadoraVeiculos.Dominio.ModuloVeiculo;
using LocadoraVeiculos.RepositorioProject.ModuloGrupoVeiculos;
using LocadoraVeiculos.RepositorioProject.shared;
using System;
using System.Collections.Generic;
using System.Data;

namespace LocadoraVeiculos.RepositorioProject.ModuloVeiculo
{
    public class MapeadorVeiculo : MapeadorBase<Veiculo>
    {
        readonly MapeadorGrupoVeiculos mapeadorGrupoVeiculos;

        public MapeadorVeiculo()
        {
            this.mapeadorGrupoVeiculos = new MapeadorGrupoVeiculos();
        }

        public override Veiculo ConverterEmRegistro(IDataReader dataReader)
        {
            var id = Guid.Parse(dataReader["ID"].ToString());            
            string modelo = dataReader["MODELO"].ToString();
            string placa = dataReader["PLACA"].ToString();
            string marca = dataReader["MARCA"].ToString();
            string cor = dataReader["COR"].ToString();
            string tipoCombustivel = dataReader["TIPOCOMBUSTIVEL"].ToString();
            decimal capacidadeTanque = Convert.ToDecimal(dataReader["CAPACIDADETANQUE"]);
            DateTime ano = Convert.ToDateTime(dataReader["ANO"]);
            decimal quilometragem = Convert.ToDecimal(dataReader["QUILOMETRAGEM"]);
            byte[] foto = (byte[])dataReader["FOTO"];     
            var grupo = mapeadorGrupoVeiculos.ConverterEmRegistro(dataReader);

            var planoCobranca = new Veiculo(modelo, placa, marca, cor, tipoCombustivel, capacidadeTanque, ano, quilometragem, foto, grupo)
            {
                _id = id
            };

            return planoCobranca;
        }

        public override Dictionary<string, object> ObtemParametrosRegistro(Veiculo registro)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", registro._id);
            parametros.Add("@MODELO", registro.Modelo);
            parametros.Add("@PLACA", registro.Placa);
            parametros.Add("@MARCA", registro.Marca);
            parametros.Add("@COR", registro.Cor);
            parametros.Add("@TIPOCOMBUSTIVEL", registro.TipoCombustivel);
            parametros.Add("@CAPACIDADETANQUE", registro.CapacidadeTanque);
            parametros.Add("@ANO", registro.Ano);
            parametros.Add("@QUILOMETRAGEM", registro.Quilometragem);
            parametros.Add("@FOTOCARRO", registro.Foto);
            parametros.Add("@GRUPOID", registro.GrupoVeiculos._id);

            return parametros;
        }
    }
}
