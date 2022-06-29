using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using System;
using System.Windows.Forms;

namespace LocadoraVeiculos.WinApp.ModuloGrupoVeiculo
{
    public partial class TelaCadastroGrupoVeiculo : Form
    {
        private GrupoVeiculos grupoVeiculos;
        TelaPrincipalForm telaPrincipal;
        ValidadorGrupoVeiculos validadorGrupoVeiculos;
        public GrupoVeiculos GrupoVeiculos
        {
            get { return grupoVeiculos; }
            set
            {
                grupoVeiculos = value;

                txtId.Text = Convert.ToString(grupoVeiculos._id);
                txtNome.Text = grupoVeiculos.NomeGrupo;
            }
        }
        public TelaCadastroGrupoVeiculo(TelaPrincipalForm telaPrincipal)
        {
            InitializeComponent();
            this.telaPrincipal = telaPrincipal;
            validadorGrupoVeiculos = new ValidadorGrupoVeiculos();
        }        

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            bool tudoValido = true;

            if (!PegarObjetoTela())
                tudoValido = false;

            if (ObjetoForInvalido())
                tudoValido = false;

            if (tudoValido)
                this.DialogResult =  DialogResult.OK;
        }

        private bool ObjetoForInvalido()
        {
            var resultado = validadorGrupoVeiculos.Validate(grupoVeiculos);

            if (resultado.IsValid) return true;

            telaPrincipal.AtualizarRodape(resultado.Errors[0].ToString());
            return false;

        }

        private bool PegarObjetoTela()
        {
            int id = 0;

            if (txtId.Text != "" )
                id = Convert.ToInt32(txtId.Text);

            if (txtNome.Text == "")
                return false;                                    

            string nome = txtNome.Text;
            
            grupoVeiculos = new GrupoVeiculos(nome);
            grupoVeiculos._id = id;

            return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            telaPrincipal.AtualizarRodape("Inserção Cancelada.");
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
