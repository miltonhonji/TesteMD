using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeMaria.BLL.Contracts;
using DeMaria.DTO;
using DeMaria.DAL;
using Npgsql;
using System.Data;
using System.ComponentModel;
using NpgsqlTypes;

namespace DeMaria.BLL
{
    public class ProdutoRepository : IBaseRepository<Produto>, IDisposable
    {
        #region Variáveis
        private static DeMaria.DAL.FactoryConnection factoryConnection;

        //Usar no método Dispose
        private IntPtr handle;
        private Component component;
        private bool disposed = false;

        #endregion Variáveis

        #region Main

        public ProdutoRepository()
        {
            factoryConnection = FactoryConnection.Instancia;
        }

        #endregion Main

        public int Deletar(Produto produto)
        {
            string linhaSql = null;

            using(NpgsqlCommand deleteCommand = new NpgsqlCommand())
            {
                try
                {
                    //linha para deletar o produto
                    linhaSql = "DELETE FROM Produto WHERE Id_Produto = @Id_Produto ";

                    deleteCommand.CommandText = linhaSql;

                    //Parmetros para deletar o produto
                    deleteCommand.Parameters.AddWithValue("@Id_Produto", produto.Id);

                    //retorna o valor
                    return factoryConnection.ExecuteUpdate(deleteCommand);

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    deleteCommand.Dispose();
                }
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

        public int Inserir(Produto produto)
        {
            int identity = 0;
            string linhaSql = String.Empty;

            using (NpgsqlCommand insertCommand = new NpgsqlCommand())
            {
                try
                {
                    linhaSql = "INSERT INTO produto ";
                    linhaSql += "( ";
                    linhaSql += "nome, ";
                    linhaSql += "descricao, ";
                    linhaSql += "preco, ";
                    linhaSql += "estoque ";
                    linhaSql += ") VALUES ";
                    linhaSql += "( ";
                    linhaSql += "@nome, ";
                    linhaSql += "@descricao, ";
                    linhaSql += "@preco ,";
                    linhaSql += "@estoque ";
                    linhaSql += " ) ";
                    linhaSql += "RETURNING id_produto ";

                    insertCommand.CommandText = linhaSql;

                    insertCommand.Parameters.AddWithValue("@nome", produto.Nome);
                    insertCommand.Parameters.AddWithValue("@descricao", produto.Descricao);
                    insertCommand.Parameters.AddWithValue("@preco", produto.Preco);
                    insertCommand.Parameters.AddWithValue("@estoque", produto.Estoque);

                    factoryConnection.ExecuteInsert(insertCommand, identity);
                    return identity;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    insertCommand.Dispose();
                }
            }
        }

        public List<Produto> Listar()
        {
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
                    linhaSql += "ORDER BY id_Produto ";

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
                finally
                {
                    selectCommand.Dispose();
                }
            }
        }

        public Produto Obter(int id)
        {
            string linhaSql = null;
            DataSet dsProduto = new DataSet();
            DTO.Produto produto = null;

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
                    selectCommand.Parameters.Add("@Id_Produto", NpgsqlDbType.Integer, 4, "Id_Produto").Value = id;

                    factoryConnection.ExecuteQuery(selectCommand, dsProduto, "Produto");

                    if(dsProduto.Tables["Produto"].Rows.Count > 0)
                    {
                        produto = new Produto
                        {
                            Id = Convert.ToInt32(dsProduto.Tables["Produto"].Rows[0]["Id_Produto"]),
                            Nome = Convert.ToString(dsProduto.Tables["Produto"].Rows[0]["Nome"]),
                            Descricao = Convert.ToString(dsProduto.Tables["Produto"].Rows[0]["Descricao"]),
                            Preco = Convert.ToDecimal(dsProduto.Tables["Produto"].Rows[0]["Preco"]),
                            Estoque = Convert.ToInt32(dsProduto.Tables["Produto"].Rows[0]["Estoque"])
                        };
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    selectCommand.Dispose();
                }
            }
            return produto;
        }

        public int Update(Produto produto)
        {
            //Linha da query sql server
            string linhaSql = null;

            using (NpgsqlCommand updateCommand = new NpgsqlCommand())
            {
                try
                {
                    linhaSql = "UPDATE Produto SET ";
                    linhaSql += "Nome = @Nome, ";
                    linhaSql += "Descricao = @Descricao, ";
                    linhaSql += "Preco = @Preco, ";
                    linhaSql += "Estoque = @Estoque ";
                    linhaSql += "WHERE Id_Produto = @Id_Produto ";

                    updateCommand.CommandText = linhaSql;

                    //Parametros para atualizar as informações do produto
                    updateCommand.Parameters.AddWithValue("@Id_Produto", produto.Id);
                    updateCommand.Parameters.AddWithValue("@Nome", produto.Nome);
                    updateCommand.Parameters.AddWithValue("@Descricao", produto.Descricao);
                    updateCommand.Parameters.AddWithValue("@Preco", produto.Preco);
                    updateCommand.Parameters.AddWithValue("@Estoque", produto.Estoque);

                    return factoryConnection.ExecuteUpdate(updateCommand);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    updateCommand.Dispose();
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
