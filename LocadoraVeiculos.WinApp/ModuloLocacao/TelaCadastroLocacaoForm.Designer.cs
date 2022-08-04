namespace LocadoraVeiculos.WinApp.ModuloLocacao
{
    partial class TelaCadastroLocacaoForm
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
            this.cmbCliente = new System.Windows.Forms.ComboBox();
            this.textoCLiente = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCondutor = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbVeiculo = new System.Windows.Forms.ComboBox();
            this.pictureBoxFoto = new System.Windows.Forms.PictureBox();
            this.labelFoto = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtKmInicial = new System.Windows.Forms.MaskedTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbPlanoCobranca = new System.Windows.Forms.ComboBox();
            this.cmbGrupoVeiculo = new System.Windows.Forms.ComboBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.dataDevolucao = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.listaTaxas = new System.Windows.Forms.CheckedListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbNivelTanque = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.labelValor = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFoto)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbCliente
            // 
            this.cmbCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCliente.FormattingEnabled = true;
            this.cmbCliente.Location = new System.Drawing.Point(387, 47);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Size = new System.Drawing.Size(170, 28);
            this.cmbCliente.TabIndex = 0;
            // 
            // textoCLiente
            // 
            this.textoCLiente.AutoSize = true;
            this.textoCLiente.Location = new System.Drawing.Point(326, 50);
            this.textoCLiente.Name = "textoCLiente";
            this.textoCLiente.Size = new System.Drawing.Size(55, 20);
            this.textoCLiente.TabIndex = 32;
            this.textoCLiente.Text = "Cliente";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 20);
            this.label1.TabIndex = 34;
            this.label1.Text = "Condutor";
            // 
            // cmbCondutor
            // 
            this.cmbCondutor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCondutor.FormattingEnabled = true;
            this.cmbCondutor.Location = new System.Drawing.Point(143, 47);
            this.cmbCondutor.Name = "cmbCondutor";
            this.cmbCondutor.Size = new System.Drawing.Size(175, 28);
            this.cmbCondutor.TabIndex = 33;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 20);
            this.label2.TabIndex = 36;
            this.label2.Text = "Veiculo";
            // 
            // cmbVeiculo
            // 
            this.cmbVeiculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVeiculo.FormattingEnabled = true;
            this.cmbVeiculo.Location = new System.Drawing.Point(117, 32);
            this.cmbVeiculo.Name = "cmbVeiculo";
            this.cmbVeiculo.Size = new System.Drawing.Size(368, 28);
            this.cmbVeiculo.TabIndex = 35;
            this.cmbVeiculo.SelectedIndexChanged += new System.EventHandler(this.cmbVeiculo_SelectedIndexChanged);
            // 
            // pictureBoxFoto
            // 
            this.pictureBoxFoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxFoto.Location = new System.Drawing.Point(117, 131);
            this.pictureBoxFoto.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBoxFoto.Name = "pictureBoxFoto";
            this.pictureBoxFoto.Size = new System.Drawing.Size(368, 153);
            this.pictureBoxFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxFoto.TabIndex = 38;
            this.pictureBoxFoto.TabStop = false;
            // 
            // labelFoto
            // 
            this.labelFoto.AutoSize = true;
            this.labelFoto.Location = new System.Drawing.Point(69, 103);
            this.labelFoto.Name = "labelFoto";
            this.labelFoto.Size = new System.Drawing.Size(42, 20);
            this.labelFoto.TabIndex = 37;
            this.labelFoto.Text = "Foto:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtKmInicial);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.pictureBoxFoto);
            this.groupBox1.Controls.Add(this.cmbVeiculo);
            this.groupBox1.Controls.Add(this.labelFoto);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(26, 166);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(531, 299);
            this.groupBox1.TabIndex = 39;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dados Veiculo";
            // 
            // txtKmInicial
            // 
            this.txtKmInicial.Location = new System.Drawing.Point(282, 69);
            this.txtKmInicial.Name = "txtKmInicial";
            this.txtKmInicial.Size = new System.Drawing.Size(203, 27);
            this.txtKmInicial.TabIndex = 40;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(54, 72);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(133, 20);
            this.label10.TabIndex = 39;
            this.label10.Text = "Km Inicial Locação";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 20);
            this.label3.TabIndex = 41;
            this.label3.Text = "Grupo Do Veiculo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 484);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 20);
            this.label4.TabIndex = 44;
            this.label4.Text = "Plano Cobrança";
            // 
            // cmbPlanoCobranca
            // 
            this.cmbPlanoCobranca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPlanoCobranca.FormattingEnabled = true;
            this.cmbPlanoCobranca.Location = new System.Drawing.Point(145, 481);
            this.cmbPlanoCobranca.Name = "cmbPlanoCobranca";
            this.cmbPlanoCobranca.Size = new System.Drawing.Size(412, 28);
            this.cmbPlanoCobranca.TabIndex = 43;
            // 
            // cmbGrupoVeiculo
            // 
            this.cmbGrupoVeiculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGrupoVeiculo.FormattingEnabled = true;
            this.cmbGrupoVeiculo.Location = new System.Drawing.Point(143, 84);
            this.cmbGrupoVeiculo.Name = "cmbGrupoVeiculo";
            this.cmbGrupoVeiculo.Size = new System.Drawing.Size(414, 28);
            this.cmbGrupoVeiculo.TabIndex = 45;
            this.cmbGrupoVeiculo.SelectedIndexChanged += new System.EventHandler(this.SelecionarUmGrupoDeVeiculosNaTela);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(306, 711);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(123, 52);
            this.btnCancelar.TabIndex = 50;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(436, 711);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(123, 52);
            this.btnSalvar.TabIndex = 49;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 525);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 20);
            this.label5.TabIndex = 52;
            this.label5.Text = "Taxas da Locação";
            // 
            // dataDevolucao
            // 
            this.dataDevolucao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dataDevolucao.Location = new System.Drawing.Point(436, 129);
            this.dataDevolucao.Name = "dataDevolucao";
            this.dataDevolucao.Size = new System.Drawing.Size(121, 27);
            this.dataDevolucao.TabIndex = 53;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(314, 132);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 20);
            this.label7.TabIndex = 56;
            this.label7.Text = "Data Devolução";
            // 
            // listaTaxas
            // 
            this.listaTaxas.CheckOnClick = true;
            this.listaTaxas.FormattingEnabled = true;
            this.listaTaxas.Location = new System.Drawing.Point(37, 548);
            this.listaTaxas.Name = "listaTaxas";
            this.listaTaxas.Size = new System.Drawing.Size(522, 114);
            this.listaTaxas.TabIndex = 58;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(56, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 20);
            this.label9.TabIndex = 59;
            this.label9.Text = "Locação Id";
            // 
            // txtId
            // 
            this.txtId.Enabled = false;
            this.txtId.Location = new System.Drawing.Point(143, 9);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(414, 27);
            this.txtId.TabIndex = 60;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(43, 134);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 20);
            this.label6.TabIndex = 62;
            this.label6.Text = "Nível Tanque";
            // 
            // cmbNivelTanque
            // 
            this.cmbNivelTanque.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNivelTanque.FormattingEnabled = true;
            this.cmbNivelTanque.Location = new System.Drawing.Point(143, 131);
            this.cmbNivelTanque.Name = "cmbNivelTanque";
            this.cmbNivelTanque.Size = new System.Drawing.Size(165, 28);
            this.cmbNivelTanque.TabIndex = 61;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(281, 670);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(153, 20);
            this.label8.TabIndex = 57;
            this.label8.Text = "Valor Total Estimado: ";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(177, 711);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 52);
            this.button1.TabIndex = 63;
            this.button1.Text = "Simular Valor";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.SimularValorLocacaoClick);
            // 
            // labelValor
            // 
            this.labelValor.AutoSize = true;
            this.labelValor.Location = new System.Drawing.Point(430, 670);
            this.labelValor.Name = "labelValor";
            this.labelValor.Size = new System.Drawing.Size(0, 20);
            this.labelValor.TabIndex = 64;
            // 
            // TelaCadastroLocacaoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 792);
            this.Controls.Add(this.labelValor);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbNivelTanque);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.listaTaxas);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dataDevolucao);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.cmbGrupoVeiculo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbPlanoCobranca);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbCondutor);
            this.Controls.Add(this.textoCLiente);
            this.Controls.Add(this.cmbCliente);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaCadastroLocacaoForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tela Cadastro Locação";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFoto)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbCliente;
        private System.Windows.Forms.Label textoCLiente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCondutor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbVeiculo;
        private System.Windows.Forms.PictureBox pictureBoxFoto;
        private System.Windows.Forms.Label labelFoto;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbPlanoCobranca;
        private System.Windows.Forms.ComboBox cmbGrupoVeiculo;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dataDevolucao;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckedListBox listaTaxas;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbNivelTanque;
        private System.Windows.Forms.MaskedTextBox txtKmInicial;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelValor;
    }
}