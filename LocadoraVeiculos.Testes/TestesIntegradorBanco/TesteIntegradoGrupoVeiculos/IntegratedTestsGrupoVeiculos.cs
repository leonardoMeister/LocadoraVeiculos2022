using LocadoraVeiculos.Controladores.ModuloControladorGrupoVeiculos;
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
            string query = @"delete from TB_VEICULO;";
            DataBase.ExecutarComando(query);
            string query2 = @"delete from TB_PLANOCOBRANCA;";
            DataBase.ExecutarComando(query2);
            string query3 = @"delete from TB_GRUPOVEICULOS;";
            DataBase.ExecutarComando(query3);
        }

        [TestMethod]
        public void DeveInserirGrupoVeiculos()
        {
            ControladorGrupoVeiculos repo = new ControladorGrupoVeiculos();

            GrupoVeiculos gveh = new GrupoVeiculos("Grupo 1");

            repo.InserirNovo(gveh);

            var gveiculos = repo.SelecionarPorId(gveh._id);

            Assert.AreEqual(gveiculos._id, gveh._id);
            Assert.AreEqual(gveiculos.NomeGrupo, gveh.NomeGrupo);
        }

        [TestMethod]
        public void DeveBuscarVariosGrupoVeiculos()
        {
            ControladorGrupoVeiculos repo = new ControladorGrupoVeiculos();

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
            ControladorGrupoVeiculos repo = new ControladorGrupoVeiculos();

            GrupoVeiculos gveh = new GrupoVeiculos("Grupo 1");

            repo.InserirNovo(gveh);

            var exite = repo.Existe(gveh._id);

            Assert.IsTrue(exite);
        }

        [TestMethod]
        public void DeveEditarGrupoVeiculos()
        {
            ControladorGrupoVeiculos repo = new ControladorGrupoVeiculos();

            GrupoVeiculos gveh = new GrupoVeiculos("Grupo 2");

            repo.InserirNovo(gveh);

            GrupoVeiculos gveh2 = new GrupoVeiculos("Grupo 3");
            gveh2._id = gveh._id;
            repo.Editar(gveh2);

            var gveiculosBanco = repo.SelecionarPorId(gveh2._id);

            Assert.AreEqual(gveh2, gveiculosBanco);
        }

        [TestMethod]
        public void DeveDeletarGrupoVeiculos()
        {
            ControladorGrupoVeiculos repo = new ControladorGrupoVeiculos();

            GrupoVeiculos gveh = new GrupoVeiculos("Grupo 2");

            repo.InserirNovo(gveh);

            repo.Excluir(gveh._id);

            var existe = repo.Existe(gveh._id);

            Assert.IsFalse(existe);
        }
    }
}
