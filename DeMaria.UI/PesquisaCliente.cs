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
    public partial class frmPesquisaCliente : Form
    {
        #region Variáveis

        private int idPesquisa;
        private int idCliente;

        #endregion Variáveis

        #region Properiedades

        public int IdPesquisa
        {
            get { return idPesquisa; }
            set { idPesquisa = value; }
        }

        public int IdCliente
        {
            get { return idCliente; }
            set { idCliente = value; }
        }

        #endregion Propriedades

        public frmPesquisaCliente()
        {
            InitializeComponent();
        }

        private void frmPesquisaCliente_Load(object sender, EventArgs e)
        {
            CarregarLista();
        }

        private void CarregarLista()
        {
            //Instanciar as classes do repositório do BLLcliente e do DTO.Cliente.
            ClienteRepository clienteRepository = new ClienteRepository();
            Cliente cliente = new Cliente();

            try
            {
                //Lista de clientes para puxar os valores para o datagridview
                List<Cliente> listaDeClientes = clienteRepository.Listar();

                //O sistema irá gerar a coluna sem ser automático.
                dgvListaClientes.AutoGenerateColumns = false;

                //Após isso, a lista irá vir vázia
                dgvListaClientes.Columns.Clear();

                //Abaixo aqui, serão os campos que irão ter os nomes das colunas
                dgvListaClientes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id", Visible = false });
                dgvListaClientes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome" });
                dgvListaClientes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Rua", HeaderText = "Rua" });
                dgvListaClientes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Numero", HeaderText = "Numero" });
                dgvListaClientes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Complemento", HeaderText = "Complemento" });
                dgvListaClientes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Bairro", HeaderText = "Bairro" });
                dgvListaClientes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Cep", HeaderText = "Cep" });
                dgvListaClientes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Telefone", HeaderText = "Telefone" });
                dgvListaClientes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Email", HeaderText = "Email" });

                //Itens da lista que serão adicionados no DataSource
                dgvListaClientes.DataSource = listaDeClientes;
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

        private void dgvListaClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Acessando a tela de Menu
            frmMenu menuPrincipal = (frmMenu)Application.OpenForms["frmMenu"];

            try
            {
                //Escolhe o cliente na posição atual
                var linhaSelecionada = dgvListaClientes.CurrentRow;

                //idcliente recebe o valor da linha
                idCliente = Convert.ToInt32(linhaSelecionada.Cells[0].Value);

                if (menuPrincipal != null)
                    menuPrincipal.AbrirFormulario(new frmCadastroDeCliente(idCliente));
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
                menuPrincipal.AbrirFormulario(new frmCadastroDeCliente(idCliente));

        }
    }
}
