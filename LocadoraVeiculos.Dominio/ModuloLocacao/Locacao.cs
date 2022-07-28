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
            Veiculo veiculo, Condutores conductor, Cliente cliente, GrupoVeiculos grupoVeiculos, PlanoCobranca planoCobranca,
            DateTime dataLocacao, DateTime dataEstimadaDevolucao, decimal quilometragemInicial, NivelTanqueEnum nivelTanqueEnumInicio,
            List<Taxas> listaTaxas, bool statusDevolucao, decimal quilometragemFinal, DateTime dataRealDaDevolucao,
            NivelTanqueEnum nivelTanqueEnumDevolucao)
        {
            this.Veiculo = veiculo;
            this.Condutores = conductor;
            this.Cliente = cliente;
            this.GrupoVeiculos = grupoVeiculos;
            this.PlanoCobranca = planoCobranca;
            this.DataLocacao = dataLocacao;
            this.DataEstimadaDevolucao = dataEstimadaDevolucao;
            this.QuilometragemInicial = quilometragemInicial;
            this.NivelTanqueEnumInicio = nivelTanqueEnumInicio;
            this.ListaTaxas = listaTaxas;
            this.StatusDevolucao = statusDevolucao;
            this.QuilometragemFinal = quilometragemFinal;
            this.DataRealDaDevolucao = dataRealDaDevolucao;
            this.NivelTanqueEnumDevolucao = nivelTanqueEnumDevolucao;
        }



        public List<Taxas> ListaTaxas { get; set; }

        public Veiculo Veiculo { get; set; }
        public Guid VeiculoId { get; set; }

        public Condutores Condutores { get; set; }
        public Guid ConductorId { get; set; }


        public Cliente Cliente { get; set; }
        public Guid ClienteId { get; set; }
        public GrupoVeiculos GrupoVeiculos { get; set; }
        public Guid GrupoVeiculosId { get; set; }
        public PlanoCobranca PlanoCobranca { get; set; }
        public Guid PlanoCobrancaId { get; set; }
        public DateTime DataLocacao { get; set; }
        public DateTime DataEstimadaDevolucao { get; set; }
        public decimal QuilometragemInicial { get; set; }
        public NivelTanqueEnum NivelTanqueEnumInicio { get; set; }
        public bool StatusDevolucao { get; set; }
        public decimal QuilometragemFinal { get; set; }
        public DateTime DataRealDaDevolucao { get; set; }

        public NivelTanqueEnum NivelTanqueEnumDevolucao { get; set; }


    }
}
