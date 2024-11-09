using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeMaria.BLL.Contracts;
using DeMaria.DTO;
using DeMaria.DAL;
using Npgsql;
using System.Data;

namespace DeMaria.BLL
{
    public class ClienteRepository : IBaseRepository<Cliente>, IDisposable
    {
        #region Variáveis
        private static DeMaria.DAL.FactoryConnection factoryConnection;

        //Usar no método Dispose
        private IntPtr handle;
        private Component component;
        private bool disposed = false;

        #endregion Variáveis

        #region Construtor
        public ClienteRepository()
        {
            factoryConnection = FactoryConnection.Instancia;
        }
        #endregion Construtor

        public int Deletar(Cliente cliente)
        {
            //int linhasAfetadas = 0;
            string linhaSql = null;

            using (NpgsqlCommand deleteCommand = new NpgsqlCommand())
            {
                try
                {
                    //Comando Sql server para deltar
                    linhaSql = "DELETE FROM Cliente WHERE Id_Cliente = @Id_Cliente";
                    
                    deleteCommand.CommandText = linhaSql;

                    //Variáveis
                    deleteCommand.Parameters.AddWithValue("@Id_Cliente", cliente.Id);

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

        public int Inserir(Cliente cliente)
        {
            int identity = 0;
            string linhaSql = null;

            using (NpgsqlCommand insertCommand = new NpgsqlCommand())
            {
                try
                {
                    linhaSql = "INSERT INTO cliente";
                    linhaSql += "( ";
                    linhaSql += "nome, ";
                    linhaSql += "rua, ";
                    linhaSql += "numero, ";
                    linhaSql += "complemento, ";
                    linhaSql += "bairro, ";
                    linhaSql += "cep, ";
                    linhaSql += "telefone, ";
                    linhaSql += "email ";
                    linhaSql += ") VALUES ";
                    linhaSql += "( ";
                    linhaSql += "@nome, ";
                    linhaSql += "@rua, ";
                    linhaSql += "@numero, ";
                    linhaSql += "@complemento, ";
                    linhaSql += "@bairro, ";
                    linhaSql += "@cep, ";
                    linhaSql += "@telefone, ";
                    linhaSql += "@email ";
                    linhaSql += ") ";
                    linhaSql += "RETURNING id_cliente";

                    insertCommand.CommandText = linhaSql;

                    insertCommand.Parameters.AddWithValue("@nome", cliente.Nome);
                    insertCommand.Parameters.AddWithValue("@rua", cliente.Rua);
                    insertCommand.Parameters.AddWithValue("@numero", cliente.Numero);
                    insertCommand.Parameters.AddWithValue("@complemento", cliente.Complemento);
                    insertCommand.Parameters.AddWithValue("@bairro", cliente.Bairro);
                    insertCommand.Parameters.AddWithValue("@cep", cliente.Cep);
                    insertCommand.Parameters.AddWithValue("@telefone", cliente.Telefone);
                    insertCommand.Parameters.AddWithValue("@email", cliente.Email);

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

        public List<Cliente> Listar()
        {
            string linhaSql = null;

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
                    linhaSql += "ORDER BY id_cliente";

                    selectCommand.CommandText = linhaSql;

                    return factoryConnection.ExecuteQueryList(selectCommand, reader => new Cliente
                    {
                        Id = Convert.ToInt32(reader["Id_Cliente"]),
                        Nome = Convert.ToString(reader["Nome"]),
                        Telefone = Convert.ToString(reader["Telefone"]),
                        Email = Convert.ToString(reader["Email"]),

                        Endereco = new Endereco
                        {
                            Rua = Convert.ToString(reader["Rua"]),
                            Numero = Convert.ToInt32(reader["Numero"]),
                            Complemento = Convert.ToString(reader["Complemento"]),
                            Bairro = Convert.ToString(reader["Bairro"]),
                            Cep = Convert.ToString(reader["Cep"])
                        }
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
        //Obter os valores 
        public Cliente Obter(int id)
        {
            DataSet dsCliente = new DataSet();
            string linhaSql = null;
            DTO.Cliente cliente = null;

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

                    selectCommand.Parameters.Add("@Id_Cliente", NpgsqlTypes.NpgsqlDbType.Integer, 4, "Id_Cliente").Value = id;

                    factoryConnection.ExecuteQuery(selectCommand, dsCliente, "Cliente");

                    if(dsCliente.Tables["Cliente"].Rows.Count > 0)
                    {
                        cliente = new Cliente
                        {
                            Id = Convert.ToInt32(dsCliente.Tables["Cliente"].Rows[0]["Id_Cliente"]),
                            Nome = Convert.ToString(dsCliente.Tables["Cliente"].Rows[0]["Nome"]),
                            Telefone = Convert.ToString(dsCliente.Tables["Cliente"].Rows[0]["Telefone"]),
                            Email = Convert.ToString(dsCliente.Tables["Cliente"].Rows[0]["Email"]),

                            Endereco = new Endereco
                            {
                                Rua = Convert.ToString(dsCliente.Tables["Cliente"].Rows[0]["Rua"]),
                                Numero = Convert.ToInt32(dsCliente.Tables["Cliente"].Rows[0]["Numero"]),
                                Complemento = Convert.ToString(dsCliente.Tables["Cliente"].Rows[0]["Complemento"]),
                                Bairro = Convert.ToString(dsCliente.Tables["Cliente"].Rows[0]["Bairro"]),
                                Cep = Convert.ToString(dsCliente.Tables["Cliente"].Rows[0]["Cep"])
                            }
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
            return cliente;
        }
        //Método para atualizar as informações do cliente
        public int Update(Cliente cliente)
        {
            string linhaSql = String.Empty;
            //int linhasAfetadas = 0;

            using (NpgsqlCommand updateCommand = new NpgsqlCommand())
            {
                try
                {
                    linhaSql = "UPDATE Cliente SET ";
                    linhaSql += "Nome = @Nome, ";
                    linhaSql += "Rua = @Rua, ";
                    linhaSql += "Numero = @Numero, ";
                    linhaSql += "Complemento = @Complemento, ";
                    linhaSql += "Bairro = @Bairro, ";
                    linhaSql += "Cep = @Cep, ";
                    linhaSql += "Telefone = @Telefone, ";
                    linhaSql += "Email = @Email ";
                    linhaSql += "Where Id_Cliente = @Id_Cliente ";

                    updateCommand.CommandText = linhaSql;

                    updateCommand.Parameters.AddWithValue("@Id_Cliente", cliente.Id);
                    updateCommand.Parameters.AddWithValue("@Nome", cliente.Nome);
                    updateCommand.Parameters.AddWithValue("@Rua", cliente.Rua);
                    updateCommand.Parameters.AddWithValue("@Numero", cliente.Numero);
                    updateCommand.Parameters.AddWithValue("@Complemento", cliente.Complemento);
                    updateCommand.Parameters.AddWithValue("@Bairro", cliente.Bairro);
                    updateCommand.Parameters.AddWithValue("@Cep", cliente.Cep);
                    updateCommand.Parameters.AddWithValue("@Telefone", cliente.Telefone);
                    updateCommand.Parameters.AddWithValue("@Email", cliente.Email);
                    //Retorna o número de linhas afetadas
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
            if(this.disposed)
            {
                //Se ok, fecha todos os recursos que não são utilizados
                if(disposing)
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
