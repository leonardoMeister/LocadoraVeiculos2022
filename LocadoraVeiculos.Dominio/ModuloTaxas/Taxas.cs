using LocadoraVeiculos.Dominio.shared;
using System;

namespace LocadoraVeiculos.Dominio.ModuloTaxas
{
    public class Taxas : EntidadeBase
    {
        public Taxas(string descricao, decimal valor)
        {
            Descricao = descricao;
            Valor = valor;
        }

        public string Descricao { get; set; }
        public decimal Valor { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Taxas taxas &&
                   _id == taxas._id &&
                   Descricao == taxas.Descricao &&
                   Valor == taxas.Valor;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_id, Descricao, Valor);
        }
    }
}
