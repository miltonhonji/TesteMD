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

                dgvListaDeClientes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Id_Cliente", HeaderText = "Id", Visible = false });
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

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            Adicionar();
        }

        private void Adicionar()
        {
            Cliente cliente = new Cliente();
            ClienteRepository clienteRepository = new ClienteRepository();

            try
            {
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

                if(idCliente == 0)
                {
                    idCliente = clienteRepository.Inserir(cliente);
                    MessageBox.Show("Cliente salvo com sucesso", "De Maria", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                throw;
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

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            dgvListaDeClientes_CellClick(null, null);
        }
    }
}
