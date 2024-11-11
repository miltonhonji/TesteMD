using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DeMaria.BLL;
using DeMaria.DTO;

namespace DeMaria.UI
{
    public partial class frmCadastroDeProdutos : Form
    {
        #region Variáveis
        private int idProduto;
        #endregion Variáveis

        public frmCadastroDeProdutos()
        {

        }

        public frmCadastroDeProdutos(int produtoId)
        {
            InitializeComponent();
            idProduto = produtoId;
            CarregarDados();
        }


        private void CarregarDados()
        {
            //Instanciar as classes do repositório do BLL.Produto e do DTO.Produto.
            ProdutoRepository produtoRepository = new ProdutoRepository();
            Produto produto = produtoRepository.Obter(idProduto);

            try
            {
                if (produto != null)
                {
                    txtNome.Text = produto.Nome;
                    txtDescricao.Text = produto.Descricao;
                    txtPreco.Text = Convert.ToDecimal(produto.Preco).ToString();
                    txtEstoque.Text = Convert.ToInt32(produto.Estoque).ToString();
                }
                else
                {
                    CadastrarNovo();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            Deletar();
        }

        private void Deletar()
        {
            ProdutoRepository produtoRepository = new ProdutoRepository();
            Produto produto = new Produto();

            produto.Id = idProduto;
            produto.Nome = txtNome.Text;

            try
            {
                if(produto.Id.Equals(0))
                {
                    MessageBox.Show("É necessário ter um produto escolhido", "De Maria", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    if(MessageBox.Show($"Deseja excluir este produto: { produto.Nome } ?", "De Maria", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (produtoRepository.Deletar(produto) > 0)
                        {
                            MessageBox.Show("Produto excluído com sucesso", "De Maria", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CadastrarNovo();
                        }
                        else
                        {
                            MessageBox.Show("Não foi possível excluir este produto", "De Maria", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            Gravar();
        }

        private void Gravar()
        {
            //Instancias para da classe Usuário para receber os dados
            ProdutoRepository produtoRepository = new ProdutoRepository();
            Produto produto = new Produto();

            produtoRepository.Obter(idProduto);

            produto.Id = idProduto;
            produto.Nome = txtNome.Text;
            produto.Descricao = txtDescricao.Text;
            produto.Preco = Convert.ToDecimal(txtPreco.Text);
            produto.Estoque = Convert.ToInt32(txtEstoque.Text);

            if(idProduto == 0)
            {
                idProduto = produtoRepository.Inserir(produto);
                MessageBox.Show("Produto salvo com sucesso", "De Maria", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CadastrarNovo();
            }
            else
            {
                if(produtoRepository.Update(produto) > 0)
                {
                    MessageBox.Show("Produto alterado com sucesso", "De Maria", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CadastrarNovo();
                }
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            CadastrarNovo();
        }

        private void CadastrarNovo()
        {
            idProduto = 0;
            txtNome.Text = String.Empty;
            txtDescricao.Text = String.Empty;
            txtEstoque.Text = String.Empty;
            txtPreco.Text = String.Empty;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
