using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraVeiculos.Dominio.shared;
using System;
using System.Collections.Generic;

namespace LocadoraVeiculos.Dominio.ModuloPlanoCobranca
{
    public class PlanoCobranca: EntidadeBase
    {

        public PlanoCobranca(string TipoPlano, decimal ValorDia, decimal LimiteKM, decimal ValorKM, GrupoVeiculos grupoVeiculos)
        {
            this.TipoPlano = TipoPlano;
            this.ValorDia = ValorDia;
            this.LimiteKM = LimiteKM;
            this.ValorKM = ValorKM;
            this.GrupoVeiculos = grupoVeiculos;
        }

        public PlanoCobranca()
        {
        }

        public string TipoPlano { get; set; }

        public decimal ValorDia { get; set; }

        public decimal LimiteKM { get; set; }

        public decimal ValorKM { get; set; }

        public GrupoVeiculos GrupoVeiculos { get; set; }
        public Guid GrupoVeiculosId { get; set; }

        public PlanoCobranca Clone()
        {
            return MemberwiseClone() as PlanoCobranca;
        }
        public override bool Equals(object obj)
        {
            return obj is PlanoCobranca cobranca &&
                   Id == cobranca.Id &&
                   TipoPlano == cobranca.TipoPlano &&
                   ValorDia == cobranca.ValorDia &&
                   LimiteKM == cobranca.LimiteKM &&
                   ValorKM == cobranca.ValorKM &&
                   EqualityComparer<GrupoVeiculos>.Default.Equals(GrupoVeiculos, cobranca.GrupoVeiculos);
        }
        public override string ToString()
        {
            return $"Id: {Id}, Tipo: {TipoPlano}";
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Id, TipoPlano, ValorDia, LimiteKM, ValorKM, GrupoVeiculos);
        }
    }
}
