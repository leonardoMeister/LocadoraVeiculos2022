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
            this.txtId = new System.Windows.Forms.TextBox();
            this.laId = new System.Windows.Forms.Label();
            this.textoCLiente = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCondutor = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbVeiculo = new System.Windows.Forms.ComboBox();
            this.pictureBoxFoto = new System.Windows.Forms.PictureBox();
            this.labelFoto = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.listBox3 = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFoto)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbCliente
            // 
            this.cmbCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCliente.FormattingEnabled = true;
            this.cmbCliente.Location = new System.Drawing.Point(620, 18);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Size = new System.Drawing.Size(151, 28);
            this.cmbCliente.TabIndex = 0;
            // 
            // txtId
            // 
            this.txtId.Enabled = false;
            this.txtId.Location = new System.Drawing.Point(96, 12);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(200, 27);
            this.txtId.TabIndex = 30;
            // 
            // laId
            // 
            this.laId.AutoSize = true;
            this.laId.Location = new System.Drawing.Point(6, 15);
            this.laId.Name = "laId";
            this.laId.Size = new System.Drawing.Size(84, 20);
            this.laId.TabIndex = 31;
            this.laId.Text = "Id Locação:";
            // 
            // textoCLiente
            // 
            this.textoCLiente.AutoSize = true;
            this.textoCLiente.Location = new System.Drawing.Point(559, 21);
            this.textoCLiente.Name = "textoCLiente";
            this.textoCLiente.Size = new System.Drawing.Size(55, 20);
            this.textoCLiente.TabIndex = 32;
            this.textoCLiente.Text = "Cliente";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(312, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 20);
            this.label1.TabIndex = 34;
            this.label1.Text = "Condutor";
            // 
            // cmbCondutor
            // 
            this.cmbCondutor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCondutor.FormattingEnabled = true;
            this.cmbCondutor.Location = new System.Drawing.Point(389, 15);
            this.cmbCondutor.Name = "cmbCondutor";
            this.cmbCondutor.Size = new System.Drawing.Size(151, 28);
            this.cmbCondutor.TabIndex = 33;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(78, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 20);
            this.label2.TabIndex = 36;
            this.label2.Text = "Veiculo";
            // 
            // cmbVeiculo
            // 
            this.cmbVeiculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVeiculo.FormattingEnabled = true;
            this.cmbVeiculo.Location = new System.Drawing.Point(147, 29);
            this.cmbVeiculo.Name = "cmbVeiculo";
            this.cmbVeiculo.Size = new System.Drawing.Size(151, 28);
            this.cmbVeiculo.TabIndex = 35;
            // 
            // pictureBoxFoto
            // 
            this.pictureBoxFoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxFoto.Location = new System.Drawing.Point(113, 84);
            this.pictureBoxFoto.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBoxFoto.Name = "pictureBoxFoto";
            this.pictureBoxFoto.Size = new System.Drawing.Size(360, 203);
            this.pictureBoxFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxFoto.TabIndex = 38;
            this.pictureBoxFoto.TabStop = false;
            // 
            // labelFoto
            // 
            this.labelFoto.AutoSize = true;
            this.labelFoto.Location = new System.Drawing.Point(53, 84);
            this.labelFoto.Name = "labelFoto";
            this.labelFoto.Size = new System.Drawing.Size(42, 20);
            this.labelFoto.TabIndex = 37;
            this.labelFoto.Text = "Foto:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBoxFoto);
            this.groupBox1.Controls.Add(this.cmbVeiculo);
            this.groupBox1.Controls.Add(this.labelFoto);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(413, 139);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(534, 322);
            this.groupBox1.TabIndex = 39;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dados Veiculo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(552, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 20);
            this.label3.TabIndex = 41;
            this.label3.Text = "Grupo Do Veiculo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 231);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(168, 20);
            this.label4.TabIndex = 44;
            this.label4.Text = "Tipo de Plano Cobrança";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(15, 264);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(368, 28);
            this.comboBox1.TabIndex = 43;
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(684, 96);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(151, 28);
            this.comboBox2.TabIndex = 45;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(81, 500);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(150, 104);
            this.listBox1.TabIndex = 46;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 20;
            this.listBox2.Location = new System.Drawing.Point(358, 500);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(150, 104);
            this.listBox2.TabIndex = 47;
            // 
            // listBox3
            // 
            this.listBox3.FormattingEnabled = true;
            this.listBox3.ItemHeight = 20;
            this.listBox3.Location = new System.Drawing.Point(15, 298);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(368, 104);
            this.listBox3.TabIndex = 48;
            // 
            // TelaCadastroLocacaoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 650);
            this.Controls.Add(this.listBox3);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbCondutor);
            this.Controls.Add(this.textoCLiente);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.laId);
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
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label laId;
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
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.ListBox listBox3;
    }
}