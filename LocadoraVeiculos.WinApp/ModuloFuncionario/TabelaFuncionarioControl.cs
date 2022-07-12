using LocadoraVeiculos.Dominio.ModuloFuncionario;
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

namespace LocadoraVeiculos.WinApp.ModuloFuncionario
{
    public partial class TabelaFuncionarioControl : UserControl
    {
        public TabelaFuncionarioControl()
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

                new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Login", HeaderText = "Login"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Senha", HeaderText = "Senha"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Salario", HeaderText = "Salario"},                
                new DataGridViewTextBoxColumn { DataPropertyName = "DataAdmicao", HeaderText = "Data Admicao"},
                new DataGridViewTextBoxColumn { DataPropertyName = "TipoPerfil", HeaderText = "Tipo Perfil"}                
            };

            return colunas;
        }

        public Guid ObtemNumeroTarefaSelecionado()
        {
            return grid.SelecionarNumero<Guid>();
        }

        public void AtualizarRegistros(List<Funcionario> grupo)
        {
            grid.Rows.Clear();

            foreach (Funcionario grupoVeiculos in grupo)
            {
                grid.Rows.Add(grupoVeiculos._id, grupoVeiculos.Nome, grupoVeiculos.Login , grupoVeiculos.Senha, grupoVeiculos.Salario,
                    grupoVeiculos.DataAdmicao, grupoVeiculos.TipoPerfil);
            }
        }
    }
}
