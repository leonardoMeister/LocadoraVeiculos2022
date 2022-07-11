using LocadoraVeiculos.Dominio.ModuloCondutores;
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

namespace LocadoraVeiculos.WinApp.ModuloCondutores
{
    public partial class TabelaCondutoresControl : UserControl
    {
        public TabelaCondutoresControl()
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

                new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome"},

                new DataGridViewTextBoxColumn { DataPropertyName = "CPF", HeaderText = "CPF"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Email", HeaderText = "Email"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Telefone", HeaderText = "Telefone"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Cnh", HeaderText = "CNH"},

                new DataGridViewTextBoxColumn { DataPropertyName = "ValidadeCnh", HeaderText = "Validade CNH"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Endereco", HeaderText = "Endereço"}

                        };

            return colunas;
        } 
        public Guid ObtemNumeroCondutoresSelecionado()
        {
            return grid.SelecionarNumero<Guid>();
        }

        public void AtualizarRegistros(List<Condutores> condutores)
        { 
            grid.Rows.Clear();

            foreach (Condutores condutor in condutores)
            {
                grid.Rows.Add(condutor._id, condutor.Nome, condutor.Cpf,
                  condutor.Email, condutor.Telefone, condutor.Cnh, condutor.ValidadeCnh, condutor.Endereco);
            }
        }
    }
}
