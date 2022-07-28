using DocumentFormat.OpenXml.Bibliography;
using LocadoraVeiculos.Dominio.ModuloCliente;
using LocadoraVeiculos.Dominio.ModuloCondutores;
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

        public Locacao(
            Veiculo veiculo, Condutores condutor, Cliente cliente, GrupoVeiculos grupoVeiculos, PlanoCobranca planoCobranca,
            DateTime dataLocacao, DateTime dataEstimadaDevolucao, decimal quilometragemInicial, NivelTanqueEnum nivelTanqueEnumInicio,
            List<Taxas> listaTaxas, bool statusDevolucao, decimal quilometragemFinal, DateTime dataRealDaDevolucao, 
            NivelTanqueEnum nivelTanqueEnumDevolucao)
        {
            Veiculo = veiculo;
            Condutores = condutor;
            Cliente = cliente;
            GrupoVeiculos = grupoVeiculos;
            PlanoCobranca = planoCobranca;
            DataLocacao = dataLocacao;
            DataEstimadaDevolucao = dataEstimadaDevolucao;
            QuilometragemInicial = quilometragemInicial;
            NivelTanqueEnumInicio = nivelTanqueEnumInicio;
            ListaTaxas = listaTaxas;
            StatusDevolucao = statusDevolucao;
            QuilometragemFinal = quilometragemFinal;
            DataRealDaDevolucao = dataRealDaDevolucao;
            NivelTanqueEnumDevolucao = nivelTanqueEnumDevolucao;
        }

        Veiculo Veiculo { get; set; }
        Condutores Condutores { get; set; }
        Cliente Cliente { get; set; }
        GrupoVeiculos GrupoVeiculos { get; set; }
        PlanoCobranca PlanoCobranca { get; set; }
        DateTime DataLocacao { get; set; }
        DateTime DataEstimadaDevolucao { get; set; }
        decimal QuilometragemInicial { get; set; }
        NivelTanqueEnum NivelTanqueEnumInicio { get; set; }

         
        List<Taxas> ListaTaxas { get; set; }


        bool StatusDevolucao { get; set;}
        decimal QuilometragemFinal { get; set; }
        DateTime DataRealDaDevolucao { get; set; }        
        NivelTanqueEnum NivelTanqueEnumDevolucao { get; set; }

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
