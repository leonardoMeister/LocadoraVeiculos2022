using LocadoraVeiculos.Dominio.ModuloCliente;
using LocadoraVeiculos.Dominio.ModuloCondutores;
using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraVeiculos.Dominio.ModuloLocacao;
using LocadoraVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraVeiculos.Dominio.ModuloTaxas;
using LocadoraVeiculos.Dominio.ModuloVeiculo;
using LocadoraVeiculos.Infra.Configuracao;
using LocadoraVeiculos.Infra.Orm.Compatilhado;
using LocadoraVeiculos.Infra.Pdf;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Testes.TestePdf
{
    [TestClass]
    public class TestePdf
    {
        private LocadoraVeiculosDbContext dbContext;

        public TestePdf()
        {
            var config = new ConfiguracaoAplicacao();

            dbContext = new LocadoraVeiculosDbContext("Data Source=(LOCALDB)\\MSSQLLOCALDB;Initial Catalog=LocadoraVeiculos;Integrated Security = True;Pooling = false;");


        }


        [TestMethod]
        public void MetodoParaAjudaraCriaroMalditoPDFLocacaoDevolucao()  
        {
            DbSet<Locacao> locacao = dbContext.Set<Locacao>();
            var loc = locacao
                .Include(x => x.PlanoCobranca)
                .Include(x => x.Cliente)
                .Include(x => x.Condutores)
                .Include(x => x.GrupoVeiculos)
                .Include(x => x.ListaTaxas)
                .Include(x => x.Veiculo)
                .FirstOrDefault();

            var local = @"C:\Users\leozi\OneDrive\Área de Trabalho\LocacaoPdf.pdf";
            GeradorRelatorioLocacao gerador = new GeradorRelatorioLocacao();
            gerador.GerarRelatorioPdf(loc, local);

            Assert.IsTrue(true);
        }
    }
}
