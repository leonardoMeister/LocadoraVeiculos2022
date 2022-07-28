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
        public Locacao(string nome)
        {
            Nome = nome;
        }

        public string Nome { get; set; }
        Veiculo Veiculo { get; set; }
        Conductor Conductor { get; set; }
        Cliente Cliente { get; set; }
        GrupoVeiculos GrupoVeiculos { get; set; }
        PlanoCobranca PlanoCobranca { get; set; }
        DateTime DataLocacao { get; set; }
        DateTime DataEstimadaDevolucao { get; set; }
        decimal QuilometragemInicial { get; set; } 


        List<Taxas> ListaTaxas { get; set; }


        bool StatusDevolucao { get; set;}
        decimal QuilometragemFinal { get; set; }
        DateTime DataRealDaDevolucao { get; set; }
        
        NivelTanqueEnum NivelTanqueEnum { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Locacao locacao &&
                   Id.Equals(locacao.Id) &&
                   Nome == locacao.Nome &&
                   EqualityComparer<Veiculo>.Default.Equals(Veiculo, locacao.Veiculo) &&
                   EqualityComparer<Conductor>.Default.Equals(Conductor, locacao.Conductor) &&
                   EqualityComparer<Cliente>.Default.Equals(Cliente, locacao.Cliente) &&
                   EqualityComparer<GrupoVeiculos>.Default.Equals(GrupoVeiculos, locacao.GrupoVeiculos) &&
                   EqualityComparer<PlanoCobranca>.Default.Equals(PlanoCobranca, locacao.PlanoCobranca) &&
                   DataLocacao.Date == locacao.DataLocacao.Date &&
                   DataEstimadaDevolucao.Date == locacao.DataEstimadaDevolucao.Date &&
                   QuilometragemInicial == locacao.QuilometragemInicial &&
                   EqualityComparer<List<Taxas>>.Default.Equals(ListaTaxas, locacao.ListaTaxas) &&
                   StatusDevolucao == locacao.StatusDevolucao &&
                   QuilometragemFinal == locacao.QuilometragemFinal &&
                   DataRealDaDevolucao.Date == locacao.DataRealDaDevolucao.Date &&
                   NivelTanqueEnum == locacao.NivelTanqueEnum;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Id);
            hash.Add(Nome);
            hash.Add(Veiculo);
            hash.Add(Conductor);
            hash.Add(Cliente);
            hash.Add(GrupoVeiculos);
            hash.Add(PlanoCobranca);
            hash.Add(DataLocacao);
            hash.Add(DataEstimadaDevolucao);
            hash.Add(QuilometragemInicial);
            hash.Add(ListaTaxas);
            hash.Add(StatusDevolucao);
            hash.Add(QuilometragemFinal);
            hash.Add(DataRealDaDevolucao);
            hash.Add(NivelTanqueEnum);
            return hash.ToHashCode();
        }

        public override string ToString()
        {
            return Nome;
        }
       
    }
}
