using LocadoraVeiculos.Dominio.ModuloTaxas;
using LocadoraVeiculos.Infra.Orm;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Testes.TestesORM.OrmTaxa
{
    [TestClass]
    public class TesteOrmTaxas
    {
        public TesteOrmTaxas()
        {
            GeradorLocadoraDbContext dbContext = new GeradorLocadoraDbContext();
            dbContext.Taxas.RemoveRange(dbContext.Taxas);

            dbContext.SaveChanges();
        }

        [TestMethod]
        public void DeveInserirTaxa()
        {
            GeradorLocadoraDbContext dbContext = new GeradorLocadoraDbContext();

            var taxa = new Taxas("Descricao da taxa",100,EnumTaxa.Diaria.ToString());

            dbContext.Taxas.Add(taxa);

            dbContext.SaveChanges();

            Taxas taxaSelecionada = dbContext.Taxas.Where(x => x.Id == taxa.Id).First();
            
            Assert.AreEqual(taxaSelecionada, taxa);
            
        }
    }
}
