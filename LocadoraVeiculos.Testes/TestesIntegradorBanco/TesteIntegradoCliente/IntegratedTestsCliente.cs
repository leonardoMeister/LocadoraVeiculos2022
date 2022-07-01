using LocadoraVeiculos.Dominio.ModuloCliente;
using LocadoraVeiculos.RepositorioProject.ModuloCliente;
using LocadoraVeiculos.RepositorioProject.shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocadoraVeiculos.Testes.TestesIntegradorBanco.TesteIntegradoCliente
{
    [TestClass]
    public class IntegratedTestsCliente
    {
        public IntegratedTestsCliente()
        {
            string query = @"delete from TB_CLIENTE;
                            DBCC CHECKIDENT (TB_CLIENTE, RESEED, 1)";
            DataBase.ExecutarComando(query);
        }

        [TestMethod]
        public void DeveInserirCliente()
        {
            RepositorioCliente repo = new RepositorioCliente(new MapeadorCliente());

            Cliente cli = new Cliente("Lonardo", "19343294399", "estrada noeva", "leonrado@gmail.com", "47 99232-3433", "Tipo 2", "minha cnh");

            repo.InserirNovo(cli);

            var cliente = repo.SelecionarPorId(cli._id);

            Assert.AreEqual(cliente._id, cli._id);
            Assert.AreEqual(cliente.Telefone, cli.Telefone);
            Assert.AreEqual(cliente.TipoCliente, cli.TipoCliente);
            Assert.AreEqual(cliente.Cnpj, cli.Cnpj);
        }

        [TestMethod]
        public void DeveBuscarVariosClientes()
        {
            RepositorioCliente repo = new RepositorioCliente(new MapeadorCliente());

            Cliente cli = new Cliente("Lonardo", "19343294399", "estrada noeva", "leonrado@gmail.com", "47 99232-3433", "Tipo 2", "minha cnh");
            Cliente cli2 = new Cliente("Lonardo2", "19343294399", "estrada noeva2", "leonrado2@gmail.com", "47 99232-3433", "Tipo 22", "minha cnh2");

            repo.InserirNovo(cli);
            repo.InserirNovo(cli2);

            var dados = repo.SelecionarTodos();

            Assert.AreEqual(2, dados.Count);

        }

        [TestMethod]
        public void DeveVerificarExistenciaCliente()
        {
            RepositorioCliente repo = new RepositorioCliente(new MapeadorCliente());

            Cliente cli = new Cliente("Lonardo", "19343294399", "estrada noeva", "leonrado@gmail.com", "47 99232-3433", "Tipo 2", "minha cnh");

            repo.InserirNovo(cli);

            var exite = repo.Existe(cli._id);

            Assert.IsTrue(exite);
        }

        [TestMethod]
        public void DeveEditarCliente()
        {
            RepositorioCliente repo = new RepositorioCliente(new MapeadorCliente());

            Cliente cli = new Cliente("Lonardo", "19343294399", "estrada noeva", "leonrado@gmail.com", "47 99232-3433", "Tipo 2", "minha cnh");

            repo.InserirNovo(cli);

            Cliente cli2 = new Cliente("Lonardo2", "19343294399", "estrada noeva2", "leonrado2@gmail.com", "47 99232-3433", "Tipo 22", "minha cnh2");

            repo.Editar(cli._id, cli2);

            var clienteBanco = repo.SelecionarPorId(cli2._id);

            Assert.AreEqual(cli2, clienteBanco);
        }

        [TestMethod]
        public void DeveDeletarCliente()
        {
            RepositorioCliente repo = new RepositorioCliente(new MapeadorCliente());

            Cliente cli = new Cliente("Lonardo", "19343294399", "estrada noeva", "leonrado@gmail.com", "47 99232-3433", "Tipo 2", "minha cnh");

            repo.InserirNovo(cli);

            repo.Excluir(cli._id);

            var existe = repo.Existe(cli._id);

            Assert.IsFalse(existe);
        }
    }
}
