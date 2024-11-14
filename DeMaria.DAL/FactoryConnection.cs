using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Npgsql;
using NpgsqlTypes;

namespace DeMaria.DAL
{
    public class FactoryConnection
    {

        #region Variáveis
        //Criando variáveis estáticas de servidor para Postagree
        private static FactoryConnection instancia = null;
        private static NpgsqlConnection conexao;

        #endregion Variáveis

        #region Propriedades
        public static string Server { get; set; }
        public static string Database { get; set; }
        public static string User { get; set; }
        public static string Password { get; set; }
        public static int Port { get; set; }

        private static string ConnectionString
        {
            get
            {
                return $"host={Server}; port={Port};Database={Database};Username={User};Password={Password}";
            }
        }

        #endregion Propriedades

        #region Main

        FactoryConnection()
        {
            if(System.Net.Dns.GetHostName().Equals("DESKTOP-IQ178NE"))
            {
                Server = "localhost";
                Port = 5432;
                Database = "demariadb";
                User = "postgres";
                Password = "admin";
            }
        }

        //Propriedade estática para a instancia
        //GET: Propriedades públicas get ou métodos de acesso garantem que outras classes
        //ou programas acessem o valor dos atribuitos da classe.
        public static FactoryConnection Instancia
        {
            get
            {
                //Se a instância for igual a nula, a instância receberá, a instância do constutor FactoryConnection()
                if (instancia == null)
                {
                    instancia = new FactoryConnection();
                }
                return instancia;
            }
        }
        #endregion Main

        #region Métodos para reuso

        //Métodos para Insert
        public void ExecuteInsert(NpgsqlCommand npgSqlCommand, int returnIdentity)
        {
            //Abrindo o banco de dados
            AbrirBancoDeDados();
            using (npgSqlCommand.Connection = conexao)
            {
                try
                {
                    //retorna o valor para identiy
                    returnIdentity = Convert.ToInt32(npgSqlCommand.ExecuteScalar());
                }
                catch (NpgsqlException nsql)
                {
                    //Tratamentos de erros para sql server
                    throw new Exception(nsql.Message);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    //Invoca o método para fechar o banco de dados
                    FecharBancoDeDados();
                    //Fechando o banco de dados SqlCommand
                    npgSqlCommand.Dispose();
                }
            }
        }

