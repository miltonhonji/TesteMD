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
            InitializeComponent();
        }

        private void frmCadastroDeProdutos_Load(object sender, EventArgs e)
        {
            CarregarProdutos();
        }

        private void CarregarProdutos()
        {
            //Instância da classe produtoRepository
            ProdutoRepository produtoRepository = new ProdutoRepository();

            try
            {
                //Lista de Produtos para o datagrid
                List<Produto> listaProdutos = produtoRepository.Listar();

                //gerar a coluna manual
                dgvListaDeProdutos.AutoGenerateColumns = false;

                //Limpando as colunas para receber os novos campos
                dgvListaDeProdutos.Columns.Clear();

                //Montando a ordem das colunas 
                //Lembrando que a coluna a Id não está  visível.
                dgvListaDeProdutos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id", Visible = false });
                dgvListaDeProdutos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome" });
                dgvListaDeProdutos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Descricao", HeaderText = "Descrição" });
                dgvListaDeProdutos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Preco", HeaderText = "Preço" });
                dgvListaDeProdutos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Estoque", HeaderText = "Quantidade" });

                //DataSource
                dgvListaDeProdutos.DataSource = listaProdutos;
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
            }
            else
            {
                if(produtoRepository.Update(produto) > 0)
                {
                    MessageBox.Show("Produto alterado com sucesso", "De Maria", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        //Commando para puxar a selecionar para os campos da tela.
        private void dgvListaDeProdutos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Selecionando a linha
            var linhaSelecionada = dgvListaDeProdutos.CurrentRow;

            //o idProduto pegará o valor do idProduto, para alteração da informação selecionada
            idProduto = Convert.ToInt32(linhaSelecionada.Cells[0].Value);

            //Puxando os valores para o campos
            txtNome.Text = Convert.ToString(linhaSelecionada.Cells[1].Value);
            txtDescricao.Text = Convert.ToString(linhaSelecionada.Cells[2].Value);
            txtPreco.Text = Convert.ToDecimal(linhaSelecionada.Cells[3].Value).ToString();
            txtEstoque.Text = Convert.ToInt32(linhaSelecionada.Cells[4].Value).ToString();
        }
    }
}
