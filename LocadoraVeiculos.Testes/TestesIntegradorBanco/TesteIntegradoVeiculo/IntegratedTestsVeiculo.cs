using LocadoraVeiculos.Controladores.ModuloServicoGrupoVeiculos;
using LocadoraVeiculos.Controladores.ModuloServicoVeiculo;
using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraVeiculos.Dominio.ModuloVeiculo;
using LocadoraVeiculos.Infra.Orm.Compatilhado;
using LocadoraVeiculos.Infra.Orm.ModuloGrupoVeiculo;
using LocadoraVeiculos.Infra.Orm.ModuloVeiculo;
using LocadoraVeiculos.RepositorioProject.ModuloVeiculo;
using LocadoraVeiculos.RepositorioProject.shared;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            var connectionString = configuracao.GetConnectionString("SqlServer");
            dbContext = new LocadoraVeiculosDbContext(connectionString);
            //string query = @"delete from TB_VEICULO;";
            //DataBase.ExecutarComando(query);
            //string query2 = @"delete from TB_PLANOCOBRANCA;";
            //DataBase.ExecutarComando(query2);
            //string query3 = @"delete from TB_GRUPOVEICULOS;";
            //DataBase.ExecutarComando(query3);
        }

        [TestMethod]
        public void DeveInserirVeiculo()
        {
            ServicoVeiculo controlador = new ServicoVeiculo(new RepositorioVeiculoOrm(dbContext));
            ServicoGrupoVeiculos controladorGrupoVeiculos = new ServicoGrupoVeiculos(new RepositorioGrupoVeiculoOrm(dbContext));

            GrupoVeiculos grupo = new GrupoVeiculos("Nome do grupo de teste");
            controladorGrupoVeiculos.InserirNovo(grupo);

            byte[] foto = new byte[] { };

            Veiculo vei = new Veiculo("Modelo do Veiculo", "ASD-3021", "Gol", "Rosa", "Gasolina", 10, DateTime.Now, 10, foto, grupo);

            var resultado = controlador.InserirNovo(vei);

            Assert.IsTrue(resultado.IsSuccess);
        }

        [TestMethod]
        public void DeveBuscarVeiculo()
        {
            ServicoVeiculo controlador = new ServicoVeiculo(new RepositorioVeiculoOrm(dbContext));
            ServicoGrupoVeiculos controladorGrupoVeiculos = new ServicoGrupoVeiculos(new RepositorioGrupoVeiculoOrm(dbContext));

            GrupoVeiculos grupo = new GrupoVeiculos("Nome do grupo de teste");
            controladorGrupoVeiculos.InserirNovo(grupo);
            byte[] foto = new byte[] { };
            Veiculo vei = new Veiculo("Modelo do Veiculo", "ASD-3021", "Gol", "Rosa", "Gasolina", 10, DateTime.Now, 10, foto, grupo);

            controlador.InserirNovo(vei);

            var resultado = controlador.SelecionarPorId(vei.Id).Value;

            Assert.AreEqual(resultado, vei);
            
        }

        [TestMethod]
        public void DeveVerificarExistenciaVeiculo()
        {
            ServicoVeiculo controlador = new ServicoVeiculo(new RepositorioVeiculoOrm(dbContext));
            ServicoGrupoVeiculos controladorGrupoVeiculos = new ServicoGrupoVeiculos(new RepositorioGrupoVeiculoOrm(dbContext));

            GrupoVeiculos grupo = new GrupoVeiculos("Nome do grupo de teste");
            controladorGrupoVeiculos.InserirNovo(grupo);
            byte[] foto = new byte[] { };
            Veiculo vei = new Veiculo("Modelo do Veiculo", "ASD-3021", "Gol", "Rosa", "Gasolina", 10, DateTime.Now, 10, foto, grupo);

            controlador.InserirNovo(vei);

            var resultado = controlador.Existe(vei.Id).Value;

            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void DeveDeletarVeiculo()
        {
            ServicoVeiculo controlador = new ServicoVeiculo(new RepositorioVeiculoOrm(dbContext));
            ServicoGrupoVeiculos controladorGrupoVeiculos = new ServicoGrupoVeiculos(new RepositorioGrupoVeiculoOrm(dbContext));

            GrupoVeiculos grupo = new GrupoVeiculos("Nome do grupo de teste");
            controladorGrupoVeiculos.InserirNovo(grupo);
            byte[] foto = new byte[] { };
            Veiculo vei = new Veiculo("Modelo do Veiculo", "ASD-3021", "Gol", "Rosa", "Gasolina", 10, DateTime.Now, 10, foto, grupo);

            controlador.InserirNovo(vei);
            controlador.Excluir(controlador.SelecionarPorId(vei.Id).Value);

            var resultado = controlador.Existe(vei.Id).Value;

            Assert.IsFalse(resultado);
        }

        [TestMethod]
        public void DeveEditarVeiculo()
        {
            ServicoVeiculo controlador = new ServicoVeiculo(new RepositorioVeiculoOrm(dbContext));
            ServicoGrupoVeiculos controladorGrupoVeiculos = new ServicoGrupoVeiculos(new RepositorioGrupoVeiculoOrm(dbContext));

            GrupoVeiculos grupo = new GrupoVeiculos("Nome do grupo de teste");
            controladorGrupoVeiculos.InserirNovo(grupo);
            byte[] foto = new byte[] { };
            Veiculo vei = new Veiculo("Modelo do Veiculo", "ASD-3021", "Gol", "Rosa", "Gasolina", 10, DateTime.Now, 10, foto, grupo);
            Veiculo vei2 = new Veiculo("Modelo do Veiculo2", "ASD-3022", "UNO", "Branco", "Gasolina", 10, DateTime.Now, 10, foto, grupo);            
            controlador.InserirNovo(vei);
            vei2.Id = vei.Id;
            controlador.Editar(vei2);
                
            var resultado = controlador.SelecionarPorId(vei.Id).Value;

            Assert.AreEqual(resultado, vei2);
        }

    }
}
