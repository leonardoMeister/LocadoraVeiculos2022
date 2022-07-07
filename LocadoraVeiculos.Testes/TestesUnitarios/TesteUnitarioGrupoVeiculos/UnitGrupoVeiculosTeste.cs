using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
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
            GrupoVeiculos gveiculos = new GrupoVeiculos("Grupo de veiculos 2");
            var result = validador.Validate(gveiculos);
            Assert.AreEqual(result.IsValid, true);

        }
    }
}
