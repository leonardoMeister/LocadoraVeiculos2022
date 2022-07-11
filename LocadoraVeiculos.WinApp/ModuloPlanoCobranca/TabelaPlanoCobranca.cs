using LocadoraVeiculos.Dominio.ModuloPlanoCobranca;
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

namespace LocadoraVeiculos.WinApp.ModuloPlanoCobranca
{
    public partial class TabelaPlanoCobranca : UserControl
    {
        public TabelaPlanoCobranca()
        {
            InitializeComponent();
            grid.ConfigurarGridZebrado();
            grid.ConfigurarGridSomenteLeitura();
            grid.Columns.AddRange(ObterColunas());
        }

        private DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
                        {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id"},
                new DataGridViewTextBoxColumn { DataPropertyName = "TipoPlano", HeaderText = "Tipo Plano"},
                new DataGridViewTextBoxColumn { DataPropertyName = "ValorDia", HeaderText = "Valor Dia"},
                new DataGridViewTextBoxColumn { DataPropertyName = "LimiteKM", HeaderText = "Limite KM"},
                new DataGridViewTextBoxColumn { DataPropertyName = "ValorKM", HeaderText = "Valor KM"},
                new DataGridViewTextBoxColumn { DataPropertyName = "GrupoVeiculos", HeaderText = "Grupo Veiculos"}
                        };

            return colunas;
        }
        public int ObtemNumeroPlanoSelecionado()
        {
            return grid.SelecionarNumero<int>();
        }

        public void AtualizarRegistros(List<PlanoCobranca> plano)
        {
            grid.Rows.Clear();

            foreach (PlanoCobranca planoCobranca in plano)
            {
                grid.Rows.Add(planoCobranca._id, planoCobranca.TipoPlano,planoCobranca.ValorDia,planoCobranca.LimiteKM,planoCobranca.ValorKM,
                    planoCobranca.GrupoVeiculos);
            }
        }
    }
}
