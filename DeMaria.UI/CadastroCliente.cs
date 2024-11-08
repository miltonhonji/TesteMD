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

                dgvListaDeClientes.DataSource = listaDeClientes;
                //dgvListaDeClientes.Columns.Clear();

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

        private void dgvListaDeClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
