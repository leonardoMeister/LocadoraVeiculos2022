using LocadoraVeiculos.Aplicacao.ModuloLocacao;
using LocadoraVeiculos.Controladores.ModuloServicoCliente;
using LocadoraVeiculos.Controladores.ModuloServicoCondutores;
using LocadoraVeiculos.Controladores.ModuloServicoGrupoVeiculos;
using LocadoraVeiculos.Controladores.ModuloServicoPlanoCobranca;
using LocadoraVeiculos.Controladores.ModuloServicoTaxas;
using LocadoraVeiculos.Controladores.ModuloServicoVeiculo;
using LocadoraVeiculos.Dominio.ModuloCliente;
using LocadoraVeiculos.Dominio.ModuloCondutores;
using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraVeiculos.Dominio.ModuloLocacao;
using LocadoraVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraVeiculos.Dominio.ModuloTaxas;
using LocadoraVeiculos.Dominio.ModuloVeiculo;
using LocadoraVeiculos.Infra.Orm.Compatilhado;
using LocadoraVeiculos.Infra.Orm.ModuloCliente;
using LocadoraVeiculos.Infra.Orm.ModuloCondutores;
using LocadoraVeiculos.Infra.Orm.ModuloGrupoVeiculo;
using LocadoraVeiculos.Infra.Orm.ModuloLocacao;
using LocadoraVeiculos.Infra.Orm.ModuloPlanoCobranca;
using LocadoraVeiculos.Infra.Orm.ModuloTaxas;
using LocadoraVeiculos.Infra.Orm.ModuloVeiculo;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;

namespace LocadoraVeiculos.Testes.TestesIntegradorBanco.TesteIntegradoLocacao
{
    [TestClass]
    public class IntegratedTestsLocacao
    {
        private LocadoraVeiculosDbContext dbContext;

        public IntegratedTestsLocacao()
        {
            var configuracao = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("ConfiguracaoAplicacao.json")
                .Build();

            var connectionString = configuracao
                .GetSection("ConnectionStrings")
                .GetSection("SqlServer")
                .Value;
            dbContext = new LocadoraVeiculosDbContext(connectionString);

            var locacoes = dbContext.Set<Locacao>();
            locacoes.RemoveRange(locacoes);

            var clientes = dbContext.Set<Cliente>();
            clientes.RemoveRange(clientes);

            var condutores = dbContext.Set<Condutores>();
            condutores.RemoveRange(condutores);

            var grupoVeiculos = dbContext.Set<GrupoVeiculos>();
            grupoVeiculos.RemoveRange(grupoVeiculos);

            var planoCobranca = dbContext.Set<PlanoCobranca>();
            planoCobranca.RemoveRange(planoCobranca);

            var taxas = dbContext.Set<Taxas>();
            taxas.RemoveRange(taxas);

            var veiculo = dbContext.Set<Veiculo>();
            veiculo.RemoveRange(veiculo);

            dbContext.SaveChanges();
        }

        [TestMethod]
        public void DeveInserirLocacao()
        {
            ServicoLocacao controlador = new ServicoLocacao(new RepositorioLocacaoOrm(dbContext), dbContext);
            ServicoVeiculo controladorVeiculo = new ServicoVeiculo(new RepositorioVeiculoOrm(dbContext), dbContext);
            ServicoCondutores controladorCondutores = new ServicoCondutores(new RepositorioCondutorOrm(dbContext), dbContext);
            ServicoCliente controladorCliente = new ServicoCliente(new RepositorioClienteOrm(dbContext), dbContext);
            ServicoGrupoVeiculos controladorGrupoVeiculos = new ServicoGrupoVeiculos(new RepositorioGrupoVeiculoOrm(dbContext), dbContext);
            ServicoPlanoCobranca controladorPlanoCobranca = new ServicoPlanoCobranca(new RepositorioPlanoCobrancaOrm(dbContext), dbContext);
            ServicoTaxas controladorTaxas = new ServicoTaxas(new RepositorioTaxaOrm(dbContext), dbContext);

            GrupoVeiculos grupo = new GrupoVeiculos("Nome do grupo de teste");
            var gru = controladorGrupoVeiculos.InserirNovo(grupo);

            byte[] foto = new byte[] { };

            Veiculo vei = new Veiculo("Modelo do Veiculo", "ASD-3021", "Gol", "Rosa", TipoCombustivelEnum.Gasolina, 10, DateTime.Now, 10, foto, grupo);
            var ve = controladorVeiculo.InserirNovo(vei);

            PlanoCobranca plano = new PlanoCobranca("Tipo Grupo 1", 100, 0, 10, grupo);
            var pla = controladorPlanoCobranca.InserirNovo(plano);

            Condutores condutor = new Condutores("Gustavo Paes", "023.599.199.94", "Andre Gargioni", "emailteste@gmail.com", "99-99999-9999", "12323432193", "segunda - feira, 4 de julho de 2022");
            var le =controladorCondutores.InserirNovo(condutor);

            Cliente cli = new Cliente("Gustavasdasdasdo", "214.432.723.99", "testeasdasdadsasd", "teste@gmail.com", "49 99830-8533",
            EnumCliente.PessoaFisica.ToString(), "");
            var les = controladorCliente.InserirNovo(cli);

            Taxas taxa = new Taxas("Aluguel Onix", 1500, EnumTaxa.Diaria.ToString());
            var taxase = controladorTaxas.InserirNovo(taxa);

            List<Taxas> tax = new List<Taxas>();
            tax.Add(taxa);




            Locacao loc = new Locacao(vei, condutor, cli, grupo, plano, DateTime.Now, DateTime.Now, 10, NivelTanqueEnum.medio, tax, false, 100, DateTime.Now, NivelTanqueEnum.alto);
            var locacao =controlador.InserirNovo(loc);

            Assert.IsTrue(locacao.IsSuccess);
        }

