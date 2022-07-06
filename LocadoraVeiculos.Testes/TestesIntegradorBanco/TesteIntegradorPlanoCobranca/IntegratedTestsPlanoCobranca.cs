using LocadoraVeiculos.Controladores.ModuloControladorGrupoVeiculos;
using LocadoraVeiculos.Controladores.ModuloPlanoCobranca;
using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraVeiculos.RepositorioProject.ModuloCliente;
using LocadoraVeiculos.RepositorioProject.shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Testes.TestesIntegradorBanco.TesteIntegradorPlanoCobranca
{
    [TestClass]
    public class IntegratedTestsPlanoCobranca
    {
        public IntegratedTestsPlanoCobranca()
        {
            string query = @"delete from TB_PLANOCOBRANCA;
                            DBCC CHECKIDENT (TB_PLANOCOBRANCA, RESEED, 1)";
            DataBase.ExecutarComando(query);

            string query2 = @"delete from TB_GRUPOVEICULOS;
                            DBCC CHECKIDENT (TB_GRUPOVEICULOS, RESEED, 1)";
            DataBase.ExecutarComando(query2);
        }

        [TestMethod]
        public void DeveInserirPlanoCobranca()
        {
            ControladorPlanoCobranca contro = new ControladorPlanoCobranca();
            ControladorGrupoVeiculos controGrupo = new ControladorGrupoVeiculos();

            GrupoVeiculos grupo = new GrupoVeiculos("Nome grupo Veiculos 1");
            controGrupo.InserirNovo(grupo);

            PlanoCobranca plano = new PlanoCobranca("Tipo Grupo 1", 100, 0, 10, grupo);

            contro.InserirNovo(plano);

            var planoNovo = contro.SelecionarPorId(plano._id);

            Assert.AreEqual(planoNovo, plano);
        }

        [TestMethod]
        public void DeveBuscarVariosPlanos()
        {
            ControladorPlanoCobranca contro = new ControladorPlanoCobranca();
            ControladorGrupoVeiculos controGrupo = new ControladorGrupoVeiculos();

            GrupoVeiculos grupo = new GrupoVeiculos("Nome grupo Veiculos 1");
            controGrupo.InserirNovo(grupo);

            PlanoCobranca plano = new PlanoCobranca("Tipo Grupo 1", 100, 0, 10, grupo);
            PlanoCobranca plano2 = new PlanoCobranca("Tipo Grupo 2", 10, 100, 16, grupo);

            contro.InserirNovo(plano);
            contro.InserirNovo(plano2);

            var planosNovos = contro.SelecionarTodos();

            Assert.AreEqual(planosNovos.Count, 2);
        }

        [TestMethod]
        public void DeveVerificarExistenciaPlano()
        {
            ControladorPlanoCobranca contro = new ControladorPlanoCobranca();
            ControladorGrupoVeiculos controGrupo = new ControladorGrupoVeiculos();

            GrupoVeiculos grupo = new GrupoVeiculos("Nome grupo Veiculos 1");
            controGrupo.InserirNovo(grupo);

            PlanoCobranca plano = new PlanoCobranca("Tipo Grupo 1", 100, 0, 10, grupo);

            contro.InserirNovo(plano);

            var planoNovo = contro.Existe(plano._id);

            Assert.AreEqual(planoNovo, true);
        }

        [TestMethod]
        public void DeveDeletarPlano()
        {
            ControladorPlanoCobranca contro = new ControladorPlanoCobranca();
            ControladorGrupoVeiculos controGrupo = new ControladorGrupoVeiculos();

            GrupoVeiculos grupo = new GrupoVeiculos("Nome grupo Veiculos 1");
            controGrupo.InserirNovo(grupo);

            PlanoCobranca plano = new PlanoCobranca("Tipo Grupo 1", 100, 0, 10, grupo);

            contro.InserirNovo(plano);

            contro.Excluir(plano._id);

            var planoNovo = contro.Existe(plano._id);

            Assert.AreEqual(planoNovo, false);
        }

        [TestMethod]
        public void DeveEditarPlano()
        {

            ControladorPlanoCobranca contro = new ControladorPlanoCobranca();
            ControladorGrupoVeiculos controGrupo = new ControladorGrupoVeiculos();

            GrupoVeiculos grupo = new GrupoVeiculos("Nome grupo Veiculos 1");
            controGrupo.InserirNovo(grupo);

            PlanoCobranca plano = new PlanoCobranca("Tipo Grupo 1", 100, 0, 10, grupo);
            PlanoCobranca plano2 = new PlanoCobranca("Tipo Grupo 2", 10, 100, 16, grupo);

            contro.InserirNovo(plano);
            plano2._id = plano._id;
            contro.Editar(plano2);

            var planoNovo = contro.SelecionarPorId(plano2._id);

            Assert.AreEqual(planoNovo , plano2);
        }
    }
}
