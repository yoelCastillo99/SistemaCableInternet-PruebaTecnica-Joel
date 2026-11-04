using Microsoft.Data.SqlClient;

namespace SistemaCableInternet.DAL.Connections
{
    public class DatabaseConnection
    {
        private readonly string _connectionString;

        public DatabaseConnection(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<string> ProbarConexionAsync()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    return $"Conexión exitosa. Base de datos: {connection.Database}";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(
                    "No fue posible conectar con SQL Server: " + ex.Message
                );
            }
        }
    }
}