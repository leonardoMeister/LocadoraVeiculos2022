using FluentValidation.Results;
using LocadoraVeiculos.Dominio.ModuloFuncionario;
using System;
using System.Windows.Forms;

namespace LocadoraVeiculos.WinApp.ModuloFuncionario
{
    public partial class TelaCadastroFuncionario : Form
    {
        private Funcionario funcionario;
        public Func<Funcionario, ValidationResult> GravarRegistro { get; set; }
        public Action<string> AtualizarRodape { get; set; }

        public Funcionario Funcionario
        {
            get { return funcionario; }
            set
            {
                funcionario = value;

                txtId.Text = Convert.ToString(funcionario._id);
                txtNome.Text = funcionario.Nome;
                txtSalario.Text = Convert.ToString(funcionario.Salario);
                cmbTipoPerfil.SelectedItem= funcionario.TipoPerfil;
                txtData.Value = funcionario.DataAdmicao;
                txtLogin.Text = funcionario.Login;
                txtSenha.Text = funcionario.Senha;
            }
        }

        public TelaCadastroFuncionario()
        {
            InitializeComponent();
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            if (!PegarObjetoTela()) return;


            var resultadoValidacao = GravarRegistro(funcionario);

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
            Guid id = new Guid();           

            if (txtId.Text != "")
                id = new Guid(txtId.Text);

            string nome = txtNome.Text;
            string login = txtLogin.Text;
            string senha = txtSenha.Text;
            decimal salario =(txtSalario.Text =="")?0: Convert.ToDecimal(txtSalario.Text);
            DateTime dataAdmicao = txtData.Value;
            string tipoPerfil = cmbTipoPerfil.Text;

            funcionario = new Funcionario(nome, login, senha, salario, dataAdmicao, tipoPerfil);

            if(id !=Guid.Empty)
                funcionario._id = id;
 
            return true;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            AtualizarRodape("Inserção Cancelada.");
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
