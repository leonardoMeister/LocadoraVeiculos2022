using LocadoraVeiculos.Dominio.ModuloLocacao;
using LocadoraVeiculos.WinApp.shared;
using System;
using System.Collections.Generic;
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

                new DataGridViewTextBoxColumn { DataPropertyName = "Condutor", HeaderText = "Condutor"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Veiculo", HeaderText = "Veiculo"},

                new DataGridViewTextBoxColumn { DataPropertyName = "DataLocacao", HeaderText = "Data Locacao"},

                new DataGridViewTextBoxColumn { DataPropertyName = "DataDevolucao", HeaderText = "Data Devolucao"},

                new DataGridViewTextBoxColumn { DataPropertyName = "ValorLocacao", HeaderText = "Valor Locacao"},

                new DataGridViewTextBoxColumn { DataPropertyName = "StatusDevolucao", HeaderText = "Status Devolucao"}

                        };

            return colunas;
        }
        public Guid ObtemNumeroLocacaoSelecionada()
        {
            return grid.SelecionarNumero<Guid>();
        }

        public void AtualizarRegistros(List<Locacao> grupo)
        {
            grid.Rows.Clear();

            foreach (Locacao locacao in grupo)
            {
                grid.Rows.Add(locacao.Id, locacao.Condutores, locacao.Veiculo, locacao.DataLocacao.Date, locacao.DataEstimadaDevolucao.Date,
                    locacao.GerarValorLocacao(), locacao.StatusDevolucao );
            }
        }
    }
}
