using LocadoraVeiculos.Dominio.ModuloCliente;
using LocadoraVeiculos.Dominio.ModuloCondutores;
using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraVeiculos.Dominio.ModuloTaxas;
using LocadoraVeiculos.Dominio.ModuloVeiculo;
using LocadoraVeiculos.Dominio.shared;
using LocadoraVeiculos.Infra.Configuracao;
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

        public decimal GerarValorLocacao()
        {
            decimal valorTaxas = PegarValorTaxasCadastradas();
            decimal valorCombustivel = PegarValorDoCombustivel();
            decimal valorPlano = PegarValorPlanoCobrancaCadastrado();

            var valorFinal = valorCombustivel + valorPlano + valorTaxas;
            ValorLocacao = valorFinal;
            return valorFinal;
        }

        private decimal PegarValorTaxasCadastradas()
        {
            decimal valor = 0;

            foreach (Taxas tax in ListaTaxas)
            {
                if (tax.Tipo == "Fixa")
                {
                    valor += tax.Valor;
                }
                else if (tax.Tipo == "Diaria")
                {
                    int dias = PegarNumeroDias();
                    valor += dias * tax.Valor;
                }
            }
            return valor;
        }
        private decimal PegarValorDoCombustivel()
        {
            if (StatusDevolucao)
            {
                decimal valorLitro = PegarValorDoLitroDoCombustivel();
                decimal litrosGastos = PegarQuantidadeLitrosGastos();
                return litrosGastos * valorLitro;
            }
            return 0;
        }
        private decimal PegarQuantidadeLitrosGastos()
        {
            decimal valorInicio = PegarRelaçaoDaQuantidadeDeListrosEnum(NivelTanqueEnumInicio);
            decimal valorfinal = PegarRelaçaoDaQuantidadeDeListrosEnum(NivelTanqueEnumDevolucao);

            if (valorfinal < valorInicio)
            {
                return valorInicio - valorfinal;
            }
            return 0;
        }
        private decimal PegarRelaçaoDaQuantidadeDeListrosEnum(NivelTanqueEnum nivelTanqueEnumInicio)
        {
            switch (nivelTanqueEnumInicio)
            {
                case NivelTanqueEnum.zerado:
                    return 0;
                case NivelTanqueEnum.baixo:
                    return 25;
                case NivelTanqueEnum.medio:
                    return 50;
                case NivelTanqueEnum.alto:
                    return 75;
                case NivelTanqueEnum.cheio:
                    return 100;
                default:
                    return 0;
            }
        }
        private decimal PegarValorDoLitroDoCombustivel()
        {
            ConfiguracaoAplicacao config = new ConfiguracaoAplicacao();

            switch (Veiculo.TipoCombustivel)
            {
                case TipoCombustivelEnum.Etanol:
                    return config.precosCombustiveis.Etanol;
                case TipoCombustivelEnum.Gasolina:
                    return config.precosCombustiveis.Gasolina;
                case TipoCombustivelEnum.Diesel:
                    return config.precosCombustiveis.Diesel;
                default:
                    return 0;
            }
        }
        private decimal PegarValorPlanoCobrancaCadastrado()
        {
            decimal valorPlano = 0;

            if (PlanoCobranca.ValorKM != 0)
                valorPlano += PegarValorDistanciaPlanoCobranca();
            if (PlanoCobranca.ValorDia != 0)
                valorPlano += PegarValorPorDiaPlanoCobranca();
            if (PlanoCobranca.LimiteKM != 0)
                valorPlano += CalcularMultaDoLimiteDeKmPlanoCobranca();

            return valorPlano;
        }
        private decimal CalcularMultaDoLimiteDeKmPlanoCobranca()
        {
            ConfiguracaoAplicacao config = new ConfiguracaoAplicacao();
            if (StatusDevolucao) // ou seja a devolução realmente foi feita
            {
                decimal quilometragemPercorrida = QuilometragemFinal - QuilometragemInicial;

                if (quilometragemPercorrida > PlanoCobranca.LimiteKM)
                {
                    decimal quilometragemFinalMulta = quilometragemPercorrida - PlanoCobranca.LimiteKM;
                    decimal valorDeMultaPorKmPercorridoaMaisQueoLimite = quilometragemFinalMulta * config.valoresDasMultas.MultaLimiteKmExcedido;
                    return valorDeMultaPorKmPercorridoaMaisQueoLimite;
                }
            }
            return 0;
        }
        private decimal PegarValorDistanciaPlanoCobranca()
        {
            if (StatusDevolucao)
            {
                decimal qilometragemPercorrida = QuilometragemFinal - QuilometragemInicial;

                return qilometragemPercorrida * PlanoCobranca.ValorKM;
            }
            return 0;
        }
        private decimal PegarValorPorDiaPlanoCobranca()
        {
            var valorDia = PlanoCobranca.ValorDia;

            int dias = PegarNumeroDias();

            return valorDia * dias;
        }
        private int PegarNumeroDias()
        {
            if (StatusDevolucao)
            {
                var data =   DataRealDaDevolucao.Date- DataLocacao.Date;

                return data.Days;
            }
            else
            {
                var data =  DataEstimadaDevolucao.Date - DataLocacao.Date;

                var dias= data.Days;
                return dias;
            }
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
