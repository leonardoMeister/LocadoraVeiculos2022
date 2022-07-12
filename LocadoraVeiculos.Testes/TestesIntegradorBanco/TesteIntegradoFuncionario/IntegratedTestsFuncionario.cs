using LocadoraVeiculos.Controladores.ModuloFuncionario;
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
            string query = @"delete from TB_FUNCIONARIO;
                            DBCC CHECKIDENT (TB_FUNCIONARIO, RESEED, 1)";

            DataBase.ExecutarComando(query);
        }

        [TestMethod]
        public void DeveInserirFuncionario()
        {
            ControladorFuncionario repo = new ControladorFuncionario();

            var fun = new Funcionario("Leonardo", "leonardo123", "leoJosePedrinho123Senha", 2800, DateTime.Now, "Funcionario");

            repo.InserirNovo(fun);

            var funcionario = repo.SelecionarPorId(fun._id);

            Assert.AreEqual(funcionario, fun);
        }

        [TestMethod]
        public void DeveBuscarVariosFuncionarios()
        {
            ControladorFuncionario repo = new ControladorFuncionario();
            var fun = new Funcionario("Leonardo", "leonardo123", "leoJosePedrinho123Senha", 2800, DateTime.Now, "Funcionario");
            var fun2 = new Funcionario("Leonardo2", "leonardo1233", "leoJosePedrinhoSenha", 4000, DateTime.Now, "Funcionario de elite");

            repo.InserirNovo(fun);
            repo.InserirNovo(fun2);
            var lista = repo.SelecionarTodos();

            Assert.AreEqual(2, lista.Count);
        }
        [TestMethod]
        public void DeveVerificarExistenciaFuncionarios()
        {
            ControladorFuncionario repo = new ControladorFuncionario();
            var fun = new Funcionario("Leonardo", "leonardo123", "leoJosePedrinho123Senha", 2800, DateTime.Now, "Funcionario");
            repo.InserirNovo(fun);

            var existe = repo.Existe(fun._id);

            Assert.IsTrue(existe);
        }
        [TestMethod]
        public void DeveVerificarExclusaoFuncionarios()
        {
            ControladorFuncionario repo = new ControladorFuncionario();
            var fun = new Funcionario("Leonardo", "leonardo123", "leoJosePedrinho123Senha", 2800, DateTime.Now, "Funcionario");
            repo.InserirNovo(fun);

            repo.Excluir(fun._id);

            var existe = repo.Existe(fun._id);

            Assert.IsFalse(existe);
        }

        [TestMethod]
        public void DeveEditarFuncionario()
        {
            ControladorFuncionario repo = new ControladorFuncionario();
            var fun = new Funcionario("Leonardo", "leonardo123", "leoJosePedrinho123Senha", 2800, DateTime.Now, "Funcionario");
            repo.InserirNovo(fun);

            var fun2 = new Funcionario("Leonardo2", "leonardo1233", "leoJosePedrinhoSenha", 4000, DateTime.Now, "Funcionario de elite");
            fun2._id = fun._id;
            repo.Editar(fun2);

            var funNovo = repo.SelecionarPorId(fun._id);
            Assert.AreEqual(funNovo, fun2);
        }
    }
}
