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
            this.maskedTextBoxCNPJ = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.maskedTextBoxTelefone = new System.Windows.Forms.MaskedTextBox();
            this.radioButtonPessoaJuridica = new System.Windows.Forms.RadioButton();
            this.radioButtonPessoaFisica = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.maskedTextBoxCNH = new System.Windows.Forms.MaskedTextBox();
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCPF
            // 
            this.txtCPF.Location = new System.Drawing.Point(96, 256);
            this.txtCPF.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCPF.Mask = "00000000000";
            this.txtCPF.Name = "txtCPF";
            this.txtCPF.Size = new System.Drawing.Size(243, 23);
            this.txtCPF.TabIndex = 15;
            this.txtCPF.ValidatingType = typeof(int);
            // 
            // laValor
            // 
            this.laValor.AutoSize = true;
            this.laValor.Location = new System.Drawing.Point(41, 52);
            this.laValor.Name = "laValor";
            this.laValor.Size = new System.Drawing.Size(40, 15);
            this.laValor.TabIndex = 20;
            this.laValor.Text = "Nome";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(128, 333);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(101, 38);
            this.btnCancelar.TabIndex = 17;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(238, 333);
            this.btnSalvar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(101, 38);
            this.btnSalvar.TabIndex = 16;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // txtId
            // 
            this.txtId.Enabled = false;
            this.txtId.Location = new System.Drawing.Point(96, 9);
            this.txtId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(243, 23);
            this.txtId.TabIndex = 13;
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(96, 50);
            this.txtNome.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(243, 23);
            this.txtNome.TabIndex = 14;
            // 
            // laNome
            // 
            this.laNome.AutoSize = true;
            this.laNome.Location = new System.Drawing.Point(56, 258);
            this.laNome.Name = "laNome";
            this.laNome.Size = new System.Drawing.Size(28, 15);
            this.laNome.TabIndex = 19;
            this.laNome.Text = "CPF";
            // 
            // laId
            // 
            this.laId.AutoSize = true;
            this.laId.Location = new System.Drawing.Point(56, 11);
            this.laId.Name = "laId";
            this.laId.Size = new System.Drawing.Size(17, 15);
            this.laId.TabIndex = 18;
            this.laId.Text = "Id";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 15);
            this.label1.TabIndex = 22;
            this.label1.Text = "Endereco:";
            // 
            // txtEndereco
            // 
            this.txtEndereco.Location = new System.Drawing.Point(96, 83);
            this.txtEndereco.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtEndereco.Name = "txtEndereco";
            this.txtEndereco.Size = new System.Drawing.Size(243, 23);
            this.txtEndereco.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 15);
            this.label2.TabIndex = 24;
            this.label2.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(96, 116);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(243, 23);
            this.txtEmail.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 15);
            this.label3.TabIndex = 26;
            this.label3.Text = "Telefone";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(48, 224);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 15);
            this.label5.TabIndex = 30;
            this.label5.Text = "CNH";
            // 
            // maskedTextBoxCNPJ
            // 
            this.maskedTextBoxCNPJ.Location = new System.Drawing.Point(96, 290);
            this.maskedTextBoxCNPJ.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.maskedTextBoxCNPJ.Mask = "00000000000";
            this.maskedTextBoxCNPJ.Name = "maskedTextBoxCNPJ";
            this.maskedTextBoxCNPJ.Size = new System.Drawing.Size(243, 23);
            this.maskedTextBoxCNPJ.TabIndex = 32;
            this.maskedTextBoxCNPJ.ValidatingType = typeof(int);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(47, 292);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 15);
            this.label6.TabIndex = 33;
            this.label6.Text = "CNPJ";
            // 
            // maskedTextBoxTelefone
            // 
            this.maskedTextBoxTelefone.Location = new System.Drawing.Point(96, 152);
            this.maskedTextBoxTelefone.Mask = "(00) 00000-0000";
            this.maskedTextBoxTelefone.Name = "maskedTextBoxTelefone";
            this.maskedTextBoxTelefone.Size = new System.Drawing.Size(121, 23);
            this.maskedTextBoxTelefone.TabIndex = 34;
            // 
            // radioButtonPessoaJuridica
            // 
            this.radioButtonPessoaJuridica.AutoSize = true;
            this.radioButtonPessoaJuridica.Location = new System.Drawing.Point(140, 7);
            this.radioButtonPessoaJuridica.Name = "radioButtonPessoaJuridica";
            this.radioButtonPessoaJuridica.Size = new System.Drawing.Size(103, 19);
            this.radioButtonPessoaJuridica.TabIndex = 37;
            this.radioButtonPessoaJuridica.TabStop = true;
            this.radioButtonPessoaJuridica.Text = "Pessoa jurídica";
            this.radioButtonPessoaJuridica.UseVisualStyleBackColor = true;
            this.radioButtonPessoaJuridica.CheckedChanged += new System.EventHandler(this.radioButtonPessoaJuridica_CheckedChanged);
            // 
            // radioButtonPessoaFisica
            // 
            this.radioButtonPessoaFisica.AutoSize = true;
            this.radioButtonPessoaFisica.Location = new System.Drawing.Point(3, 7);
            this.radioButtonPessoaFisica.Name = "radioButtonPessoaFisica";
            this.radioButtonPessoaFisica.Size = new System.Drawing.Size(91, 19);
            this.radioButtonPessoaFisica.TabIndex = 35;
            this.radioButtonPessoaFisica.TabStop = true;
            this.radioButtonPessoaFisica.Text = "Pessoa física";
            this.radioButtonPessoaFisica.UseVisualStyleBackColor = true;
            this.radioButtonPessoaFisica.CheckedChanged += new System.EventHandler(this.radioButtonPessoaFisica_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 190);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 15);
            this.label7.TabIndex = 36;
            this.label7.Text = "Tipo de cliente:";
            // 
            // maskedTextBoxCNH
            // 
            this.maskedTextBoxCNH.Location = new System.Drawing.Point(96, 219);
            this.maskedTextBoxCNH.Mask = "000000000";
            this.maskedTextBoxCNH.Name = "maskedTextBoxCNH";
            this.maskedTextBoxCNH.Size = new System.Drawing.Size(121, 23);
            this.maskedTextBoxCNH.TabIndex = 38;
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(514, 136);
            this.txtNumero.Mask = "00000";
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(46, 23);
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
            this.comboBoxEstado.Location = new System.Drawing.Point(514, 50);
            this.comboBoxEstado.Name = "comboBoxEstado";
            this.comboBoxEstado.Size = new System.Drawing.Size(60, 23);
            this.comboBoxEstado.TabIndex = 41;
            // 
            // txtRua
            // 
            this.txtRua.Location = new System.Drawing.Point(514, 107);
            this.txtRua.Name = "txtRua";
            this.txtRua.Size = new System.Drawing.Size(291, 23);
            this.txtRua.TabIndex = 46;
            // 
            // txtBairro
            // 
            this.txtBairro.Location = new System.Drawing.Point(514, 78);
            this.txtBairro.Name = "txtBairro";
            this.txtBairro.Size = new System.Drawing.Size(291, 23);
            this.txtBairro.TabIndex = 44;
            // 
            // txtCidade
            // 
            this.txtCidade.Location = new System.Drawing.Point(640, 50);
            this.txtCidade.Name = "txtCidade";
            this.txtCidade.Size = new System.Drawing.Size(164, 23);
            this.txtCidade.TabIndex = 42;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(446, 140);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 15);
            this.label12.TabIndex = 47;
            this.label12.Text = "Número:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(471, 111);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(30, 15);
            this.label11.TabIndex = 45;
            this.label11.Text = "Rua:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(459, 82);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 15);
            this.label10.TabIndex = 43;
            this.label10.Text = "Bairro:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(588, 53);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 15);
            this.label8.TabIndex = 40;
            this.label8.Text = "Cidade:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(456, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 15);
            this.label4.TabIndex = 39;
            this.label4.Text = "Estado:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioButtonPessoaJuridica);
            this.panel1.Controls.Add(this.radioButtonPessoaFisica);
            this.panel1.Location = new System.Drawing.Point(96, 181);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(257, 32);
            this.panel1.TabIndex = 49;
            // 
            // TelaCadastroClienteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 380);
            this.Controls.Add(this.panel1);
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
            this.Controls.Add(this.maskedTextBoxCNH);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.maskedTextBoxTelefone);
            this.Controls.Add(this.maskedTextBoxCNPJ);
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
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaCadastroClienteForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Cliente";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.MaskedTextBox maskedTextBoxCNPJ;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxTelefone;
        private System.Windows.Forms.RadioButton radioButtonPessoaJuridica;
        private System.Windows.Forms.RadioButton radioButtonPessoaFisica;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxCNH;
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
        private System.Windows.Forms.Panel panel1;
    }
}