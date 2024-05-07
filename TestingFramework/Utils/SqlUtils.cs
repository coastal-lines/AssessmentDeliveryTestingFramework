using TestingFramework.Core.Logging;
using System.Data.SqlClient;

namespace TestingFramework.Utils
{
    public class SqlUtils
    {
        private SqlCommand command;

        public string GetConnectionData(string dataSource, string initialCatalog, string userId, string password)
        {
            return $"Data Source={dataSource}; " +
                               $"Initial Catalog={initialCatalog}; " +
                               $"User ID={userId}; " +
                               $"Password={password}; " +
                               "Integrated Security=false;";
        }

        public SqlConnection OpenDBConnect(string dataSource, string initialCatalog, string userId, string password)
        {
            var connectionData = GetConnectionData(dataSource, initialCatalog, userId, password);

            using (SqlConnection connection = new SqlConnection(connectionData))
            {
                try
                {
                    connection.Open();

                    return connection;
                }
                catch (Exception ex)
                {
                    Logger.LogError($"Error DB connection for '{dataSource}'", ex);
                    throw;
                }
            }
        }

        public SqlDataReader RunScript(SqlConnection connection, string sqlScript)
        {
            try
            {
                command = new SqlCommand(sqlScript, connection);
            }

            catch (Exception ex)
            {
                Logger.LogError(ex.Message, ex);
                connection.Close();
            }

            var reader = command.ExecuteReader();
            return reader;
        }
    }
}
