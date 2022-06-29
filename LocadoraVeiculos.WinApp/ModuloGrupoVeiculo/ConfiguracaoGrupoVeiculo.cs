using LocadoraVeiculos.Controladores.ModuloControladorGrupoVeiculos;
using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraVeiculos.Repositorio.shared;
using LocadoraVeiculos.RepositorioProject.ModuloGrupoVeiculos;
using LocadoraVeiculos.WinApp.shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraVeiculos.WinApp.ModuloGrupoVeiculo
{
    public class ConfiguracaoGrupoVeiculo : ConfiguracaoBase, ICadastravel
    {
        TabelaGrupoVeiculo tabelaGrupoVeiculos;
        ControladorGrupoVeiculos controlador;
        TelaCadastroGrupoVeiculo telaCadastroGrupoVeiculo;
        TelaPrincipalForm telaPrincipal;
        public ConfiguracaoGrupoVeiculo(TelaPrincipalForm tela)
        {
            tabelaGrupoVeiculos = new TabelaGrupoVeiculo();
            controlador = new ControladorGrupoVeiculos();
            telaPrincipal = tela;
        }

        public void Editar()
        {
            telaCadastroGrupoVeiculo = new TelaCadastroGrupoVeiculo(telaPrincipal);

            int id = tabelaGrupoVeiculos.ObtemNumeroTarefaSelecionado();
            var registro = controlador.SelecionarPorId(id);
            telaCadastroGrupoVeiculo.GrupoVeiculos = registro;

            if (telaCadastroGrupoVeiculo.ShowDialog() == DialogResult.OK)
            {
                var grupo = telaCadastroGrupoVeiculo.GrupoVeiculos;
                controlador.Editar(grupo._id, grupo);

                telaPrincipal.AtualizarRodape("Edição Grupo Veiculos Realizado Com Sucesso");
            }

        }

        public void Excluir()
        {
            int id = tabelaGrupoVeiculos.ObtemNumeroTarefaSelecionado();
            try
            {
                controlador.Excluir(id);
                telaPrincipal.AtualizarRodape("Grupo de Veiculos Removido com sucesso.");
            }
            catch (Exception ex)
            {
                telaPrincipal.AtualizarRodape($"Não foi possivel Remover, Mensagem: {ex}");
                return;
            }

        }

        public void Inserir()
        {
            telaCadastroGrupoVeiculo = new TelaCadastroGrupoVeiculo(telaPrincipal);

            if (telaCadastroGrupoVeiculo.ShowDialog() == DialogResult.OK)
            {
                var grupo = telaCadastroGrupoVeiculo.GrupoVeiculos;
                controlador.InserirNovo(grupo);

                telaPrincipal.AtualizarRodape("Cadastro Grupo Veiculos Realizado Com Sucesso");
            }

        }

        public ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxGrupoVeiculo();
        }

        public override UserControl ObtemListagem()
        {
            List<GrupoVeiculos> grupoVeiculos = controlador.SelecionarTodos();

            tabelaGrupoVeiculos.AtualizarRegistros(grupoVeiculos);

            return tabelaGrupoVeiculos;
        }

    }
}
