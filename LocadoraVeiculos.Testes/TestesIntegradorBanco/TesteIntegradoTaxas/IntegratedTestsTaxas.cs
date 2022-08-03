using LocadoraVeiculos.Controladores.ModuloServicoTaxas;
using LocadoraVeiculos.Dominio.ModuloTaxas;
using LocadoraVeiculos.Infra.Configuracao;
using LocadoraVeiculos.Infra.Orm.Compatilhado;
using LocadoraVeiculos.Infra.Orm.ModuloTaxas;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocadoraVeiculos.Testes.TestesIntegradorBanco.TesteIntegradoTaxas
{
    [TestClass]
    public class IntegratedTestsTaxas
    {
        private LocadoraVeiculosDbContext dbContext;

        public IntegratedTestsTaxas()
        {
            var config = new ConfiguracaoAplicacao();

            dbContext = new LocadoraVeiculosDbContext(config.connectionStrings.SqlServer);


            var taxas = dbContext.Set<Taxas>();
            taxas.RemoveRange(taxas);
            dbContext.SaveChanges();
        }

        [TestMethod]
        public void DeveInserirTaxas()
        {
            ServicoTaxas repo = new ServicoTaxas(new RepositorioTaxaOrm(dbContext), dbContext);
            Taxas tax = new Taxas("Aluguel Onix", 1500, EnumTaxa.Diaria.ToString());
            repo.InserirNovo(tax);

            var taxas = repo.SelecionarPorId(tax.Id).Value;

            Assert.AreEqual(taxas, tax);
        }

        [TestMethod]
        public void DeveBuscarVariosTaxas()
        {
            ServicoTaxas repo = new ServicoTaxas(new RepositorioTaxaOrm(dbContext), dbContext);
            Taxas tax = new Taxas("Aluguel Onix", 1500, EnumTaxa.Diaria.ToString());
            Taxas tax2 = new Taxas("Aluguel HB20", 1000, EnumTaxa.Diaria.ToString());

            repo.InserirNovo(tax);
            repo.InserirNovo(tax2);
            var lista = repo.SelecionarTodos().Value;

            Assert.AreEqual(2, lista.Count);
        }

        [TestMethod]
        public void DeveVerificarExistenciaTaxas()
        {
            ServicoTaxas repo = new ServicoTaxas(new RepositorioTaxaOrm(dbContext), dbContext);
            Taxas tax = new Taxas("Aluguel Onix", 1500, EnumTaxa.Diaria.ToString());
            repo.InserirNovo(tax);

            var exite = repo.Existe(tax.Id);

            Assert.IsTrue(exite.Value);
        }

        [TestMethod]
        public void DeveEditarTaxas()
        {
            ServicoTaxas repo = new ServicoTaxas(new RepositorioTaxaOrm(dbContext), dbContext);
            Taxas tax = new Taxas("Aluguel Onix", 1500, EnumTaxa.Diaria.ToString());
            repo.InserirNovo(tax);

            tax.Descricao = "NOVA DESCRICAO PARA TAXA";
            repo.Editar(tax);

            var taxNovo = repo.SelecionarPorId(tax.Id).Value;
            Assert.AreEqual(taxNovo, tax);
        }

        [TestMethod]
        public void DeveDeletarTaxas()
        {
            ServicoTaxas repo = new ServicoTaxas(new RepositorioTaxaOrm(dbContext), dbContext);
            Taxas tax = new Taxas("Aluguel HB20", 1000, EnumTaxa.Diaria.ToString());
            repo.InserirNovo(tax);

            repo.Excluir(repo.SelecionarPorId(tax.Id).Value);

            var existe = repo.Existe(tax.Id);

            Assert.IsFalse(existe.Value);
        }
    }
}
