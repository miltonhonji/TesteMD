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
            CarregarListaDeVendas();
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

        private void CarregarListaDeVendas()
        {
            //Instanciar as classes do VendaRepository e a DTO.Venda
            VendaRepository vendaRepository = new VendaRepository();
            Venda venda = new Venda();

            try
            {
                //Lista de cliente, aonde os dados serão obtidos pela lista da classe VendaRepository
                List<Venda> listaDeVendas = vendaRepository.ListarVendas();

                //Gerar as colunas manualmente
                dgvListaDeVendas.AutoGenerateColumns = false;

                //Após isso, limpar a grid, para receber os campos referentes as vendas
                dgvListaDeVendas.Columns.Clear();

                //Os nomes das colunas no datagridView
                dgvListaDeVendas.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Id_Venda", HeaderText = "Id_Venda", Visible = false });
                dgvListaDeVendas.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Id_Cliente", HeaderText = "Id_Cliente", Visible = false });
                dgvListaDeVendas.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Data_Venda", HeaderText = "Data_Venda" });
                dgvListaDeVendas.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Valor_Total", HeaderText = "Valor_Total" });

                dgvListaDeVendas.DataSource = listaDeVendas;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
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
