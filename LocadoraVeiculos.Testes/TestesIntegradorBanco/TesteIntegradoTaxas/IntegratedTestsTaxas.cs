using LocadoraVeiculos.Controladores.ModuloControladorTaxas;
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
            string query = @"delete from TB_TAXAS;
                            DBCC CHECKIDENT (TB_TAXAS, RESEED, 1)";
            DataBase.ExecutarComando(query);
        }

        [TestMethod]
        public void DeveInserirTaxas()
        {
            ControladorTaxas repo = new ControladorTaxas();

            Taxas tax = new Taxas("Aluguel Onix", 1500, EnumTaxa.Diaria.ToString());

            repo.InserirNovo(tax);

            var taxas = repo.SelecionarPorId(tax._id);

            Assert.AreEqual(taxas._id, tax._id);
            Assert.AreEqual(taxas.Descricao, tax.Descricao);
            Assert.AreEqual(taxas.Valor, tax.Valor);
        }

        [TestMethod]
        public void DeveBuscarVariosTaxas()
        {
            ControladorTaxas repo = new ControladorTaxas();

            Taxas tax = new Taxas("Aluguel Onix", 1500, EnumTaxa.Diaria.ToString());
            Taxas tax2 = new Taxas("Aluguel HB20", 1000, EnumTaxa.Diaria.ToString());

            repo.InserirNovo(tax);
            repo.InserirNovo(tax2);

            var dados = repo.SelecionarTodos();

            Assert.AreEqual(2, dados.Count);

        }

        [TestMethod]
        public void DeveVerificarExistenciaTaxas()
        {
            ControladorTaxas repo = new ControladorTaxas();

            Taxas tax = new Taxas("Aluguel Onix", 1500, EnumTaxa.Diaria.ToString());

            repo.InserirNovo(tax);

            var exite = repo.Existe(tax._id);

            Assert.IsTrue(exite);
        }

        [TestMethod]
        public void DeveEditarTaxas()
        {
            ControladorTaxas repo = new ControladorTaxas();

            Taxas tax = new Taxas("Aluguel Onix", 1500, EnumTaxa.Diaria.ToString());

            repo.InserirNovo(tax);

            Taxas tax2 = new Taxas("Aluguel HB20", 1000, EnumTaxa.Diaria.ToString());
            tax2._id = tax._id;

            repo.Editar(tax2);

            var taxasBanco = repo.SelecionarPorId(tax2._id);

            Assert.AreEqual(tax2, taxasBanco);
        }

        [TestMethod]
        public void DeveDeletarTaxas()
        {
            ControladorTaxas repo = new ControladorTaxas();

            Taxas tax = new Taxas("Aluguel HB20", 1000, EnumTaxa.Diaria.ToString());

            repo.InserirNovo(tax);

            repo.Excluir(tax._id);

            var existe = repo.Existe(tax._id);

            Assert.IsFalse(existe);
        }
    }
}
