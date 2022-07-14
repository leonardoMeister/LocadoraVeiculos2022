using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraVeiculos.Dominio.shared;
using System;
using System.Collections.Generic;

namespace LocadoraVeiculos.Dominio.ModuloPlanoCobranca
{
    public class PlanoCobranca: EntidadeBase
    {
        public PlanoCobranca(string tipo, decimal valorDia, decimal limite, decimal valorKm, GrupoVeiculos grupo)
        {
            TipoPlano = tipo;
            ValorDia = valorDia;
            LimiteKM = limite;
            ValorKM = valorKm;
            GrupoVeiculos = grupo;
        }

        public string TipoPlano { get; set; }

        public decimal ValorDia { get; set; }

        public decimal LimiteKM { get; set; }

        public decimal ValorKM { get; set; }

        public GrupoVeiculos GrupoVeiculos { get; set; }
        public PlanoCobranca Clone()
        {
            return MemberwiseClone() as PlanoCobranca;
        }
        public override bool Equals(object obj)
        {
            return obj is PlanoCobranca cobranca &&
                   _id == cobranca._id &&
                   TipoPlano == cobranca.TipoPlano &&
                   ValorDia == cobranca.ValorDia &&
                   LimiteKM == cobranca.LimiteKM &&
                   ValorKM == cobranca.ValorKM &&
                   EqualityComparer<GrupoVeiculos>.Default.Equals(GrupoVeiculos, cobranca.GrupoVeiculos);
        }
        public override string ToString()
        {
            return $"Id: {_id}, Tipo: {TipoPlano}";
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(_id, TipoPlano, ValorDia, LimiteKM, ValorKM, GrupoVeiculos);
        }
    }
}
