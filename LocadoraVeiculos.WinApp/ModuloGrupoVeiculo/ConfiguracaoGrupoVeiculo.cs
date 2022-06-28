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
    public class ConfiguracaoGrupoVeiculo : ConfiguracaoBase<GrupoVeiculos>, ICadastravel
    {
        TabelaGrupoVeiculo tabelaGrupoVeiculos;
        ControladorGrupoVeiculos controlador;
        TelaCadastroGrupoVeiculo telaCadastroGrupoVeiculo;
        public ConfiguracaoGrupoVeiculo()
        {            
            tabelaGrupoVeiculos = new TabelaGrupoVeiculo();
            controlador = new ControladorGrupoVeiculos(new ValidadorGrupoVeiculos(), new RepositorioGrupoVeiculos(new MapeadorGrupoVeiculos()));
        }

        public void Editar()
        {
            int id = tabelaGrupoVeiculos.ObtemNumeroTarefaSelecionado();
        }

        public void Excluir()
        {
            int id = tabelaGrupoVeiculos.ObtemNumeroTarefaSelecionado();
        }

        public void Inserir()
        {
            telaCadastroGrupoVeiculo = new TelaCadastroGrupoVeiculo();

            if (telaCadastroGrupoVeiculo.ShowDialog() == DialogResult.OK)
            {
                var grupoVei = telaCadastroGrupoVeiculo.GrupoVeiculos;

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
