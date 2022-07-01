using FluentValidation.Results;
using LocadoraVeiculos.Dominio.ModuloCondutores;
using System;
using System.Windows.Forms;

namespace LocadoraVeiculos.WinApp.ModuloCondutores
{
    public partial class TelaCadastroCondutoresForm : Form
    {
        private Condutores condutor;
        public Action<string> AtualizarRodape { get; set; }
        public Func<Condutores, ValidationResult> GravarRegistro { get; internal set; }


        public Condutores Condutores
        {
            get { return Condutores; }
            set
            {
                condutor = value;

                if (condutor._id != 0)
                    PreencherDadosNaTela();

            }
        }

        private void PreencherDadosNaTela()
        {
            txtId.Text = Convert.ToString(condutor._id);
            txtNome.Text = condutor.Nome;
            condutor.Telefone = condutor.Telefone.Replace(" ", "-");
            maskedTextBoxTelefone.Text = condutor.Telefone;
            txtCPF.Text = condutor.Cpf;
            txtEmail.Text = condutor.Email;
            txtEndereco.Text = condutor.Endereco;
            txtCnh.Text = condutor.Cnh;
            txtValidadeCnh.Text = condutor.ValidadeCnh;


        }

        public TelaCadastroCondutoresForm()
        {
            InitializeComponent();

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!PegarObjetoTela()) return;


            var resultadoValidacao = GravarRegistro(condutor);

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

            string nome = txtNome.Text;
            string endereco = txtEndereco.Text;
            string email = txtEmail.Text;
            string telefone = PegarTelefone();           
            string cpf = txtCPF.Text;
            string cnh = txtCnh.Text;
            string validadecnh = txtValidadeCnh.Text;

            condutor = new Condutores(nome, cpf, endereco, email, telefone, cnh, validadecnh)
            {
                _id = id
            };

            return true;
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

    }
}