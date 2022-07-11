using LocadoraVeiculos.Dominio.ModuloCliente;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Testes.TestesUnitarios.TestesUnitarioCliente
{
    [TestClass]
    public class UnitClienteTeste
    {

        [TestMethod]
        public void DevePermitirCriar() 
        {
            ValidadorCliente validadorCliente = new ValidadorCliente();

            Cliente cli = new Cliente("leonardo", "132.321.232.00", "Estrada nova", "leonardo@gmail.com", "47 99239-8644",
                EnumCliente.PessoaFisica.ToString(), "");

            var resultado = validadorCliente.Validate(cli);

            Assert.AreEqual(resultado.IsValid, true);
        }
        [TestMethod]
        public void DeveImpedirCriar() 
        {
            ValidadorCliente validadorCliente = new ValidadorCliente();

            Cliente cli = new Cliente("leonardo", "132.3232.00", "Estrada nova", "leonardo@gmail.com", "47 99239-8644",
                EnumCliente.PessoaFisica.ToString(), "");
            Cliente cli2 = new Cliente("le", "132.312.132.00", "Estrada nova", "leonardo@gmail.com", "47 99239-8644",
                EnumCliente.PessoaFisica.ToString(), "");
            Cliente cli3 = new Cliente("leonardo", "132.312.132.00", "Es", "leonardo@gmail.com", "47 99239-8644",
                EnumCliente.PessoaFisica.ToString(), "");
            Cliente cli4 = new Cliente("leonardo", "132.312.132.00", "Estrada Nova", "leonardogmail.com", "47 99239-8644",
                EnumCliente.PessoaFisica.ToString(), "");
            Cliente cli5 = new Cliente("leonardo", "132.312.132.00", "Estrada Nova", "leonardo@gmail.com", "47 99238644",
                EnumCliente.PessoaFisica.ToString(), "");
            Cliente cli6 = new Cliente("leonardo", "", "Estrada Nova", "leonardo@gmail.com", "47 99233-8644",
                EnumCliente.PessoaFisica.ToString(), "");

            var resultado = validadorCliente.Validate(cli);
            Assert.AreEqual(resultado.IsValid, false);

            resultado = validadorCliente.Validate(cli2);
            Assert.AreEqual(resultado.IsValid, false);

            resultado = validadorCliente.Validate(cli3);
            Assert.AreEqual(resultado.IsValid, false);

            resultado = validadorCliente.Validate(cli4);
            Assert.AreEqual(resultado.IsValid, false);

            resultado = validadorCliente.Validate(cli5);
            Assert.AreEqual(resultado.IsValid, false);

            resultado = validadorCliente.Validate(cli6);
            Assert.AreEqual(resultado.IsValid, false);
        }


    }
}
