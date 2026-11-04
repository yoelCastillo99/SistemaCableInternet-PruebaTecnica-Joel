
using Microsoft.Data.SqlClient;
using SistemaCableInternet.BLL.Interfaces;
using SistemaCableInternet.BLL.Models;
using System.Data;

namespace SistemaCableInternet.DAL.Repositories
{
    public class ZonaRepository : IZonaRepository
    {
        private readonly string _connectionString;

        public ZonaRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<Zona>> ListarAsync(
            string? buscar = null,
            bool? activo = null)
        {
            var zonas = new List<Zona>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = new SqlCommand("usp_Zona_Listar", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue(
                    "@Buscar",
                    string.IsNullOrWhiteSpace(buscar)
                        ? DBNull.Value
                        : buscar
                );

                command.Parameters.AddWithValue(
                    "@Activo",
                    activo.HasValue
                        ? activo.Value
                        : DBNull.Value
                );

                await connection.OpenAsync();

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        zonas.Add(new Zona
                        {
                            ZonaId = reader.GetInt32(reader.GetOrdinal("ZonaId")),
                            Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                            Activo = reader.GetBoolean(reader.GetOrdinal("Activo"))
                        });
                    }
                }
            }

            return zonas;
        }

        public async Task<Zona?> ObtenerPorIdAsync(int zonaId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = new SqlCommand("usp_Zona_ObtenerPorId", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@ZonaId", zonaId);

                await connection.OpenAsync();

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        return new Zona
                        {
                            ZonaId = reader.GetInt32(reader.GetOrdinal("ZonaId")),
                            Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                            Activo = reader.GetBoolean(reader.GetOrdinal("Activo"))
                        };
                    }
                }
            }

            return null;
        }

        public async Task<int> InsertarAsync(Zona zona)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = new SqlCommand("usp_Zona_Insertar", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Nombre", zona.Nombre);

                await connection.OpenAsync();

                object? resultado = await command.ExecuteScalarAsync();

                return Convert.ToInt32(resultado);
            }
        }

        public async Task ActualizarAsync(Zona zona)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = new SqlCommand("usp_Zona_Actualizar", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@ZonaId", zona.ZonaId);
                command.Parameters.AddWithValue("@Nombre", zona.Nombre);

                await connection.OpenAsync();

                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task CambiarEstadoAsync(int zonaId, bool activo)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = new SqlCommand("usp_Zona_CambiarEstado", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@ZonaId", zonaId);
                command.Parameters.AddWithValue("@Activo", activo);

                await connection.OpenAsync();

                await command.ExecuteNonQueryAsync();
            }
        }
    }
}

