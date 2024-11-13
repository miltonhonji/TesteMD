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
        private int idCliente;
        //Variável para ápresentar erros na hora carregar o grid no combobox.
        private bool feito = false;

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
            feito = true;
            CarregarListaDeVendas(Convert.ToInt32(cboCliente.SelectedValue.ToString()));
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

        private void CarregarListaDeVendas(int idCliente)
        {
            //Instanciar as classes do VendaRepository e a DTO.Venda
            VendaRepository vendaRepository = new VendaRepository();

            try
            {
                //Lista de cliente, aonde os dados serão obtidos pela lista da classe VendaRepository
                List<Venda> listaDeVendas = vendaRepository.ListarVendas(idCliente);

                //Gerar as colunas manualmente
                dgvListaDeVendas.AutoGenerateColumns = false;

                //Após isso, limpar a grid, para receber os campos referentes as vendas
                dgvListaDeVendas.Columns.Clear();

                //Os nomes das colunas no datagridView
                dgvListaDeVendas.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "IdVenda", HeaderText = "Id_Venda", Visible=false });
                dgvListaDeVendas.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "IdCliente", HeaderText = "Id Cliente", Visible = false });
                dgvListaDeVendas.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "DataVenda", HeaderText = "Data Venda" });
                dgvListaDeVendas.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ValorTotal", HeaderText = "Valor Total" });

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

        private void cboCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(feito)
                CarregarListaDeVendas(Convert.ToInt32(cboCliente.SelectedValue.ToString()));
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            dgvListaDeVendas_CellClick(null, null);
        }

        private void dgvListaDeVendas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmMenu menuPrincipal = (frmMenu)Application.OpenForms["frmMenu"];

            try
            {
                //Escolhe o cliente na posição atual
                var linhaSelecionada = dgvListaDeVendas.CurrentRow;

                //idcliente recebe o valor da linha
                idVenda = Convert.ToInt32(linhaSelecionada.Cells[0].Value);
                idCliente = Convert.ToInt32(linhaSelecionada.Cells[1].Value);

                if (menuPrincipal != null)
                    menuPrincipal.AbrirFormulario(new frmVendaDeProdutos(idVenda, idCliente));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
