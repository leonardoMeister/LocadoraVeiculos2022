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

                return;
            }

            DialogResult = DialogResult.OK;
        }

        private bool PegarObjetoTela()
        {
            int id = 0;

            if (txtId.Text != "")
                id = Convert.ToInt32(txtId.Text);

            if (txtNome.Text == "" || txtEndereco.Text == "" || txtEmail.Text == "" || maskedTextBoxTelefone.Text == "")
            {
                AtualizarRodape("Favor Preencher todos os campos.");
                return false;
            }

            string nome = txtNome.Text;
            string endereco = txtEndereco.Text;
            string email = txtEmail.Text;
            string telefone = maskedTextBoxTelefone.Text;
            string tipo = radioButtonPessoaFisica.Checked ? "Pessoa física" : "Pessoa jurídica";
            string cnh = maskedTextBoxCNH.Text;
            string cpf = txtCPF.Text;
            string cnpj = maskedTextBoxCNPJ.Text;

            Cliente = new(nome, cpf, endereco, email, telefone, tipo, cnh)
            {
                _id = id
            };

            return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            AtualizarRodape("Inserção Cancelada.");
            this.DialogResult = DialogResult.Cancel;
        }

        private void radioButtonPessoaFisica_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonPessoaFisica.Checked)
                maskedTextBoxCNPJ.Enabled = false;

            if (!radioButtonPessoaFisica.Checked)
                maskedTextBoxCNPJ.Enabled = true;
        }

        private void radioButtonPessoaJuridica_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonPessoaJuridica.Checked)
                txtCPF.Enabled = false;

            if (!radioButtonPessoaJuridica.Checked)
                txtCPF.Enabled = true;
        }
    }
}
