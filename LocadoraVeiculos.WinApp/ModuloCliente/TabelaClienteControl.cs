using LocadoraVeiculos.Dominio.ModuloCliente;
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

namespace LocadoraVeiculos.WinApp.ModuloCliente
{
    public partial class TabelaClienteControl : UserControl
    {
        public TabelaClienteControl()
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

                new DataGridViewTextBoxColumn { DataPropertyName = "TipoCliente", HeaderText = "Tipo Cliente"},

                new DataGridViewTextBoxColumn { DataPropertyName = "CNPJ", HeaderText = "CNPJ"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Endereco", HeaderText = "Endereço"}

                        };

            return colunas;
        } 
        public Guid ObtemNumeroClienteSelecionado()
        {
            return grid.SelecionarNumero<Guid>();
        }

        public void AtualizarRegistros(List<Cliente> clientes)
        { 
            grid.Rows.Clear();

            foreach (Cliente cliente in clientes)
            {
                grid.Rows.Add(cliente._id, cliente.Nome, cliente.Cpf,
                  cliente.Email, cliente.Telefone, cliente.TipoCliente, cliente.Cnpj,cliente.Endereco);
            }
        }
    }
}
