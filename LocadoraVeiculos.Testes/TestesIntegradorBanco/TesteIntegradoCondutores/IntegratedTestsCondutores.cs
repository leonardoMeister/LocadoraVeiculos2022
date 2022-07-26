using LocadoraVeiculos.Controladores.ModuloServicoCondutores;
using LocadoraVeiculos.Dominio.ModuloCondutores;
using LocadoraVeiculos.Infra.Orm.Compatilhado;
using LocadoraVeiculos.Infra.Orm.ModuloCondutores;
using LocadoraVeiculos.RepositorioProject.shared;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace LocadoraVeiculos.Testes.TestesIntegradorBanco.TesteIntegradoCondutores
{
    [TestClass]
    public class IntegratedTestsCondutores
    {
        private LocadoraVeiculosDbContext dbContext;

        public IntegratedTestsCondutores()
        {
            var configuracao = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("ConfiguracaoAplicacao.json")
             .Build();

            var connectionString = configuracao.GetConnectionString("SqlServer");
            dbContext = new LocadoraVeiculosDbContext(connectionString);

            //string query = @"delete from TB_CONDUTORES;";
            //DataBase.ExecutarComando(query);
        }

        [TestMethod] 
        public void DeveInserirCondutores()
        {
            ServicoCondutores repo = new ServicoCondutores(new RepositorioCondutorOrm(dbContext));

            Condutores condutor = new Condutores("Gustavo Paes", "023.599.199.94", "Andre Gargioni", "emailteste@gmail.com", "99-99999-9999", "12323432193", "segunda - feira, 4 de julho de 2022");

            repo.InserirNovo(condutor);

            var condutores = repo.SelecionarPorId(condutor.Id).Value;

            Assert.AreEqual(condutores, condutor);
        }

        [TestMethod]
        public void DeveBuscarVariosCondutores()
        {
            ServicoCondutores repo = new ServicoCondutores(new RepositorioCondutorOrm(dbContext));

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
            ServicoCondutores repo = new ServicoCondutores(new RepositorioCondutorOrm(dbContext));

            Condutores tax = new Condutores("Gustavo Paes", "023.599.199.94", "Andre Gargioni", "emailteste@gmail.com", "99-99999-9999", "12323432193", "segunda - feira, 4 de julho de 2022");

            repo.InserirNovo(tax);

            var exite = repo.Existe(tax.Id).Value;

            Assert.IsTrue(exite);
        }

        [TestMethod]
        public void DeveDeletarCondutores()
        {
            ServicoCondutores repo = new ServicoCondutores(new RepositorioCondutorOrm(dbContext));

            Condutores condutore = new Condutores("Gustavo Paes", "023.599.199.94", "Andre Gargioni", "emailteste@gmail.com", "99-99999-9999", "12323432193", "segunda - feira, 4 de julho de 2022");

            repo.InserirNovo(condutore);

            repo.Excluir(repo.SelecionarPorId(condutore.Id).Value);

            var existe = repo.Existe(condutore.Id).Value;

            Assert.IsFalse(existe);
        }
    }
}
