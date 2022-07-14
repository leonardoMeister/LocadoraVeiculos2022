using LocadoraVeiculos.Controladores.ModuloServicoCondutores;
using LocadoraVeiculos.Dominio.ModuloCondutores;
using LocadoraVeiculos.RepositorioProject.shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocadoraVeiculos.Testes.TestesIntegradorBanco.TesteIntegradoCondutores
{
    [TestClass]
    public class IntegratedTestsCondutores
    {
        public IntegratedTestsCondutores()
        {
            string query = @"delete from TB_CONDUTORES;";
            DataBase.ExecutarComando(query);
        }

        [TestMethod] 
        public void DeveInserirCondutores()
        {
            ServicoCondutores repo = new ServicoCondutores();

            Condutores condutor = new Condutores("Gustavo Paes", "023.599.199.94", "Andre Gargioni", "emailteste@gmail.com", "99-99999-9999", "12323432193", "segunda - feira, 4 de julho de 2022");

            repo.InserirNovo(condutor);

            var condutores = repo.SelecionarPorId(condutor._id).Value;

            Assert.AreEqual(condutores, condutor);
        }

        [TestMethod]
        public void DeveBuscarVariosCondutores()
        {
            ServicoCondutores repo = new ServicoCondutores();

            Condutores tax = new Condutores("Gustavo Paes1", "023.599.199.93", "Andre Gargioni1", "emailteste1@gmail.com", "99-99999-9991", "12323432191", "segunda - feira, 4 de julho de 2022");
            Condutores tax2 = new Condutores("Gustavo Paes2", "023.599.199.95", "Andre Gargioni2", "emailteste2@gmail.com", "99-99999-9992", "12323432192", "segunda - feira, 4 de julho de 2022");

            repo.InserirNovo(tax);
            repo.InserirNovo(tax2);

            var dados = repo.SelecionarTodos().Value;

            Assert.AreEqual(2, dados.Count);

        }

        [TestMethod]
        public void DeveVerificarExistenciaCondutores()
        {
            ServicoCondutores repo = new ServicoCondutores();

            Condutores tax = new Condutores("Gustavo Paes", "023.599.199.94", "Andre Gargioni", "emailteste@gmail.com", "99-99999-9999", "12323432193", "segunda - feira, 4 de julho de 2022");

            repo.InserirNovo(tax);

            var exite = repo.Existe(tax._id).Value;

            Assert.IsTrue(exite);
        }

        [TestMethod]
        public void DeveDeletarCondutores()
        {
            ServicoCondutores repo = new ServicoCondutores();

            Condutores tax = new Condutores("Gustavo Paes", "02359919994", "Andre Gargioni", "emailteste@gmail.com", "99-99999-9999", "dasdasdasdasdas", "segunda - feira, 4 de julho de 2022");

            repo.InserirNovo(tax);

            repo.Excluir(repo.SelecionarPorId(tax._id).Value);

            var existe = repo.Existe(tax._id).Value;

            Assert.IsFalse(existe);
        }
    }
}
