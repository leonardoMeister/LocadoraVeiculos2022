using FluentValidation.Results;
using LocadoraVeiculos.Dominio.ModuloCliente;
using System;
using System.Windows.Forms;

namespace LocadoraVeiculos.WinApp.ModuloCliente
{
    public partial class TelaCadastroClienteForm : Form
    {
        public Cliente cliente;
        public Action<string> AtualizarRodape { get; set; }


        public Cliente Cliente
        {
            get { return Cliente; }
            set
            {
                cliente = value;
                PreencherDadosNaTela();

            }
        }

        public Func<Cliente, FluentResults.Result<Cliente>> GravarRegistro { get; internal set; }

        private void PreencherDadosNaTela()
        {
            if (cliente.TipoCliente == "PessoaFisica")
            {
                radioButtonPessoaJuridica.Checked = false;
                radioButtonPessoaFisica.Checked = true;
            }
            else if (cliente.TipoCliente == "PessoaJuridica")
            {
                radioButtonPessoaFisica.Checked = false;
                radioButtonPessoaJuridica.Checked = true;
            }

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

                if (erro.StartsWith("Falha no sistema"))
                {
                    MessageBox.Show(erro,
                    "Inserção Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    AtualizarRodape(erro);

                    DialogResult = DialogResult.None;
                }
            }
            else this.DialogResult = DialogResult.OK;
        }

        private void PegarObjetoTela()
        {            
            cliente.Nome = txtNome.Text;
            cliente.Endereco = txtEndereco.Text;
            cliente.Email = txtEmail.Text;
            cliente.Telefone = PegarTelefone();
            cliente.TipoCliente = radioButtonPessoaFisica.Checked ? "PessoaFisica" : "PessoaJuridica";            
            cliente.Cpf = txtCPF.Text;
            cliente.Cnpj = maskedTextBoxCNPJ.Text;            
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
