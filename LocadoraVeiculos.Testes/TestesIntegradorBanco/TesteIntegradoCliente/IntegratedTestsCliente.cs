using LocadoraVeiculos.Dominio.ModuloCliente;
using LocadoraVeiculos.RepositorioProject.ModuloCliente;
using LocadoraVeiculos.RepositorioProject.shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Testes.TestesIntegradorBanco.TesteIntegradoCliente
{
    [TestClass]
    public class IntegratedTestsCliente
    {
        public IntegratedTestsCliente()
        {
            string query = @"delete from TB_CLIENTE;
                            DBCC CHECKIDENT (TB_CLIENTE, RESEED, 0)";
            DataBase.ExecutarComando(query);
        }

        [TestMethod]
        public void DeveInserirCliente()
        {
            RepositorioCliente repo = new RepositorioCliente(new MapeadorCliente());

            Cliente cli = new Cliente("Lonardo","19343294399","estrada noeva","leonrado@gmail.com","47 99232-3433","Tipo 2","minha cnh");

            repo.InserirNovo(cli);

            var cliente = repo.SelecionarPorId(cli._id);

            Assert.AreEqual(cliente._id, cli._id);
            Assert.AreEqual(cliente.Telefone, cli.Telefone);
            Assert.AreEqual(cliente.TipoCliente, cli.TipoCliente);
            Assert.AreEqual(cliente.Cnh, cli.Cnh);


        }
    }
}
