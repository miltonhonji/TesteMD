namespace DeMaria.UI
{
    partial class frmVendaDeProdutos
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
            this.grpInformacoesDoCliente = new System.Windows.Forms.GroupBox();
            this.lblTelefone = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.mskTelefone = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCep = new System.Windows.Forms.Label();
            this.txtRua = new System.Windows.Forms.TextBox();
            this.mskCep = new System.Windows.Forms.MaskedTextBox();
            this.lblRua = new System.Windows.Forms.Label();
            this.lblBairro = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.txtBairro = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblComplemento = new System.Windows.Forms.Label();
            this.txtComplemento = new System.Windows.Forms.TextBox();
            this.grpInformacoesDoCliente.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpInformacoesDoCliente
            // 
            this.grpInformacoesDoCliente.Controls.Add(this.lblTelefone);
            this.grpInformacoesDoCliente.Controls.Add(this.txtNome);
            this.grpInformacoesDoCliente.Controls.Add(this.mskTelefone);
            this.grpInformacoesDoCliente.Controls.Add(this.label1);
            this.grpInformacoesDoCliente.Controls.Add(this.lblCep);
            this.grpInformacoesDoCliente.Controls.Add(this.txtRua);
            this.grpInformacoesDoCliente.Controls.Add(this.mskCep);
            this.grpInformacoesDoCliente.Controls.Add(this.lblRua);
            this.grpInformacoesDoCliente.Controls.Add(this.lblBairro);
            this.grpInformacoesDoCliente.Controls.Add(this.txtNumero);
            this.grpInformacoesDoCliente.Controls.Add(this.txtBairro);
            this.grpInformacoesDoCliente.Controls.Add(this.label2);
            this.grpInformacoesDoCliente.Controls.Add(this.lblComplemento);
            this.grpInformacoesDoCliente.Controls.Add(this.txtComplemento);
            this.grpInformacoesDoCliente.Location = new System.Drawing.Point(12, 12);
            this.grpInformacoesDoCliente.Name = "grpInformacoesDoCliente";
            this.grpInformacoesDoCliente.Size = new System.Drawing.Size(513, 184);
            this.grpInformacoesDoCliente.TabIndex = 0;
            this.grpInformacoesDoCliente.TabStop = false;
            this.grpInformacoesDoCliente.Text = "Informações do Cliente";
            // 
            // lblTelefone
            // 
            this.lblTelefone.AutoSize = true;
            this.lblTelefone.Location = new System.Drawing.Point(321, 139);
            this.lblTelefone.Name = "lblTelefone";
            this.lblTelefone.Size = new System.Drawing.Size(49, 13);
            this.lblTelefone.TabIndex = 13;
            this.lblTelefone.Text = "Telefone";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(15, 33);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(483, 20);
            this.txtNome.TabIndex = 2;
            // 
            // mskTelefone
            // 
            this.mskTelefone.Location = new System.Drawing.Point(325, 155);
            this.mskTelefone.Mask = "(00) 00000-0000";
            this.mskTelefone.Name = "mskTelefone";
            this.mskTelefone.Size = new System.Drawing.Size(100, 20);
            this.mskTelefone.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nome";
            // 
            // lblCep
            // 
            this.lblCep.AutoSize = true;
            this.lblCep.Location = new System.Drawing.Point(13, 139);
            this.lblCep.Name = "lblCep";
            this.lblCep.Size = new System.Drawing.Size(28, 13);
            this.lblCep.TabIndex = 11;
            this.lblCep.Text = "CEP";
            // 
            // txtRua
            // 
            this.txtRua.Location = new System.Drawing.Point(15, 73);
            this.txtRua.Name = "txtRua";
            this.txtRua.Size = new System.Drawing.Size(278, 20);
            this.txtRua.TabIndex = 4;
            // 
            // mskCep
            // 
            this.mskCep.Location = new System.Drawing.Point(15, 155);
            this.mskCep.Mask = "00000-000";
            this.mskCep.Name = "mskCep";
            this.mskCep.Size = new System.Drawing.Size(100, 20);
            this.mskCep.TabIndex = 12;
            // 
            // lblRua
            // 
            this.lblRua.AutoSize = true;
            this.lblRua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblRua.Location = new System.Drawing.Point(12, 57);
            this.lblRua.Name = "lblRua";
            this.lblRua.Size = new System.Drawing.Size(27, 13);
            this.lblRua.TabIndex = 3;
            this.lblRua.Text = "Rua";
            // 
            // lblBairro
            // 
            this.lblBairro.AutoSize = true;
            this.lblBairro.Location = new System.Drawing.Point(321, 97);
            this.lblBairro.Name = "lblBairro";
            this.lblBairro.Size = new System.Drawing.Size(34, 13);
            this.lblBairro.TabIndex = 9;
            this.lblBairro.Text = "Bairro";
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(324, 73);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(174, 20);
            this.txtNumero.TabIndex = 6;
            // 
            // txtBairro
            // 
            this.txtBairro.Location = new System.Drawing.Point(324, 113);
            this.txtBairro.Name = "txtBairro";
            this.txtBairro.Size = new System.Drawing.Size(174, 20);
            this.txtBairro.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(321, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Número";
            // 
            // lblComplemento
            // 
            this.lblComplemento.AutoSize = true;
            this.lblComplemento.Location = new System.Drawing.Point(13, 97);
            this.lblComplemento.Name = "lblComplemento";
            this.lblComplemento.Size = new System.Drawing.Size(71, 13);
            this.lblComplemento.TabIndex = 7;
            this.lblComplemento.Text = "Complemento";
            // 
            // txtComplemento
            // 
            this.txtComplemento.Location = new System.Drawing.Point(15, 113);
            this.txtComplemento.Name = "txtComplemento";
            this.txtComplemento.Size = new System.Drawing.Size(278, 20);
            this.txtComplemento.TabIndex = 8;
            // 
            // frmVendaDeProdutos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 450);
            this.Controls.Add(this.grpInformacoesDoCliente);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmVendaDeProdutos";
            this.Text = "Venda de Produtos";
            this.grpInformacoesDoCliente.ResumeLayout(false);
            this.grpInformacoesDoCliente.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox grpInformacoesDoCliente;
        private System.Windows.Forms.Label lblTelefone;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.MaskedTextBox mskTelefone;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCep;
        private System.Windows.Forms.TextBox txtRua;
        private System.Windows.Forms.MaskedTextBox mskCep;
        private System.Windows.Forms.Label lblRua;
        private System.Windows.Forms.Label lblBairro;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.TextBox txtBairro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblComplemento;
        private System.Windows.Forms.TextBox txtComplemento;
    }
}