using LocadoraVeiculos.Controladores.ModuloServicoGrupoVeiculos;
using LocadoraVeiculos.Controladores.ModuloServicoVeiculo;
using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraVeiculos.Dominio.ModuloLocacao;
using LocadoraVeiculos.Dominio.ModuloVeiculo;
using LocadoraVeiculos.Infra.Orm.Compatilhado;
using LocadoraVeiculos.Infra.Orm.ModuloGrupoVeiculo;
using LocadoraVeiculos.Infra.Orm.ModuloVeiculo;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace LocadoraVeiculos.Testes.TestesIntegradorBanco.TesteIntegradoVeiculo
{
    [TestClass]
    public class IntegratedTestsVeiculo
    {
        private LocadoraVeiculosDbContext dbContext;

        public IntegratedTestsVeiculo()
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

            var locacao = dbContext.Set<Locacao>();
            locacao.RemoveRange(locacao);

            var veiculos = dbContext.Set<Veiculo>();
            veiculos.RemoveRange(veiculos);

            dbContext.SaveChanges();
        }

        [TestMethod]
        public void DeveInserirVeiculo()
        {
            ServicoVeiculo controlador = new ServicoVeiculo(new RepositorioVeiculoOrm(dbContext), dbContext);
            ServicoGrupoVeiculos controladorGrupoVeiculos = new ServicoGrupoVeiculos(new RepositorioGrupoVeiculoOrm(dbContext), dbContext);

            GrupoVeiculos grupo = new GrupoVeiculos("Nome do grupo de teste");
            controladorGrupoVeiculos.InserirNovo(grupo);

            byte[] foto = new byte[] { };

            Veiculo vei = new Veiculo("Modelo do Veiculo", "ASD-3021", "Gol", "Rosa", TipoCombustivelEnum.Gasolina, 10, DateTime.Now, 10, foto, grupo);

            var resultado = controlador.InserirNovo(vei);

            Assert.IsTrue(resultado.IsSuccess);
        }

        [TestMethod]
        public void DeveBuscarVeiculo()
        {
            ServicoVeiculo controlador = new ServicoVeiculo(new RepositorioVeiculoOrm(dbContext), dbContext);
            ServicoGrupoVeiculos controladorGrupoVeiculos = new ServicoGrupoVeiculos(new RepositorioGrupoVeiculoOrm(dbContext), dbContext);

            GrupoVeiculos grupo = new GrupoVeiculos("Nome do grupo de teste");
            controladorGrupoVeiculos.InserirNovo(grupo);
            byte[] foto = new byte[] { };
            Veiculo vei = new Veiculo("Modelo do Veiculo", "ASD-3021", "Gol", "Rosa", TipoCombustivelEnum.Gasolina, 10, DateTime.Now, 10, foto, grupo);

            controlador.InserirNovo(vei);

            var resultado = controlador.SelecionarPorId(vei.Id).Value;

            Assert.AreEqual(resultado, vei);
            
        }

        [TestMethod]
        public void DeveVerificarExistenciaVeiculo()
        {
            ServicoVeiculo controlador = new ServicoVeiculo(new RepositorioVeiculoOrm(dbContext), dbContext);
            ServicoGrupoVeiculos controladorGrupoVeiculos = new ServicoGrupoVeiculos(new RepositorioGrupoVeiculoOrm(dbContext), dbContext);

            GrupoVeiculos grupo = new GrupoVeiculos("Nome do grupo de teste");
            controladorGrupoVeiculos.InserirNovo(grupo);
            byte[] foto = new byte[] { };
            Veiculo vei = new Veiculo("Modelo do Veiculo", "ASD-3021", "Gol", "Rosa", TipoCombustivelEnum.Gasolina, 10, DateTime.Now, 10, foto, grupo);

            controlador.InserirNovo(vei);

            var resultado = controlador.Existe(vei.Id).Value;

            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void DeveDeletarVeiculo()
        {
            ServicoVeiculo controlador = new ServicoVeiculo(new RepositorioVeiculoOrm(dbContext), dbContext);
            ServicoGrupoVeiculos controladorGrupoVeiculos = new ServicoGrupoVeiculos(new RepositorioGrupoVeiculoOrm(dbContext), dbContext);

            GrupoVeiculos grupo = new GrupoVeiculos("Nome do grupo de teste");
            controladorGrupoVeiculos.InserirNovo(grupo);
            byte[] foto = new byte[] { };
            Veiculo vei = new Veiculo("Modelo do Veiculo", "ASD-3021", "Gol", "Rosa", TipoCombustivelEnum.Gasolina, 10, DateTime.Now, 10, foto, grupo);

            controlador.InserirNovo(vei);
            controlador.Excluir(controlador.SelecionarPorId(vei.Id).Value);

            var resultado = controlador.Existe(vei.Id).Value;

            Assert.IsFalse(resultado);
        }

        [TestMethod]
        public void DeveEditarVeiculo()
        {
            ServicoVeiculo controlador = new ServicoVeiculo(new RepositorioVeiculoOrm(dbContext), dbContext);
            ServicoGrupoVeiculos controladorGrupoVeiculos = new ServicoGrupoVeiculos(new RepositorioGrupoVeiculoOrm(dbContext), dbContext);

            GrupoVeiculos grupo = new GrupoVeiculos("Nome do grupo de teste");
            controladorGrupoVeiculos.InserirNovo(grupo);
            byte[] foto = new byte[] { };
            Veiculo vei = new Veiculo("Modelo do Veiculo", "ASD-3021", "Gol", "Rosa", TipoCombustivelEnum.Gasolina, 10, DateTime.Now, 10, foto, grupo);

            controlador.InserirNovo(vei);
            vei.Modelo = "NOVO MODELO DE VEICULO EDICAO";
            controlador.Editar(vei);
                
            var resultado = controlador.SelecionarPorId(vei.Id).Value;

            Assert.AreEqual(resultado, vei);
        }

    }
}
