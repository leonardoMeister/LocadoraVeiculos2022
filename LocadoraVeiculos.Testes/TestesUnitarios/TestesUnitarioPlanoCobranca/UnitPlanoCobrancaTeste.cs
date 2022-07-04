using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraVeiculos.Dominio.ModuloPlanoCobranca;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Testes.TestesUnitarios.TestesUnitarioPlanoCobranca
{

    [TestClass]
    public class UnitPlanoCobrancaTeste
    {

        [TestMethod]
        public void DeveImpedirCriar()
        {
            ValidadorPlanoCobranca validador = new ValidadorPlanoCobranca();

            GrupoVeiculos grupo = new GrupoVeiculos("Grupo 1");

            PlanoCobranca plano1 = new PlanoCobranca("Tipo numero 1", 0, 0, 0, grupo);
            PlanoCobranca plano2 = new PlanoCobranca("Tipo numero 1", 0, 1, 0, grupo);
            PlanoCobranca plano3 = new PlanoCobranca("Tipo", 1, 1, 0, grupo);
            PlanoCobranca plano4 = new PlanoCobranca("Tipo numero 1", 1, 1, 1, null);
            PlanoCobranca plano5 = new PlanoCobranca("Tipo numero @", 1, 1, 1, grupo);

            var result = validador.Validate(plano1);
            Assert.AreEqual(result.IsValid, false);

            result = validador.Validate(plano2);
            Assert.AreEqual(result.IsValid, false);

            result = validador.Validate(plano3);
            Assert.AreEqual(result.IsValid, false);

            result = validador.Validate(plano4);
            Assert.AreEqual(result.IsValid, false);

            result = validador.Validate(plano5);
            Assert.AreEqual(result.IsValid, false);
        }
         
        [TestMethod]
        public void DevePermitirCriar()
        {
            ValidadorPlanoCobranca validador = new ValidadorPlanoCobranca();

            GrupoVeiculos grupo = new GrupoVeiculos("Grupo 1");

            PlanoCobranca plano1 = new PlanoCobranca("Tipo numero 1", 1, 0, 0, grupo);

            var result = validador.Validate(plano1);
            Assert.AreEqual(result.IsValid, true);

        }
    }
}
