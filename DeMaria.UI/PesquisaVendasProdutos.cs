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
    public partial class frmPesquisaVendasProdutos : Form
    {
        #region Variáveis

        private int idPesquisa;
        private int idVenda;

        #endregion Variáveis

        #region Properiedades

        public int IdPesquisa
        {
            get { return idPesquisa; }
            set { idPesquisa = value; }
        }

        #endregion Propriedades

        public frmPesquisaVendasProdutos()
        {
            InitializeComponent();
        }

        private void frmPesquisaVendasProdutos_Load(object sender, EventArgs e)
        {
            CarregarComboBox();
        }

        //Carregar a Lista Suspensa para escolher o cliente
        private void CarregarComboBox()
        {
            //Instanciando as classes BLL.ClienteRepository
            ClienteRepository clienteRepository = new ClienteRepository();

            //Lista de cliente, aonde os dados serão obtidos pela lista da classe ClienteRepository
            List<Cliente> listaDeClientes = clienteRepository.Listar();

            //Preenchendo o datasource
            cboCliente.DataSource = listaDeClientes;
            //O valor irá mostrar o nome do cliente
            cboCliente.DisplayMember = "Nome";
            cboCliente.ValueMember = "Id";

        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            CadastrarNovaVenda();
        }

        private void CadastrarNovaVenda()
        {
            //Verificar se o cliente foi selecionado no combobox
            if(cboCliente.SelectedItem != null)
            {
                //caso tenha um cliente selecionado no combobox
                int clienteId = (int)cboCliente.SelectedValue;

                //Fechando a janela de Lista
                this.Close();
                //Abrindo outra tela de Cadastro de Clientes vázia
                frmMenu menuPrincipal = (frmMenu)Application.OpenForms["frmMenu"];

                if (menuPrincipal != null)
                    menuPrincipal.AbrirFormulario(new frmVendaDeProdutos(idVenda, clienteId));
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
