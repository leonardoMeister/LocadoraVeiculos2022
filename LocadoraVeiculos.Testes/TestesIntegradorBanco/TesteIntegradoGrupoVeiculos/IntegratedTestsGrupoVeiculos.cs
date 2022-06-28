using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraVeiculos.RepositorioProject.ModuloGrupoVeiculos;
using LocadoraVeiculos.RepositorioProject.shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocadoraVeiculos.Testes.TestesIntegradorBanco.TesteIntegradoGrupoVeiculos
{
    [TestClass]
    public class IntegratedTestsGrupoVeiculos
    {
        public IntegratedTestsGrupoVeiculos()
        {
            string query = @"delete from TB_GRUPOVEICULOS;
                            DBCC CHECKIDENT (TB_GRUPOVEICULOS, RESEED, 0)";
            DataBase.ExecutarComando(query);
        }

        [TestMethod]
        public void DeveInserirGrupoVeiculos()
        {
            RepositorioGrupoVeiculos repo = new RepositorioGrupoVeiculos(new MapeadorGrupoVeiculos());

            GrupoVeiculos gveh = new GrupoVeiculos("Grupo 1");

            repo.InserirNovo(gveh);
             
            var gveiculos = repo.SelecionarPorId(gveh._id);

            Assert.AreEqual(gveiculos._id, gveh._id);
            Assert.AreEqual(gveiculos.NomeGrupo, gveh.NomeGrupo);
        }

        [TestMethod]
        public void DeveBuscarVariosGrupoVeiculos()
        {
            RepositorioGrupoVeiculos repo = new RepositorioGrupoVeiculos(new MapeadorGrupoVeiculos());

            GrupoVeiculos gveh = new GrupoVeiculos("Grupo 1");
            GrupoVeiculos gveh2 = new GrupoVeiculos("Grupo 2");

            repo.InserirNovo(gveh);
            repo.InserirNovo(gveh2);

            var dados = repo.SelecionarTodos();

            Assert.AreEqual(2, dados.Count);

        }

        [TestMethod]
        public void DeveVerificarExistenciaGrupoVeiculos()
        {
            RepositorioGrupoVeiculos repo = new RepositorioGrupoVeiculos(new MapeadorGrupoVeiculos());

            GrupoVeiculos gveh = new GrupoVeiculos("Grupo 1");

            repo.InserirNovo(gveh);

            var exite = repo.Existe(gveh._id);

            Assert.IsTrue(exite);
        }

        [TestMethod]
        public void DeveEditarGrupoVeiculos()
        {
            RepositorioGrupoVeiculos repo = new RepositorioGrupoVeiculos(new MapeadorGrupoVeiculos());

            GrupoVeiculos gveh = new GrupoVeiculos("Grupo 2");

            repo.InserirNovo(gveh);

            GrupoVeiculos gveh2 = new GrupoVeiculos("Grupo 3");

            repo.Editar(gveh._id, gveh2);

            var gveiculosBanco = repo.SelecionarPorId(gveh2._id);

            Assert.AreEqual(gveh2, gveiculosBanco);
        }

        [TestMethod]
        public void DeveDeletarGrupoVeiculos()
        {
            RepositorioGrupoVeiculos repo = new RepositorioGrupoVeiculos(new MapeadorGrupoVeiculos());

            GrupoVeiculos gveh = new GrupoVeiculos("Grupo 2");

            repo.InserirNovo(gveh);

            repo.Excluir(gveh._id);

            var existe = repo.Existe(gveh._id);

            Assert.IsFalse(existe);
        }
    }
}
