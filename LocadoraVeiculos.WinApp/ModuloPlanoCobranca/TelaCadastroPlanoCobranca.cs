using FluentValidation.Results;
using LocadoraVeiculos.Dominio.ModuloPlanoCobranca;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

                //txtId.Text = Convert.ToString(grupoVeiculos._id);
                //txtNome.Text = grupoVeiculos.NomeGrupo;
            }
        }

        public TelaCadastroPlanoCobranca()
        {
            InitializeComponent();
        }
    }
}