        [TestMethod]
        public void DeveBuscarLocacao()
        {
            ServicoLocacao controlador = new ServicoLocacao(new RepositorioLocacaoOrm(dbContext), dbContext);
            ServicoVeiculo controladorVeiculo = new ServicoVeiculo(new RepositorioVeiculoOrm(dbContext), dbContext);
            ServicoCondutores controladorCondutores = new ServicoCondutores(new RepositorioCondutorOrm(dbContext), dbContext);
            ServicoCliente controladorCliente = new ServicoCliente(new RepositorioClienteOrm(dbContext), dbContext);
            ServicoGrupoVeiculos controladorGrupoVeiculos = new ServicoGrupoVeiculos(new RepositorioGrupoVeiculoOrm(dbContext), dbContext);
            ServicoPlanoCobranca controladorPlanoCobranca = new ServicoPlanoCobranca(new RepositorioPlanoCobrancaOrm(dbContext), dbContext);
            ServicoTaxas controladorTaxas = new ServicoTaxas(new RepositorioTaxaOrm(dbContext), dbContext);

            GrupoVeiculos grupo = new GrupoVeiculos("Nome do grupo de teste");
            var gru =controladorGrupoVeiculos.InserirNovo(grupo);

            byte[] foto = new byte[] { };

            Veiculo vei = new Veiculo("Modelo do Veiculo", "ASD-3021", "Gol", "Rosa", TipoCombustivelEnum.Gasolina, 10, DateTime.Now, 10, foto, grupo);
            var ve =controladorVeiculo.InserirNovo(vei);

            PlanoCobranca plano = new PlanoCobranca("Tipo Grupo 1", 100, 0, 10, grupo);
            var pla = controladorPlanoCobranca.InserirNovo(plano);

            Condutores condutor = new Condutores("Gustavo Paes", "023.599.199.94", "Andre Gargioni", "emailteste@gmail.com", "99-99999-9999", "12323432193", "segunda - feira, 4 de julho de 2022");
            controladorCondutores.InserirNovo(condutor);

            Cliente cli = new Cliente("Gustavo", "214.432.723.99", "teste", "teste@gmail.com", "49 99830-8533",
            EnumCliente.PessoaFisica.ToString(), "");
            controladorCliente.InserirNovo(cli);

            Taxas taxa = new Taxas("Aluguel Onix", 1500, EnumTaxa.Diaria.ToString());
            controladorTaxas.InserirNovo(taxa);

            List<Taxas> tax = new List<Taxas>();
            tax.Add(taxa);




            Locacao loc = new Locacao(vei, condutor, cli, grupo, plano, DateTime.Now, DateTime.Now, 10, NivelTanqueEnum.medio, tax, false, 100, DateTime.Now, NivelTanqueEnum.alto);
            var locacao = controlador.InserirNovo(loc);

            var resultado = controlador.SelecionarPorId(loc.Id).Value;

            Assert.AreEqual(resultado, loc);

        }

