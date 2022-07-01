using LocadoraVeiculos.Dominio.shared;
using System;

namespace LocadoraVeiculos.Dominio.ModuloTaxas
{
    public class Taxas : EntidadeBase
    {
        public Taxas(string descricao, decimal valor, string tipo)
        {
            Descricao = descricao;
            Valor = valor;
            Tipo = tipo;    
        }

        public string Tipo { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Taxas taxas &&
                   _id == taxas._id &&
                   Tipo == taxas.Tipo &&
                   Descricao == taxas.Descricao &&
                   Valor == taxas.Valor;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_id, Tipo, Descricao, Valor);
        }
    }
}
