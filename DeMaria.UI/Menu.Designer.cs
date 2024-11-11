namespace DeMaria.UI
{
    partial class frmMenu
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
            this.pnlOpcoesMenu = new System.Windows.Forms.Panel();
            this.btnCadastroDeVendas = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnCadastroDeProdutos = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCadastroDeClientes = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlFormulario = new System.Windows.Forms.Panel();
            this.pnlOpcoesMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlOpcoesMenu
            // 
            this.pnlOpcoesMenu.Controls.Add(this.btnCadastroDeVendas);
            this.pnlOpcoesMenu.Controls.Add(this.panel3);
            this.pnlOpcoesMenu.Controls.Add(this.btnCadastroDeProdutos);
            this.pnlOpcoesMenu.Controls.Add(this.panel2);
            this.pnlOpcoesMenu.Controls.Add(this.btnCadastroDeClientes);
            this.pnlOpcoesMenu.Controls.Add(this.panel1);
            this.pnlOpcoesMenu.Location = new System.Drawing.Point(1, 1);
            this.pnlOpcoesMenu.Name = "pnlOpcoesMenu";
            this.pnlOpcoesMenu.Size = new System.Drawing.Size(256, 611);
            this.pnlOpcoesMenu.TabIndex = 0;
            // 
            // btnCadastroDeVendas
            // 
            this.btnCadastroDeVendas.Location = new System.Drawing.Point(10, 169);
            this.btnCadastroDeVendas.Name = "btnCadastroDeVendas";
            this.btnCadastroDeVendas.Size = new System.Drawing.Size(246, 48);
            this.btnCadastroDeVendas.TabIndex = 4;
            this.btnCadastroDeVendas.Text = "Vendas de Produtos";
            this.btnCadastroDeVendas.UseVisualStyleBackColor = true;
            this.btnCadastroDeVendas.Click += new System.EventHandler(this.btnCadastroDeVendas_Click);
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(1, 169);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(14, 48);
            this.panel3.TabIndex = 5;
            // 
            // btnCadastroDeProdutos
            // 
            this.btnCadastroDeProdutos.Location = new System.Drawing.Point(10, 123);
            this.btnCadastroDeProdutos.Name = "btnCadastroDeProdutos";
            this.btnCadastroDeProdutos.Size = new System.Drawing.Size(246, 48);
            this.btnCadastroDeProdutos.TabIndex = 2;
            this.btnCadastroDeProdutos.Text = "Produtos";
            this.btnCadastroDeProdutos.UseVisualStyleBackColor = true;
            this.btnCadastroDeProdutos.Click += new System.EventHandler(this.btnCadastroDeProdutos_Click);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(1, 123);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(14, 48);
            this.panel2.TabIndex = 3;
            // 
            // btnCadastroDeClientes
            // 
            this.btnCadastroDeClientes.Location = new System.Drawing.Point(10, 76);
            this.btnCadastroDeClientes.Name = "btnCadastroDeClientes";
            this.btnCadastroDeClientes.Size = new System.Drawing.Size(246, 48);
            this.btnCadastroDeClientes.TabIndex = 1;
            this.btnCadastroDeClientes.Text = "Clientes";
            this.btnCadastroDeClientes.UseVisualStyleBackColor = true;
            this.btnCadastroDeClientes.Click += new System.EventHandler(this.btnCadastroDeClientes_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(1, 76);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(14, 48);
            this.panel1.TabIndex = 1;
            // 
            // pnlFormulario
            // 
            this.pnlFormulario.Location = new System.Drawing.Point(257, 1);
            this.pnlFormulario.Name = "pnlFormulario";
            this.pnlFormulario.Size = new System.Drawing.Size(1026, 489);
            this.pnlFormulario.TabIndex = 1;
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 611);
            this.Controls.Add(this.pnlOpcoesMenu);
            this.Controls.Add(this.pnlFormulario);
            this.Name = "frmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.pnlOpcoesMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlOpcoesMenu;
        private System.Windows.Forms.Button btnCadastroDeVendas;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnCadastroDeProdutos;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCadastroDeClientes;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlFormulario;
    }
}