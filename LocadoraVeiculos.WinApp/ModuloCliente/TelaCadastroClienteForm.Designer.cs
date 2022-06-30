namespace LocadoraVeiculos.WinApp.ModuloCliente
{
    partial class TelaCadastroClienteForm
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
            this.txtCPF = new System.Windows.Forms.MaskedTextBox();
            this.laValor = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.laNome = new System.Windows.Forms.Label();
            this.laId = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEndereco = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.maskedTextBox2 = new System.Windows.Forms.MaskedTextBox();
            this.radioButtonPessoaJuridica = new System.Windows.Forms.RadioButton();
            this.radioButtonPessoaFisica = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.maskedTextBox3 = new System.Windows.Forms.MaskedTextBox();
            this.txtNumero = new System.Windows.Forms.MaskedTextBox();
            this.comboBoxEstado = new System.Windows.Forms.ComboBox();
            this.txtRua = new System.Windows.Forms.TextBox();
            this.txtBairro = new System.Windows.Forms.TextBox();
            this.txtCidade = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtCPF
            // 
            this.txtCPF.Location = new System.Drawing.Point(110, 341);
            this.txtCPF.Mask = "00000000000";
            this.txtCPF.Name = "txtCPF";
            this.txtCPF.Size = new System.Drawing.Size(277, 27);
            this.txtCPF.TabIndex = 15;
            this.txtCPF.ValidatingType = typeof(int);
            // 
            // laValor
            // 
            this.laValor.AutoSize = true;
            this.laValor.Location = new System.Drawing.Point(47, 69);
            this.laValor.Name = "laValor";
            this.laValor.Size = new System.Drawing.Size(50, 20);
            this.laValor.TabIndex = 20;
            this.laValor.Text = "Nome";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(146, 444);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(115, 50);
            this.btnCancelar.TabIndex = 17;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(272, 444);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(115, 50);
            this.btnSalvar.TabIndex = 16;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // txtId
            // 
            this.txtId.Enabled = false;
            this.txtId.Location = new System.Drawing.Point(110, 12);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(277, 27);
            this.txtId.TabIndex = 13;
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(110, 66);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(277, 27);
            this.txtNome.TabIndex = 14;
            // 
            // laNome
            // 
            this.laNome.AutoSize = true;
            this.laNome.Location = new System.Drawing.Point(64, 344);
            this.laNome.Name = "laNome";
            this.laNome.Size = new System.Drawing.Size(33, 20);
            this.laNome.TabIndex = 19;
            this.laNome.Text = "CPF";
            // 
            // laId
            // 
            this.laId.AutoSize = true;
            this.laId.Location = new System.Drawing.Point(64, 15);
            this.laId.Name = "laId";
            this.laId.Size = new System.Drawing.Size(22, 20);
            this.laId.TabIndex = 18;
            this.laId.Text = "Id";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 20);
            this.label1.TabIndex = 22;
            this.label1.Text = "Endereco:";
            // 
            // txtEndereco
            // 
            this.txtEndereco.Location = new System.Drawing.Point(110, 111);
            this.txtEndereco.Name = "txtEndereco";
            this.txtEndereco.Size = new System.Drawing.Size(277, 27);
            this.txtEndereco.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 20);
            this.label2.TabIndex = 24;
            this.label2.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(110, 154);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(277, 27);
            this.txtEmail.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 205);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 20);
            this.label3.TabIndex = 26;
            this.label3.Text = "Telefone";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(55, 299);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 20);
            this.label5.TabIndex = 30;
            this.label5.Text = "CNH";
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(110, 386);
            this.maskedTextBox1.Mask = "00000000000";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(277, 27);
            this.maskedTextBox1.TabIndex = 32;
            this.maskedTextBox1.ValidatingType = typeof(int);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(54, 389);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 20);
            this.label6.TabIndex = 33;
            this.label6.Text = "CNPJ";
            // 
            // maskedTextBox2
            // 
            this.maskedTextBox2.Location = new System.Drawing.Point(110, 202);
            this.maskedTextBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.maskedTextBox2.Mask = "(00) 00000-0000";
            this.maskedTextBox2.Name = "maskedTextBox2";
            this.maskedTextBox2.Size = new System.Drawing.Size(138, 27);
            this.maskedTextBox2.TabIndex = 34;
            // 
            // radioButtonPessoaJuridica
            // 
            this.radioButtonPessoaJuridica.AutoSize = true;
            this.radioButtonPessoaJuridica.Location = new System.Drawing.Point(323, 251);
            this.radioButtonPessoaJuridica.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radioButtonPessoaJuridica.Name = "radioButtonPessoaJuridica";
            this.radioButtonPessoaJuridica.Size = new System.Drawing.Size(127, 24);
            this.radioButtonPessoaJuridica.TabIndex = 37;
            this.radioButtonPessoaJuridica.TabStop = true;
            this.radioButtonPessoaJuridica.Text = "Pessoa jurídica";
            this.radioButtonPessoaJuridica.UseVisualStyleBackColor = true;
            // 
            // radioButtonPessoaFisica
            // 
            this.radioButtonPessoaFisica.AutoSize = true;
            this.radioButtonPessoaFisica.Location = new System.Drawing.Point(135, 251);
            this.radioButtonPessoaFisica.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radioButtonPessoaFisica.Name = "radioButtonPessoaFisica";
            this.radioButtonPessoaFisica.Size = new System.Drawing.Size(112, 24);
            this.radioButtonPessoaFisica.TabIndex = 35;
            this.radioButtonPessoaFisica.TabStop = true;
            this.radioButtonPessoaFisica.Text = "Pessoa física";
            this.radioButtonPessoaFisica.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 253);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 20);
            this.label7.TabIndex = 36;
            this.label7.Text = "Tipo de cliente:";
            // 
            // maskedTextBox3
            // 
            this.maskedTextBox3.Location = new System.Drawing.Point(110, 292);
            this.maskedTextBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.maskedTextBox3.Mask = "000000000";
            this.maskedTextBox3.Name = "maskedTextBox3";
            this.maskedTextBox3.Size = new System.Drawing.Size(138, 27);
            this.maskedTextBox3.TabIndex = 38;
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(587, 182);
            this.txtNumero.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNumero.Mask = "00000";
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(52, 27);
            this.txtNumero.TabIndex = 48;
            this.txtNumero.ValidatingType = typeof(int);
            // 
            // comboBoxEstado
            // 
            this.comboBoxEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEstado.FormattingEnabled = true;
            this.comboBoxEstado.Items.AddRange(new object[] {
            "AC",
            "AL",
            "AP",
            "AM",
            "BA",
            "CE",
            "ES",
            "GO",
            "MA",
            "MT",
            "MS",
            "MG",
            "PA",
            "PB",
            "PR",
            "PE",
            "PI",
            "RJ",
            "RN",
            "RS",
            "RO",
            "RR",
            "SC",
            "SP",
            "SE",
            "TO",
            "DF"});
            this.comboBoxEstado.Location = new System.Drawing.Point(587, 66);
            this.comboBoxEstado.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBoxEstado.Name = "comboBoxEstado";
            this.comboBoxEstado.Size = new System.Drawing.Size(68, 28);
            this.comboBoxEstado.TabIndex = 41;
            // 
            // txtRua
            // 
            this.txtRua.Location = new System.Drawing.Point(587, 143);
            this.txtRua.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRua.Name = "txtRua";
            this.txtRua.Size = new System.Drawing.Size(332, 27);
            this.txtRua.TabIndex = 46;
            // 
            // txtBairro
            // 
            this.txtBairro.Location = new System.Drawing.Point(587, 104);
            this.txtBairro.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBairro.Name = "txtBairro";
            this.txtBairro.Size = new System.Drawing.Size(332, 27);
            this.txtBairro.TabIndex = 44;
            // 
            // txtCidade
            // 
            this.txtCidade.Location = new System.Drawing.Point(732, 66);
            this.txtCidade.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCidade.Name = "txtCidade";
            this.txtCidade.Size = new System.Drawing.Size(187, 27);
            this.txtCidade.TabIndex = 42;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(510, 187);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(66, 20);
            this.label12.TabIndex = 47;
            this.label12.Text = "Número:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(538, 148);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(37, 20);
            this.label11.TabIndex = 45;
            this.label11.Text = "Rua:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(525, 110);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 20);
            this.label10.TabIndex = 43;
            this.label10.Text = "Bairro:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(672, 71);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 20);
            this.label8.TabIndex = 40;
            this.label8.Text = "Cidade:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(521, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 20);
            this.label4.TabIndex = 39;
            this.label4.Text = "Estado:";
            // 
            // TelaCadastroClienteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 506);
            this.Controls.Add(this.txtNumero);
            this.Controls.Add(this.comboBoxEstado);
            this.Controls.Add(this.txtRua);
            this.Controls.Add(this.txtBairro);
            this.Controls.Add(this.txtCidade);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.maskedTextBox3);
            this.Controls.Add(this.radioButtonPessoaJuridica);
            this.Controls.Add(this.radioButtonPessoaFisica);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.maskedTextBox2);
            this.Controls.Add(this.maskedTextBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtEndereco);
            this.Controls.Add(this.txtCPF);
            this.Controls.Add(this.laValor);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.laNome);
            this.Controls.Add(this.laId);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaCadastroClienteForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TelaCadastroClienteForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox txtCPF;
        private System.Windows.Forms.Label laValor;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label laNome;
        private System.Windows.Forms.Label laId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEndereco;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox maskedTextBox2;
        private System.Windows.Forms.RadioButton radioButtonPessoaJuridica;
        private System.Windows.Forms.RadioButton radioButtonPessoaFisica;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MaskedTextBox maskedTextBox3;
        private System.Windows.Forms.MaskedTextBox txtNumero;
        private System.Windows.Forms.ComboBox comboBoxEstado;
        private System.Windows.Forms.TextBox txtRua;
        private System.Windows.Forms.TextBox txtBairro;
        private System.Windows.Forms.TextBox txtCidade;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
    }
}