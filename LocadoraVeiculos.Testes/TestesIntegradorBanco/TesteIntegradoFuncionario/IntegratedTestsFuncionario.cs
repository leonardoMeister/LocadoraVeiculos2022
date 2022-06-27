using LocadoraVeiculos.Dominio.ModuloFuncionario;
using LocadoraVeiculos.RepositorioProject.ModuloFuncionario;
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
                            DBCC CHECKIDENT (TB_FUNCIONARIO, RESEED, 0)";

            DataBase.ExecutarComando(query);
        }

        [TestMethod]
        public void DeveInserirFuncionario()
        {
            RepositorioFuncionario repo = new RepositorioFuncionario(new MapeadorFuncionario());

            var fun = new Funcionario("Leonardo", "leonardo123", "leoJosePedrinho123Senha", 2800, DateTime.Now, "Funcionario");

            repo.InserirNovo(fun);

            var funcionario = repo.SelecionarPorId(fun._id);

            Assert.AreEqual(funcionario, fun);
        }

        [TestMethod]
        public void DeveBuscarVariosFuncionarios()
        {
            RepositorioFuncionario repo = new RepositorioFuncionario(new MapeadorFuncionario());
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
            RepositorioFuncionario repo = new RepositorioFuncionario(new MapeadorFuncionario());
            var fun = new Funcionario("Leonardo", "leonardo123", "leoJosePedrinho123Senha", 2800, DateTime.Now, "Funcionario");
            repo.InserirNovo(fun);

            var existe = repo.Existe(fun._id);

            Assert.IsTrue(existe);
        }
        [TestMethod]
        public void DeveVerificarExclusaoFuncionarios()
        {
            RepositorioFuncionario repo = new RepositorioFuncionario(new MapeadorFuncionario());
            var fun = new Funcionario("Leonardo", "leonardo123", "leoJosePedrinho123Senha", 2800, DateTime.Now, "Funcionario");
            repo.InserirNovo(fun);

            repo.Excluir(fun._id);

            var existe = repo.Existe(fun._id);

            Assert.IsFalse(existe);
        }

        [TestMethod]
        public void DeveEditarFuncionario()
        {
            RepositorioFuncionario repo = new RepositorioFuncionario(new MapeadorFuncionario());
            var fun = new Funcionario("Leonardo", "leonardo123", "leoJosePedrinho123Senha", 2800, DateTime.Now, "Funcionario");
            repo.InserirNovo(fun);
            
            var fun2 = new Funcionario("Leonardo2", "leonardo1233", "leoJosePedrinhoSenha", 4000, DateTime.Now, "Funcionario de elite");
            repo.Editar(fun._id, fun2);

            var funNovo = repo.SelecionarPorId(fun._id);
            Assert.AreEqual(funNovo, fun2);
        }
    }
}
