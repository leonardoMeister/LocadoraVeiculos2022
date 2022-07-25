using LocadoraVeiculos.Controladores.ModuloServicoTaxas;
using LocadoraVeiculos.Dominio.ModuloTaxas;
using LocadoraVeiculos.RepositorioProject.ModuloTaxas;
using LocadoraVeiculos.RepositorioProject.shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocadoraVeiculos.Testes.TestesIntegradorBanco.TesteIntegradoTaxas
{
    [TestClass]
    public class IntegratedTestsTaxas
    {
        public IntegratedTestsTaxas()
        {
            string query = @"delete from TB_TAXAS;";
            DataBase.ExecutarComando(query);
        }

        [TestMethod]
        public void DeveInserirTaxas()
        {
            ServicoTaxas repo = new ServicoTaxas();
            Taxas tax = new Taxas("Aluguel Onix", 1500, EnumTaxa.Diaria.ToString());
            repo.InserirNovo(tax);

            var taxas = repo.SelecionarPorId(tax.Id).Value;

            Assert.AreEqual(taxas, tax);
        }

        [TestMethod]
        public void DeveBuscarVariosTaxas()
        {
            ServicoTaxas repo = new ServicoTaxas();
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
            ServicoTaxas repo = new ServicoTaxas();
            Taxas tax = new Taxas("Aluguel Onix", 1500, EnumTaxa.Diaria.ToString());
            repo.InserirNovo(tax);

            var exite = repo.Existe(tax.Id);

            Assert.IsTrue(exite.Value);
        }

        [TestMethod]
        public void DeveEditarTaxas()
        {
            ServicoTaxas repo = new ServicoTaxas();
            Taxas tax = new Taxas("Aluguel Onix", 1500, EnumTaxa.Diaria.ToString());
            repo.InserirNovo(tax);

            Taxas tax2 = new Taxas("Aluguel HB20", 1000, EnumTaxa.Diaria.ToString());
            tax2.Id = tax.Id;
            repo.Editar(tax2);

            var taxNovo = repo.SelecionarPorId(tax2.Id).Value;
            Assert.AreEqual(taxNovo, tax2);
        }

        [TestMethod]
        public void DeveDeletarTaxas()
        {
            ServicoTaxas repo = new ServicoTaxas();
            Taxas tax = new Taxas("Aluguel HB20", 1000, EnumTaxa.Diaria.ToString());
            repo.InserirNovo(tax);

            repo.Excluir(repo.SelecionarPorId(tax.Id).Value);

            var existe = repo.Existe(tax.Id);

            Assert.IsFalse(existe.Value);
        }
    }
}
