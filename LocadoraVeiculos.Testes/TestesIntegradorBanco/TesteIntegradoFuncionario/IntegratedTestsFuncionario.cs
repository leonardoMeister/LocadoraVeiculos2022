using LocadoraVeiculos.Controladores.ModuloServicoFuncionario;
using LocadoraVeiculos.Dominio.ModuloFuncionario;
using LocadoraVeiculos.RepositorioProject.shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LocadoraVeiculos.Testes.TestesIntegradorBanco.TesteIntegradoFuncionario
{
    [TestClass]
    public class IntegratedTestsFuncionario
    {
        public IntegratedTestsFuncionario()
        {
            string query = @"delete from TB_FUNCIONARIO;";

            DataBase.ExecutarComando(query);
        }

        [TestMethod]
        public void DeveInserirFuncionario()
        {
            ServicoFuncionario repo = new ServicoFuncionario();

            var fun = new Funcionario("Leonardo", "leonardo123", "leoJosePedrinho123Senha", 2800, DateTime.Now, "Funcionario");

            repo.InserirNovo(fun);

            var funcionario = repo.SelecionarPorId(fun._id).Value;

            Assert.AreEqual(funcionario, fun);
        }

        [TestMethod]
        public void DeveBuscarVariosFuncionarios()
        {
            ServicoFuncionario repo = new ServicoFuncionario();
            var fun = new Funcionario("Leonardo", "leonardo123", "leoJosePedrinho123Senha", 2800, DateTime.Now, "Funcionario");
            var fun2 = new Funcionario("Leonardo2", "leonardo1233", "leoJosePedrinhoSenha", 4000, DateTime.Now, "Funcionario de elite");

            repo.InserirNovo(fun);
            repo.InserirNovo(fun2);
            var lista = repo.SelecionarTodos().Value;

            Assert.AreEqual(2, lista.Count);
        }
        [TestMethod]
        public void DeveVerificarExistenciaFuncionarios()
        {
            ServicoFuncionario repo = new ServicoFuncionario();
            var fun = new Funcionario("Leonardo", "leonardo123", "leoJosePedrinho123Senha", 2800, DateTime.Now, "Funcionario");
            repo.InserirNovo(fun);

            var existe = repo.Existe(fun._id);

            Assert.IsTrue(existe.Value);
        }
        [TestMethod]
        public void DeveVerificarExclusaoFuncionarios()
        {
            ServicoFuncionario repo = new ServicoFuncionario();
            var fun = new Funcionario("Leonardo", "leonardo123", "leoJosePedrinho123Senha", 2800, DateTime.Now, "Funcionario");
            repo.InserirNovo(fun);
            
            repo.Excluir(repo.SelecionarPorId(fun._id).Value);

            var existe = repo.Existe(fun._id);

            Assert.IsFalse(existe.Value);
        }

        [TestMethod]
        public void DeveEditarFuncionario()
        {
            ServicoFuncionario repo = new ServicoFuncionario();
            var fun = new Funcionario("Leonardo", "leonardo123", "leoJosePedrinho123Senha", 2800, DateTime.Now, "Funcionario");
            repo.InserirNovo(fun);

            var fun2 = new Funcionario("Leonardo2", "leonardo1233", "leoJosePedrinhoSenha", 4000, DateTime.Now, "Funcionario de elite");
            fun2._id = fun._id;
            repo.Editar(fun2);

            var funNovo = repo.SelecionarPorId(fun._id).Value;
            Assert.AreEqual(funNovo, fun2);
        }
    }
}
