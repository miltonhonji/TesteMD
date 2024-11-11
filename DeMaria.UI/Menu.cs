using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeMaria.UI
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void btnCadastroDeClientes_Click(object sender, EventArgs e)
        {
            //abrir formulario para pesquisar cliente
            AbrirFormulario(new frmPesquisaCliente());
        }

        private void btnCadastroDeProdutos_Click(object sender, EventArgs e)
        {
            //Abrir o formulário de para pesquisar produtos
            AbrirFormulario(new PesquisaProduto());
        }

        private void btnCadastroDeVendas_Click(object sender, EventArgs e)
        {
            //Chamando a tela de Pesquisa Vendas de Produto
            AbrirFormulario(new frmPesquisaVendasProdutos());
        }

        //Método para abrir o form no Panel Container
        //Precisa ficar em público para abrir os outros formulários
        public void AbrirFormulario(object frmPrincipal)
        {
            //Removendo o container
            if (pnlFormulario.Controls.Count > 0)
                this.pnlFormulario.Controls.RemoveAt(0);

            //Criando o formulário secundário 
            Form frmSecundario = frmPrincipal as Form;
            //Aqui indica que ele não será o formulário principal
            frmSecundario.TopLevel = false;
            //Ele preenhce todas as bordas da painel
            frmSecundario.Dock = DockStyle.Fill;
            //Após isso, ele adiciona o formulário
            this.pnlFormulario.Controls.Add(frmSecundario);
            this.pnlFormulario.Tag = frmSecundario;
            frmSecundario.Show();
        }

        //fechando o formulário para abrir outro
        public void FecharFormulario(object frmPrincipal)
        {
            //Verifica se há um painel na tela
            //se houve, ele será fechado
            if(pnlFormulario.Controls.Count > 0)
            {
                //Fecha e remove o formulário atual
                //Exemplo: Ocorrerá se o formulário de lista de clientes para a formulário de cadastro de clientes
                Form formularioAtual = pnlFormulario.Controls[0] as Form;

                if(formularioAtual != null)
                {
                    //Fechando o formulário atual
                    formularioAtual.Close();
                    //Remove o formulário atual
                    pnlFormulario.Controls.Remove(formularioAtual);
                }

                //Verifica se o novo formulário é valido e abrirá dentro do Panel
                Form novoFormulario = frmPrincipal as Form;
                if(novoFormulario != null)
                {
                    novoFormulario.TopLevel = false;
                    novoFormulario.Dock = DockStyle.Fill;
                    pnlFormulario.Controls.Add(novoFormulario);
                    pnlFormulario.Tag = novoFormulario;
                    novoFormulario.Show();
                }
            }
        }

    }
}