        [TestMethod]
        public void DeveVerificarExistenciaLocacao()
        {
            ServicoLocacao controlador = new ServicoLocacao(new RepositorioLocacaoOrm(dbContext), dbContext);
            ServicoVeiculo controladorVeiculo = new ServicoVeiculo(new RepositorioVeiculoOrm(dbContext), dbContext);
            ServicoCondutores controladorCondutores = new ServicoCondutores(new RepositorioCondutorOrm(dbContext), dbContext);
            ServicoCliente controladorCliente = new ServicoCliente(new RepositorioClienteOrm(dbContext), dbContext);
            ServicoGrupoVeiculos controladorGrupoVeiculos = new ServicoGrupoVeiculos(new RepositorioGrupoVeiculoOrm(dbContext), dbContext);
            ServicoPlanoCobranca controladorPlanoCobranca = new ServicoPlanoCobranca(new RepositorioPlanoCobrancaOrm(dbContext), dbContext);
            ServicoTaxas controladorTaxas = new ServicoTaxas(new RepositorioTaxaOrm(dbContext), dbContext);

            GrupoVeiculos grupo = new GrupoVeiculos("Nome do grupo de teste");
            var gru = controladorGrupoVeiculos.InserirNovo(grupo);

            byte[] foto = new byte[] { };

            Veiculo vei = new Veiculo("Modelo do Veiculo", "ASD-3021", "Gol", "Rosa", TipoCombustivelEnum.Gasolina, 10, DateTime.Now, 10, foto, grupo);
            var ve = controladorVeiculo.InserirNovo(vei);

            PlanoCobranca plano = new PlanoCobranca("Tipo Grupo 1", 100, 0, 10, grupo);
            var pla = controladorPlanoCobranca.InserirNovo(plano);

            Condutores condutor = new Condutores("Gustavo Paes", "023.599.199.94", "Andre Gargioni", "emailteste@gmail.com", "99-99999-9999", "12323432193", "segunda - feira, 4 de julho de 2022");
            controladorCondutores.InserirNovo(condutor);

            Cliente cli = new Cliente("Gustavo", "214.432.723.99", "teste", "teste@gmail.com", "49 99830-8533",
            EnumCliente.PessoaFisica.ToString(), "");
            controladorCliente.InserirNovo(cli);

            Taxas taxa = new Taxas("Aluguel Onix", 1500, EnumTaxa.Diaria.ToString());
            controladorTaxas.InserirNovo(taxa);

            List<Taxas> tax = new List<Taxas>();
            tax.Add(taxa);




            Locacao loc = new Locacao(vei, condutor, cli, grupo, plano, DateTime.Now, DateTime.Now, 10, NivelTanqueEnum.medio, tax, false, 100, DateTime.Now, NivelTanqueEnum.alto);
            var locacao = controlador.InserirNovo(loc);

            var resultado = controlador.Existe(loc.Id).Value;

            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void DeveDeletarLocacao() 
        {
            ServicoLocacao controlador = new ServicoLocacao(new RepositorioLocacaoOrm(dbContext), dbContext);
            ServicoVeiculo controladorVeiculo = new ServicoVeiculo(new RepositorioVeiculoOrm(dbContext), dbContext);
            ServicoCondutores controladorCondutores = new ServicoCondutores(new RepositorioCondutorOrm(dbContext), dbContext);
            ServicoCliente controladorCliente = new ServicoCliente(new RepositorioClienteOrm(dbContext), dbContext);
            ServicoGrupoVeiculos controladorGrupoVeiculos = new ServicoGrupoVeiculos(new RepositorioGrupoVeiculoOrm(dbContext), dbContext);
            ServicoPlanoCobranca controladorPlanoCobranca = new ServicoPlanoCobranca(new RepositorioPlanoCobrancaOrm(dbContext), dbContext);
            ServicoTaxas controladorTaxas = new ServicoTaxas(new RepositorioTaxaOrm(dbContext), dbContext);

            GrupoVeiculos grupo = new GrupoVeiculos("Nome do grupo de teste");
            var gru = controladorGrupoVeiculos.InserirNovo(grupo);

            byte[] foto = new byte[] { };

            Veiculo vei = new Veiculo("Modelo do Veiculo", "ASD-3021", "Gol", "Rosa", TipoCombustivelEnum.Gasolina, 10, DateTime.Now, 10, foto, grupo);
            var ve = controladorVeiculo.InserirNovo(vei);

            PlanoCobranca plano = new PlanoCobranca("Tipo Grupo 1", 100, 0, 10, grupo);
            var pla = controladorPlanoCobranca.InserirNovo(plano);

            Condutores condutor = new Condutores("Gustavo Paes", "023.599.199.94", "Andre Gargioni", "emailteste@gmail.com", "99-99999-9999", "12323432193", "segunda - feira, 4 de julho de 2022");
            controladorCondutores.InserirNovo(condutor);

            Cliente cli = new Cliente("Gustavo", "214.432.723.99", "teste", "teste@gmail.com", "49 99830-8533",
            EnumCliente.PessoaFisica.ToString(), "");
            controladorCliente.InserirNovo(cli);

            Taxas taxa = new Taxas("Aluguel Onix", 1500, EnumTaxa.Diaria.ToString());
            controladorTaxas.InserirNovo(taxa);

            List<Taxas> tax = new List<Taxas>();
            tax.Add(taxa);




            Locacao loc = new Locacao(vei, condutor, cli, grupo, plano, DateTime.Now, DateTime.Now, 10, NivelTanqueEnum.medio, tax, false, 100, DateTime.Now, NivelTanqueEnum.alto);
            var locacao = controlador.InserirNovo(loc);

            controlador.Excluir(loc);

            var resultado = controlador.Existe(loc.Id).Value;

            Assert.IsFalse(resultado);
        }

        [TestMethod]
        public void DeveEditarLocacao()
        {
            ServicoLocacao controlador = new ServicoLocacao(new RepositorioLocacaoOrm(dbContext), dbContext);
            ServicoVeiculo controladorVeiculo = new ServicoVeiculo(new RepositorioVeiculoOrm(dbContext), dbContext);
            ServicoCondutores controladorCondutores = new ServicoCondutores(new RepositorioCondutorOrm(dbContext), dbContext);
            ServicoCliente controladorCliente = new ServicoCliente(new RepositorioClienteOrm(dbContext), dbContext);
            ServicoGrupoVeiculos controladorGrupoVeiculos = new ServicoGrupoVeiculos(new RepositorioGrupoVeiculoOrm(dbContext), dbContext);
            ServicoPlanoCobranca controladorPlanoCobranca = new ServicoPlanoCobranca(new RepositorioPlanoCobrancaOrm(dbContext), dbContext);
            ServicoTaxas controladorTaxas = new ServicoTaxas(new RepositorioTaxaOrm(dbContext), dbContext);

            GrupoVeiculos grupo = new GrupoVeiculos("Nome do grupo de teste");
            var gru = controladorGrupoVeiculos.InserirNovo(grupo);

            byte[] foto = new byte[] { };

            Veiculo vei = new Veiculo("Modelo do Veiculo", "ASD-3021", "Gol", "Rosa", TipoCombustivelEnum.Gasolina, 10, DateTime.Now, 10, foto, grupo);
            var ve = controladorVeiculo.InserirNovo(vei);

            PlanoCobranca plano = new PlanoCobranca("Tipo Grupo 1", 100, 0, 10, grupo);
            var pla = controladorPlanoCobranca.InserirNovo(plano);

            Condutores condutor = new Condutores("Gustavo Paes", "023.599.199.94", "Andre Gargioni", "emailteste@gmail.com", "99-99999-9999", "12323432193", "segunda - feira, 4 de julho de 2022");
            controladorCondutores.InserirNovo(condutor);

            Cliente cli = new Cliente("Gustavo", "214.432.723.99", "teste", "teste@gmail.com", "49 99830-8533",
            EnumCliente.PessoaFisica.ToString(), "");
            controladorCliente.InserirNovo(cli);

            Taxas taxa = new Taxas("Aluguel Onix", 1500, EnumTaxa.Diaria.ToString());
            controladorTaxas.InserirNovo(taxa);

            List<Taxas> tax = new List<Taxas>();
            tax.Add(taxa);




            Locacao loc = new Locacao(vei, condutor, cli, grupo, plano, DateTime.Now, DateTime.Now, 10, NivelTanqueEnum.medio, tax, false, 100, DateTime.Now, NivelTanqueEnum.alto);
            var locacao = controlador.InserirNovo(loc);

            loc.QuilometragemFinal = 100;
            loc.NivelTanqueEnumDevolucao = NivelTanqueEnum.zerado;
            loc.DataRealDaDevolucao = DateTime.MaxValue;

            controlador.Editar(loc);

            var resultado = controlador.SelecionarPorId(loc.Id).Value;

            Assert.AreEqual(resultado, loc);
        }
    }
}
