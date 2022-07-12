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
                if (taxa.Tipo == EnumTaxa.Fixa.ToString()) radioFixa.Checked = true;
                if (taxa.Tipo == EnumTaxa.Diaria.ToString()) radioDiaria.Checked = true;
            }
        }

        public Func<Taxas, ValidationResult> GravarRegistro { get; internal set; }

        public TelaCadastroTaxaForm()
        {
            InitializeComponent();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            AtualizarRodape("Inserção Cancelada.");
            this.DialogResult = DialogResult.Cancel;

        }

        private void BtnSalvar_Click(object sender, EventArgs e)
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
            Guid id = new Guid();

            if (txtId.Text != "")
                id = new Guid(txtId.Text);

            if (txtDescricao.Text == "" || txtValor.Text == "")
            {
                AtualizarRodape("Favor Preencher todos os campos.");
                return false;
            }                

            string descricao = txtDescricao.Text;
            decimal valor = Convert.ToDecimal(txtValor.Text);
            string tipo = (radioDiaria.Checked) ? EnumTaxa.Diaria.ToString() : EnumTaxa.Fixa.ToString();
            taxa = new Taxas(descricao, valor, tipo);

            if (id != Guid.Empty)
                taxa._id = id;


            return true;
        }

    }
}
