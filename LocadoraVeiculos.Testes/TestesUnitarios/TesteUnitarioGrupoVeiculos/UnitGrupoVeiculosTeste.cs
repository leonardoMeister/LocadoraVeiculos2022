using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraVeiculos.RepositorioProject.ModuloGrupoVeiculos;
using LocadoraVeiculos.RepositorioProject.shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocadoraVeiculos.Testes.TestesUnitarios.TesteUnitarioGrupoVeiculos
{
    [TestClass]
    public class UnitGrupoVeiculosTeste
    {
        [TestMethod]
        public void DeveImpedirCriarGrupoVeiculosSemNomeGrupo()
        {
            ValidadorGrupoVeiculos validador = new ValidadorGrupoVeiculos();

            GrupoVeiculos gveiculos = new GrupoVeiculos("");
            var result = validador.Validate(gveiculos);
            Assert.AreEqual(result.IsValid, false);
        }

        [TestMethod]
        public void DevePermitirCriarGrupoVeiculos()
        {
            ValidadorGrupoVeiculos validador = new ValidadorGrupoVeiculos();
            GrupoVeiculos gveiculos = new GrupoVeiculos("Grupo 2");
            var result = validador.Validate(gveiculos);
            Assert.AreEqual(result.IsValid, true);

        }
    }
}
