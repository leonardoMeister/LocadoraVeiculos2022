using LocadoraVeiculos.Dominio.ModuloCondutores;
using LocadoraVeiculos.RepositorioProject.ModuloCondutores;
using LocadoraVeiculos.RepositorioProject.shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocadoraVeiculos.Testes.TestesUnitarios.TesteUnitarioCondutores
{
    [TestClass]
    public class UnitCondutoresTeste
    {
        [TestMethod]
        public void DeveImpedirCriarCondutoresSemNome()
        {
            ValidadorCondutores validador = new ValidadorCondutores();

            Condutores condutores = new Condutores("", "02359919994", "Andre Gargioni", "emailteste@gmail.com", "99-99999-9999", "dasdasdasdasdas", "segunda - feira, 4 de julho de 2022");
            var result = validador.Validate(condutores);
            Assert.AreEqual(result.IsValid, false);
        }

        [TestMethod]
        public void DeveImpedirCriarCondutoresNome2Caractere()
        {
            ValidadorCondutores validador = new ValidadorCondutores();

            Condutores condutores = new Condutores("da", "02359919994", "Andre Gargioni", "emailteste@gmail.com", "99-99999-9999", "dasdasdasdasdas", "segunda - feira, 4 de julho de 2022");
            var result = validador.Validate(condutores);
            Assert.AreEqual(result.IsValid, false);
        }

        [TestMethod]
        public void DevePermitirCriarCondutores()
        {
            ValidadorCondutores validador = new ValidadorCondutores();
            Condutores condutores = new Condutores("Gustavo Paes", "02359919994", "Andre Gargioni", "emailteste@gmail.com", "99-99999-9999", "dasdasdasdasdas", "segunda - feira, 4 de julho de 2022");
            var result = validador.Validate(condutores);
            Assert.AreEqual(result.IsValid, true);

        }
    }
}
