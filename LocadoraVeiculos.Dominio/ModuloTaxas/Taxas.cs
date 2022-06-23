using LocadoraVeiculos.Dominio.shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
