using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using NpgsqlTypes;
using DeMaria.DAL;
using DeMaria.DTO;
using System.ComponentModel;

namespace DeMaria.BLL
{
    public class RelatorioRepository
    {
        #region Variáveis
        private static DeMaria.DAL.FactoryConnection factoryConnection;

        //Usar no método Dispose
        private IntPtr handle;
        private Component component;
        private bool disposed = false;

        #endregion Variáveis

        #region Main

        public RelatorioRepository()
        {
            factoryConnection = FactoryConnection.Instancia;
        }
        #endregion Main

        public DataSet GerarRelatorioDoCliente(int idCliente)
        {
            DataSet dsCliente = new DataSet();
            string linhaSql;

            using (NpgsqlCommand selectCommand = new NpgsqlCommand())
            {
                try
                {
                    linhaSql = "SELECT ";
                    linhaSql += "Id_Cliente, ";
                    linhaSql += "Nome, ";
                    linhaSql += "Rua,";
                    linhaSql += "Numero, ";
                    linhaSql += "Complemento, ";
                    linhaSql += "Bairro, ";
                    linhaSql += "Cep, ";
                    linhaSql += "Telefone, ";
                    linhaSql += "Email  ";
                    linhaSql += "FROM Cliente ";
                    linhaSql += "WHERE Id_cliente = @Id_Cliente ";

                    selectCommand.CommandText = linhaSql;

                    selectCommand.Parameters.AddWithValue("@Id_Cliente", NpgsqlDbType.Integer, 4).Value = idCliente;

                    factoryConnection.ExecuteQuery(selectCommand, dsCliente, "Cliente");

                    return dsCliente;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public DataSet GerarRelatorioDoProduto(int idProduto)
        {
            DataSet dsProduto = new DataSet();
            string linhaSql = null;
            using (NpgsqlCommand selectCommand = new NpgsqlCommand())
            {
                try
                {
                    linhaSql = "SELECT ";
                    linhaSql += "Id_Produto,";
                    linhaSql += "Nome, ";
                    linhaSql += "Descricao, ";
                    linhaSql += "Preco, ";
                    linhaSql += "Estoque ";
                    linhaSql += "FROM Produto ";
                    linhaSql += "WHERE Id_Produto = @Id_Produto ";

                    selectCommand.CommandText = linhaSql;
                    selectCommand.Parameters.Add("@Id_Produto", NpgsqlDbType.Integer, 4, "Id_Produto").Value = idProduto;

                    factoryConnection.ExecuteQuery(selectCommand, dsProduto, "Produto");

                    return dsProduto;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

    }
}
