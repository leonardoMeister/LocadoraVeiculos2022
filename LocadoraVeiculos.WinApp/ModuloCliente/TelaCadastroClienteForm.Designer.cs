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
            this.laValor = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.laNome = new System.Windows.Forms.Label();
            this.laId = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.maskedTextBoxTelefone = new System.Windows.Forms.MaskedTextBox();
            this.radioButtonPessoaJuridica = new System.Windows.Forms.RadioButton();
            this.radioButtonPessoaFisica = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.maskedTextBoxCNPJ = new System.Windows.Forms.MaskedTextBox();
            this.txtCPF = new System.Windows.Forms.MaskedTextBox();
            this.txtEndereco = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // laValor
            // 
            this.laValor.AutoSize = true;
            this.laValor.Location = new System.Drawing.Point(11, 73);
            this.laValor.Name = "laValor";
            this.laValor.Size = new System.Drawing.Size(50, 20);
            this.laValor.TabIndex = 20;
            this.laValor.Text = "Nome";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(191, 327);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(115, 51);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(317, 327);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(115, 51);
            this.btnSalvar.TabIndex = 8;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // txtId
            // 
            this.txtId.Enabled = false;
            this.txtId.Location = new System.Drawing.Point(85, 12);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(119, 27);
            this.txtId.TabIndex = 1;
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(84, 66);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(348, 27);
            this.txtNome.TabIndex = 2;
            // 
            // laNome
            // 
            this.laNome.AutoSize = true;
            this.laNome.Location = new System.Drawing.Point(28, 238);
            this.laNome.Name = "laNome";
            this.laNome.Size = new System.Drawing.Size(33, 20);
            this.laNome.TabIndex = 19;
            this.laNome.Text = "CPF";
            // 
            // laId
            // 
            this.laId.AutoSize = true;
            this.laId.Location = new System.Drawing.Point(36, 12);
            this.laId.Name = "laId";
            this.laId.Size = new System.Drawing.Size(22, 20);
            this.laId.TabIndex = 18;
            this.laId.Text = "Id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 20);
            this.label2.TabIndex = 24;
            this.label2.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(84, 122);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(348, 27);
            this.txtEmail.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(235, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 20);
            this.label3.TabIndex = 26;
            this.label3.Text = "Telefone";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(235, 239);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 20);
            this.label6.TabIndex = 33;
            this.label6.Text = "CNPJ";
            // 
            // maskedTextBoxTelefone
            // 
            this.maskedTextBoxTelefone.Location = new System.Drawing.Point(302, 13);
            this.maskedTextBoxTelefone.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.maskedTextBoxTelefone.Mask = "00-00000-0000";
            this.maskedTextBoxTelefone.Name = "maskedTextBoxTelefone";
            this.maskedTextBoxTelefone.Size = new System.Drawing.Size(130, 27);
            this.maskedTextBoxTelefone.TabIndex = 7;
            // 
            // radioButtonPessoaJuridica
            // 
            this.radioButtonPessoaJuridica.AutoSize = true;
            this.radioButtonPessoaJuridica.Location = new System.Drawing.Point(169, 9);
            this.radioButtonPessoaJuridica.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radioButtonPessoaJuridica.Name = "radioButtonPessoaJuridica";
            this.radioButtonPessoaJuridica.Size = new System.Drawing.Size(127, 24);
            this.radioButtonPessoaJuridica.TabIndex = 37;
            this.radioButtonPessoaJuridica.TabStop = true;
            this.radioButtonPessoaJuridica.Text = "Pessoa jurídica";
            this.radioButtonPessoaJuridica.UseVisualStyleBackColor = true;
            this.radioButtonPessoaJuridica.CheckedChanged += new System.EventHandler(this.radioButtonPessoaJuridica_CheckedChanged);
            // 
            // radioButtonPessoaFisica
            // 
            this.radioButtonPessoaFisica.AutoSize = true;
            this.radioButtonPessoaFisica.Location = new System.Drawing.Point(3, 9);
            this.radioButtonPessoaFisica.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radioButtonPessoaFisica.Name = "radioButtonPessoaFisica";
            this.radioButtonPessoaFisica.Size = new System.Drawing.Size(112, 24);
            this.radioButtonPessoaFisica.TabIndex = 35;
            this.radioButtonPessoaFisica.TabStop = true;
            this.radioButtonPessoaFisica.Text = "Pessoa física";
            this.radioButtonPessoaFisica.UseVisualStyleBackColor = true;
            this.radioButtonPessoaFisica.CheckedChanged += new System.EventHandler(this.radioButtonPessoaFisica_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 181);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 20);
            this.label7.TabIndex = 36;
            this.label7.Text = "Tipo:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioButtonPessoaJuridica);
            this.panel1.Controls.Add(this.radioButtonPessoaFisica);
            this.panel1.Location = new System.Drawing.Point(85, 168);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(347, 43);
            this.panel1.TabIndex = 49;
            // 
            // maskedTextBoxCNPJ
            // 
            this.maskedTextBoxCNPJ.Location = new System.Drawing.Point(282, 236);
            this.maskedTextBoxCNPJ.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.maskedTextBoxCNPJ.Mask = "00,000,000/0000-00";
            this.maskedTextBoxCNPJ.Name = "maskedTextBoxCNPJ";
            this.maskedTextBoxCNPJ.Size = new System.Drawing.Size(150, 27);
            this.maskedTextBoxCNPJ.TabIndex = 5;
            // 
            // txtCPF
            // 
            this.txtCPF.Location = new System.Drawing.Point(84, 235);
            this.txtCPF.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCPF.Mask = "000,000,000-00";
            this.txtCPF.Name = "txtCPF";
            this.txtCPF.Size = new System.Drawing.Size(138, 27);
            this.txtCPF.TabIndex = 4;
            // 
            // txtEndereco
            // 
            this.txtEndereco.Location = new System.Drawing.Point(84, 280);
            this.txtEndereco.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEndereco.Name = "txtEndereco";
            this.txtEndereco.Size = new System.Drawing.Size(348, 27);
            this.txtEndereco.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(2, 283);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 20);
            this.label8.TabIndex = 40;
            this.label8.Text = "Endereço:";
            // 
            // TelaCadastroClienteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 394);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtEndereco);
            this.Controls.Add(this.txtCPF);
            this.Controls.Add(this.maskedTextBoxCNPJ);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.maskedTextBoxTelefone);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtEmail);
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
            this.Text = "Cadastro de Cliente";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label laValor;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label laNome;
        private System.Windows.Forms.Label laId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxTelefone;
        private System.Windows.Forms.RadioButton radioButtonPessoaJuridica;
        private System.Windows.Forms.RadioButton radioButtonPessoaFisica;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxCNPJ;
        private System.Windows.Forms.MaskedTextBox txtCPF;
        private System.Windows.Forms.TextBox txtEndereco;
        private System.Windows.Forms.Label label8;
    }
}