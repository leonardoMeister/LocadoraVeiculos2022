using LocadoraVeiculos.Controladores.ModuloServicoFuncionario;
using LocadoraVeiculos.Dominio.ModuloFuncionario;
using LocadoraVeiculos.Infra.Orm.Compatilhado;
using LocadoraVeiculos.Infra.Orm.ModuloFuncionario;
using LocadoraVeiculos.RepositorioProject.shared;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace LocadoraVeiculos.Testes.TestesIntegradorBanco.TesteIntegradoFuncionario
{
    [TestClass]
    public class IntegratedTestsFuncionario
    {
        private LocadoraVeiculosDbContext dbContext;

        public IntegratedTestsFuncionario()
        {
            var configuracao = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("ConfiguracaoAplicacao.json")
                .Build();

            var connectionString = configuracao
                .GetSection("ConnectionStrings")
                .GetSection("SqlServer")
                .Value;
            dbContext = new LocadoraVeiculosDbContext(connectionString);

            var funcionario = dbContext.Set<Funcionario>();
            funcionario.RemoveRange(funcionario);
            dbContext.SaveChanges();
        }

        [TestMethod]
        public void DeveInserirFuncionario()
        {
            ServicoFuncionario repo = new ServicoFuncionario(new RepositorioFuncionarioOrm(dbContext), dbContext);

            var fun = new Funcionario("Leonardo", "leonardo123", "leoJosePedrinho123Senha", 2800, DateTime.Now, "Funcionario");

            repo.InserirNovo(fun);

            var funcionario = repo.SelecionarPorId(fun.Id).Value;

            Assert.AreEqual(funcionario, fun);
        }

        [TestMethod]
        public void DeveBuscarVariosFuncionarios()
        {
            ServicoFuncionario repo = new ServicoFuncionario(new RepositorioFuncionarioOrm(dbContext), dbContext);
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
            ServicoFuncionario repo = new ServicoFuncionario(new RepositorioFuncionarioOrm(dbContext), dbContext);
            var fun = new Funcionario("Leonardo", "leonardo123", "leoJosePedrinho123Senha", 2800, DateTime.Now, "Funcionario");
            repo.InserirNovo(fun);

            var existe = repo.Existe(fun.Id).Value;

            Assert.IsTrue(existe);
        }
        [TestMethod]
        public void DeveVerificarExclusaoFuncionarios()
        {
            ServicoFuncionario repo = new ServicoFuncionario(new RepositorioFuncionarioOrm(dbContext), dbContext);
            var fun = new Funcionario("Leonardo", "leonardo123", "leoJosePedrinho123Senha", 2800, DateTime.Now, "Funcionario");
            repo.InserirNovo(fun);
            
            repo.Excluir(repo.SelecionarPorId(fun.Id).Value);

            var existe = repo.Existe(fun.Id).Value;

            Assert.IsFalse(existe);
        }

        [TestMethod]
        public void DeveEditarFuncionario()
        {
            ServicoFuncionario repo = new ServicoFuncionario(new RepositorioFuncionarioOrm(dbContext), dbContext);
            var fun = new Funcionario("Leonardo", "leonardo123", "leoJosePedrinho123Senha", 2800, DateTime.Now, "Funcionario");
            repo.InserirNovo(fun);

            fun.Nome = "Novo nome para funcionario";
            var le = repo.Editar(fun);

            var funNovo = repo.SelecionarPorId(fun.Id).Value;
            Assert.AreEqual(funNovo, fun);
        }
    }
}