        public int ExecuteScalar(NpgsqlCommand sqlCommand)
        {
            AbrirBancoDeDados();

            using (sqlCommand.Connection = conexao)
            {
                try
                {
                    return Convert.ToInt32(sqlCommand.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao executar o comando SQL", ex);
                }
                finally
                {
                    FecharBancoDeDados();
                }
            }
        }

        /// <summary>
        /// Método para executar comandos SQL que não retornam dados (como INSERT, UPDATE, DELETE).
        /// </summary>
        /// <param name="command">Comando SQL a ser executado.</param>
        /// <returns>O número de linhas afetadas pela execução do comando.</returns>
        public int ExecuteNonQuery(NpgsqlCommand command)
        {
            // Inicializa o número de linhas afetadas
            int rowsAffected = 0;

            // Abrindo a conexão
            AbrirBancoDeDados();

            using (command.Connection = conexao)
            {
                // Inicia a transação
                command.Transaction = conexao.BeginTransaction();

                try
                {
                    // Executa o comando e obtém o número de linhas afetadas
                    rowsAffected = command.ExecuteNonQuery();

                    // Efetiva a execução da transação
                    command.Transaction.Commit();
                }
                catch (Exception ex)
                {
                    try
                    {
                        // Desfaz os comandos em caso de erro
                        command.Transaction.Rollback("SampleTransaction");
                    }
                    catch (NpgsqlException nsql)
                    {
                        if (command.Connection != null)
                        {
                            throw new Exception("An exception of type " + nsql.GetType() +
                                " was encountered while attempting to roll back the transaction.");
                        }
                    }
                    throw new Exception(ex.Message);
                }
                finally
                {
                    // Libera os recursos do comando
                    command.Dispose();
                    // Fecha a conexão
                    FecharBancoDeDados();
                }
            }

            return rowsAffected;
        }

        /// <summary>
        /// Método para executar múltiplos comandos
        /// </summary>
        /// <param name="sqlCommand"></param>
        /// <param name="returnDataSet"></param>
        /// <param name="nameTableDataSet"></param>
       public int ExecuteNonQuery(List<NpgsqlCommand> commands)
        {
            //Aqui iremos colocar o total de linha afetadas
            int affectedRows = 0;
            //Abrir o banco de dados
            AbrirBancoDeDados();

            //Inicia transação
            using (var transaction = conexao.BeginTransaction())
            {
                try
                {
                    //Laço for para cada comando da lista
                    foreach(var command in commands)
                    {
                        //Cada comando receberá a conexão
                        command.Connection = conexao;
                        command.Transaction = transaction;

                        //Total de linhas afetadas e soma quantidade de linhas afetadas
                        affectedRows += command.ExecuteNonQuery();
                    }
                    //Efetiva a tranação 
                    transaction.Commit();

                }
                catch (Exception ex)
                {
                    try
                    {
                        //Desfaz os comandos caso aconteça erros
                        transaction.Rollback();
                    }
                    catch (NpgsqlException nsql)
                    {
                        throw new Exception(nsql.Message);
                    }
                }
                finally
                {
                    //Libera os comandos
                    foreach (var command in commands)
                    {
                        command.Dispose();
                    }
                    //Fecha do banco de dados
                    FecharBancoDeDados();
                }
            }

            //Retorna as linhas afetadas
            return affectedRows;
        }

        //Métodos para Obter os valores
        public void ExecuteQuery(NpgsqlCommand sqlCommand, DataSet returnDataSet, string nameTableDataSet)
        {
            //Abrindo a conexão
            AbrirBancoDeDados();
            //using para a connectionString e o para o dataAdapter
            using (sqlCommand.Connection = conexao)
            {
                using (NpgsqlDataAdapter sqlDataAdapter = new NpgsqlDataAdapter(sqlCommand))
                {
                    try
                    {
                        //Adiciona ou atualiza a linha do Dataset
                        sqlDataAdapter.Fill(returnDataSet, nameTableDataSet);
                    }
                    catch(NpgsqlException nsql)
                    {
                        throw new Exception(nsql.Message);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        FecharBancoDeDados();
                    }
                }
            }
        }

        //Método para gerar uma lista
        public List<T> ExecuteQueryList<T>(NpgsqlCommand sqlCommand, Func<NpgsqlDataReader, T> mapFunction)
        {
            //Abrindo o banco de dados
            AbrirBancoDeDados();
            NpgsqlDataReader dataReader;

            List<T> list = new List<T>();
            //using para a connectionString e o para o dataAdapter
            using (sqlCommand.Connection = conexao)
            {
                using (dataReader = sqlCommand.ExecuteReader())
                {
                    try
                    {
                        //Enquanto é ido o datareader
                        while(dataReader.Read())
                        {
                            T item = mapFunction(dataReader);
                            list.Add(item);
                        }
                        //fecha o datareader
                        dataReader.Close();
                    }
                    catch (NpgsqlException nsql)
                    {
                        throw new Exception(nsql.Message);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        FecharBancoDeDados();
                    }
                    //Retorna a lista
                    return list;
                }
            }
        }

        //Método para o uso do Update, que retornará o número de linhas afetadas
        public int ExecuteUpdate(NpgsqlCommand sqlCommand)
        {
            int returnAffectedRows = 0;
            //Abrindo a conexão
            AbrirBancoDeDados();
            //using para a connectionString e o para o dataAdapter
            using (sqlCommand.Connection = conexao)
            {
                try
                {
                    //Executa o comando do Postgresql
                    returnAffectedRows = sqlCommand.ExecuteNonQuery();
                    //retorna a linha afetada
                    return returnAffectedRows;
                }
                catch(NpgsqlException nsql)
                {
                    throw new Exception(nsql.Message);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    FecharBancoDeDados();
                    sqlCommand.Dispose();
                }
            }
        }

        #endregion Métodos para reuso

        #region Abre e fecha a conexão

        public static void AbrirBancoDeDados()
        {
            //conexao receberá a conectionString
            conexao = new NpgsqlConnection(ConnectionString);

            try
            {
                //Abrindo a conexão
                conexao.Open();
            }
            catch(NpgsqlException nsql)
            {
                throw new Exception(nsql.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Fecha a conexão
        private static void FecharBancoDeDados()
        {
            if (conexao.State == ConnectionState.Open)
                conexao.Close();
        }

        #endregion Abre e fecha a conexão 
    }
}
