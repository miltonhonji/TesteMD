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

        //Método para AtualizarVendas
        public int AtualizarVenda(Venda venda, List<ItemVenda> itensDaVenda)
        {
            string linhaSql;
            string linhaSqlItem;
            string linhaSqlInsertIntem;
            //Comandos instanciando a uma lista de comandos Postgre
            var comandos = new List<NpgsqlCommand>();

            try
            {
                using (NpgsqlCommand updateCommand = new NpgsqlCommand())
                {
                    linhaSql = "UPDATE Venda SET ";
                    linhaSql += "Id_Cliente = @Id_Cliente, ";
                    linhaSql += "Data_Venda = @Data_Venda, ";
                    linhaSql += "Valor_Total = @Valor_Total ";
                    linhaSql += "WHERE Id_Venda = @Id_Venda ";

                    updateCommand.CommandText = linhaSql;

                    //Valores e parâmetros
                    updateCommand.Parameters.AddWithValue("@Id_Cliente", venda.IdCliente);
                    updateCommand.Parameters.AddWithValue("@Data_Venda", venda.DataVenda);
                    updateCommand.Parameters.AddWithValue("@Valor_Total", venda.ValorTotal);
                    updateCommand.Parameters.AddWithValue("@Id_Venda", venda.IdVenda);
                    comandos.Add(updateCommand);
                }

                foreach (var item in itensDaVenda)
                {
                    if(item.IdItemVenda > 0)
                    {
                        using (NpgsqlCommand updateCommandItemVenda = new NpgsqlCommand())
                        {
                            linhaSqlItem = "UPDATE ItemVenda SET ";
                            linhaSqlItem += "Id_Venda = @Id_Venda, ";
                            linhaSqlItem += "Id_Produto = @Id_Produto, ";
                            linhaSqlItem += "Quantidade = @Quantidade, ";
                            linhaSqlItem += "WHERE Id_Item_Venda = @Id_Item_Venda ";

                            //CommandText
                            updateCommandItemVenda.CommandText = linhaSqlItem;

                            //Valores e parâmetros
                            updateCommandItemVenda.Parameters.AddWithValue("@Id_Venda", item.IdVenda);
                            updateCommandItemVenda.Parameters.AddWithValue("@Id_Produto", item.IdProduto);
                            updateCommandItemVenda.Parameters.AddWithValue("@Quantidade", item.Quantidade);
                            updateCommandItemVenda.Parameters.AddWithValue("@Id_Item_Venda", item.IdItemVenda);

                            //Comando para adicionar o segundo comando
                            comandos.Add(updateCommandItemVenda);
                        }
                    }
                    else
                    {
                        using (NpgsqlCommand insertCommand = new NpgsqlCommand())
                        {
                            linhaSqlInsertIntem = "INSERT INTO ItemVenda ";
                            linhaSqlInsertIntem += "( ";
                            linhaSqlInsertIntem += "Id_Venda, ";
                            linhaSqlInsertIntem += "Id_Produto, ";
                            linhaSqlInsertIntem += "Quantidade ";
                            linhaSqlInsertIntem += ") VALUES ";
                            linhaSqlInsertIntem += "( ";
                            linhaSqlInsertIntem += "@Id_Venda, ";
                            linhaSqlInsertIntem += "@Id_Produto, ";
                            linhaSqlInsertIntem += "@Quantidade ";
                            linhaSqlInsertIntem += ") ";

                            insertCommand.CommandText = linhaSqlInsertIntem;

                            insertCommand.Parameters.AddWithValue("@Id_Venda", venda.IdVenda);
                            insertCommand.Parameters.AddWithValue("@Id_Produto", item.IdProduto);
                            insertCommand.Parameters.AddWithValue("@Quantidade", item.Quantidade);

                            //comandos para adicionar o produto
                            comandos.Add(insertCommand);
                        }
                    }
                }

                // Chama o método de reuso na camada DAL para executar todos os comandos
                return factoryConnection.ExecuteNonQuery(comandos);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Dispose()
        {
            Dispose(true);
            //Tarefa da fila é finalizado para
            //previnir a finalização do código para este objeto 
            //executando um segundo tempo.
            GC.SuppressFinalize(this);
        }

        public List<Venda> ListarVendas(int idCliente)
        {
            string linhaSql;

            using (NpgsqlCommand selectCommand = new NpgsqlCommand())
            {
                try
                {
                    linhaSql = "SELECT  ";
                    linhaSql += "Id_Venda, ";
                    linhaSql += "Id_Cliente, ";
                    linhaSql += "Data_Venda, ";
                    linhaSql += "Valor_Total ";
                    linhaSql += "FROM Venda ";
                    linhaSql += "WHERE Id_Cliente = @Id_Cliente ";
                    linhaSql += "Order by Id_Venda ";

                    selectCommand.CommandText = linhaSql;

                    selectCommand.Parameters.Add("@Id_Cliente", NpgsqlDbType.Integer, 4, "Id_Cliente").Value = idCliente;

                    return factoryConnection.ExecuteQueryList(selectCommand, reader => new Venda
                    {
                        IdVenda = Convert.ToInt32(reader["Id_Venda"]),
                        IdCliente = Convert.ToInt32(reader["Id_Cliente"]),
                        DataVenda = Convert.ToDateTime(reader["Data_Venda"]),
                        ValorTotal = Convert.ToDecimal(reader["Valor_Total"])
                    });
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        //Obter a venda
        public Venda Obter(int id)
        {
            //Instâncias de DataSet
            DataSet dsVenda = new DataSet();
            //Instâncias de string de conexão
            string linhaSql = null;
            //Instâncias de entidades
            DTO.Venda venda = null;

            using (NpgsqlCommand selectCommand = new NpgsqlCommand())
            {
                try
                {
                    linhaSql = "SELECT  ";
                    linhaSql += "Id_Venda, ";
                    linhaSql += "Id_Cliente, ";
                    linhaSql += "Data_Venda, ";
                    linhaSql += "Valor_Total ";
                    linhaSql += "FROM Venda ";
                    linhaSql += "WHERE Id_Venda = @Id_Venda ";
                    linhaSql += "Order by Id_Venda ";

                    selectCommand.CommandText = linhaSql;

                    selectCommand.Parameters.Add("@Id_Venda", NpgsqlTypes.NpgsqlDbType.Integer, 4, "Id_Venda").Value = id;

                    factoryConnection.ExecuteQuery(selectCommand, dsVenda, "Venda");

                    if(dsVenda.Tables["Venda"].Rows.Count > 0)
                    {
                        venda = new Venda
                        {
                            IdVenda = Convert.ToInt32(dsVenda.Tables["Venda"].Rows[0]["Id_Venda"]),
                            IdCliente = Convert.ToInt32(dsVenda.Tables["Venda"].Rows[0]["Id_Cliente"]),
                            DataVenda = Convert.ToDateTime(dsVenda.Tables["Venda"].Rows[0]["Data_Venda"]),
                            ValorTotal = Convert.ToDecimal(dsVenda.Tables["Venda"].Rows[0]["Valor_Total"])
                        };
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            return venda;
        }

        public List<Produto> ObterListaDeProdutos()
        {
            string linhaSql = null;

            using (NpgsqlCommand selectCommand = new NpgsqlCommand())
            {
                try
                {
                    linhaSql = "SELECT ";
                    linhaSql += "Id_produto, ";
                    linhaSql += "CAST(FALSE AS BOOLEAN) AS 'Selecionar', ";
                    linhaSql += "Nome, ";
                    linhaSql += "Preco, ";
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
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public DataSet ObterItemVenda(int idVenda)
        {
            string linhaSqlServer = null;
            DataSet dsItemVenda = new DataSet();

            try
            {
                using (NpgsqlCommand selectCommand = new NpgsqlCommand())
                {
                    linhaSqlServer = "SELECT ";
                    linhaSqlServer += "itv.Id_Produto AS id_Produto, ";
                    linhaSqlServer += "prd.Nome, ";
                    linhaSqlServer += "itv.Quantidade AS Estoque, ";
                    linhaSqlServer += "CAST(FALSE AS BOOLEAN) AS Selecionar ";
                    linhaSqlServer += "FROM itemvenda itv ";
                    linhaSqlServer += "INNER JOIN Produto prd ON itv.Id_Produto = prd.Id_Produto ";
                    linhaSqlServer += "WHERE itv.Id_Venda = @Id_Venda ";


                    selectCommand.CommandText = linhaSqlServer;
                    //Id_Venda como parâmetros
                    selectCommand.Parameters.Add("@Id_Venda", NpgsqlDbType.Integer, 4, "Id_Venda").Value = idVenda;

                    factoryConnection.ExecuteQuery(selectCommand, dsItemVenda, "ItemVenda");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return dsItemVenda;
        }

        public int RegistrarVenda(Venda venda, List<ItemVenda> itensVenda)
        {
            string linhaSql;
            string linhaSqlChild;
            int idVenda = 0; 
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
                    linhaSql += ") VALUES ";
                    linhaSql += "( ";
                    linhaSql += "@Id_Cliente, ";
                    linhaSql += "@Data_Venda, ";
                    linhaSql += "@Valor_Total ";
                    linhaSql += ") RETURNING Id_Venda ";

                    insertCommand.CommandText = linhaSql;

                    insertCommand.Parameters.AddWithValue("@Id_Cliente", venda.IdCliente);
                    insertCommand.Parameters.AddWithValue("@Data_Venda", DateTime.Now);
                    insertCommand.Parameters.AddWithValue("@Valor_Total", venda.ValorTotal);

                    idVenda = Convert.ToInt32(factoryConnection.ExecuteScalar(insertCommand));

                    linhaSqlChild = "INSERT INTO ItemVenda ";
                    linhaSqlChild += "( ";
                    linhaSqlChild += "Id_Venda, ";
                    linhaSqlChild += "Id_Produto, ";
                    linhaSqlChild += "Quantidade ";
                    linhaSqlChild += ") VALUES ";
                    linhaSqlChild += "( ";
                    linhaSqlChild += "@Id_Venda, ";
                    linhaSqlChild += "@Id_Produto, ";
                    linhaSqlChild += "@Quantidade ";
                    linhaSqlChild += ") ";


                    foreach (var item in itensVenda)
                    {
                        using (NpgsqlCommand insertItemCommand = new NpgsqlCommand())
                        {
                            insertItemCommand.CommandText = linhaSqlChild;

                            insertItemCommand.Parameters.AddWithValue("@Id_Venda", idVenda);
                            insertItemCommand.Parameters.AddWithValue("@Id_Produto", item.IdProduto);
                            insertItemCommand.Parameters.AddWithValue("@Quantidade", item.Quantidade);

                            linhasAfetadas += factoryConnection.ExecuteNonQuery(insertItemCommand);
                        }
                    }
                    return idVenda;

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            //Checa se o dispose já foi chamado
            if (this.disposed)
            {
                //Se ok, fecha todos os recursos que não são utilizados
                if (disposing)
                {
                    //Liberando recursos gerenciados
                    if (component != null)
                        component.Dispose();

                    //Lança os recursos não gerenciáveis. Se o descarte é falso,
                    //apenas o seguinte código é executado
                    handle = IntPtr.Zero;
                }
                disposed = true;
            }
        }
    }
}
