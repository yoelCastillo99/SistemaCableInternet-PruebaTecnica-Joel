
using Microsoft.Data.SqlClient;
using SistemaCableInternet.BLL.Interfaces;
using SistemaCableInternet.BLL.Models;
using System.Data;

namespace SistemaCableInternet.DAL.Repositories
{
    public class ServicioRepository : IServicioRepository
    {
        private readonly string _connectionString;

        public ServicioRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<Servicio>> ListarAsync(
            string? buscar = null,
            bool? activo = null)
        {
            var servicios = new List<Servicio>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = new SqlCommand(
                "usp_Servicio_Listar", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@Buscar", SqlDbType.NVarChar, 100)
                    .Value = string.IsNullOrWhiteSpace(buscar)
                        ? DBNull.Value : buscar;

                command.Parameters.Add("@Activo", SqlDbType.Bit)
                    .Value = activo.HasValue
                        ? activo.Value : DBNull.Value;

                await connection.OpenAsync();

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        servicios.Add(new Servicio
                        {
                            ServicioId = Convert.ToInt32(reader["ServicioId"]),
                            Descripcion = reader["Descripcion"].ToString()!,
                            Activo = Convert.ToBoolean(reader["Activo"])
                        });
                    }
                }
            }

            return servicios;
        }

        public async Task<Servicio?> ObtenerPorIdAsync(int servicioId)
        {
            Servicio? servicio = null;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = new SqlCommand(
                "usp_Servicio_ObtenerPorId", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@ServicioId", SqlDbType.Int)
                    .Value = servicioId;

                await connection.OpenAsync();

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        servicio = new Servicio
                        {
                            ServicioId = Convert.ToInt32(reader["ServicioId"]),
                            Descripcion = reader["Descripcion"].ToString()!,
                            Activo = Convert.ToBoolean(reader["Activo"])
                        };
                    }
                }
            }

            return servicio;
        }

        public async Task<int> InsertarAsync(Servicio servicio)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = new SqlCommand(
                "usp_Servicio_Insertar", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@Descripcion", SqlDbType.NVarChar, 100)
                    .Value = servicio.Descripcion;

                await connection.OpenAsync();

                object? resultado = await command.ExecuteScalarAsync();

                return Convert.ToInt32(resultado);
            }
        }

        public async Task ActualizarAsync(Servicio servicio)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = new SqlCommand(
                "usp_Servicio_Actualizar", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@ServicioId", SqlDbType.Int)
                    .Value = servicio.ServicioId;

                command.Parameters.Add("@Descripcion", SqlDbType.NVarChar, 100)
                    .Value = servicio.Descripcion;

                await connection.OpenAsync();

                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task CambiarEstadoAsync(int servicioId, bool activo)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = new SqlCommand(
                "usp_Servicio_CambiarEstado", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@ServicioId", SqlDbType.Int)
                    .Value = servicioId;

                command.Parameters.Add("@Activo", SqlDbType.Bit)
                    .Value = activo;

                await connection.OpenAsync();

                await command.ExecuteNonQueryAsync();
            }
        }
    }
}

