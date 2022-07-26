using LocadoraVeiculos.Controladores.ModuloServicoGrupoVeiculos;
using LocadoraVeiculos.Controladores.ModuloServicoPlanoCobranca;
using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraVeiculos.Infra.Orm.Compatilhado;
using LocadoraVeiculos.Infra.Orm.ModuloGrupoVeiculo;
using LocadoraVeiculos.Infra.Orm.ModuloPlanoCobranca;
using LocadoraVeiculos.RepositorioProject.shared;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace LocadoraVeiculos.Testes.TestesIntegradorBanco.TesteIntegradorPlanoCobranca
{
    [TestClass]
    public class IntegratedTestsPlanoCobranca
    {
        private LocadoraVeiculosDbContext dbContext;

        public IntegratedTestsPlanoCobranca()
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
        public void DeveInserirPlanoCobranca()
        {
            ServicoPlanoCobranca contro = new ServicoPlanoCobranca(new RepositorioPlanoCobrancaOrm(dbContext));
            ServicoGrupoVeiculos controGrupo = new ServicoGrupoVeiculos(new RepositorioGrupoVeiculoOrm(dbContext));

            GrupoVeiculos grupo = new GrupoVeiculos("Nome grupo Veiculos 1");
            controGrupo.InserirNovo(grupo);

            PlanoCobranca plano = new PlanoCobranca("Tipo Grupo 1", 100, 0, 10, grupo);
            contro.InserirNovo(plano);

            var planoNovo = contro.SelecionarPorId(plano.Id).Value;

            Assert.AreEqual(planoNovo, plano);
        }

        [TestMethod]
        public void DeveBuscarVariosPlanos()
        {
            ServicoPlanoCobranca contro = new ServicoPlanoCobranca(new RepositorioPlanoCobrancaOrm(dbContext));
            ServicoGrupoVeiculos controGrupo = new ServicoGrupoVeiculos(new RepositorioGrupoVeiculoOrm(dbContext));

            GrupoVeiculos grupo = new GrupoVeiculos("Nome grupo Veiculos 1");
            controGrupo.InserirNovo(grupo);

            PlanoCobranca plano = new PlanoCobranca("Tipo Grupo 1", 100, 0, 10, grupo);
            PlanoCobranca plano2 = new PlanoCobranca("Tipo Grupo 2", 10, 100, 16, grupo);

            contro.InserirNovo(plano);
            contro.InserirNovo(plano2);

            var planosNovos = contro.SelecionarTodos().Value;

            Assert.AreEqual(planosNovos.Count, 2);
        }

        [TestMethod]
        public void DeveVerificarExistenciaPlano()
        {
            ServicoPlanoCobranca contro = new ServicoPlanoCobranca(new RepositorioPlanoCobrancaOrm(dbContext));
            ServicoGrupoVeiculos controGrupo = new ServicoGrupoVeiculos(new RepositorioGrupoVeiculoOrm(dbContext));

            GrupoVeiculos grupo = new GrupoVeiculos("Nome grupo Veiculos 1");
            controGrupo.InserirNovo(grupo);

            PlanoCobranca plano = new PlanoCobranca("Tipo Grupo 1", 100, 0, 10, grupo);

            contro.InserirNovo(plano);

            var planoNovo = contro.Existe(plano.Id);

            Assert.IsTrue(planoNovo.Value);
        }

        [TestMethod]
        public void DeveDeletarPlano()
        {
            ServicoPlanoCobranca contro = new ServicoPlanoCobranca(new RepositorioPlanoCobrancaOrm(dbContext));
            ServicoGrupoVeiculos controGrupo = new ServicoGrupoVeiculos(new RepositorioGrupoVeiculoOrm(dbContext));

            GrupoVeiculos grupo = new GrupoVeiculos("Nome grupo Veiculos 1");
            controGrupo.InserirNovo(grupo);

            PlanoCobranca plano = new PlanoCobranca("Tipo Grupo 1", 100, 0, 10, grupo);

            contro.InserirNovo(plano);

            contro.Excluir(contro.SelecionarPorId(plano.Id).Value);

            var planoNovo = contro.Existe(plano.Id).Value;

            Assert.IsFalse(planoNovo);
        }

        [TestMethod]
        public void DeveEditarPlano()
        {
            ServicoPlanoCobranca contro = new ServicoPlanoCobranca(new RepositorioPlanoCobrancaOrm(dbContext));
            ServicoGrupoVeiculos controGrupo = new ServicoGrupoVeiculos(new RepositorioGrupoVeiculoOrm(dbContext));

            GrupoVeiculos grupo = new GrupoVeiculos("Nome grupo Veiculos 1");
            controGrupo.InserirNovo(grupo);

            PlanoCobranca plano = new PlanoCobranca("Tipo Grupo 1", 100, 0, 10, grupo);
            PlanoCobranca plano2 = new PlanoCobranca("Tipo Grupo 2", 10, 100, 16, grupo);
            contro.InserirNovo(plano);

            plano2.Id = plano.Id;
            contro.Editar(plano2);

            var planoNovo = contro.SelecionarPorId(plano2.Id).Value;

            Assert.AreEqual(planoNovo , plano2);
        }
    }
}
