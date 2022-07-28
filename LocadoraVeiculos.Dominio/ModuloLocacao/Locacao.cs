using DocumentFormat.OpenXml.Bibliography;
using LocadoraVeiculos.Dominio.ModuloCliente;
using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraVeiculos.Dominio.ModuloTaxas;
using LocadoraVeiculos.Dominio.ModuloVeiculo;
using LocadoraVeiculos.Dominio.shared;
using System;
using System.Collections.Generic;

namespace LocadoraVeiculos.Dominio.ModuloLocacao
{
    public class Locacao : EntidadeBase
    {
        public Locacao()
        {
        }

        public  Veiculo Veiculo { get; set; }
        public Conductor Conductor { get; set; }
        public Cliente Cliente { get; set; }
        public GrupoVeiculos GrupoVeiculos { get; set; }
        public PlanoCobranca PlanoCobranca { get; set; }
        public DateTime DataLocacao { get; set; }
        public DateTime DataEstimadaDevolucao { get; set; }
        public decimal QuilometragemInicial { get; set; }
        public NivelTanqueEnum NivelTanqueEnumInicio { get; set; }


        public List<Taxas> ListaTaxas { get; set; }


        public bool StatusDevolucao { get; set;}
        public decimal QuilometragemFinal { get; set; }
        public DateTime DataRealDaDevolucao { get; set; }

        public NivelTanqueEnum NivelTanqueEnumDevolucao { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Locacao locacao &&
                   Id.Equals(locacao.Id) &&
                   EqualityComparer<Veiculo>.Default.Equals(Veiculo, locacao.Veiculo) &&
                   EqualityComparer<Conductor>.Default.Equals(Conductor, locacao.Conductor) &&
                   EqualityComparer<Cliente>.Default.Equals(Cliente, locacao.Cliente) &&
                   EqualityComparer<GrupoVeiculos>.Default.Equals(GrupoVeiculos, locacao.GrupoVeiculos) &&
                   EqualityComparer<PlanoCobranca>.Default.Equals(PlanoCobranca, locacao.PlanoCobranca) &&
                   DataLocacao == locacao.DataLocacao &&
                   DataEstimadaDevolucao == locacao.DataEstimadaDevolucao &&
                   QuilometragemInicial == locacao.QuilometragemInicial &&
                   NivelTanqueEnumInicio == locacao.NivelTanqueEnumInicio &&
                   EqualityComparer<List<Taxas>>.Default.Equals(ListaTaxas, locacao.ListaTaxas) &&
                   StatusDevolucao == locacao.StatusDevolucao &&
                   QuilometragemFinal == locacao.QuilometragemFinal &&
                   DataRealDaDevolucao == locacao.DataRealDaDevolucao &&
                   NivelTanqueEnumDevolucao == locacao.NivelTanqueEnumDevolucao;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Id);
            hash.Add(Veiculo);
            hash.Add(Conductor);
            hash.Add(Cliente);
            hash.Add(GrupoVeiculos);
            hash.Add(PlanoCobranca);
            hash.Add(DataLocacao);
            hash.Add(DataEstimadaDevolucao);
            hash.Add(QuilometragemInicial);
            hash.Add(NivelTanqueEnumInicio);
            hash.Add(ListaTaxas);
            hash.Add(StatusDevolucao);
            hash.Add(QuilometragemFinal);
            hash.Add(DataRealDaDevolucao);
            hash.Add(NivelTanqueEnumDevolucao);
            return hash.ToHashCode();
        }

       
    }
}
