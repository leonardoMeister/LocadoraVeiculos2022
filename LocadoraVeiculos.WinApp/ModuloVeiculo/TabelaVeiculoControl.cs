using LocadoraVeiculos.Dominio.ModuloVeiculo;
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

namespace LocadoraVeiculos.WinApp.ModuloVeiculo
{
    public partial class TabelaVeiculoControl : UserControl
    {
        public TabelaVeiculoControl()
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
                new DataGridViewTextBoxColumn { DataPropertyName = "Modelo", HeaderText = "Modelo"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Placas", HeaderText = "Placas"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Marca", HeaderText = "Marca"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Cor", HeaderText = "Cor"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Tipo de Combustivel", HeaderText = "Tipo de Combustivel"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Capacidade do Tanque", HeaderText = "Capacidade do Tanque"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Ano", HeaderText = "Ano"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Quilometragem", HeaderText = "Quilometragem"}
                        };

            return colunas;
        }
        public int ObtemNumeroTarefaSelecionado()
        {
            return grid.SelecionarNumero<int>();
        }

        public void AtualizarRegistros(List<Veiculo> grupo)
        {
            grid.Rows.Clear();

            foreach (Veiculo veiculo in grupo)
            {
                grid.Rows.Add(veiculo.Modelo, veiculo.Placa, veiculo.Marca, veiculo.Cor, veiculo.TipoCombustivel, veiculo.CapacidadeTanque,
                    veiculo.Ano, veiculo.Quilometragem);
            }
        }
    }
}
