using LocadoraVeiculos.Controladores.ModuloServicoGrupoVeiculos;
using LocadoraVeiculos.Controladores.ModuloServicoPlanoCobranca;
using LocadoraVeiculos.Controladores.ModuloServicoTaxas;
using LocadoraVeiculos.Dominio.ModuloCliente;
using LocadoraVeiculos.Dominio.ModuloCondutores;
using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraVeiculos.Dominio.ModuloLocacao;
using LocadoraVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraVeiculos.Dominio.ModuloTaxas;
using LocadoraVeiculos.Dominio.ModuloVeiculo;
using LocadoraVeiculos.Infra.Orm.ModuloCliente;
using LocadoraVeiculos.Infra.Orm.ModuloCondutores;
using LocadoraVeiculos.Infra.Orm.ModuloGrupoVeiculo;
using LocadoraVeiculos.Infra.Orm.ModuloPlanoCobranca;
using LocadoraVeiculos.Infra.Orm.ModuloTaxas;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace LocadoraVeiculos.Testes.TestesUnitarios.TestesUnitarioLocacao
{
    [TestClass]
    public class UnitLocacaoTeste
    {
        [TestMethod]
        public void DeveImpedirCriar()
        {
            ValidadorLocacao validador = new ValidadorLocacao();
            GrupoVeiculos grupo = new GrupoVeiculos("Nome do grupo de teste");
            byte[] foto = new byte[] { };
            Veiculo vei = new Veiculo("Modelo do Veiculo", "ASD-3021", "Gol", "Rosa", "Gasolina", 10, DateTime.Now, 10, foto, grupo);
            PlanoCobranca plano = new PlanoCobranca("Tipo Grupo 1", 100, 0, 10, grupo);
            Condutores condutor = new Condutores("Gustavo Paes", "023.599.199.94", "Andre Gargioni", "emailteste@gmail.com", "99-99999-9999", "12323432193", "segunda - feira, 4 de julho de 2022");
            Cliente cli = new Cliente("Gustavo", "214.432.723.99", "teste", "teste@gmail.com", "49 99830-8533",
            EnumCliente.PessoaFisica.ToString(), "");
            Taxas taxa = new Taxas("Aluguel Onix", 1500, EnumTaxa.Diaria.ToString());
            List<Taxas> tax = new List<Taxas>();
            tax.Add(taxa);


            Locacao loc = new Locacao(vei, condutor, cli, grupo, plano, DateTime.Now, DateTime.Now, 10, NivelTanqueEnum.medio, tax, false, 100, DateTime.Now, NivelTanqueEnum.alto);
            var validacao = validador.Validate(loc);
            Assert.IsFalse(validacao.IsValid);

            loc = new Locacao(vei, condutor, cli, grupo, plano, DateTime.Now, DateTime.Now, 15, NivelTanqueEnum.medio, tax, true, 200, DateTime.Now, NivelTanqueEnum.alto);
            validacao = validador.Validate(loc);
            Assert.IsFalse(validacao.IsValid);

            loc = new Locacao(vei, condutor, cli, grupo, plano, DateTime.Now, DateTime.Now, 1, NivelTanqueEnum.medio, tax, true, 130, DateTime.Now, NivelTanqueEnum.alto);
            validacao = validador.Validate(loc);
            Assert.IsFalse(validacao.IsValid);
        }

        [TestMethod]
        public void DevePermitirCriar()
        {
            ValidadorLocacao validador = new ValidadorLocacao();
            GrupoVeiculos grupo = new GrupoVeiculos("Nome do grupo de teste");
            byte[] foto = new byte[] { };
            Veiculo vei = new Veiculo("Modelo do Veiculo", "ASD-3021", "Gol", "Rosa", "Gasolina", 10, DateTime.Now, 10, foto, grupo);
            PlanoCobranca plano = new PlanoCobranca("Tipo Grupo 1", 100, 0, 10, grupo);
            Condutores condutor = new Condutores("Gustavo Paes", "023.599.199.94", "Andre Gargioni", "emailteste@gmail.com", "99-99999-9999", "12323432193", "segunda - feira, 4 de julho de 2022");
            Cliente cli = new Cliente("Gustavo", "214.432.723.99", "teste", "teste@gmail.com", "49 99830-8533",
            EnumCliente.PessoaFisica.ToString(), "");
            Taxas taxa = new Taxas("Aluguel Onix", 1500, EnumTaxa.Diaria.ToString());
            List<Taxas> tax = new List<Taxas>();
            tax.Add(taxa);
            Locacao loc = new Locacao(vei, condutor, cli, grupo, plano, DateTime.Now, DateTime.Now, 10, NivelTanqueEnum.medio, tax, false, 100, DateTime.Now, NivelTanqueEnum.alto);

            var validacao = validador.Validate(loc);

            Assert.IsTrue(validacao.IsValid);
        }
    }
}
