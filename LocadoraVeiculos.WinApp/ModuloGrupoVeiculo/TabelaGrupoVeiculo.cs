using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraVeiculos.WinApp.shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraVeiculos.WinApp.ModuloGrupoVeiculo
{
    public partial class TabelaGrupoVeiculo : UserControl
    {
        public TabelaGrupoVeiculo()
        {
            InitializeComponent();
            grid.ConfigurarGridZebrado();
            grid.ConfigurarGridSomenteLeitura();
            grid.Columns.AddRange(ObterColunas());
        }
        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id"},

                new DataGridViewTextBoxColumn { DataPropertyName = "NomeGrupo", HeaderText = "Nome Grupo"}

            };

            return colunas;
        }

        public Guid ObtemNumeroGrupoVeiculosSelecionado()
        {
            return grid.SelecionarNumero<Guid>();
        }

        public void AtualizarRegistros(List<GrupoVeiculos> grupo)
        {
            grid.Rows.Clear();

            foreach (GrupoVeiculos grupoVeiculos in grupo)
            {
                grid.Rows.Add(grupoVeiculos._id, grupoVeiculos.NomeGrupo );
            }
        }
    }
}
