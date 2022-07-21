using FluentValidation.Results;
using LocadoraVeiculos.Dominio.ModuloCliente;
using System;
using System.Windows.Forms;

namespace LocadoraVeiculos.WinApp.ModuloCliente
{
    public partial class TelaCadastroClienteForm : Form
    {
        private Cliente cliente;
        public Action<string> AtualizarRodape { get; set; }


        public Cliente Cliente
        {
            get { return Cliente; }
            set
            {
                cliente = value;

                PreencherDadosNaTela();
                radioButtonPessoaFisica.Checked = true;

            }
        }

        public Func<Cliente, FluentResults.Result<Cliente>> GravarRegistro { get; internal set; }

        private void PreencherDadosNaTela()
        {
            if (cliente.TipoCliente == "PessoaFisica")
            {
                radioButtonPessoaFisica.Checked = true;
            }
            else radioButtonPessoaJuridica.Checked = true;

            txtId.Text = Convert.ToString( cliente.Id);
            txtNome.Text = cliente.Nome;
            cliente.Telefone = cliente.Telefone.Replace(" ", "-");
            maskedTextBoxTelefone.Text = cliente.Telefone;
            maskedTextBoxCNPJ.Text = cliente.Cnpj;
            txtCPF.Text = cliente.Cpf;
            txtEmail.Text = cliente.Email;
            txtEndereco.Text = cliente.Endereco;
            

        }

        public TelaCadastroClienteForm()
        {
            InitializeComponent();
            radioButtonPessoaFisica.Checked = true;

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            PegarObjetoTela();


            var resultadoValidacao = GravarRegistro(cliente);

            if (resultadoValidacao.IsFailed)
            {
                string erro = resultadoValidacao.Errors[0].Message;

                AtualizarRodape(erro);

                DialogResult = DialogResult.None;

                return;
            }

            DialogResult = DialogResult.OK;
        }

        private void PegarObjetoTela()
        {
            Guid id = new Guid();

            if (txtId.Text != "")
                id = new Guid(txtId.Text);

            string nome = txtNome.Text;
            string endereco = txtEndereco.Text;
            string email = txtEmail.Text;
            string telefone = PegarTelefone();
            string tipo = radioButtonPessoaFisica.Checked ? "PessoaFisica" : "PessoaJuridica";            
            string cpf = txtCPF.Text;
            string cnpj = maskedTextBoxCNPJ.Text;

            cliente = new Cliente(nome, cpf, endereco, email, telefone, tipo, cnpj);

            if (id != Guid.Empty)
                cliente.Id = id;

        }

        private string PegarTelefone()
        {
            var telefone = maskedTextBoxTelefone.Text;
            telefone = telefone.Replace(" ", "");            
            telefone = telefone.Replace("-", " ");
                
            return telefone;

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

            txtCPF.Text = "";
        }

        private void radioButtonPessoaJuridica_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonPessoaJuridica.Checked)
                txtCPF.Enabled = false;

            if (!radioButtonPessoaJuridica.Checked)
                txtCPF.Enabled = true;

            maskedTextBoxCNPJ.Text = "";
        }

    }
}
