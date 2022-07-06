namespace LocadoraVeiculos.WinApp.ModuloPlanoCobranca
{
    partial class TelaCadastroPlanoCobranca
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtValorDia = new System.Windows.Forms.MaskedTextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.laId = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLimiteKM = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtValorKM = new System.Windows.Forms.MaskedTextBox();
            this.cmbGrupoVeiculo = new System.Windows.Forms.ComboBox();
            this.txtTipo = new System.Windows.Forms.TextBox();
            this.laNome = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 20);
            this.label2.TabIndex = 26;
            this.label2.Text = "Valor por dia:";
            // 
            // txtValorDia
            // 
            this.txtValorDia.Location = new System.Drawing.Point(123, 96);
            this.txtValorDia.Mask = "99999999";
            this.txtValorDia.Name = "txtValorDia";
            this.txtValorDia.Size = new System.Drawing.Size(256, 27);
            this.txtValorDia.TabIndex = 25;
            this.txtValorDia.ValidatingType = typeof(int);
            // 
            // txtId
            // 
            this.txtId.Enabled = false;
            this.txtId.Location = new System.Drawing.Point(123, 16);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(256, 27);
            this.txtId.TabIndex = 30;
            // 
            // laId
            // 
            this.laId.AutoSize = true;
            this.laId.Location = new System.Drawing.Point(51, 19);
            this.laId.Name = "laId";
            this.laId.Size = new System.Drawing.Size(66, 20);
            this.laId.TabIndex = 29;
            this.laId.Text = "Id Plano:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.TabIndex = 32;
            this.label1.Text = "Limite de KM:";
            // 
            // txtLimiteKM
            // 
            this.txtLimiteKM.Location = new System.Drawing.Point(123, 139);
            this.txtLimiteKM.Mask = "99999999";
            this.txtLimiteKM.Name = "txtLimiteKM";
            this.txtLimiteKM.Size = new System.Drawing.Size(256, 27);
            this.txtLimiteKM.TabIndex = 31;
            this.txtLimiteKM.ValidatingType = typeof(int);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 183);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 20);
            this.label3.TabIndex = 34;
            this.label3.Text = "Valor por KM:";
            // 
            // txtValorKM
            // 
            this.txtValorKM.Location = new System.Drawing.Point(123, 180);
            this.txtValorKM.Mask = "99999999";
            this.txtValorKM.Name = "txtValorKM";
            this.txtValorKM.Size = new System.Drawing.Size(256, 27);
            this.txtValorKM.TabIndex = 33;
            this.txtValorKM.ValidatingType = typeof(int);
            // 
            // cmbGrupoVeiculo
            // 
            this.cmbGrupoVeiculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGrupoVeiculo.FormattingEnabled = true;
            this.cmbGrupoVeiculo.Location = new System.Drawing.Point(123, 230);
            this.cmbGrupoVeiculo.Name = "cmbGrupoVeiculo";
            this.cmbGrupoVeiculo.Size = new System.Drawing.Size(256, 28);
            this.cmbGrupoVeiculo.TabIndex = 35;
            // 
            // txtTipo
            // 
            this.txtTipo.Location = new System.Drawing.Point(123, 58);
            this.txtTipo.Name = "txtTipo";
            this.txtTipo.Size = new System.Drawing.Size(256, 27);
            this.txtTipo.TabIndex = 37;
            // 
            // laNome
            // 
            this.laNome.AutoSize = true;
            this.laNome.Location = new System.Drawing.Point(12, 61);
            this.laNome.Name = "laNome";
            this.laNome.Size = new System.Drawing.Size(105, 20);
            this.laNome.TabIndex = 36;
            this.laNome.Text = "Tipo do Plano:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 230);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 20);
            this.label4.TabIndex = 38;
            this.label4.Text = "Grupo Veiculo:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(139, 284);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(115, 44);
            this.btnCancelar.TabIndex = 39;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(264, 284);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(115, 44);
            this.btnSalvar.TabIndex = 40;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // TelaCadastroPlanoCobranca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 342);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTipo);
            this.Controls.Add(this.laNome);
            this.Controls.Add(this.cmbGrupoVeiculo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtValorKM);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLimiteKM);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.laId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtValorDia);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaCadastroPlanoCobranca";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tela de Cadastro de Plano de Cobrança";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox txtValorDia;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label laId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox txtLimiteKM;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox txtValorKM;
        private System.Windows.Forms.ComboBox cmbGrupoVeiculo;
        private System.Windows.Forms.TextBox txtTipo;
        private System.Windows.Forms.Label laNome;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSalvar;
    }
}