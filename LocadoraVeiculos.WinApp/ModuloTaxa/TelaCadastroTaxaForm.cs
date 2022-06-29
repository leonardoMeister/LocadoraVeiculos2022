using FluentValidation.Results;
using LocadoraVeiculos.Dominio.ModuloTaxas;
using System;
using System.Windows.Forms;

namespace LocadoraVeiculos.WinApp.ModuloTaxa
{
    public partial class TelaCadastroTaxaForm : Form
    {
        private Taxas taxa;
        public Action<string> AtualizarRodape { get; set; }

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

        public Func<Taxas, ValidationResult> GravarRegistro { get; internal set; }

        public TelaCadastroTaxaForm()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            AtualizarRodape("Inserção Cancelada.");
            this.DialogResult = DialogResult.Cancel;

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!PegarObjetoTela()) return;


            var resultadoValidacao = GravarRegistro(taxa);

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
            int id = 0;

            if (txtId.Text != "")
                id = Convert.ToInt32(txtId.Text);

            if (txtDescricao.Text == "" || txtValor.Text == "")
            {
                AtualizarRodape("Favor Preencher todos os campos.");
                return false;
            }
                

            string descricao = txtDescricao.Text;
            decimal valor = Convert.ToDecimal(txtValor.Text);

            taxa = new Taxas(descricao, valor)
            {
                _id = id
            };

            return true;
        }

    }
}
