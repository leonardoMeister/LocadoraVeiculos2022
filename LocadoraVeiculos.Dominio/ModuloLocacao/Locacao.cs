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
            this.Veiculo = veiculo;
            this.Condutores = condutor;
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
         
        public Veiculo Veiculo { get; set; }
        public Guid VeiculoId { get; set; }
         
        public Condutores Condutores { get; set; }
        public Guid CondutoresId { get; set; }

        public Cliente Cliente { get; set; }
        public Guid ClienteId { get; set; }

        public GrupoVeiculos GrupoVeiculos { get; set; }
        public Guid GrupoVeiculosId { get; set; }

        public PlanoCobranca PlanoCobranca { get; set; }
        public Guid PlanoCobrancaId { get; set; }

        public List<Taxas> ListaTaxas { get; set; }


        public DateTime DataLocacao { get; set; }
        public DateTime DataRealDaDevolucao { get; set; }
        public DateTime DataEstimadaDevolucao { get; set; }

        public decimal QuilometragemInicial { get; set; }
        public NivelTanqueEnum NivelTanqueEnumInicio { get; set; }
        public NivelTanqueEnum NivelTanqueEnumDevolucao { get; set; }

        public bool StatusDevolucao { get; set; }
        public decimal QuilometragemFinal { get; set; }
        public decimal ValorLocacao { get; set; }

        public void GerarValorLocacao()
        {            
            decimal valorDia = PegarValorPorDia();




            decimal valorDistancia = PegarValorDistancia();
        }

        private decimal PegarValorDistancia()
        {
            decimal qilometragemPercorrida = QuilometragemFinal - QuilometragemInicial;

            return qilometragemPercorrida * PlanoCobranca.ValorKM;
        }

        private decimal PegarValorPorDia()
        {
            var valorDia = PlanoCobranca.ValorDia;

            var data = DataLocacao - DataEstimadaDevolucao;

            int dias = data.Days;

            return valorDia * dias;
        }

        public Locacao Clone()
        {
            return MemberwiseClone() as Locacao;
        }

        public override bool Equals(object obj)
        {
            return obj is Locacao locacao &&
                   Id.Equals(locacao.Id) &&
                   EqualityComparer<Veiculo>.Default.Equals(Veiculo, locacao.Veiculo) &&
                   EqualityComparer<Condutores>.Default.Equals(Condutores, locacao.Condutores) &&
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
            hash.Add(Condutores);
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
