namespace DeMaria.UI
{
    partial class frmPesquisaVendasProdutos
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
            this.cboCliente = new System.Windows.Forms.ComboBox();
            this.lblNomeDoCliente = new System.Windows.Forms.Label();
            this.btnNovo = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cboCliente
            // 
            this.cboCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboCliente.FormattingEnabled = true;
            this.cboCliente.Location = new System.Drawing.Point(288, 57);
            this.cboCliente.Name = "cboCliente";
            this.cboCliente.Size = new System.Drawing.Size(372, 21);
            this.cboCliente.TabIndex = 6;
            // 
            // lblNomeDoCliente
            // 
            this.lblNomeDoCliente.AutoSize = true;
            this.lblNomeDoCliente.Location = new System.Drawing.Point(285, 38);
            this.lblNomeDoCliente.Name = "lblNomeDoCliente";
            this.lblNomeDoCliente.Size = new System.Drawing.Size(85, 13);
            this.lblNomeDoCliente.TabIndex = 7;
            this.lblNomeDoCliente.Text = "Nome do Cliente";
            // 
            // btnNovo
            // 
            this.btnNovo.Location = new System.Drawing.Point(765, 148);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(119, 50);
            this.btnNovo.TabIndex = 8;
            this.btnNovo.Text = "Novo";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(765, 216);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 50);
            this.button1.TabIndex = 9;
            this.button1.Text = "Novo";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(765, 287);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(119, 50);
            this.btnSair.TabIndex = 10;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // frmPesquisaVendasProdutos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 612);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.lblNomeDoCliente);
            this.Controls.Add(this.cboCliente);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPesquisaVendasProdutos";
            this.Text = "PesquisaVendasProdutos";
            this.Load += new System.EventHandler(this.frmPesquisaVendasProdutos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cboCliente;
        private System.Windows.Forms.Label lblNomeDoCliente;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnSair;
    }
}