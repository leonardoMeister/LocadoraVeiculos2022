namespace LocadoraVeiculos.WinApp.ModuloLocacao
{
    partial class TelaCadastroDevolucaoForm
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
            this.pictureBoxFoto = new System.Windows.Forms.PictureBox();
            this.labelFoto = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.laId = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.laCliente = new System.Windows.Forms.Label();
            this.laCondutor = new System.Windows.Forms.Label();
            this.laGrupoVeiculo = new System.Windows.Forms.Label();
            this.laVeiculo = new System.Windows.Forms.Label();
            this.laPlano = new System.Windows.Forms.Label();
            this.laDataLocacao = new System.Windows.Forms.Label();
            this.laDataDevolucao = new System.Windows.Forms.Label();
            this.laValorTotal = new System.Windows.Forms.Label();
            this.cmbNivelTanque = new System.Windows.Forms.ComboBox();
            this.txtQuilometragemFinal = new System.Windows.Forms.MaskedTextBox();
            this.dataRealDevolucao = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listaTaxas = new System.Windows.Forms.CheckedListBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFoto)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxFoto
            // 
            this.pictureBoxFoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxFoto.Location = new System.Drawing.Point(107, 46);
            this.pictureBoxFoto.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBoxFoto.Name = "pictureBoxFoto";
            this.pictureBoxFoto.Size = new System.Drawing.Size(324, 203);
            this.pictureBoxFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxFoto.TabIndex = 42;
            this.pictureBoxFoto.TabStop = false;
            // 
            // labelFoto
            // 
            this.labelFoto.AutoSize = true;
            this.labelFoto.Location = new System.Drawing.Point(17, 46);
            this.labelFoto.Name = "labelFoto";
            this.labelFoto.Size = new System.Drawing.Size(42, 20);
            this.labelFoto.TabIndex = 41;
            this.labelFoto.Text = "Foto:";
            // 
            // txtId
            // 
            this.txtId.Enabled = false;
            this.txtId.Location = new System.Drawing.Point(107, 9);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(324, 27);
            this.txtId.TabIndex = 39;
            // 
            // laId
            // 
            this.laId.AutoSize = true;
            this.laId.Location = new System.Drawing.Point(17, 9);
            this.laId.Name = "laId";
            this.laId.Size = new System.Drawing.Size(84, 20);
            this.laId.TabIndex = 40;
            this.laId.Text = "Id Locação:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 262);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 20);
            this.label1.TabIndex = 44;
            this.label1.Text = "Check List Devolução";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(178, 475);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(123, 52);
            this.btnCancelar.TabIndex = 52;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(308, 475);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(123, 52);
            this.btnSalvar.TabIndex = 51;
            this.btnSalvar.Text = "Gravar Devolução";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.laCliente);
            this.groupBox1.Controls.Add(this.laCondutor);
            this.groupBox1.Controls.Add(this.laGrupoVeiculo);
            this.groupBox1.Controls.Add(this.laVeiculo);
            this.groupBox1.Controls.Add(this.laPlano);
            this.groupBox1.Controls.Add(this.laDataLocacao);
            this.groupBox1.Controls.Add(this.laDataDevolucao);
            this.groupBox1.Controls.Add(this.laValorTotal);
            this.groupBox1.Controls.Add(this.cmbNivelTanque);
            this.groupBox1.Controls.Add(this.txtQuilometragemFinal);
            this.groupBox1.Controls.Add(this.dataRealDevolucao);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(446, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(405, 517);
            this.groupBox1.TabIndex = 53;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dados Da Locação";
            // 
            // laCliente
            // 
            this.laCliente.AutoSize = true;
            this.laCliente.Location = new System.Drawing.Point(200, 46);
            this.laCliente.Name = "laCliente";
            this.laCliente.Size = new System.Drawing.Size(107, 20);
            this.laCliente.TabIndex = 76;
            this.laCliente.Text = "Texto exemplo";
            // 
            // laCondutor
            // 
            this.laCondutor.AutoSize = true;
            this.laCondutor.Location = new System.Drawing.Point(200, 88);
            this.laCondutor.Name = "laCondutor";
            this.laCondutor.Size = new System.Drawing.Size(107, 20);
            this.laCondutor.TabIndex = 75;
            this.laCondutor.Text = "Texto exemplo";
            // 
            // laGrupoVeiculo
            // 
            this.laGrupoVeiculo.AutoSize = true;
            this.laGrupoVeiculo.Location = new System.Drawing.Point(200, 130);
            this.laGrupoVeiculo.Name = "laGrupoVeiculo";
            this.laGrupoVeiculo.Size = new System.Drawing.Size(107, 20);
            this.laGrupoVeiculo.TabIndex = 74;
            this.laGrupoVeiculo.Text = "Texto exemplo";
            // 
            // laVeiculo
            // 
            this.laVeiculo.AutoSize = true;
            this.laVeiculo.Location = new System.Drawing.Point(200, 172);
            this.laVeiculo.Name = "laVeiculo";
            this.laVeiculo.Size = new System.Drawing.Size(107, 20);
            this.laVeiculo.TabIndex = 73;
            this.laVeiculo.Text = "Texto exemplo";
            // 
            // laPlano
            // 
            this.laPlano.AutoSize = true;
            this.laPlano.Location = new System.Drawing.Point(200, 217);
            this.laPlano.Name = "laPlano";
            this.laPlano.Size = new System.Drawing.Size(107, 20);
            this.laPlano.TabIndex = 72;
            this.laPlano.Text = "Texto exemplo";
            // 
            // laDataLocacao
            // 
            this.laDataLocacao.AutoSize = true;
            this.laDataLocacao.Location = new System.Drawing.Point(200, 263);
            this.laDataLocacao.Name = "laDataLocacao";
            this.laDataLocacao.Size = new System.Drawing.Size(107, 20);
            this.laDataLocacao.TabIndex = 71;
            this.laDataLocacao.Text = "Texto exemplo";
            // 
            // laDataDevolucao
            // 
            this.laDataDevolucao.AutoSize = true;
            this.laDataDevolucao.Location = new System.Drawing.Point(200, 303);
            this.laDataDevolucao.Name = "laDataDevolucao";
            this.laDataDevolucao.Size = new System.Drawing.Size(107, 20);
            this.laDataDevolucao.TabIndex = 70;
            this.laDataDevolucao.Text = "Texto exemplo";
            // 
            // laValorTotal
            // 
            this.laValorTotal.AutoSize = true;
            this.laValorTotal.Location = new System.Drawing.Point(200, 349);
            this.laValorTotal.Name = "laValorTotal";
            this.laValorTotal.Size = new System.Drawing.Size(107, 20);
            this.laValorTotal.TabIndex = 69;
            this.laValorTotal.Text = "Texto exemplo";
            // 
            // cmbNivelTanque
            // 
            this.cmbNivelTanque.FormattingEnabled = true;
            this.cmbNivelTanque.Location = new System.Drawing.Point(200, 479);
            this.cmbNivelTanque.Name = "cmbNivelTanque";
            this.cmbNivelTanque.Size = new System.Drawing.Size(199, 28);
            this.cmbNivelTanque.TabIndex = 68;
            // 
            // txtQuilometragemFinal
            // 
            this.txtQuilometragemFinal.Location = new System.Drawing.Point(200, 391);
            this.txtQuilometragemFinal.Name = "txtQuilometragemFinal";
            this.txtQuilometragemFinal.Size = new System.Drawing.Size(199, 27);
            this.txtQuilometragemFinal.TabIndex = 67;
            // 
            // dataRealDevolucao
            // 
            this.dataRealDevolucao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dataRealDevolucao.Location = new System.Drawing.Point(200, 438);
            this.dataRealDevolucao.Name = "dataRealDevolucao";
            this.dataRealDevolucao.Size = new System.Drawing.Size(199, 27);
            this.dataRealDevolucao.TabIndex = 66;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(32, 482);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(116, 20);
            this.label12.TabIndex = 64;
            this.label12.Text = "Nivel do Tanque";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(32, 438);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(116, 20);
            this.label11.TabIndex = 63;
            this.label11.Text = "Data Devolução";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(32, 394);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(153, 20);
            this.label10.TabIndex = 62;
            this.label10.Text = "Quilometragem Atual";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(32, 263);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(103, 20);
            this.label9.TabIndex = 61;
            this.label9.Text = "Data Locação:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(32, 88);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 20);
            this.label8.TabIndex = 60;
            this.label8.Text = "Condutor:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(32, 130);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(126, 20);
            this.label7.TabIndex = 59;
            this.label7.Text = "Grupo de Veiculo:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 172);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 20);
            this.label6.TabIndex = 58;
            this.label6.Text = "Veiculo:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 217);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 20);
            this.label5.TabIndex = 57;
            this.label5.Text = "Plano:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 303);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 20);
            this.label4.TabIndex = 56;
            this.label4.Text = "Data Devolução:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 349);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 20);
            this.label3.TabIndex = 55;
            this.label3.Text = "Valor Total:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 20);
            this.label2.TabIndex = 54;
            this.label2.Text = "Cliente:";
            // 
            // listaTaxas
            // 
            this.listaTaxas.FormattingEnabled = true;
            this.listaTaxas.Location = new System.Drawing.Point(16, 285);
            this.listaTaxas.Name = "listaTaxas";
            this.listaTaxas.Size = new System.Drawing.Size(415, 180);
            this.listaTaxas.TabIndex = 77;
            // 
            // TelaCadastroDevolucaoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 538);
            this.Controls.Add(this.listaTaxas);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBoxFoto);
            this.Controls.Add(this.labelFoto);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.laId);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaCadastroDevolucaoForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Devolucao";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFoto)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxFoto;
        private System.Windows.Forms.Label labelFoto;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label laId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label laCliente;
        private System.Windows.Forms.Label laCondutor;
        private System.Windows.Forms.Label laGrupoVeiculo;
        private System.Windows.Forms.Label laVeiculo;
        private System.Windows.Forms.Label laPlano;
        private System.Windows.Forms.Label laDataLocacao;
        private System.Windows.Forms.Label laDataDevolucao;
        private System.Windows.Forms.Label laValorTotal;
        private System.Windows.Forms.ComboBox cmbNivelTanque;
        private System.Windows.Forms.MaskedTextBox txtQuilometragemFinal;
        private System.Windows.Forms.DateTimePicker dataRealDevolucao;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox listaTaxas;
    }
}