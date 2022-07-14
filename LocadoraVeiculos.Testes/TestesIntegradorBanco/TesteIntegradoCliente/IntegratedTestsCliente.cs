using LocadoraVeiculos.Controladores.ModuloServicoCliente;
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
            string query = @"delete from TB_CLIENTE;";
            DataBase.ExecutarComando(query);
        }

        [TestMethod]
        public void DeveInserirCliente()
        {
            ServicoCliente repo = new ServicoCliente();

            Cliente cli = new Cliente("Lonardo", "193.432.943.99", "estrada noeva", "leonrado@gmail.com", "47 99232-3433",
                EnumCliente.PessoaFisica.ToString(), "");

            repo.InserirNovo(cli);

            var cliente = repo.SelecionarPorId(cli._id).Value;

            Assert.AreEqual(cliente._id, cli._id);
            Assert.AreEqual(cliente.Telefone, cli.Telefone);
            Assert.AreEqual(cliente.TipoCliente, cli.TipoCliente);
            Assert.AreEqual(cliente.Cnpj, cli.Cnpj);
        }

        [TestMethod]
        public void DeveBuscarVariosClientes()
        {
            ServicoCliente repo = new ServicoCliente();

            Cliente cli = new Cliente("Lonardo", "193.432.943.99", "estrada noeva", "leonrado@gmail.com", "47 99232-3433",
                EnumCliente.PessoaFisica.ToString(), "");
            Cliente cli2 = new Cliente("LonardoMeister", "193.432.943.93", "estrada noevaEdiutada", "leonrado@gmail.com", "47 99232-3433",
                EnumCliente.PessoaFisica.ToString(), "");

            repo.InserirNovo(cli);
            repo.InserirNovo(cli2);

            var dados = repo.SelecionarTodos().Value;

            Assert.AreEqual(2, dados.Count);

        }

        [TestMethod]
        public void DeveVerificarExistenciaCliente()
        {
            ServicoCliente repo = new ServicoCliente();

            Cliente cli = new Cliente("Lonardo", "193.432.943.99", "estrada noeva", "leonrado@gmail.com", "47 99232-3433",
                           EnumCliente.PessoaFisica.ToString(), "");

            repo.InserirNovo(cli);

            var exite = repo.Existe(cli._id).Value;

            Assert.IsTrue(exite);
        }

        [TestMethod]
        public void DeveEditarCliente()
        {
            ServicoCliente repo = new ServicoCliente();

            Cliente cli = new Cliente("Lonardo", "193.432.943.99", "estrada noeva", "leonrado@gmail.com", "47 99232-3433",
                           EnumCliente.PessoaFisica.ToString(), "");
            repo.InserirNovo(cli);

            Cliente cli2 = new Cliente("LonardoEDITADO", "193.432.943.97", "estrada noevaEDITADO", "leonradoEDITADO@gmail.com", "48 99232-3433",
                           EnumCliente.PessoaFisica.ToString(), "");

            cli2._id = cli._id;
            repo.Editar(cli2);

            var clienteBanco = repo.SelecionarPorId(cli2._id).Value;

            Assert.AreEqual(cli2, clienteBanco);
        }

        [TestMethod]
        public void DeveDeletarCliente()
        {
            ServicoCliente repo = new ServicoCliente();

            Cliente cli = new Cliente("Lonardo", "193.432.943.99", "estrada noeva", "leonrado@gmail.com", "47 99232-3433",
                                       EnumCliente.PessoaFisica.ToString(), "");
            repo.InserirNovo(cli);

            repo.Excluir(repo.SelecionarPorId(cli._id).Value);

            var existe = repo.Existe(cli._id).Value;

            Assert.IsFalse(existe);
        }
    }
}
