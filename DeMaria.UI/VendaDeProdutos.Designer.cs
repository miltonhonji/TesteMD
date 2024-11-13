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
            this.grpProduto = new System.Windows.Forms.GroupBox();
            this.btnSelecionar = new System.Windows.Forms.Button();
            this.dgvListaDeProdutos = new System.Windows.Forms.DataGridView();
            this.txtNomeDoProduto = new System.Windows.Forms.TextBox();
            this.lblNomeDoProduto = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRetirarProduto = new System.Windows.Forms.Button();
            this.dgvProdutosEscolhidos = new System.Windows.Forms.DataGridView();
            this.dtpDataDeVenda = new System.Windows.Forms.DateTimePicker();
            this.lblDataDeVenda = new System.Windows.Forms.Label();
            this.txtValorTotal = new System.Windows.Forms.TextBox();
            this.lblValorTotal = new System.Windows.Forms.Label();
            this.lblQuantidadeItens = new System.Windows.Forms.Label();
            this.txtQuantidadeItens = new System.Windows.Forms.TextBox();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnGravar = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.grpInformacoesDoCliente.SuspendLayout();
            this.grpProduto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaDeProdutos)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutosEscolhidos)).BeginInit();
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
            this.grpInformacoesDoCliente.Location = new System.Drawing.Point(12, 10);
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
            // grpProduto
            // 
            this.grpProduto.Controls.Add(this.btnSelecionar);
            this.grpProduto.Controls.Add(this.dgvListaDeProdutos);
            this.grpProduto.Controls.Add(this.txtNomeDoProduto);
            this.grpProduto.Controls.Add(this.lblNomeDoProduto);
            this.grpProduto.Location = new System.Drawing.Point(12, 200);
            this.grpProduto.Name = "grpProduto";
            this.grpProduto.Size = new System.Drawing.Size(513, 250);
            this.grpProduto.TabIndex = 15;
            this.grpProduto.TabStop = false;
            this.grpProduto.Text = "Informações do Produto";
            // 
            // btnSelecionar
            // 
            this.btnSelecionar.Location = new System.Drawing.Point(402, 211);
            this.btnSelecionar.Name = "btnSelecionar";
            this.btnSelecionar.Size = new System.Drawing.Size(96, 33);
            this.btnSelecionar.TabIndex = 12;
            this.btnSelecionar.Text = "Selecionar";
            this.btnSelecionar.UseVisualStyleBackColor = true;
            this.btnSelecionar.Click += new System.EventHandler(this.btnSelecionar_Click);
            // 
            // dgvListaDeProdutos
            // 
            this.dgvListaDeProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaDeProdutos.Location = new System.Drawing.Point(15, 58);
            this.dgvListaDeProdutos.Name = "dgvListaDeProdutos";
            this.dgvListaDeProdutos.Size = new System.Drawing.Size(483, 146);
            this.dgvListaDeProdutos.TabIndex = 11;
            // 
            // txtNomeDoProduto
            // 
            this.txtNomeDoProduto.Location = new System.Drawing.Point(15, 33);
            this.txtNomeDoProduto.Name = "txtNomeDoProduto";
            this.txtNomeDoProduto.Size = new System.Drawing.Size(483, 20);
            this.txtNomeDoProduto.TabIndex = 2;
            // 
            // lblNomeDoProduto
            // 
            this.lblNomeDoProduto.AutoSize = true;
            this.lblNomeDoProduto.Location = new System.Drawing.Point(12, 17);
            this.lblNomeDoProduto.Name = "lblNomeDoProduto";
            this.lblNomeDoProduto.Size = new System.Drawing.Size(90, 13);
            this.lblNomeDoProduto.TabIndex = 1;
            this.lblNomeDoProduto.Text = "Nome do Produto";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRetirarProduto);
            this.groupBox1.Controls.Add(this.dgvProdutosEscolhidos);
            this.groupBox1.Location = new System.Drawing.Point(12, 455);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(513, 213);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Informações do Produto";
            // 
            // btnRetirarProduto
            // 
            this.btnRetirarProduto.Location = new System.Drawing.Point(402, 163);
            this.btnRetirarProduto.Name = "btnRetirarProduto";
            this.btnRetirarProduto.Size = new System.Drawing.Size(96, 33);
            this.btnRetirarProduto.TabIndex = 13;
            this.btnRetirarProduto.Text = "Retirar Produto";
            this.btnRetirarProduto.UseVisualStyleBackColor = true;
            this.btnRetirarProduto.Click += new System.EventHandler(this.btnRetirarProduto_Click);
            // 
            // dgvProdutosEscolhidos
            // 
            this.dgvProdutosEscolhidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProdutosEscolhidos.Location = new System.Drawing.Point(15, 23);
            this.dgvProdutosEscolhidos.Name = "dgvProdutosEscolhidos";
            this.dgvProdutosEscolhidos.Size = new System.Drawing.Size(483, 131);
            this.dgvProdutosEscolhidos.TabIndex = 11;
            // 
            // dtpDataDeVenda
            // 
            this.dtpDataDeVenda.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDataDeVenda.Location = new System.Drawing.Point(102, 674);
            this.dtpDataDeVenda.Name = "dtpDataDeVenda";
            this.dtpDataDeVenda.Size = new System.Drawing.Size(96, 20);
            this.dtpDataDeVenda.TabIndex = 17;
            // 
            // lblDataDeVenda
            // 
            this.lblDataDeVenda.AutoSize = true;
            this.lblDataDeVenda.Location = new System.Drawing.Point(14, 677);
            this.lblDataDeVenda.Name = "lblDataDeVenda";
            this.lblDataDeVenda.Size = new System.Drawing.Size(82, 13);
            this.lblDataDeVenda.TabIndex = 14;
            this.lblDataDeVenda.Text = "Data de Venda:";
            // 
            // txtValorTotal
            // 
            this.txtValorTotal.Location = new System.Drawing.Point(429, 698);
            this.txtValorTotal.Name = "txtValorTotal";
            this.txtValorTotal.Size = new System.Drawing.Size(96, 20);
            this.txtValorTotal.TabIndex = 13;
            // 
            // lblValorTotal
            // 
            this.lblValorTotal.AutoSize = true;
            this.lblValorTotal.Location = new System.Drawing.Point(362, 702);
            this.lblValorTotal.Name = "lblValorTotal";
            this.lblValorTotal.Size = new System.Drawing.Size(61, 13);
            this.lblValorTotal.TabIndex = 12;
            this.lblValorTotal.Text = "Valor Total:";
            // 
            // lblQuantidadeItens
            // 
            this.lblQuantidadeItens.AutoSize = true;
            this.lblQuantidadeItens.Location = new System.Drawing.Point(333, 677);
            this.lblQuantidadeItens.Name = "lblQuantidadeItens";
            this.lblQuantidadeItens.Size = new System.Drawing.Size(90, 13);
            this.lblQuantidadeItens.TabIndex = 18;
            this.lblQuantidadeItens.Text = "Quantidade itens:";
            // 
            // txtQuantidadeItens
            // 
            this.txtQuantidadeItens.Location = new System.Drawing.Point(429, 674);
            this.txtQuantidadeItens.Name = "txtQuantidadeItens";
            this.txtQuantidadeItens.Size = new System.Drawing.Size(96, 20);
            this.txtQuantidadeItens.TabIndex = 19;
            // 
            // btnNovo
            // 
            this.btnNovo.Location = new System.Drawing.Point(17, 735);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(96, 33);
            this.btnNovo.TabIndex = 14;
            this.btnNovo.Text = "Novo";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // btnGravar
            // 
            this.btnGravar.Location = new System.Drawing.Point(195, 735);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(96, 33);
            this.btnGravar.TabIndex = 20;
            this.btnGravar.Text = "Gravar";
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(429, 735);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(96, 33);
            this.btnSair.TabIndex = 21;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // frmVendaDeProdutos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1080, 805);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dtpDataDeVenda);
            this.Controls.Add(this.lblDataDeVenda);
            this.Controls.Add(this.txtQuantidadeItens);
            this.Controls.Add(this.lblQuantidadeItens);
            this.Controls.Add(this.grpProduto);
            this.Controls.Add(this.grpInformacoesDoCliente);
            this.Controls.Add(this.lblValorTotal);
            this.Controls.Add(this.txtValorTotal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmVendaDeProdutos";
            this.Text = "Venda de Produtos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.grpInformacoesDoCliente.ResumeLayout(false);
            this.grpInformacoesDoCliente.PerformLayout();
            this.grpProduto.ResumeLayout(false);
            this.grpProduto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaDeProdutos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutosEscolhidos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.GroupBox grpProduto;
        private System.Windows.Forms.TextBox txtNomeDoProduto;
        private System.Windows.Forms.Label lblNomeDoProduto;
        private System.Windows.Forms.DataGridView dgvListaDeProdutos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvProdutosEscolhidos;
        private System.Windows.Forms.TextBox txtValorTotal;
        private System.Windows.Forms.Label lblValorTotal;
        private System.Windows.Forms.Label lblDataDeVenda;
        private System.Windows.Forms.DateTimePicker dtpDataDeVenda;
        private System.Windows.Forms.Button btnSelecionar;
        private System.Windows.Forms.TextBox txtQuantidadeItens;
        private System.Windows.Forms.Label lblQuantidadeItens;
        private System.Windows.Forms.Button btnRetirarProduto;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.Button btnSair;
    }
}