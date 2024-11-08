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

        public int Deletar(Cliente TEntity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
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
                    linhaSql += "id_cliente, ";
                    linhaSql += "Nome , ";
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
                        Id = Convert.ToInt32(reader["id_cliente"]),
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
            }
        }

        public Cliente Obter(int id)
        {
            throw new NotImplementedException();
        }

        public int Update(Cliente TEntity)
        {
            throw new NotImplementedException();
        }
    }
}
