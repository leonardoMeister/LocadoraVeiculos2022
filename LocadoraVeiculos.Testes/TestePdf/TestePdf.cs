using LocadoraVeiculos.Dominio.ModuloCliente;
using LocadoraVeiculos.Dominio.ModuloCondutores;
using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraVeiculos.Dominio.ModuloLocacao;
using LocadoraVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraVeiculos.Dominio.ModuloTaxas;
using LocadoraVeiculos.Dominio.ModuloVeiculo;
using LocadoraVeiculos.Infra.Configuracao;
using LocadoraVeiculos.Infra.Orm.Compatilhado;
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

            dbContext = new LocadoraVeiculosDbContext(config.connectionStrings.SqlServer);


            var locacoes = dbContext.Set<Locacao>();
            locacoes.RemoveRange(locacoes);

            var clientes = dbContext.Set<Cliente>();
            clientes.RemoveRange(clientes);

            var condutores = dbContext.Set<Condutores>();
            condutores.RemoveRange(condutores);

            var grupoVeiculos = dbContext.Set<GrupoVeiculos>();
            grupoVeiculos.RemoveRange(grupoVeiculos);

            var planoCobranca = dbContext.Set<PlanoCobranca>();
            planoCobranca.RemoveRange(planoCobranca);

            var taxas = dbContext.Set<Taxas>();
            taxas.RemoveRange(taxas);

            var veiculo = dbContext.Set<Veiculo>();
            veiculo.RemoveRange(veiculo);

            dbContext.SaveChanges();
        }


        [TestMethod]
        public void DeveCrirPdf() 
        {
            GrupoVeiculos grupo = new GrupoVeiculos("Nome do grupo de teste");

            byte[] foto = new byte[] { };
            Veiculo vei = new Veiculo("Modelo do Veiculo", "ASD-3021", "Gol", "Rosa", TipoCombustivelEnum.Gasolina, 10, DateTime.Now, 10, foto, grupo);
            PlanoCobranca plano = new PlanoCobranca("Tipo Grupo 1", 100, 0, 10, grupo);
            Condutores condutor = new Condutores("Gustavo Paes", "023.599.199.94", "Andre Gargioni", "emailteste@gmail.com", "99-99999-9999", "12323432193", "segunda - feira, 4 de julho de 2022");
            Cliente cli = new Cliente("Gustavasdasdasdo", "214.432.723.99", "testeasdasdadsasd", "teste@gmail.com", "49 99830-8533",
            EnumCliente.PessoaFisica.ToString(), "");
            Taxas taxa = new Taxas("Aluguel Onix", 1500, EnumTaxa.Diaria.ToString());
            List<Taxas> tax = new List<Taxas>();
            tax.Add(taxa);

            Locacao locacao = new Locacao(vei, condutor, cli, grupo, plano, DateTime.Now, DateTime.Now, 10, NivelTanqueEnum.medio, tax, false, 100, DateTime.Now, NivelTanqueEnum.alto);

            
        }
    }
}
