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

        public frmVendaDeProdutos()
        {

        }
        public frmVendaDeProdutos(int clienteId)
        {
            InitializeComponent();
            idCliente = clienteId;
            CarregaCliente();
        }

        //Fazer um método para carregar os nomes dos clientes
        private void CarregaCliente()
        {
            //Primeiro iremos instanciar as classes e as DTOS do cliente para mostrar nos campos abaixo
            ClienteRepository clienteRepository = new ClienteRepository();
            Cliente cliente = clienteRepository.Obter(idCliente);

            try
            {
                if(cliente != null)
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
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
