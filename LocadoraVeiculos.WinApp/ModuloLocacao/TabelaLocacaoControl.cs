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

namespace LocadoraVeiculos.WinApp.ModuloLocacao
{
    public partial class TabelaLocacaoControl : UserControl
    {
        public TabelaLocacaoControl()
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

                new DataGridViewTextBoxColumn { DataPropertyName = "Modelo", HeaderText = "Modelo"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Placa", HeaderText = "Placa"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Marca", HeaderText = "Marca"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Cor", HeaderText = "Cor"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Tipo de Combustivel", HeaderText = "Tipo de Combustivel"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Ano", HeaderText = "Ano"},

                        };

            return colunas;
        }
        public Guid ObtemNumeroVeiculoSelecionado()
        {
            return grid.SelecionarNumero<Guid>();
        }

        public void AtualizarRegistros(List<Veiculo> grupo)
        {
            grid.Rows.Clear();

            foreach (Veiculo veiculo in grupo)
            {
                grid.Rows.Add(veiculo.Id, veiculo.Modelo, veiculo.Placa, veiculo.Marca, veiculo.Cor, veiculo.TipoCombustivel,
                    veiculo.Ano.Date);
            }
        }
    }
}
