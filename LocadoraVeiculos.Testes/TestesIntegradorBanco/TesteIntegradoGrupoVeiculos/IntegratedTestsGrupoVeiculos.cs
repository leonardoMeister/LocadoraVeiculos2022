using LocadoraVeiculos.Controladores.ModuloServicoGrupoVeiculos;
using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraVeiculos.Infra.Orm.Compatilhado;
using LocadoraVeiculos.Infra.Orm.ModuloGrupoVeiculo;
using LocadoraVeiculos.RepositorioProject.ModuloGrupoVeiculos;
using LocadoraVeiculos.RepositorioProject.shared;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace LocadoraVeiculos.Testes.TestesIntegradorBanco.TesteIntegradoGrupoVeiculos
{
    [TestClass]
    public class IntegratedTestsGrupoVeiculos
    {
        LocadoraVeiculosDbContext dbContext;
        public IntegratedTestsGrupoVeiculos()
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
        public void DeveInserirGrupoVeiculos()
        {
            ServicoGrupoVeiculos repo = new ServicoGrupoVeiculos(new RepositorioGrupoVeiculoOrm(dbContext));
            GrupoVeiculos gveh = new GrupoVeiculos("Grupo 1");
            repo.InserirNovo(gveh);

            var gveiculos = repo.SelecionarPorId(gveh.Id).Value;

            Assert.AreEqual(gveiculos, gveh);
        }

        [TestMethod]
        public void DeveBuscarVariosGrupoVeiculos()
        {
            ServicoGrupoVeiculos repo = new ServicoGrupoVeiculos(new RepositorioGrupoVeiculoOrm(dbContext));
            GrupoVeiculos gveh = new GrupoVeiculos("Grupo 1");
            GrupoVeiculos gveh2 = new GrupoVeiculos("Grupo 2");

            repo.InserirNovo(gveh);
            repo.InserirNovo(gveh2);

            var dados = repo.SelecionarTodos().Value;

            Assert.AreEqual(2, dados.Count);

        }

        [TestMethod]
        public void DeveVerificarExistenciaGrupoVeiculos()
        {
            ServicoGrupoVeiculos repo = new ServicoGrupoVeiculos(new RepositorioGrupoVeiculoOrm(dbContext));
            GrupoVeiculos gveh = new GrupoVeiculos("Grupo 1");
            repo.InserirNovo(gveh);

            var exite = repo.Existe(gveh.Id);

            Assert.IsTrue(exite.Value);
        }

        [TestMethod]
        public void DeveEditarGrupoVeiculos()
        {
            ServicoGrupoVeiculos repo = new ServicoGrupoVeiculos(new RepositorioGrupoVeiculoOrm(dbContext));
            GrupoVeiculos gveh = new GrupoVeiculos("Grupo 2");
            repo.InserirNovo(gveh);

            GrupoVeiculos gveh2 = new GrupoVeiculos("Grupo 3");
            gveh2.Id = gveh.Id;
            repo.Editar(gveh2);

            var gvehNovo = repo.SelecionarPorId(gveh2.Id).Value;

            Assert.AreEqual(gvehNovo, gveh2);
        }

        [TestMethod]
        public void DeveDeletarGrupoVeiculos()
        {
            ServicoGrupoVeiculos repo = new ServicoGrupoVeiculos(new RepositorioGrupoVeiculoOrm(dbContext));
            GrupoVeiculos gveh = new GrupoVeiculos("Grupo 2");
            repo.InserirNovo(gveh);

            repo.Excluir(repo.SelecionarPorId(gveh.Id).Value);

            var existe = repo.Existe(gveh.Id);

            Assert.IsFalse(existe.Value);
        }
    }
}
