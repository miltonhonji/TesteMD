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
    public partial class frmVendaDeProdutos : Form
    {
        private int idCliente;
        private int idVenda;

        public frmVendaDeProdutos()
        {

        }

        public frmVendaDeProdutos(int vendaId, int clienteId)
        {
            InitializeComponent();
            idCliente = clienteId;
            idVenda = vendaId;

            CarregarDataGridView();

            if (vendaId == 0)
            {
                ObterCliente();
            }
            else
            {
                //Obtém as  as informações de venda e de item de venda.
                ObterVendas();
                //ObterItemVenda(idVenda);
            }
        }

        //Fazer um método para obter os nomes dos clientes
        private void ObterCliente()
        {
            //Primeiro iremos instanciar as classes e as DTOS do cliente para mostrar nos campos abaixo
            ClienteRepository clienteRepository = new ClienteRepository();
            Cliente cliente = clienteRepository.Obter(idCliente);

            try
            {
                if (cliente != null)
                {
                    txtNome.Text = cliente.Nome;
                    txtRua.Text = cliente.Rua;
                    txtNumero.Text = cliente.Numero.ToString();
                    txtComplemento.Text = cliente.Complemento;
                    txtBairro.Text = cliente.Bairro;
                    mskCep.Text = cliente.Cep;
                    mskTelefone.Text = cliente.Telefone;

                    //Os campos precisarão vir desabilitados
                    txtNome.Enabled = false;
                    txtRua.Enabled = false;
                    txtNumero.Enabled = false;
                    txtComplemento.Enabled = false;
                    txtBairro.Enabled = false;
                    mskCep.Enabled = false;
                    mskTelefone.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void ObterVendas()
        {
            //Instacias da classes VendaRepository e Venda
            VendaRepository vendaRepository = new VendaRepository();
            Venda venda = vendaRepository.Obter(idVenda);
            //Dataset para o datagridview
            DataSet dsItemVenda = vendaRepository.ObterItemVenda(idVenda);
            //Variável para indicar a quantidadeTotal (que estava salvo na última gravação).
            int quantidadeTotal = 0;

            if (venda != null)
            {
                idCliente = venda.IdCliente;

                if ((venda.IdCliente != 0) && (venda.IdVenda !=0))
                {
                    ObterCliente();

                    dtpDataDeVenda.Value = Convert.ToDateTime(venda.DataVenda);
                    txtValorTotal.Text = Convert.ToDecimal(venda.ValorTotal).ToString();

                    dtpDataDeVenda.Enabled = false;
                    txtValorTotal.Enabled = false;

                    //Configura o datasource
                    dgvProdutosEscolhidos.DataSource = dsItemVenda.Tables["ItemVenda"];

                    //Deixando algumas colunas ocultas
                    dgvProdutosEscolhidos.Columns["Id_Produto"].Visible = false;

                    //Percorre todas as  linhas da tabela e soma com valor da coluna do estoque
                    foreach (DataRow linha in dsItemVenda.Tables["ItemVenda"].Rows)
                    {
                        //Quantidade total recebedno o valor da linha do estoque
                        quantidadeTotal += Convert.ToInt32(linha["Estoque"]);
                    }
                    //O textbox recebe o valor da quantidade Total
                    txtQuantidadeItens.Text = quantidadeTotal.ToString();
                }
            }
        }

        private void ObterItemVenda(int idVenda)
        {
            //Instacias da classes VendaRepository e Venda
            VendaRepository vendaRepository = new VendaRepository();
            //Dataset para o datagridview
            DataSet dsItemVenda = vendaRepository.ObterItemVenda(idVenda);
            //Variável para indicar a quantidadeTotal (que estava salvo na última gravação).
            int quantidadeTotal = 0;

            //Configura o datasource
            dgvProdutosEscolhidos.DataSource = dsItemVenda.Tables["ItemVenda"];

            dgvListaDeProdutos.AutoGenerateColumns = false;

            if (dsItemVenda.Tables["ItemVenda"].Rows.Count > 0)
            {
                dgvProdutosEscolhidos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Id_Produto", HeaderText = "Id_Produto", Visible = false });
                dgvProdutosEscolhidos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome" });
                dgvProdutosEscolhidos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Preco", HeaderText = "Preco" });
                dgvProdutosEscolhidos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Estoque", HeaderText = "Quantidade" });
            }

            //Percorre todas as  linhas da tabela e soma com valor da coluna do estoque
            foreach(DataRow linha in dsItemVenda.Tables["ItemVenda"].Rows)
            {
                //Quantidade total recebedno o valor da linha do estoque
                quantidadeTotal += Convert.ToInt32(linha["Estoque"]);
            }
            //O textbox recebe o valor da quantidade Total
            txtQuantidadeItens.Text = quantidadeTotal.ToString();
        }

        private void CarregarDataGridView()
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
                dgvListaDeProdutos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "IdItemVenda", HeaderText = "Id Item Venda", Visible = false });
                dgvListaDeProdutos.Columns.Add(new DataGridViewCheckBoxColumn { DataPropertyName = "Selecionar", HeaderText = "Selecionar" });
                dgvListaDeProdutos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome" });
                dgvListaDeProdutos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Descricao", HeaderText = "Descrição", Visible = false });
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

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            CarregarProdutosEscolhidos();
        }

        private void CarregarProdutosEscolhidos()
        {
            //Lista Produtos temporária
            List<Produto> produtosSelecionados = new List<Produto>();

            try
            {
                //Faz o laço e verifica cada linha se está ticado
                foreach (DataGridViewRow linha in dgvListaDeProdutos.Rows)
                {
                    //Faz a verificação da linha, se está ticado o botão "Selecionar"
                    if (Convert.ToBoolean(linha.Cells[2].Value) == true)
                    {
                        //Valor que irá ser retirado
                        int quantidadeEscolhida = 1;

                        int estoqueAtual = Convert.ToInt32(linha.Cells[6].Value);

                        if (estoqueAtual >= quantidadeEscolhida)
                        {
                            //Instancia do Produto
                            Produto produto = new Produto
                            {
                                Id = Convert.ToInt32(linha.Cells[0].Value),
                                IdItemVenda = Convert.ToInt32(linha.Cells[1].Value),
                                Nome = Convert.ToString(linha.Cells[3].Value),
                                Descricao = Convert.ToString(linha.Cells[4].Value),
                                Preco = Convert.ToDecimal(linha.Cells[5].Value),
                                Estoque = quantidadeEscolhida
                            };

                            // Atualiza o estoque na lista original
                            linha.Cells[6].Value = estoqueAtual - quantidadeEscolhida;
                            //Então adicona o produto 
                            produtosSelecionados.Add(produto);
                        }
                        else
                        {
                            MessageBox.Show("Quantidade insuficiente em estoque.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

                //Configura as colunas do segundo DataGridView
                if (dgvProdutosEscolhidos.Columns.Count == 0)
                {
                    dgvProdutosEscolhidos.AutoGenerateColumns = false;

                    dgvProdutosEscolhidos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id"}); 
                    dgvProdutosEscolhidos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "IdItemVenda", HeaderText = "IdItemVenda"});
                    dgvProdutosEscolhidos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome" });
                    dgvProdutosEscolhidos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Preco", HeaderText = "Preco" });
                    dgvProdutosEscolhidos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Estoque", HeaderText = "Quantidade" });
                    dgvProdutosEscolhidos.Columns.Add(new DataGridViewCheckBoxColumn { DataPropertyName = "Selecionar", HeaderText = "Selecionar" });
                }

                //Atribui a lista de produtos selecionados no datasource que irá receber os valores
                dgvProdutosEscolhidos.DataSource = produtosSelecionados;

                //Invoca o método
                AtualizarValorTotal();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void AtualizarValorTotal()
        {
            //Valor total
            decimal total = 0;
            //Quantidade de itens
            int quantidadeDeItens = 0;

            try
            {
                //passando as linhas 
                foreach (DataGridViewRow somatoriaLinha in dgvProdutosEscolhidos.Rows)
                {
                    //Somatória da quantidade de itens.
                    quantidadeDeItens += Convert.ToInt32(somatoriaLinha.Cells[4].Value);
                    total += Convert.ToDecimal(somatoriaLinha.Cells[3].Value) * Convert.ToInt32(somatoriaLinha.Cells[4].Value);
                }

                //o campo texto recebendo do valor da linha
                txtValorTotal.Text = total.ToString();
                //O campo de valor estará desabilitado.
                txtValorTotal.Enabled = false;
                //Este campo receberá a quantidade de produtos.
                txtQuantidadeItens.Text = quantidadeDeItens.ToString();
                //o campo também ficará desabilitado
                txtQuantidadeItens.Enabled = false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            Gravar();
        }

        private void Gravar()
        {
            //Criando a variável para gravar um registro
            VendaRepository vendaRepository = new VendaRepository();
            Venda venda = new Venda();

            try
            {
                venda.IdCliente = idCliente;
                venda.DataVenda = DateTime.Now;
                venda.ValorTotal = Convert.ToDecimal(txtValorTotal.Text);

                //Criei uma lista para gravar os valores da grid
                List<ItemVenda> itensVenda = new List<ItemVenda>();

                //Adiciona os produtos do datagrid view
                foreach (DataGridViewRow linha in dgvProdutosEscolhidos.Rows)
                {
                    if(Convert.ToBoolean(linha.Cells[5].Value) == true)
                    {
                        //Instanciando a classe ItemVenda para adcionar a lista de Item de Venda
                        ItemVenda itemVenda = new ItemVenda
                        {
                            IdProduto = Convert.ToInt32(linha.Cells[0].Value),
                            IdItemVenda = Convert.ToInt32(linha.Cells[1].Value),
                            Quantidade = Convert.ToInt32(linha.Cells[4].Value)
                        };

                        itensVenda.Add(itemVenda);
                    }
                }

                if (itensVenda.Count > 0)
                {
                    if(idVenda == 0)
                    {
                        idVenda = vendaRepository.RegistrarVenda(venda, itensVenda);
                        MessageBox.Show("Venda Registrada com sucesso!", "De Maria", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        venda.IdVenda = idVenda;
                        //Chamando o método para atualizar a venda
                        vendaRepository.AtualizarVenda(venda, itensVenda);
                        MessageBox.Show("Venda Atualizada com sucesso!", "De Maria", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    LimparCampos();
                }
                else
                {
                    MessageBox.Show("Erro ao registrar venda.", "De Maria", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void btnRetirarProduto_Click(object sender, EventArgs e)
        {
            RetirarProdutoDeVenda();
        }

        private void RetirarProdutoDeVenda()
        {
            int idProduto;

            try
            {
                List<Produto> produtosSelecionados = new List<Produto>();
                List<int> produtosParaRemover = new List<int>();

                foreach (DataGridViewRow linha in dgvProdutosEscolhidos.Rows)
                {
                    //Faz a verificação da linha se o produto está ticado deletado
                    if(Convert.ToBoolean(linha.Cells[3].Value) == true)
                    {
                        //Adiciona o id para a remoção
                        idProduto = Convert.ToInt32(linha.Cells[0].Value);
                        //Remove o produto
                        produtosParaRemover.Add(idProduto);
                    }
                }

                //Remove os produtos da lista
                produtosSelecionados.RemoveAll(produto => produtosParaRemover.Contains(produto.Id));

                //Atualiza o datasource
                dgvProdutosEscolhidos.DataSource = null;
                //dgvProdutosEscolhidos.DataSource = produtosSelecionados;

                //Atualiza os valores
                AtualizarValorTotal();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void LimparCampos()
        {
            idVenda = 0;
            idCliente = 0;
            txtNome.Text = String.Empty;
            txtRua.Text = String.Empty;
            txtNumero.Text = String.Empty;
            txtComplemento.Text = String.Empty;
            txtBairro.Text = String.Empty;
            mskCep.Text = String.Empty;
            mskTelefone.Text = String.Empty;
            dtpDataDeVenda.Value = DateTime.Now;
            txtValorTotal.Text = String.Empty;
            txtQuantidadeItens.Text = String.Empty;
            dgvListaDeProdutos.DataSource = null;
            dgvProdutosEscolhidos.DataSource = null;

            //Os campos precisarão vir desabilitados
            txtNome.Enabled = false;
            txtRua.Enabled = false;
            txtNumero.Enabled = false;
            txtComplemento.Enabled = false;
            txtBairro.Enabled = false;
            mskCep.Enabled = false;
            mskTelefone.Enabled = false;
        }
    }
}
