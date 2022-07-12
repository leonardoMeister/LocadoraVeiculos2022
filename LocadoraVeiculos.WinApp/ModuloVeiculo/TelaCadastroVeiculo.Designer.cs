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
            this.textBoxPlacas = new System.Windows.Forms.TextBox();
            this.textBoxMarca = new System.Windows.Forms.TextBox();
            this.labelMarca = new System.Windows.Forms.Label();
            this.textBoxCor = new System.Windows.Forms.TextBox();
            this.labelCor = new System.Windows.Forms.Label();
            this.labelTipoCombustivel = new System.Windows.Forms.Label();
            this.comboBoxTipoCombustivel = new System.Windows.Forms.ComboBox();
            this.textBoxCapacidadeTanque = new System.Windows.Forms.TextBox();
            this.labelCapacidadeTanque = new System.Windows.Forms.Label();
            this.labelLitros = new System.Windows.Forms.Label();
            this.textBoxAno = new System.Windows.Forms.TextBox();
            this.labelAno = new System.Windows.Forms.Label();
            this.textBoxQuilometragem = new System.Windows.Forms.TextBox();
            this.labelQuilometragem = new System.Windows.Forms.Label();
            this.labelFoto = new System.Windows.Forms.Label();
            this.pictureBoxFoto = new System.Windows.Forms.PictureBox();
            this.openFileDialogFoto = new System.Windows.Forms.OpenFileDialog();
            this.buttonCarregarFoto = new System.Windows.Forms.Button();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.buttonSalvar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFoto)).BeginInit();
            this.SuspendLayout();
            // 
            // labelModelo
            // 
            this.labelModelo.AutoSize = true;
            this.labelModelo.Location = new System.Drawing.Point(14, 16);
            this.labelModelo.Name = "labelModelo";
            this.labelModelo.Size = new System.Drawing.Size(64, 20);
            this.labelModelo.TabIndex = 0;
            this.labelModelo.Text = "Modelo:";
            // 
            // textBoxModelo
            // 
            this.textBoxModelo.Location = new System.Drawing.Point(128, 12);
            this.textBoxModelo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxModelo.Name = "textBoxModelo";
            this.textBoxModelo.Size = new System.Drawing.Size(428, 27);
            this.textBoxModelo.TabIndex = 1;
            // 
            // labelPlacas
            // 
            this.labelPlacas.AutoSize = true;
            this.labelPlacas.Location = new System.Drawing.Point(14, 55);
            this.labelPlacas.Name = "labelPlacas";
            this.labelPlacas.Size = new System.Drawing.Size(53, 20);
            this.labelPlacas.TabIndex = 0;
            this.labelPlacas.Text = "Placas:";
            // 
            // textBoxPlacas
            // 
            this.textBoxPlacas.Location = new System.Drawing.Point(128, 51);
            this.textBoxPlacas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxPlacas.Name = "textBoxPlacas";
            this.textBoxPlacas.Size = new System.Drawing.Size(428, 27);
            this.textBoxPlacas.TabIndex = 1;
            // 
            // textBoxMarca
            // 
            this.textBoxMarca.Location = new System.Drawing.Point(128, 89);
            this.textBoxMarca.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxMarca.Name = "textBoxMarca";
            this.textBoxMarca.Size = new System.Drawing.Size(428, 27);
            this.textBoxMarca.TabIndex = 1;
            // 
            // labelMarca
            // 
            this.labelMarca.AutoSize = true;
            this.labelMarca.Location = new System.Drawing.Point(14, 93);
            this.labelMarca.Name = "labelMarca";
            this.labelMarca.Size = new System.Drawing.Size(53, 20);
            this.labelMarca.TabIndex = 0;
            this.labelMarca.Text = "Marca:";
            // 
            // textBoxCor
            // 
            this.textBoxCor.Location = new System.Drawing.Point(128, 128);
            this.textBoxCor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxCor.Name = "textBoxCor";
            this.textBoxCor.Size = new System.Drawing.Size(428, 27);
            this.textBoxCor.TabIndex = 1;
            // 
            // labelCor
            // 
            this.labelCor.AutoSize = true;
            this.labelCor.Location = new System.Drawing.Point(14, 132);
            this.labelCor.Name = "labelCor";
            this.labelCor.Size = new System.Drawing.Size(35, 20);
            this.labelCor.TabIndex = 0;
            this.labelCor.Text = "Cor:";
            // 
            // labelTipoCombustivel
            // 
            this.labelTipoCombustivel.AutoSize = true;
            this.labelTipoCombustivel.Location = new System.Drawing.Point(14, 171);
            this.labelTipoCombustivel.Name = "labelTipoCombustivel";
            this.labelTipoCombustivel.Size = new System.Drawing.Size(149, 20);
            this.labelTipoCombustivel.TabIndex = 0;
            this.labelTipoCombustivel.Text = "Tipo de Combustível:";
            // 
            // comboBoxTipoCombustivel
            // 
            this.comboBoxTipoCombustivel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTipoCombustivel.FormattingEnabled = true;
            this.comboBoxTipoCombustivel.Items.AddRange(new object[] {
            "Gasolina",
            "Diesel",
            "Etanol",
            "GNV"});
            this.comboBoxTipoCombustivel.Location = new System.Drawing.Point(171, 168);
            this.comboBoxTipoCombustivel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBoxTipoCombustivel.Name = "comboBoxTipoCombustivel";
            this.comboBoxTipoCombustivel.Size = new System.Drawing.Size(397, 28);
            this.comboBoxTipoCombustivel.TabIndex = 2;
            // 
            // textBoxCapacidadeTanque
            // 
            this.textBoxCapacidadeTanque.Location = new System.Drawing.Point(171, 205);
            this.textBoxCapacidadeTanque.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxCapacidadeTanque.Name = "textBoxCapacidadeTanque";
            this.textBoxCapacidadeTanque.Size = new System.Drawing.Size(95, 27);
            this.textBoxCapacidadeTanque.TabIndex = 1;
            // 
            // labelCapacidadeTanque
            // 
            this.labelCapacidadeTanque.AutoSize = true;
            this.labelCapacidadeTanque.Location = new System.Drawing.Point(14, 209);
            this.labelCapacidadeTanque.Name = "labelCapacidadeTanque";
            this.labelCapacidadeTanque.Size = new System.Drawing.Size(164, 20);
            this.labelCapacidadeTanque.TabIndex = 0;
            this.labelCapacidadeTanque.Text = "Capacidade do Tanque:";
            // 
            // labelLitros
            // 
            this.labelLitros.AutoSize = true;
            this.labelLitros.Location = new System.Drawing.Point(274, 209);
            this.labelLitros.Name = "labelLitros";
            this.labelLitros.Size = new System.Drawing.Size(45, 20);
            this.labelLitros.TabIndex = 0;
            this.labelLitros.Text = "Litros";
            // 
            // textBoxAno
            // 
            this.textBoxAno.Location = new System.Drawing.Point(128, 244);
            this.textBoxAno.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxAno.Name = "textBoxAno";
            this.textBoxAno.Size = new System.Drawing.Size(428, 27);
            this.textBoxAno.TabIndex = 1;
            // 
            // labelAno
            // 
            this.labelAno.AutoSize = true;
            this.labelAno.Location = new System.Drawing.Point(14, 248);
            this.labelAno.Name = "labelAno";
            this.labelAno.Size = new System.Drawing.Size(39, 20);
            this.labelAno.TabIndex = 0;
            this.labelAno.Text = "Ano:";
            // 
            // textBoxQuilometragem
            // 
            this.textBoxQuilometragem.Location = new System.Drawing.Point(128, 283);
            this.textBoxQuilometragem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxQuilometragem.Name = "textBoxQuilometragem";
            this.textBoxQuilometragem.Size = new System.Drawing.Size(428, 27);
            this.textBoxQuilometragem.TabIndex = 1;
            // 
            // labelQuilometragem
            // 
            this.labelQuilometragem.AutoSize = true;
            this.labelQuilometragem.Location = new System.Drawing.Point(14, 287);
            this.labelQuilometragem.Name = "labelQuilometragem";
            this.labelQuilometragem.Size = new System.Drawing.Size(117, 20);
            this.labelQuilometragem.TabIndex = 0;
            this.labelQuilometragem.Text = "Quilometragem:";
            // 
            // labelFoto
            // 
            this.labelFoto.AutoSize = true;
            this.labelFoto.Location = new System.Drawing.Point(14, 325);
            this.labelFoto.Name = "labelFoto";
            this.labelFoto.Size = new System.Drawing.Size(42, 20);
            this.labelFoto.TabIndex = 0;
            this.labelFoto.Text = "Foto:";
            // 
            // pictureBoxFoto
            // 
            this.pictureBoxFoto.Location = new System.Drawing.Point(128, 325);
            this.pictureBoxFoto.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBoxFoto.Name = "pictureBoxFoto";
            this.pictureBoxFoto.Size = new System.Drawing.Size(323, 179);
            this.pictureBoxFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxFoto.TabIndex = 3;
            this.pictureBoxFoto.TabStop = false;
            // 
            // openFileDialogFoto
            // 
            this.openFileDialogFoto.FileName = "openFileDialog1";
            // 
            // buttonCarregarFoto
            // 
            this.buttonCarregarFoto.Location = new System.Drawing.Point(471, 473);
            this.buttonCarregarFoto.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonCarregarFoto.Name = "buttonCarregarFoto";
            this.buttonCarregarFoto.Size = new System.Drawing.Size(86, 31);
            this.buttonCarregarFoto.TabIndex = 4;
            this.buttonCarregarFoto.Text = "Carregar";
            this.buttonCarregarFoto.UseVisualStyleBackColor = true;
            this.buttonCarregarFoto.Click += new System.EventHandler(this.buttonCarregarFoto_Click);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Location = new System.Drawing.Point(469, 553);
            this.buttonCancelar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(86, 31);
            this.buttonCancelar.TabIndex = 4;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            // 
            // buttonSalvar
            // 
            this.buttonSalvar.Location = new System.Drawing.Point(376, 553);
            this.buttonSalvar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonSalvar.Name = "buttonSalvar";
            this.buttonSalvar.Size = new System.Drawing.Size(86, 31);
            this.buttonSalvar.TabIndex = 4;
            this.buttonSalvar.Text = "Salvar";
            this.buttonSalvar.UseVisualStyleBackColor = true;
            // 
            // TelaCadastroVeiculo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 600);
            this.Controls.Add(this.buttonSalvar);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonCarregarFoto);
            this.Controls.Add(this.pictureBoxFoto);
            this.Controls.Add(this.comboBoxTipoCombustivel);
            this.Controls.Add(this.textBoxQuilometragem);
            this.Controls.Add(this.textBoxAno);
            this.Controls.Add(this.textBoxCapacidadeTanque);
            this.Controls.Add(this.textBoxCor);
            this.Controls.Add(this.textBoxMarca);
            this.Controls.Add(this.textBoxPlacas);
            this.Controls.Add(this.textBoxModelo);
            this.Controls.Add(this.labelLitros);
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
            this.Text = "Cadastro de Veículo";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelModelo;
        private System.Windows.Forms.TextBox textBoxModelo;
        private System.Windows.Forms.Label labelPlacas;
        private System.Windows.Forms.TextBox textBoxPlacas;
        private System.Windows.Forms.TextBox textBoxMarca;
        private System.Windows.Forms.Label labelMarca;
        private System.Windows.Forms.TextBox textBoxCor;
        private System.Windows.Forms.Label labelCor;
        private System.Windows.Forms.Label labelTipoCombustivel;
        private System.Windows.Forms.ComboBox comboBoxTipoCombustivel;
        private System.Windows.Forms.TextBox textBoxCapacidadeTanque;
        private System.Windows.Forms.Label labelCapacidadeTanque;
        private System.Windows.Forms.Label labelLitros;
        private System.Windows.Forms.TextBox textBoxAno;
        private System.Windows.Forms.Label labelAno;
        private System.Windows.Forms.TextBox textBoxQuilometragem;
        private System.Windows.Forms.Label labelQuilometragem;
        private System.Windows.Forms.Label labelFoto;
        private System.Windows.Forms.PictureBox pictureBoxFoto;
        private System.Windows.Forms.OpenFileDialog openFileDialogFoto;
        private System.Windows.Forms.Button buttonCarregarFoto;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Button buttonSalvar;
    }
}