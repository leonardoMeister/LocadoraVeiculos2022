namespace LocadoraVeiculos.WinApp.ModuloVeiculo
{
    partial class TelaCadastroVeiculo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelModelo = new System.Windows.Forms.Label();
            this.textBoxModelo = new System.Windows.Forms.TextBox();
            this.labelPlacas = new System.Windows.Forms.Label();
            this.textBoxMarca = new System.Windows.Forms.TextBox();
            this.labelMarca = new System.Windows.Forms.Label();
            this.textCor = new System.Windows.Forms.TextBox();
            this.labelCor = new System.Windows.Forms.Label();
            this.labelTipoCombustivel = new System.Windows.Forms.Label();
            this.comboBoxTipoCombustivel = new System.Windows.Forms.ComboBox();
            this.labelCapacidadeTanque = new System.Windows.Forms.Label();
            this.labelAno = new System.Windows.Forms.Label();
            this.labelQuilometragem = new System.Windows.Forms.Label();
            this.labelFoto = new System.Windows.Forms.Label();
            this.pictureBoxFoto = new System.Windows.Forms.PictureBox();
            this.openFileDialogFoto = new System.Windows.Forms.OpenFileDialog();
            this.buttonCarregarFoto = new System.Windows.Forms.Button();
            this.cmbGrupoVeiculo = new System.Windows.Forms.ComboBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.textBoxCapacidadeTanque = new System.Windows.Forms.MaskedTextBox();
            this.textBoxQuilometragem = new System.Windows.Forms.MaskedTextBox();
            this.data = new System.Windows.Forms.DateTimePicker();
            this.txtId = new System.Windows.Forms.TextBox();
            this.laId = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPlacas = new System.Windows.Forms.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFoto)).BeginInit();
            this.SuspendLayout();
            // 
            // labelModelo
            // 
            this.labelModelo.AutoSize = true;
            this.labelModelo.Location = new System.Drawing.Point(50, 46);
            this.labelModelo.Name = "labelModelo";
            this.labelModelo.Size = new System.Drawing.Size(64, 20);
            this.labelModelo.TabIndex = 0;
            this.labelModelo.Text = "Modelo:";
            // 
            // textBoxModelo
            // 
            this.textBoxModelo.Location = new System.Drawing.Point(132, 46);
            this.textBoxModelo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxModelo.Name = "textBoxModelo";
            this.textBoxModelo.Size = new System.Drawing.Size(144, 27);
            this.textBoxModelo.TabIndex = 1;
            // 
            // labelPlacas
            // 
            this.labelPlacas.AutoSize = true;
            this.labelPlacas.Location = new System.Drawing.Point(61, 79);
            this.labelPlacas.Name = "labelPlacas";
            this.labelPlacas.Size = new System.Drawing.Size(53, 20);
            this.labelPlacas.TabIndex = 0;
            this.labelPlacas.Text = "Placas:";
            // 
            // textBoxMarca
            // 
            this.textBoxMarca.Location = new System.Drawing.Point(131, 116);
            this.textBoxMarca.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxMarca.Name = "textBoxMarca";
            this.textBoxMarca.Size = new System.Drawing.Size(145, 27);
            this.textBoxMarca.TabIndex = 3;
            // 
            // labelMarca
            // 
            this.labelMarca.AutoSize = true;
            this.labelMarca.Location = new System.Drawing.Point(61, 116);
            this.labelMarca.Name = "labelMarca";
            this.labelMarca.Size = new System.Drawing.Size(53, 20);
            this.labelMarca.TabIndex = 0;
            this.labelMarca.Text = "Marca:";
            // 
            // textCor
            // 
            this.textCor.Location = new System.Drawing.Point(346, 81);
            this.textCor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textCor.Name = "textCor";
            this.textCor.Size = new System.Drawing.Size(145, 27);
            this.textCor.TabIndex = 6;
            // 
            // labelCor
            // 
            this.labelCor.AutoSize = true;
            this.labelCor.Location = new System.Drawing.Point(294, 85);
            this.labelCor.Name = "labelCor";
            this.labelCor.Size = new System.Drawing.Size(35, 20);
            this.labelCor.TabIndex = 0;
            this.labelCor.Text = "Cor:";
            // 
            // labelTipoCombustivel
            // 
            this.labelTipoCombustivel.AutoSize = true;
            this.labelTipoCombustivel.Location = new System.Drawing.Point(20, 156);
            this.labelTipoCombustivel.Name = "labelTipoCombustivel";
            this.labelTipoCombustivel.Size = new System.Drawing.Size(94, 20);
            this.labelTipoCombustivel.TabIndex = 0;
            this.labelTipoCombustivel.Text = "Combustível:";
            // 
            // comboBoxTipoCombustivel
            // 
            this.comboBoxTipoCombustivel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTipoCombustivel.FormattingEnabled = true;
            this.comboBoxTipoCombustivel.ItemHeight = 20;
            this.comboBoxTipoCombustivel.Items.AddRange(new object[] {
            "Gasolina",
            "Diesel",
            "Etanol",
            "GNV"});
            this.comboBoxTipoCombustivel.Location = new System.Drawing.Point(132, 158);
            this.comboBoxTipoCombustivel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBoxTipoCombustivel.Name = "comboBoxTipoCombustivel";
            this.comboBoxTipoCombustivel.Size = new System.Drawing.Size(144, 28);
            this.comboBoxTipoCombustivel.TabIndex = 4;
            // 
            // labelCapacidadeTanque
            // 
            this.labelCapacidadeTanque.AutoSize = true;
            this.labelCapacidadeTanque.Location = new System.Drawing.Point(285, 118);
            this.labelCapacidadeTanque.Name = "labelCapacidadeTanque";
            this.labelCapacidadeTanque.Size = new System.Drawing.Size(99, 20);
            this.labelCapacidadeTanque.TabIndex = 0;
            this.labelCapacidadeTanque.Text = "Capa/Tanque:";
            // 
            // labelAno
            // 
            this.labelAno.AutoSize = true;
            this.labelAno.Location = new System.Drawing.Point(292, 49);
            this.labelAno.Name = "labelAno";
            this.labelAno.Size = new System.Drawing.Size(39, 20);
            this.labelAno.TabIndex = 0;
            this.labelAno.Text = "Ano:";
            // 
            // labelQuilometragem
            // 
            this.labelQuilometragem.AutoSize = true;
            this.labelQuilometragem.Location = new System.Drawing.Point(285, 161);
            this.labelQuilometragem.Name = "labelQuilometragem";
            this.labelQuilometragem.Size = new System.Drawing.Size(117, 20);
            this.labelQuilometragem.TabIndex = 0;
            this.labelQuilometragem.Text = "Quilometragem:";
            // 
            // labelFoto
            // 
            this.labelFoto.AutoSize = true;
            this.labelFoto.Location = new System.Drawing.Point(71, 242);
            this.labelFoto.Name = "labelFoto";
            this.labelFoto.Size = new System.Drawing.Size(42, 20);
            this.labelFoto.TabIndex = 0;
            this.labelFoto.Text = "Foto:";
            // 
            // pictureBoxFoto
            // 
            this.pictureBoxFoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxFoto.Location = new System.Drawing.Point(131, 242);
            this.pictureBoxFoto.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBoxFoto.Name = "pictureBoxFoto";
            this.pictureBoxFoto.Size = new System.Drawing.Size(360, 203);
            this.pictureBoxFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxFoto.TabIndex = 3;
            this.pictureBoxFoto.TabStop = false;
            // 
            // openFileDialogFoto
            // 
            this.openFileDialogFoto.FileName = "openFileDialog1";
            // 
            // buttonCarregarFoto
            // 
            this.buttonCarregarFoto.Location = new System.Drawing.Point(131, 453);
            this.buttonCarregarFoto.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonCarregarFoto.Name = "buttonCarregarFoto";
            this.buttonCarregarFoto.Size = new System.Drawing.Size(148, 46);
            this.buttonCarregarFoto.TabIndex = 10;
            this.buttonCarregarFoto.Text = "Carregar Fotografia";
            this.buttonCarregarFoto.UseVisualStyleBackColor = true;
            this.buttonCarregarFoto.Click += new System.EventHandler(this.buttonCarregarFoto_Click);
            // 
            // cmbGrupoVeiculo
            // 
            this.cmbGrupoVeiculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGrupoVeiculo.FormattingEnabled = true;
            this.cmbGrupoVeiculo.Location = new System.Drawing.Point(132, 199);
            this.cmbGrupoVeiculo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbGrupoVeiculo.Name = "cmbGrupoVeiculo";
            this.cmbGrupoVeiculo.Size = new System.Drawing.Size(359, 28);
            this.cmbGrupoVeiculo.TabIndex = 9;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(266, 524);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(115, 44);
            this.btnCancelar.TabIndex = 12;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click_1);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(391, 524);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(115, 44);
            this.btnSalvar.TabIndex = 11;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click_1);
            // 
            // textBoxCapacidadeTanque
            // 
            this.textBoxCapacidadeTanque.Location = new System.Drawing.Point(390, 118);
            this.textBoxCapacidadeTanque.Mask = "00000";
            this.textBoxCapacidadeTanque.Name = "textBoxCapacidadeTanque";
            this.textBoxCapacidadeTanque.Size = new System.Drawing.Size(101, 27);
            this.textBoxCapacidadeTanque.TabIndex = 7;
            this.textBoxCapacidadeTanque.ValidatingType = typeof(int);
            // 
            // textBoxQuilometragem
            // 
            this.textBoxQuilometragem.Location = new System.Drawing.Point(408, 161);
            this.textBoxQuilometragem.Mask = "0000000000";
            this.textBoxQuilometragem.Name = "textBoxQuilometragem";
            this.textBoxQuilometragem.Size = new System.Drawing.Size(83, 27);
            this.textBoxQuilometragem.TabIndex = 8;
            this.textBoxQuilometragem.ValidatingType = typeof(int);
            // 
            // data
            // 
            this.data.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.data.Location = new System.Drawing.Point(346, 47);
            this.data.Name = "data";
            this.data.Size = new System.Drawing.Size(145, 27);
            this.data.TabIndex = 5;
            // 
            // txtId
            // 
            this.txtId.Enabled = false;
            this.txtId.Location = new System.Drawing.Point(131, 8);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(360, 27);
            this.txtId.TabIndex = 30;
            // 
            // laId
            // 
            this.laId.AutoSize = true;
            this.laId.Location = new System.Drawing.Point(36, 11);
            this.laId.Name = "laId";
            this.laId.Size = new System.Drawing.Size(77, 20);
            this.laId.TabIndex = 31;
            this.laId.Text = "Id Veiculo:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 202);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 20);
            this.label1.TabIndex = 32;
            this.label1.Text = "Grupo Veiculo";
            // 
            // textBoxPlacas
            // 
            this.textBoxPlacas.Location = new System.Drawing.Point(132, 82);
            this.textBoxPlacas.Name = "textBoxPlacas";
            this.textBoxPlacas.Size = new System.Drawing.Size(144, 27);
            this.textBoxPlacas.TabIndex = 2;
            this.textBoxPlacas.ValidatingType = typeof(int);
            // 
            // TelaCadastroVeiculo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 581);
            this.Controls.Add(this.textBoxPlacas);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.laId);
            this.Controls.Add(this.data);
            this.Controls.Add(this.textBoxQuilometragem);
            this.Controls.Add(this.textBoxCapacidadeTanque);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.cmbGrupoVeiculo);
            this.Controls.Add(this.buttonCarregarFoto);
            this.Controls.Add(this.pictureBoxFoto);
            this.Controls.Add(this.comboBoxTipoCombustivel);
            this.Controls.Add(this.textCor);
            this.Controls.Add(this.textBoxMarca);
            this.Controls.Add(this.textBoxModelo);
            this.Controls.Add(this.labelFoto);
            this.Controls.Add(this.labelQuilometragem);
            this.Controls.Add(this.labelAno);
            this.Controls.Add(this.labelCapacidadeTanque);
            this.Controls.Add(this.labelTipoCombustivel);
            this.Controls.Add(this.labelCor);
            this.Controls.Add(this.labelMarca);
            this.Controls.Add(this.labelPlacas);
            this.Controls.Add(this.labelModelo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaCadastroVeiculo";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Veículo";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelModelo;
        private System.Windows.Forms.TextBox textBoxModelo;
        private System.Windows.Forms.Label labelPlacas;
        private System.Windows.Forms.TextBox textBoxMarca;
        private System.Windows.Forms.Label labelMarca;
        private System.Windows.Forms.TextBox textCor;
        private System.Windows.Forms.Label labelCor;
        private System.Windows.Forms.Label labelTipoCombustivel;
        private System.Windows.Forms.ComboBox comboBoxTipoCombustivel;
        private System.Windows.Forms.Label labelCapacidadeTanque;
        private System.Windows.Forms.Label labelAno;
        private System.Windows.Forms.Label labelQuilometragem;
        private System.Windows.Forms.Label labelFoto;
        private System.Windows.Forms.PictureBox pictureBoxFoto;
        private System.Windows.Forms.OpenFileDialog openFileDialogFoto;
        private System.Windows.Forms.Button buttonCarregarFoto;
        private System.Windows.Forms.ComboBox cmbGrupoVeiculo;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.MaskedTextBox textBoxCapacidadeTanque;
        private System.Windows.Forms.MaskedTextBox textBoxQuilometragem;
        private System.Windows.Forms.DateTimePicker data;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label laId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox textBoxPlacas;
    }
}