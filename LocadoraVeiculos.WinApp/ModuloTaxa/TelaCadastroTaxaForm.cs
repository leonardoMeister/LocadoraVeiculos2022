using LocadoraVeiculos.Dominio.ModuloTaxas;
using System;
using System.Windows.Forms;

namespace LocadoraVeiculos.WinApp.ModuloTaxa
{
    public partial class TelaCadastroTaxaForm : Form
    {
        private Taxas taxa;
        TelaPrincipalForm telaPrincipal;
        ValidadorTaxas validadorTaxas;

        public Taxas Taxa
        {
            get { return taxa; }
            set
            {
                taxa = value;

                txtId.Text = Convert.ToString(taxa._id);
                txtDescricao.Text = taxa.Descricao;
                txtValor.Text = Convert.ToString(taxa.Valor);
            }
        }

        public TelaCadastroTaxaForm(TelaPrincipalForm telaPrincipal)
        {
            InitializeComponent();
            this.telaPrincipal = telaPrincipal;
            validadorTaxas = new ValidadorTaxas();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            telaPrincipal.AtualizarRodape("Inserção Cancelada.");
            this.DialogResult = DialogResult.Cancel;

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            bool tudoValido = true;

            if (!PegarObjetoTela()) return;

            if (!ObjetoForInvalido())
                tudoValido = false;

            if (tudoValido)
                this.DialogResult = DialogResult.OK;
        }

        private bool ObjetoForInvalido()
        {
            var resultado = validadorTaxas.Validate(taxa);

            if (resultado.IsValid) return true;

            telaPrincipal.AtualizarRodape(resultado.Errors[0].ToString());
            return false;
        }

        private bool PegarObjetoTela()
        {
            int id = 0;

            if (txtId.Text != "")
                id = Convert.ToInt32(txtId.Text);

            if (txtDescricao.Text == "" || txtValor.Text == "")
                return false;

            string descricao = txtDescricao.Text;
            decimal valor = Convert.ToDecimal(txtValor.Text);

            taxa = new Taxas(descricao, valor);
            taxa._id = id;

            return true;
        }

    }
}
