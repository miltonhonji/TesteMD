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

        }

        public frmCadastroDeCliente(int clienteId)
        {
            InitializeComponent();
            idCliente = clienteId;
            ObterDados();
        }

        private void ObterDados()
        {
            //Instâncias das classes de cliente e dto.cliente
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
                    txtEmail.Text = cliente.Email;
                }
                else
                {
                    CadastrarNovo();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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
                    CadastrarNovo();
                }
                else
                {
                    //se o idCliente for maior que 0.
                    if (clienteRepository.Update(cliente) > 0)
                    {
                        MessageBox.Show("Cliente alterado com sucesso", "De Maria", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        CadastrarNovo();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
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

        private void btnGerarRelatorio_Click(object sender, EventArgs e)
        {
            GerarRelatorioCliente();
        }

        private void GerarRelatorioCliente()
        {
            //Verifica se o Id do Cliente foi definido
            if(idCliente > 0)
            {
                frmRelatorio relatorioCliente = new frmRelatorio(idCliente);
                relatorioCliente.ShowDialog();
            }
            else
            {
                MessageBox.Show("Não foi salvo o cliente antes de gerar um relatório", "De Maria", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
