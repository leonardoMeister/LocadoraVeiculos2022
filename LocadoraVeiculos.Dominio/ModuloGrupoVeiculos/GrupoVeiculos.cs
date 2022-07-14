using LocadoraVeiculos.Dominio.shared;
using System;

namespace LocadoraVeiculos.Dominio.ModuloGrupoVeiculos
{
    public class GrupoVeiculos : EntidadeBase
    {
        public GrupoVeiculos(string nomeGrupo)
        {
            NomeGrupo = nomeGrupo;
        }

        public string NomeGrupo { get; set; }

        public override bool Equals(object obj)
        {
            return obj is GrupoVeiculos veiculos &&
                   _id == veiculos._id &&
                   NomeGrupo == veiculos.NomeGrupo;
        }
        public override string ToString()
        {
            return $"Nome:{NomeGrupo}.";
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(_id, NomeGrupo);
        }
    }
}