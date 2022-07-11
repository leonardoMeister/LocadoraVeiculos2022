using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraVeiculos.Dominio.ModuloVeiculo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Testes.TestesUnitarios.TestesUnitarioVeiculo
{
    [TestClass]
    public class UnitVeiculoTeste
    {

        [TestMethod]
        public void DeveImpedirCriar()
        {
            ValidadorVeiculo validador = new ValidadorVeiculo();
            GrupoVeiculos grupo = new GrupoVeiculos("Nome do grupo de teste");

            Veiculo vei = new Veiculo("Mo", "ASD-3021", "Gol", "Rosa", "Gasolina", 10, DateTime.Now, 10, null, grupo);
            var validacao = validador.Validate(vei);
            Assert.IsFalse(validacao.IsValid);

            vei = new Veiculo("Modelo do Veiculo", "ASD3021", "Gol", "Rosa", "Gasolina", 10, DateTime.Now, 10, null, grupo);
            validacao = validador.Validate(vei);
            Assert.IsFalse(validacao.IsValid);

            vei = new Veiculo("Modelo do Veiculo", "ASD-3021", "Go", "Rosa", "Gasolina", 10, DateTime.Now, 10, null, grupo);
            validacao = validador.Validate(vei);
            Assert.IsFalse(validacao.IsValid);

            vei = new Veiculo("Modelo do Veiculo", "ASD-3021", "Gol", "Ro", "Gasolina", 10, DateTime.Now, 10, null, grupo);
            validacao = validador.Validate(vei);
            Assert.IsFalse(validacao.IsValid);

            vei = new Veiculo("Modelo do Veiculo", "ASD-3021", "Gol", "Rosa", "Ga", 10, DateTime.Now, 10, null, grupo);
            validacao = validador.Validate(vei);
            Assert.IsFalse(validacao.IsValid);

            vei = new Veiculo("Modelo do Veiculo", "ASD-3021", "Gol", "Rosa", "Gasolina", 0, DateTime.Now, 10, null, grupo);
            validacao = validador.Validate(vei);
            Assert.IsFalse(validacao.IsValid);

            vei = new Veiculo("Modelo do Veiculo", "ASD-3021", "Gol", "Rosa", "Gasolina", 10, DateTime.Now, 0, null, grupo);
            validacao = validador.Validate(vei);
            Assert.IsFalse(validacao.IsValid);

            vei = new Veiculo("Modelo do Veiculo", "ASD-3021", "Gol", "Rosa", "Gasolina", 10, DateTime.MinValue, 10, null, grupo);
            validacao = validador.Validate(vei);
            Assert.IsFalse(validacao.IsValid);

            vei = new Veiculo("Modelo do Veiculo", "ASD-3021", "Gol", "Rosa", "Gasolina", 10, DateTime.Now, 10, null, null);
            validacao = validador.Validate(vei);
            Assert.IsFalse(validacao.IsValid);
        }

        [TestMethod]
        public void DevePermitirCriar()
        {
            ValidadorVeiculo validador = new ValidadorVeiculo();
            GrupoVeiculos grupo = new GrupoVeiculos("Nome do grupo de teste");
            Veiculo vei = new Veiculo("Modelo do Veiculo", "ASD-3021", "Gol", "Rosa", "Gasolina", 10, DateTime.Now, 10, null, grupo);

            var validacao = validador.Validate(vei);

            Assert.IsTrue(validacao.IsValid);
        }
    }
}
