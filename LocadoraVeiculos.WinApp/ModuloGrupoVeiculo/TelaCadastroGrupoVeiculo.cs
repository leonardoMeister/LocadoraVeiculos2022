using FluentResults;
using FluentValidation.Results;
using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using System;
using System.Windows.Forms;

namespace LocadoraVeiculos.WinApp.ModuloGrupoVeiculo
{
    public partial class TelaCadastroGrupoVeiculo : Form
    {
        public GrupoVeiculos grupoVeiculos;

        public Action<string> AtualizarRodape { get; set; }

        public GrupoVeiculos GrupoVeiculos
        {
            get { return grupoVeiculos; }
            set
            {
                grupoVeiculos = value;

                txtId.Text = Convert.ToString(grupoVeiculos.Id);
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
            PegarObjetoTela();

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
            else this.DialogResult = DialogResult.OK;
        }

        private void PegarObjetoTela()
        {                           
            grupoVeiculos.NomeGrupo = txtNome.Text;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            AtualizarRodape("Inserção Cancelada.");
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
