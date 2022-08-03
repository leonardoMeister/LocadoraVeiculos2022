using LocadoraVeiculos.Dominio.ModuloLocacao;
using LocadoraVeiculos.Dominio.shared;
using System;
using System.Collections.Generic;

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

        public Taxas()
        {
        }

        public string Tipo { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public List<Locacao> Locacoes { get; set; }
        public override bool Equals(object obj)
        {
            return obj is Taxas taxas &&
                   Id == taxas.Id &&
                   Tipo == taxas.Tipo &&
                   Descricao == taxas.Descricao &&
                   Valor == taxas.Valor;
        }

        public override string ToString()
        {
            return Descricao;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Tipo, Descricao, Valor);
        }
    }
}
