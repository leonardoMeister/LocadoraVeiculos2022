using LocadoraVeiculos.Dominio.ModuloFuncionario;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Testes.TestesUnitarios.TestesUnitarioFuncionario
{
    [TestClass]
    public class UnitFuncionarioTeste
    {
        [TestMethod]
        public void DeveImpedirCriar()
        {
            ValidadorFuncionario validador = new ValidadorFuncionario();

            Funcionario func1 = new Funcionario("Leonardo", "leoNardo", "leo", 1400, DateTime.Now, "Academico");
            Funcionario func2 = new Funcionario("Le", "leoNardo", "leoNardo", 1400, DateTime.Now, "Academico");
            Funcionario func3 = new Funcionario("Leonardo", "leoNardo", "leoNardo", 0, DateTime.Now, "Academico");            
            Funcionario func4 = new Funcionario("Leonardo", "le", "leonardo", 1400, DateTime.Now, "Academico");

            var result = validador.Validate(func1);
            Assert.AreEqual(result.IsValid, false);

            result = validador.Validate(func2);
            Assert.AreEqual(result.IsValid, false);
            
            result = validador.Validate(func3);
            Assert.AreEqual(result.IsValid, false);

            result = validador.Validate(func4);
            Assert.AreEqual(result.IsValid, false);
        }

        [TestMethod]
        public void DevePermitirCriar()
        {
            ValidadorFuncionario validador = new ValidadorFuncionario();

            Funcionario func1 = new Funcionario("Leonardo", "leoNardo", "leoNardo", 1400, DateTime.Now, "Academico");

            var result = validador.Validate(func1);
            Assert.AreEqual(result.IsValid, true);
        }
    }
}
