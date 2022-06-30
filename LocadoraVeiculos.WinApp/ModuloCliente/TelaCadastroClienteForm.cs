using FluentValidation.Results;
using LocadoraVeiculos.Dominio.ModuloCliente;
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
    public partial class TelaCadastroClienteForm : Form
    {
        private Cliente cliente;
        public Action<string> AtualizarRodape { get; set; }
        public Func<Cliente, ValidationResult> GravarRegistro { get; internal set; }


        public Cliente Cliente
        {
            get { return Cliente; }
            set
            {
                cliente = value;

                txtId.Text = Convert.ToString(cliente._id);
                txtNome.Text = cliente.Nome;
                txtCPF.Text = Convert.ToString(cliente.Cpf);
                txtEndereco.Text = cliente.Endereco;
                txtEmail.Text = cliente.Email;
                //txtTelefone.Text = cliente.Telefone;
                //comboTipoCliente.SelectedItem = cliente.TipoCliente;
                //txtCnh.Text = cliente.Cnh;

            }
        }
        public TelaCadastroClienteForm()
        {
            InitializeComponent();
            CarregarTiposCLiente();
        }

        private void CarregarTiposCLiente()
        {

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!PegarObjetoTela()) return;


            var resultadoValidacao = GravarRegistro(cliente);

            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

                AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
            else
            {
                DialogResult = DialogResult.OK;
            }
        }

        private bool PegarObjetoTela()
        {
            return false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            AtualizarRodape("Inserção Cancelada.");
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
