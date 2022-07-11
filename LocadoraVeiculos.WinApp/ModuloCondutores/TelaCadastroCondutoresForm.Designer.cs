namespace LocadoraVeiculos.WinApp.ModuloCondutores
{
    partial class TelaCadastroCondutoresForm
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
            this.maskedTextBoxTelefone = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCPF = new System.Windows.Forms.MaskedTextBox();
            this.txtEndereco = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCnh = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCliente = new System.Windows.Forms.ComboBox();
            this.dateTimeCnh = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // laValor
            // 
            this.laValor.AutoSize = true;
            this.laValor.Location = new System.Drawing.Point(33, 104);
            this.laValor.Name = "laValor";
            this.laValor.Size = new System.Drawing.Size(40, 15);
            this.laValor.TabIndex = 20;
            this.laValor.Text = "Nome";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(200, 316);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(101, 38);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(310, 316);
            this.btnSalvar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(101, 38);
            this.btnSalvar.TabIndex = 8;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // txtId
            // 
            this.txtId.Enabled = false;
            this.txtId.Location = new System.Drawing.Point(74, 9);
            this.txtId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(105, 23);
            this.txtId.TabIndex = 1;
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(84, 97);
            this.txtNome.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(318, 23);
            this.txtNome.TabIndex = 3;
            // 
            // laNome
            // 
            this.laNome.AutoSize = true;
            this.laNome.Location = new System.Drawing.Point(45, 228);
            this.laNome.Name = "laNome";
            this.laNome.Size = new System.Drawing.Size(28, 15);
            this.laNome.TabIndex = 19;
            this.laNome.Text = "CPF";
            // 
            // laId
            // 
            this.laId.AutoSize = true;
            this.laId.Location = new System.Drawing.Point(46, 14);
            this.laId.Name = "laId";
            this.laId.Size = new System.Drawing.Size(17, 15);
            this.laId.TabIndex = 18;
            this.laId.Text = "Id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 15);
            this.label2.TabIndex = 24;
            this.label2.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(84, 139);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(318, 23);
            this.txtEmail.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 15);
            this.label3.TabIndex = 26;
            this.label3.Text = "Telefone";
            // 
            // maskedTextBoxTelefone
            // 
            this.maskedTextBoxTelefone.Location = new System.Drawing.Point(84, 57);
            this.maskedTextBoxTelefone.Mask = "00-00000-0000";
            this.maskedTextBoxTelefone.Name = "maskedTextBoxTelefone";
            this.maskedTextBoxTelefone.Size = new System.Drawing.Size(144, 23);
            this.maskedTextBoxTelefone.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 186);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 15);
            this.label7.TabIndex = 36;
            this.label7.Text = "Endereço";
            // 
            // txtCPF
            // 
            this.txtCPF.Location = new System.Drawing.Point(84, 223);
            this.txtCPF.Mask = "000,000,000-00";
            this.txtCPF.Name = "txtCPF";
            this.txtCPF.Size = new System.Drawing.Size(105, 23);
            this.txtCPF.TabIndex = 6;
            // 
            // txtEndereco
            // 
            this.txtEndereco.Location = new System.Drawing.Point(84, 180);
            this.txtEndereco.Name = "txtEndereco";
            this.txtEndereco.Size = new System.Drawing.Size(318, 23);
            this.txtEndereco.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(39, 266);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 15);
            this.label8.TabIndex = 40;
            this.label8.Text = "CNH";
            // 
            // txtCnh
            // 
            this.txtCnh.Location = new System.Drawing.Point(84, 260);
            this.txtCnh.Name = "txtCnh";
            this.txtCnh.Size = new System.Drawing.Size(105, 23);
            this.txtCnh.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(195, 265);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 15);
            this.label1.TabIndex = 42;
            this.label1.Text = "Validade CNH";
            // 
            // cmbCliente
            // 
            this.cmbCliente.FormattingEnabled = true;
            this.cmbCliente.Location = new System.Drawing.Point(245, 9);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Size = new System.Drawing.Size(157, 23);
            this.cmbCliente.TabIndex = 43;
            this.cmbCliente.SelectedIndexChanged += new System.EventHandler(this.CarregarDadosCliente);
            // 
            // dateTimeCnh
            // 
            this.dateTimeCnh.Location = new System.Drawing.Point(281, 260);
            this.dateTimeCnh.Name = "dateTimeCnh";
            this.dateTimeCnh.Size = new System.Drawing.Size(121, 23);
            this.dateTimeCnh.TabIndex = 44;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(190, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 15);
            this.label4.TabIndex = 45;
            this.label4.Text = "Clientes";
            // 
            // TelaCadastroCondutoresForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 376);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dateTimeCnh);
            this.Controls.Add(this.cmbCliente);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCnh);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtEndereco);
            this.Controls.Add(this.txtCPF);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.maskedTextBoxTelefone);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaCadastroCondutoresForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Cliente";
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
        private System.Windows.Forms.MaskedTextBox maskedTextBoxTelefone;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MaskedTextBox txtCPF;
        private System.Windows.Forms.TextBox txtEndereco;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCnh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCliente;
        private System.Windows.Forms.DateTimePicker dateTimeCnh;
        private System.Windows.Forms.Label label4;
    }
}