using FluentValidation.Results;
using LocadoraVeiculos.Controladores.ModuloControladorGrupoVeiculos;
using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraVeiculos.Dominio.ModuloPlanoCobranca;
using System;
using System.Windows.Forms;

namespace LocadoraVeiculos.WinApp.ModuloPlanoCobranca
{
    public partial class TelaCadastroPlanoCobranca : Form
    {
        private PlanoCobranca planoCobranca;
        public Action<string> AtualizarRodape { get; set; }
        public Func<PlanoCobranca, ValidationResult> GravarRegistro { get; internal set; }
        public PlanoCobranca PlanoCobranca
        {
            get { return planoCobranca; }
            set
            {
                planoCobranca = value;

                txtId.Text = Convert.ToString(planoCobranca._id);
                txtLimiteKM.Text = Convert.ToString(planoCobranca.LimiteKM);
                txtTipo.Text = Convert.ToString(planoCobranca.TipoPlano);
                txtValorDia.Text = Convert.ToString(planoCobranca.ValorDia);
                txtValorKM.Text = Convert.ToString(planoCobranca.ValorKM);
                cmbGrupoVeiculo.SelectedItem = planoCobranca.GrupoVeiculos;
            }
        }

        public TelaCadastroPlanoCobranca()
        {
            InitializeComponent();
            AtualizarPlanosCobranca();
        }

        private void AtualizarPlanosCobranca()
        {
            ControladorGrupoVeiculos control = new ControladorGrupoVeiculos();
            var dados = control.SelecionarTodos();
            foreach (var dado in dados)
            {
                cmbGrupoVeiculo.Items.Add(dado);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            AtualizarRodape("Inserção Cancelada.");
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!PegarObjetoTela()) return;


            var resultadoValidacao = GravarRegistro(PlanoCobranca);

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

            string tipo = txtTipo.Text;
            decimal valorDia = 0;
            decimal limite = 0;
            decimal valorKm = 0;
            if (txtValorDia.Text != "") valorDia = Convert.ToDecimal(txtValorDia.Text);
            if (txtLimiteKM.Text != "") limite = Convert.ToDecimal(txtLimiteKM.Text);
            if (txtValorKM.Text != "") valorKm = Convert.ToDecimal(txtValorKM.Text);

            GrupoVeiculos grupo = null;

            if (cmbGrupoVeiculo.SelectedIndex != -1) grupo = (GrupoVeiculos)cmbGrupoVeiculo.SelectedItem;

            planoCobranca = new PlanoCobranca(tipo, valorDia, limite, valorKm, grupo);

            if (id != Guid.Empty)
                planoCobranca._id = id;

            return true;
        }
    }
}
