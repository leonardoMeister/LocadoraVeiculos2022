using LocadoraVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraVeiculos.Dominio.shared;
using System;
using System.Collections.Generic;

namespace LocadoraVeiculos.Dominio.ModuloGrupoVeiculos
{
    public class GrupoVeiculos : EntidadeBase
    {
        public GrupoVeiculos(string nomeGrupo)
        {
            NomeGrupo = nomeGrupo;
        }

        public string NomeGrupo { get; set; }
        //public List<PlanoCobranca>PlanoCobranca { get; set; }

        public GrupoVeiculos Clone()
        {
            return MemberwiseClone() as GrupoVeiculos;
        }
        public override bool Equals(object obj)
        {
            return obj is GrupoVeiculos veiculos &&
                   Id == veiculos.Id &&
                   NomeGrupo == veiculos.NomeGrupo;
        }
        public override string ToString()
        {
            return NomeGrupo;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Id, NomeGrupo);
        }
    }
}