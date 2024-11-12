using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using NpgsqlTypes;
using System.Data;
using DeMaria.BLL.Contracts;
using DeMaria.DAL;
using DeMaria.DTO;

namespace DeMaria.BLL
{
    public class VendaRepository : IDisposable
    {
        #region Variáveis
        private static DeMaria.DAL.FactoryConnection factoryConnection;

        //Usar no método Dispose
        private IntPtr handle;
        private Component component;
        private bool disposed = false;

        #endregion Variáveis

        public VendaRepository()
        {
            factoryConnection = FactoryConnection.Instancia;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public List<Produto> ObterListaDeProdutos()
        {
            string linhaSql = null;

            using (NpgsqlCommand selectCommand = new NpgsqlCommand())
            {
                linhaSql = "SELECT ";
                linhaSql += "id_produto, ";
                linhaSql += "CAST(FALSE AS BOOLEAN) AS 'Selecionar', ";
                linhaSql += "nome, ";
                linhaSql += "preco, ";
                linhaSql += "Estoque ";
                linhaSql += "FROM produto ";
                linhaSql += "ORDER BY Id_Produto ";

                selectCommand.CommandText = linhaSql;

                return factoryConnection.ExecuteQueryList(selectCommand, reader => new Produto
                {
                    Id = Convert.ToInt32(reader["Id_Produto"]),
                    Nome = Convert.ToString(reader["Nome"]),
                    Descricao = Convert.ToString(reader["Descricao"]),
                    Preco = Convert.ToDecimal(reader["Preco"]),
                    Estoque = Convert.ToInt32(reader["Estoque"])
                });

            }
        }

        public int RegistrarVenda(Venda venda, List<ItemVenda> itensVenda)
        {
            string linhaSql;
            string linhaSqlChild;
            int linhasAfetadas = 0;

            using (NpgsqlCommand insertCommand = new NpgsqlCommand())
            {

                try
                {
                    linhaSql = "INSERT INTO Venda ";
                    linhaSql += "( ";
                    linhaSql += "Id_Cliente, ";
                    linhaSql += "Data_Venda, ";
                    linhaSql += "Valor_Total ";
                    linhaSql += ")VALUES ";
                    linhaSql += "( ";
                    linhaSql += "@Id_Cliente, ";
                    linhaSql += "@Data_Venda, ";
                    linhaSql += "@Valor_Total ";
                    linhaSql += ") RETURNING Id_Venda ";

                    linhaSqlChild = "INSERT INTO ItemVenda ";
                    linhaSqlChild += "( ";
                    linhaSqlChild += "Id_Venda, ";
                    linhaSqlChild += "Id_Produto, ";
                    linhaSqlChild += "Quantidade ";
                    linhaSqlChild += ")VALUES ";
                    linhaSqlChild += "( ";
                    linhaSqlChild += "@ReturnId, ";
                    linhaSqlChild += "@Id_Produto, ";
                    linhaSqlChild += "@Quantidade ";
                    linhaSqlChild += ") ";

                    insertCommand.CommandText = linhaSql;

                    insertCommand.Parameters.AddWithValue("@Id_Cliente", venda.IdCliente);
                    insertCommand.Parameters.AddWithValue("@Data_Venda", DateTime.Now);
                    insertCommand.Parameters.AddWithValue("@Valor_Total", venda.ValorTotal);

                    foreach (var item in itensVenda)
                    {
                        //insertCommand.Parameters.AddWithValue("@Id_Venda", item.IdVenda);
                        insertCommand.Parameters.AddWithValue("@Id_Produto", item.IdProduto);
                        insertCommand.Parameters.AddWithValue("@Quantidade", item.Quantidade);
                    }

                    factoryConnection.ExecuteNested(insertCommand, linhaSqlChild, linhasAfetadas);

                    return linhasAfetadas;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
