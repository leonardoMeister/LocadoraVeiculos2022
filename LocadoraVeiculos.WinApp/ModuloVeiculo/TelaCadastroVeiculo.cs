using LocadoraVeiculos.Dominio.ModuloVeiculo;
using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using LocadoraVeiculos.Controladores.ModuloServicoGrupoVeiculos;
using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using FluentResults;

namespace LocadoraVeiculos.WinApp.ModuloVeiculo
{
    public partial class TelaCadastroVeiculo : Form
    {
        public TelaCadastroVeiculo(ServicoGrupoVeiculos servico)
        {
            InitializeComponent();
            AtualizarPlanosCobranca();
            Servico = servico;
        }

        private void AtualizarPlanosCobranca()
        {
            var dados = Servico.SelecionarTodos().Value;
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
                CarregarFoto();
                txtId.Text = veiculo.Id.ToString();
                textBoxModelo.Text = veiculo.Modelo;
                textBoxPlacas.Text = veiculo.Placa;
                textBoxMarca.Text = veiculo.Marca;
                data.Value = veiculo.Ano;
                textCor.Text = veiculo.Cor;
                textBoxCapacidadeTanque.Text =  veiculo.CapacidadeTanque.ToString();
                textBoxQuilometragem.Text = veiculo.Quilometragem.ToString();
                cmbGrupoVeiculo.SelectedItem = veiculo.GrupoVeiculos;
                comboBoxTipoCombustivel.SelectedItem = veiculo.TipoCombustivel;
            }
        }

        private void CarregarFoto()
        {
            MemoryStream memory = new MemoryStream(veiculo.Foto);

            pictureBoxFoto.Image = Image.FromStream(memory);

            bmp = new Bitmap(pictureBoxFoto.Image);
        }

        public Func<Veiculo, Result<Veiculo>> GravarRegistro { get; internal set; }
        public ServicoGrupoVeiculos Servico { get; }

        private void PegarObjetoTela()
        {
            Guid id = new Guid();

            if (txtId.Text != "")
                id = new Guid(txtId.Text);

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
            string cor = textCor.Text;
            string tipoCombustivel = comboBoxTipoCombustivel.Text;            
            DateTime ano = data.Value;
            
            decimal capacidadeTanque =  (textBoxCapacidadeTanque.Text == "")? 0:  Convert.ToDecimal(textBoxCapacidadeTanque.Text);
            decimal quilometragem =  (textBoxQuilometragem.Text == "")? 0: Convert.ToDecimal(textBoxQuilometragem.Text);


            GrupoVeiculos grupo = null;
            if (cmbGrupoVeiculo.SelectedIndex != -1) grupo = (GrupoVeiculos)cmbGrupoVeiculo.SelectedItem;

            veiculo = new Veiculo(modelo, placa, marca, cor, tipoCombustivel, capacidadeTanque, ano, quilometragem, foto, grupo);

            if (id != Guid.Empty)
                veiculo.Id = id;

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

            if (resultadoValidacao.IsFailed)
            {
                string erro = resultadoValidacao.Errors[0].Message;

                if (erro.StartsWith("Falha no sistema"))
                {
                    MessageBox.Show(erro,
                    "Inserção Veiculo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    AtualizarRodape(erro);

                    DialogResult = DialogResult.None;
                }
            }
            else this.DialogResult = DialogResult.OK;
        }
        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            AtualizarRodape("Inserção Cancelada.");
            this.DialogResult = DialogResult.Cancel;
        }
    }
}