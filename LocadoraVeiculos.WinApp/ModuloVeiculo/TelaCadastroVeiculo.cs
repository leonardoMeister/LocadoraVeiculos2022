using LocadoraVeiculos.Dominio.ModuloVeiculo;
using System;
using FluentValidation.Results;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using LocadoraVeiculos.Controladores.ModuloControladorGrupoVeiculos;
using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;

namespace LocadoraVeiculos.WinApp.ModuloVeiculo
{
    public partial class TelaCadastroVeiculo : Form
    {
        public TelaCadastroVeiculo()
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

        private Bitmap bmp;
        public Action<string> AtualizarRodape { get; set; }

        Veiculo veiculo;
        public Veiculo Veiculo
        {
            get { return veiculo; }
            set
            {
                veiculo = value;

                //txtId.Text = Convert.ToString(planoCobranca._id);
                //txtLimiteKM.Text = Convert.ToString(planoCobranca.LimiteKM);
                //txtTipo.Text = Convert.ToString(planoCobranca.TipoPlano);
                //txtValorDia.Text = Convert.ToString(planoCobranca.ValorDia);
                //txtValorKM.Text = Convert.ToString(planoCobranca.ValorKM);
                //cmbGrupoVeiculo.SelectedItem = planoCobranca.GrupoVeiculos;
            }
        }
        public Func<Veiculo, ValidationResult> GravarRegistro { get; internal set; }


        private void PegarObjetoTela()
        {
            int id = 0;

            if (txtId.Text != "")
                id = Convert.ToInt32(txtId.Text);

            MemoryStream memory = new MemoryStream();
            byte[] foto = null;
            if (bmp != null)
            {
                bmp.Save(memory, ImageFormat.Bmp);
                foto = memory.ToArray();
            }

            string modelo = textBoxModelo.Text;
            string placa = textBoxPlacas.Text;
            string marca = textBoxMarca.Text;
            string cor = textBoxCor.Text;
            string tipoCombustivel = comboBoxTipoCombustivel.Text;            
            DateTime ano = data.Value;
            
            decimal capacidadeTanque =  (textBoxCapacidadeTanque.Text == "")? 0:  Convert.ToDecimal(textBoxCapacidadeTanque.Text);
            decimal quilometragem =  (textBoxQuilometragem.Text == "")? 0: Convert.ToDecimal(textBoxQuilometragem.Text);


            GrupoVeiculos grupo = null;
            if (cmbGrupoVeiculo.SelectedIndex != -1) grupo = (GrupoVeiculos)cmbGrupoVeiculo.SelectedItem;

            veiculo = new Veiculo(modelo, placa, marca, cor, tipoCombustivel, capacidadeTanque, ano, quilometragem, foto, grupo)
            {
                _id = id
            };

        }

        private void buttonCarregarFoto_Click(object sender, EventArgs e)
        {
            if (openFileDialogFoto.ShowDialog() == DialogResult.OK)
            {
                string nome = openFileDialogFoto.FileName;

                bmp = new Bitmap(nome);

                pictureBoxFoto.Image = bmp;
            }
        }

        private void btnSalvar_Click_1(object sender, EventArgs e)
        {
            PegarObjetoTela();


            if(veiculo.Foto is null)
            {
                AtualizarRodape("Foto deve ser selecionada");

                DialogResult = DialogResult.None;
                return;
            }

            var resultadoValidacao = GravarRegistro(veiculo);

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

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            AtualizarRodape("Inserção Cancelada.");
            this.DialogResult = DialogResult.Cancel;
        }
    }
}