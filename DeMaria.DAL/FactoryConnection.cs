using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Npgsql;

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

        //Método para o uso do Update
        public void ExecuteUpdate(NpgsqlCommand sqlCommand, int returnAffectedRows)
        {
            //Abrindo a conexão
            AbrirBancoDeDados();
            //using para a connectionString e o para o dataAdapter
            using (sqlCommand.Connection = conexao)
            {
                try
                {
                    returnAffectedRows = Convert.ToInt32(sqlCommand.ExecuteNonQuery());
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
