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
    public partial class PesquisaProduto : Form
    {
        #region Variáveis
        private int idProduto;
        #endregion Variáveis

        public PesquisaProduto()
        {
            InitializeComponent();
            CarregarLista();
        }

        private void CarregarLista()
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

        private void btnNovo_Click(object sender, EventArgs e)
        {
            //Fechando a janela de Lista
            this.Close();
            //Abrindo outra tela de Cadastro de Clientes vázia
            frmMenu menuPrincipal = (frmMenu)Application.OpenForms["frmMenu"];

            if (menuPrincipal != null)
                menuPrincipal.AbrirFormulario(new frmCadastroDeProdutos(idProduto));
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvListaDeProdutos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Acessando a tela de Menu
            frmMenu menuPrincipal = (frmMenu)Application.OpenForms["frmMenu"];

            try
            {
                //Escolhe o cliente na posição atual
                var linhaSelecionada = dgvListaDeProdutos.CurrentRow;

                //idcliente recebe o valor da linha
                idProduto = Convert.ToInt32(linhaSelecionada.Cells[0].Value);

                if (menuPrincipal != null)
                    menuPrincipal.AbrirFormulario(new frmCadastroDeProdutos(idProduto));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            dgvListaDeProdutos_CellClick(null, null);
        }
    }
}
