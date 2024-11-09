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
    public partial class frmCadastroDeCliente : Form
    {
        #region Variáveis
        private int idCliente;
        #endregion Variáveis

        public frmCadastroDeCliente()
        {
            InitializeComponent();
        }

        private void frmCadastroDeCliente_Load(object sender, EventArgs e)
        {
            CarregarClienteParaODataGridView();
        }

        private void CarregarClienteParaODataGridView()
        {
            ClienteRepository clienteRepository = new ClienteRepository();

            try
            {
                List<Cliente> listaDeClientes = clienteRepository.Listar();

                dgvListaDeClientes.AutoGenerateColumns = false;
                //Populando os clientes na datagridview.
                dgvListaDeClientes.Columns.Clear();

                dgvListaDeClientes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id", Visible = false });
                dgvListaDeClientes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome" });
                dgvListaDeClientes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Rua", HeaderText = "Rua" });
                dgvListaDeClientes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Numero", HeaderText = "Número" });
                dgvListaDeClientes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Complemento", HeaderText = "Complemento" });
                dgvListaDeClientes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Bairro", HeaderText = "Bairro" });
                dgvListaDeClientes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Cep", HeaderText = "Cep" });
                dgvListaDeClientes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Telefone", HeaderText = "Telefone" });
                dgvListaDeClientes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Email", HeaderText = "Email" });

                dgvListaDeClientes.DataSource = listaDeClientes;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            Deletar();
        }

        private void Deletar()
        {
            ClienteRepository clienteRepository = new ClienteRepository();
            Cliente cliente = new Cliente();

            cliente.Id = idCliente;

            try
            {
                if (cliente.Id.Equals(0))
                {
                    MessageBox.Show("É necessário ter um cliente escolhido", "De Maria", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    if (MessageBox.Show($"Deseja excluir este cliente: { cliente.Nome } ?", "De Maria", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (clienteRepository.Deletar(cliente) > 0)
                        {
                            MessageBox.Show("Cliente excluído com sucesso", "De Maria", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CadastrarNovo();
                        }
                        else
                        {
                            MessageBox.Show("Não foi possível excluir este cliente", "De Maria", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível excluir este cliente", "De Maria", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                clienteRepository.Dispose();
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            Gravar();
        }

        private void Gravar()
        {
            Cliente cliente = new Cliente();
            ClienteRepository clienteRepository = new ClienteRepository();

            try
            {
                //Invoca o método Obter para verificar se existe um idCliente
                clienteRepository.Obter(idCliente);

                cliente.Id = idCliente;
                cliente.Nome = txtNome.Text;

                cliente.Endereco = new Endereco
                {
                    Rua = txtRua.Text,
                    Numero = Convert.ToInt32(txtNumero.Text),
                    Complemento = txtComplemento.Text,
                    Bairro = txtBairro.Text,
                    Cep = mskCep.Text
                };

                cliente.Telefone = mskTelefone.Text;
                cliente.Email = txtEmail.Text;

                //Se o cliente é igual a 0
                if (idCliente == 0)
                {
                    idCliente = clienteRepository.Inserir(cliente);
                    MessageBox.Show("Cliente salvo com sucesso", "De Maria", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    //se o idCliente for maior que 0.
                    if (clienteRepository.Update(cliente) > 0)
                    {
                        MessageBox.Show("Cliente alterado com sucesso", "De Maria", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void dgvListaDeClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Pegar o valor da linha selecionada
            var Row = dgvListaDeClientes.CurrentRow;
            //idCliente recebendo o valor da linha que será populado na lista do datagrid
            //Lembrando que o idCliente (primeira coluna, está oculta)
            idCliente = Convert.ToInt32(Row.Cells[0].Value);

            //Após escolher um cliente da lista, quando clicamos em cima do nome, as informações, iráo popular para os campos acima            
            //Lembrando que está seguindo a ordem do grid.
            txtNome.Text = Row.Cells[1].Value.ToString();
            txtRua.Text = Row.Cells[2].Value.ToString();
            txtNumero.Text = Convert.ToInt32(Row.Cells[3].Value).ToString();
            txtComplemento.Text = Row.Cells[4].Value.ToString();
            txtBairro.Text = Row.Cells[5].Value.ToString();
            mskCep.Text = Row.Cells[6].Value.ToString();
            mskTelefone.Text = Row.Cells[7].Value.ToString();
            txtEmail.Text = Row.Cells[8].Value.ToString();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            CadastrarNovo();
        }

        private void CadastrarNovo()
        {
            idCliente = 0;
            txtNome.Text = String.Empty;
            txtRua.Text = String.Empty;
            txtNumero.Text = String.Empty;
            txtComplemento.Text = String.Empty;
            txtBairro.Text = String.Empty;
            mskCep.Text = "00000-000";
            mskTelefone.Text = "(00) 00000-0000";
            txtEmail.Text = String.Empty;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
