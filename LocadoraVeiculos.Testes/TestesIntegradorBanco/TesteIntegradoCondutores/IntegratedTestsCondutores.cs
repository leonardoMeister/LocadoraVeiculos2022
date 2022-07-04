using LocadoraVeiculos.Dominio.ModuloCondutores;
using LocadoraVeiculos.RepositorioProject.ModuloCondutores;
using LocadoraVeiculos.RepositorioProject.shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocadoraVeiculos.Testes.TestesIntegradorBanco.TesteIntegradoCondutores
{
    [TestClass]
    public class IntegratedTestsCondutores
    {
        public IntegratedTestsCondutores()
        {
            string query = @"delete from TB_CONDUTORES;
                            DBCC CHECKIDENT (TB_CONDUTORES, RESEED, 1)";
            DataBase.ExecutarComando(query);
        }

        [TestMethod]
        public void DeveInserirCondutores()
        {
            RepositorioCondutores repo = new RepositorioCondutores(new MapeadorCondutores());

            Condutores condutor = new Condutores("Gustavo Paes", "02359919994", "Andre Gargioni", "emailteste@gmail.com", "99-99999-9999", "dasdasdasdasdas", "segunda - feira, 4 de julho de 2022");

            repo.InserirNovo(condutor);

            var condutores = repo.SelecionarPorId(condutor._id);

            Assert.AreEqual(condutores._id, condutor._id);
            Assert.AreEqual(condutores.Nome, condutor.Nome);
            Assert.AreEqual(condutores.Cpf, condutor.Cpf);
            Assert.AreEqual(condutores.Endereco, condutor.Endereco);
            Assert.AreEqual(condutores.Email, condutor.Email);
            Assert.AreEqual(condutores.Telefone, condutor.Telefone);
            Assert.AreEqual(condutores.Cnh, condutor.Cnh);
            Assert.AreEqual(condutores.ValidadeCnh, condutor.ValidadeCnh);
        }

        [TestMethod]
        public void DeveBuscarVariosCondutores()
        {
            RepositorioCondutores repo = new RepositorioCondutores(new MapeadorCondutores());

            Condutores tax = new Condutores("Gustavo Paes 2", "02359919994", "Andre Gargioni 2", "emailteste2@gmail.com", "99-99999-9999", "dasdasdasdasdas", "segunda - feira, 4 de julho de 2022");
            Condutores tax2 = new Condutores("Gustavo Paes 3", "02359919994", "Andre Gargioni 3", "emailteste3@gmail.com", "99-99999-9999", "dasdasdasdasdas", "segunda - feira, 4 de julho de 2022");

            repo.InserirNovo(tax);
            repo.InserirNovo(tax2);

            var dados = repo.SelecionarTodos();

            Assert.AreEqual(2, dados.Count);

        }

        [TestMethod]
        public void DeveVerificarExistenciaCondutores()
        {
            RepositorioCondutores repo = new RepositorioCondutores(new MapeadorCondutores());

            Condutores tax = new Condutores("Gustavo Paes", "02359919994", "Andre Gargioni", "emailteste@gmail.com", "99-99999-9999", "dasdasdasdasdas", "segunda - feira, 4 de julho de 2022");

            repo.InserirNovo(tax);

            var exite = repo.Existe(tax._id);

            Assert.IsTrue(exite);
        }

        [TestMethod]
        public void DeveDeletarCondutores()
        {
            RepositorioCondutores repo = new RepositorioCondutores(new MapeadorCondutores());

            Condutores tax = new Condutores("Gustavo Paes", "02359919994", "Andre Gargioni", "emailteste@gmail.com", "99-99999-9999", "dasdasdasdasdas", "segunda - feira, 4 de julho de 2022");

            repo.InserirNovo(tax);

            repo.Excluir(tax._id);

            var existe = repo.Existe(tax._id);

            Assert.IsFalse(existe);
        }
    }
}
