using LocadoraVeiculos.Controladores.ModuloControladorGrupoVeiculos;
using LocadoraVeiculos.Controladores.ModuloVeiculo;
using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraVeiculos.Dominio.ModuloVeiculo;
using LocadoraVeiculos.RepositorioProject.shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Testes.TestesIntegradorBanco.TesteIntegradoVeiculo
{
    [TestClass]
    public class IntegratedTestsVeiculo
    {
        public IntegratedTestsVeiculo()
        {
            string query = @"delete from TB_VEICULO;";
            DataBase.ExecutarComando(query);
            string query2 = @"delete from TB_PLANOCOBRANCA;";
            DataBase.ExecutarComando(query2);
            string query3 = @"delete from TB_GRUPOVEICULOS;";
            DataBase.ExecutarComando(query3);
        }

        [TestMethod]
        public void DeveInserirVeiculo()
        {
            ControladorVeiculo controlador = new ControladorVeiculo();
            ControladorGrupoVeiculos controladorGrupoVeiculos = new ControladorGrupoVeiculos();

            GrupoVeiculos grupo = new GrupoVeiculos("Nome do grupo de teste");
            controladorGrupoVeiculos.InserirNovo(grupo);

            byte[] foto = new byte[] { };

            Veiculo vei = new Veiculo("Modelo do Veiculo", "ASD-3021", "Gol", "Rosa", "Gasolina", 10, DateTime.Now, 10, foto, grupo);

            var resultado = controlador.InserirNovo(vei);

            Assert.IsTrue(resultado.IsValid);
        }

        [TestMethod]
        public void DeveBuscarVeiculo()
        {
            ControladorVeiculo controlador = new ControladorVeiculo();

            ControladorGrupoVeiculos controladorGrupoVeiculos = new ControladorGrupoVeiculos();

            GrupoVeiculos grupo = new GrupoVeiculos("Nome do grupo de teste");
            controladorGrupoVeiculos.InserirNovo(grupo);
            byte[] foto = new byte[] { };
            Veiculo vei = new Veiculo("Modelo do Veiculo", "ASD-3021", "Gol", "Rosa", "Gasolina", 10, DateTime.Now, 10, foto, grupo);

            controlador.InserirNovo(vei);

            var resultado = controlador.SelecionarPorId(vei._id);

            Assert.AreEqual(resultado, vei);
            
        }

        [TestMethod]
        public void DeveVerificarExistenciaVeiculo()
        {
            ControladorVeiculo controlador = new ControladorVeiculo();

            ControladorGrupoVeiculos controladorGrupoVeiculos = new ControladorGrupoVeiculos();

            GrupoVeiculos grupo = new GrupoVeiculos("Nome do grupo de teste");
            controladorGrupoVeiculos.InserirNovo(grupo);
            byte[] foto = new byte[] { };
            Veiculo vei = new Veiculo("Modelo do Veiculo", "ASD-3021", "Gol", "Rosa", "Gasolina", 10, DateTime.Now, 10, foto, grupo);

            controlador.InserirNovo(vei);

            var resultado = controlador.Existe(vei._id);

            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void DeveDeletarVeiculo()
        {
            ControladorVeiculo controlador = new ControladorVeiculo();

            ControladorGrupoVeiculos controladorGrupoVeiculos = new ControladorGrupoVeiculos();

            GrupoVeiculos grupo = new GrupoVeiculos("Nome do grupo de teste");
            controladorGrupoVeiculos.InserirNovo(grupo);
            byte[] foto = new byte[] { };
            Veiculo vei = new Veiculo("Modelo do Veiculo", "ASD-3021", "Gol", "Rosa", "Gasolina", 10, DateTime.Now, 10, foto, grupo);

            controlador.InserirNovo(vei);
            controlador.Excluir(vei._id);

            var resultado = controlador.Existe(vei._id);

            Assert.IsFalse(resultado);
        }

        [TestMethod]
        public void DeveEditarVeiculo()
        {
            ControladorVeiculo controlador = new ControladorVeiculo();

            ControladorGrupoVeiculos controladorGrupoVeiculos = new ControladorGrupoVeiculos();

            GrupoVeiculos grupo = new GrupoVeiculos("Nome do grupo de teste");
            controladorGrupoVeiculos.InserirNovo(grupo);
            byte[] foto = new byte[] { };
            Veiculo vei = new Veiculo("Modelo do Veiculo", "ASD-3021", "Gol", "Rosa", "Gasolina", 10, DateTime.Now, 10, foto, grupo);
            Veiculo vei2 = new Veiculo("Modelo do Veiculo2", "ASD-3022", "UNO", "Branco", "Gasolina", 10, DateTime.Now, 10, foto, grupo);            
            controlador.InserirNovo(vei);
            vei2._id = vei._id;
            controlador.Editar(vei2);
                
            var resultado = controlador.SelecionarPorId(vei._id);

            Assert.AreEqual(resultado, vei2);
        }

    }
}
