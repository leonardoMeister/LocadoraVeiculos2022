using FluentResults;
using FluentValidation.Results;
using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using System;
using System.Windows.Forms;

namespace LocadoraVeiculos.WinApp.ModuloGrupoVeiculo
{
    public partial class TelaCadastroGrupoVeiculo : Form
    {
        private GrupoVeiculos grupoVeiculos;

        public Action<string> AtualizarRodape { get; set; }

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

        public Func<GrupoVeiculos, Result<GrupoVeiculos>> GravarRegistro { get; internal set; }

        public TelaCadastroGrupoVeiculo()
        {
            InitializeComponent();
        }        

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            if (!PegarObjetoTela()) return;


            var resultadoValidacao = GravarRegistro(GrupoVeiculos);

            if (resultadoValidacao.IsFailed)
            {
                string erro = resultadoValidacao.Errors[0].Message;

                if (erro.StartsWith("Falha no sistema"))
                {
                    MessageBox.Show(erro,
                    "Inserção Grupo de Veiculos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    AtualizarRodape(erro);

                    DialogResult = DialogResult.None;
                }
            }
        }

        private bool PegarObjetoTela()
        {
            Guid id = new Guid();

            if (txtId.Text != "")
                id = new Guid(txtId.Text);

            if (txtNome.Text == "")
            {
                AtualizarRodape("Favor Preencher todos os campos.");
                return false;
            }
                
            string nome = txtNome.Text;

            grupoVeiculos = new GrupoVeiculos(nome);

            if (id != Guid.Empty)
                grupoVeiculos._id = id;

            return true;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            AtualizarRodape("Inserção Cancelada.");
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
