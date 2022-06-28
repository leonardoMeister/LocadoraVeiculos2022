using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraVeiculos.WinApp.ModuloGrupoVeiculo
{
    public partial class TelaCadastroGrupoVeiculo : Form
    {
        private GrupoVeiculos grupoVeiculos;

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


        public TelaCadastroGrupoVeiculo()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            btnCancelar.DialogResult = DialogResult.Cancel;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            PegarObjetoTela();
            btnSalvar.DialogResult = DialogResult.OK;
        }

        private void PegarObjetoTela()
        {
            int id = 0;
            if (txtId.Text !="")
                 id = Convert.ToInt32(txtId.Text);

            string nome = txtNome.Text;

            grupoVeiculos = new GrupoVeiculos(nome);
            grupoVeiculos._id = id;
        }
    }
}
