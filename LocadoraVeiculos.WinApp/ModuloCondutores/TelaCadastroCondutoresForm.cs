using FluentValidation.Results;
using LocadoraVeiculos.Controladores.ModuloServicoCliente;
using LocadoraVeiculos.Dominio.ModuloCliente;
using LocadoraVeiculos.Dominio.ModuloCondutores;
using LocadoraVeiculos.RepositorioProject.ModuloCliente;
using System;
using System.Windows.Forms;

namespace LocadoraVeiculos.WinApp.ModuloCondutores
{
    public partial class TelaCadastroCondutoresForm : Form
    {
        private Condutores condutor;
        public Action<string> AtualizarRodape { get; set; }

        public ServicoCliente controladorCliente;

        public Condutores Condutores
        {
            get { return Condutores; }
            set
            {
                condutor = value;
                PreencherDadosNaTela();
            }
        } 

        public Func<Condutores, FluentResults.Result<Condutores>> GravarRegistro { get; internal set; }

        private void PreencherDadosNaTela()
        {
            txtId.Text = Convert.ToString(condutor.Id);
            txtNome.Text = condutor.Nome;
            condutor.Telefone = condutor.Telefone.Replace(" ", "-");
            maskedTextBoxTelefone.Text = condutor.Telefone;
            txtCPF.Text = condutor.Cpf;
            txtEmail.Text = condutor.Email;
            txtEndereco.Text = condutor.Endereco;
            txtCnh.Text = condutor.Cnh;
            dateTimeCnh.Text = condutor.ValidadeCnh;
        }

        public TelaCadastroCondutoresForm()
        {
            InitializeComponent();
            controladorCliente = new ServicoCliente();
            CarregarClientes();
        }

        private void CarregarClientes()
        {
            var cliente = controladorCliente.SelecionarTodos().Value;

            foreach (var item in cliente)
            {
                cmbCliente.Items.Add(item);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!PegarObjetoTela()) return;


            var resultadoValidacao = GravarRegistro(condutor);

            if (resultadoValidacao.IsFailed)
            {
                string erro = resultadoValidacao.Errors[0].Message;

                if (erro.StartsWith("Falha no sistema"))
                {
                    MessageBox.Show(erro,
                    "Inserção Condutor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    AtualizarRodape(erro);

                    DialogResult = DialogResult.None;
                }
            }
            else this.DialogResult = DialogResult.OK;
        }

        private bool PegarObjetoTela()
        {
            Guid id = new Guid();

            if (txtId.Text != "")
                id = new Guid(txtId.Text);

            string nome = txtNome.Text;
            string endereco = txtEndereco.Text;
            string email = txtEmail.Text;
            string telefone = PegarTelefone();           
            string cpf = txtCPF.Text;
            string cnh = txtCnh.Text;
            string validadecnh = dateTimeCnh.Text;

            condutor = new Condutores(nome, cpf, endereco, email, telefone, cnh, validadecnh);

            if (id != Guid.Empty)
                condutor.Id = id;

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

        private void CarregarDadosCliente(object sender, EventArgs e)
        {
            Cliente cliente = (Cliente)cmbCliente.SelectedItem;

            if (cliente != null)
            {
                txtNome.Text = cliente.Nome;
                cliente.Telefone = cliente.Telefone.Replace(" ", "-");
                maskedTextBoxTelefone.Text = cliente.Telefone;
                txtCPF.Text = cliente.Cpf;
                txtEmail.Text = cliente.Email;
                txtEndereco.Text = cliente.Endereco;
            }
        }


    }
}