using LocadoraVeiculos.Controladores.ModuloServicoGrupoVeiculos;
using LocadoraVeiculos.Controladores.ModuloServicoPlanoCobranca;
using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraVeiculos.RepositorioProject.shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocadoraVeiculos.Testes.TestesIntegradorBanco.TesteIntegradorPlanoCobranca
{
    [TestClass]
    public class IntegratedTestsPlanoCobranca
    {
        public IntegratedTestsPlanoCobranca()
        {
            string query = @"delete from TB_VEICULO;";
            DataBase.ExecutarComando(query);

            string query2 = @"delete from TB_PLANOCOBRANCA;";
            DataBase.ExecutarComando(query2);

            string query3 = @"delete from TB_GRUPOVEICULOS;";
            DataBase.ExecutarComando(query3);
        }

        [TestMethod]
        public void DeveInserirPlanoCobranca()
        {
            ServicoPlanoCobranca contro = new ServicoPlanoCobranca();
            ServicoGrupoVeiculos controGrupo = new ServicoGrupoVeiculos();

            GrupoVeiculos grupo = new GrupoVeiculos("Nome grupo Veiculos 1");
            controGrupo.InserirNovo(grupo);

            PlanoCobranca plano = new PlanoCobranca("Tipo Grupo 1", 100, 0, 10, grupo);
            contro.InserirNovo(plano);

            var planoNovo = contro.SelecionarPorId(plano._id).Value;

            Assert.AreEqual(planoNovo, plano);
        }

        [TestMethod]
        public void DeveBuscarVariosPlanos()
        {
            ServicoPlanoCobranca contro = new ServicoPlanoCobranca();
            ServicoGrupoVeiculos controGrupo = new ServicoGrupoVeiculos();

            GrupoVeiculos grupo = new GrupoVeiculos("Nome grupo Veiculos 1");
            controGrupo.InserirNovo(grupo);

            PlanoCobranca plano = new PlanoCobranca("Tipo Grupo 1", 100, 0, 10, grupo);
            PlanoCobranca plano2 = new PlanoCobranca("Tipo Grupo 2", 10, 100, 16, grupo);

            contro.InserirNovo(plano);
            contro.InserirNovo(plano2);

            var planosNovos = contro.SelecionarTodos().Value;

            Assert.AreEqual(planosNovos.Count, 2);
        }

        [TestMethod]
        public void DeveVerificarExistenciaPlano()
        {
            ServicoPlanoCobranca contro = new ServicoPlanoCobranca();
            ServicoGrupoVeiculos controGrupo = new ServicoGrupoVeiculos();

            GrupoVeiculos grupo = new GrupoVeiculos("Nome grupo Veiculos 1");
            controGrupo.InserirNovo(grupo);

            PlanoCobranca plano = new PlanoCobranca("Tipo Grupo 1", 100, 0, 10, grupo);

            contro.InserirNovo(plano);

            var planoNovo = contro.Existe(plano._id);

            Assert.IsTrue(planoNovo.Value);
        }

        [TestMethod]
        public void DeveDeletarPlano()
        {
            ServicoPlanoCobranca contro = new ServicoPlanoCobranca();
            ServicoGrupoVeiculos controGrupo = new ServicoGrupoVeiculos();

            GrupoVeiculos grupo = new GrupoVeiculos("Nome grupo Veiculos 1");
            controGrupo.InserirNovo(grupo);

            PlanoCobranca plano = new PlanoCobranca("Tipo Grupo 1", 100, 0, 10, grupo);

            contro.InserirNovo(plano);

            contro.Excluir(contro.SelecionarPorId(plano._id).Value);

            var planoNovo = contro.Existe(plano._id).Value;

            Assert.IsFalse(planoNovo);
        }

        [TestMethod]
        public void DeveEditarPlano()
        {
            ServicoPlanoCobranca contro = new ServicoPlanoCobranca();
            ServicoGrupoVeiculos controGrupo = new ServicoGrupoVeiculos();

            GrupoVeiculos grupo = new GrupoVeiculos("Nome grupo Veiculos 1");
            controGrupo.InserirNovo(grupo);

            PlanoCobranca plano = new PlanoCobranca("Tipo Grupo 1", 100, 0, 10, grupo);
            PlanoCobranca plano2 = new PlanoCobranca("Tipo Grupo 2", 10, 100, 16, grupo);
            contro.InserirNovo(plano);

            plano2._id = plano._id;
            contro.Editar(plano2);

            var planoNovo = contro.SelecionarPorId(plano2._id).Value;

            Assert.AreEqual(planoNovo , plano2);
        }
    }
}
