using LocadoraVeiculos.Dominio.ModuloFuncionario;
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
    public partial class TelaCadastroFuncionario : Form
    {
        private Funcionario funcionario; 
        TelaPrincipalForm telaPrincipal;

        public Funcionario Funcionario
        {
            get { return funcionario; }
            set
            {
                funcionario = value;

                txtId.Text = Convert.ToString(funcionario._id);
                txtNome.Text = funcionario.Nome;
                txtSalario.Text = Convert.ToString(funcionario.Salario);
                txtTipoPerfil.Text = funcionario.TipoPerfil;
                txtData.Value = funcionario.DataAdmicao;
                txtLogin.Text = funcionario.Login;
                txtSenha.Text = funcionario.Senha;
            }
        }
        public TelaCadastroFuncionario(TelaPrincipalForm telaPrincipal)
        {
            InitializeComponent();
            this.telaPrincipal = telaPrincipal;

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            bool tudoValido = true;

            if (!PegarObjetoTela())
                tudoValido = false;

            if (ObjetoForInvalido())
                tudoValido = false;

            if (tudoValido)
                this.DialogResult = DialogResult.OK;
        }

        private bool ObjetoForInvalido()
        {
            return false;
            //VALIDAR AQUI
            //DEPOIS JOGAR A MENSAGEM NO RODAPE
        }

        private bool PegarObjetoTela()
        {
            int id = 0;

            if (txtId.Text != "")
                id = Convert.ToInt32(txtId.Text);

            if (txtLogin.Text == "" || txtNome.Text == "" || txtSalario.Text == ""
                || txtSenha.Text == "" || txtTipoPerfil.Text == "" )
                return false;

            string nome = txtNome.Text;
            string login = txtLogin.Text;
            string senha = txtSenha.Text;
            decimal salario = Convert.ToDecimal(txtSalario.Text);
            DateTime dataAdmicao = txtData.Value;
            string tipoPerfil = txtTipoPerfil.Text;
            
            funcionario = new Funcionario(nome,login,senha,salario,dataAdmicao,tipoPerfil);
            funcionario._id = id;

            return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            telaPrincipal.AtualizarRodape("Inserção Cancelada.");
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
