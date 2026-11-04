
using Microsoft.Data.SqlClient;
using SistemaCableInternet.BLL.Interfaces;
using SistemaCableInternet.BLL.Models;
using System.Data;

namespace SistemaCableInternet.DAL.Repositories
{
    public class DireccionRepository : IDireccionRepository
    {
        private readonly string _connectionString;

        public DireccionRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Listar direcciones
        public async Task<List<Direccion>> ListarAsync(
            string? buscar = null,
            int? contratoId = null,
            int? zonaId = null)
        {
            var direcciones = new List<Direccion>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = new SqlCommand("usp_Direccion_Listar", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue(
                    "@Buscar",
                    string.IsNullOrWhiteSpace(buscar)
                        ? DBNull.Value
                        : buscar
                );

                command.Parameters.AddWithValue(
                    "@ContratoId",
                    contratoId.HasValue
                        ? contratoId.Value
                        : DBNull.Value
                );

                command.Parameters.AddWithValue(
                    "@ZonaId",
                    zonaId.HasValue
                        ? zonaId.Value
                        : DBNull.Value
                );

                await connection.OpenAsync();

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        direcciones.Add(new Direccion
                        {
                            DireccionId = reader.GetInt32(reader.GetOrdinal("DireccionId")),
                            ContratoId = reader.GetInt32(reader.GetOrdinal("ContratoId")),
                            ZonaId = reader.GetInt32(reader.GetOrdinal("ZonaId")),
                            DireccionTexto = reader.GetString(reader.GetOrdinal("Direccion")),
                            Zona = reader.GetString(reader.GetOrdinal("Zona")),
                            EstadoContrato = reader.GetString(reader.GetOrdinal("EstadoContrato"))
                        });
                    }
                }
            }

            return direcciones;
        }

        // Obtener dirección por ID
        public async Task<Direccion?> ObtenerPorIdAsync(int direccionId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = new SqlCommand("usp_Direccion_ObtenerPorId", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@DireccionId", direccionId);

                await connection.OpenAsync();

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        return new Direccion
                        {
                            DireccionId = reader.GetInt32(reader.GetOrdinal("DireccionId")),
                            ContratoId = reader.GetInt32(reader.GetOrdinal("ContratoId")),
                            ZonaId = reader.GetInt32(reader.GetOrdinal("ZonaId")),
                            DireccionTexto = reader.GetString(reader.GetOrdinal("Direccion")),
                            Zona = reader.GetString(reader.GetOrdinal("Zona")),
                            EstadoContrato = reader.GetString(reader.GetOrdinal("EstadoContrato"))
                        };
                    }
                }
            }

            return null;
        }

        // Insertar dirección
        public async Task<int> InsertarAsync(Direccion direccion)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = new SqlCommand("usp_Direccion_Insertar", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@ContratoId", direccion.ContratoId);
                command.Parameters.AddWithValue("@ZonaId", direccion.ZonaId);
                command.Parameters.AddWithValue("@Direccion", direccion.DireccionTexto);

                await connection.OpenAsync();

                object? resultado = await command.ExecuteScalarAsync();

                return Convert.ToInt32(resultado);
            }
        }

        // Actualizar dirección
        public async Task ActualizarAsync(Direccion direccion)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = new SqlCommand("usp_Direccion_Actualizar", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@DireccionId", direccion.DireccionId);
                command.Parameters.AddWithValue("@ContratoId", direccion.ContratoId);
                command.Parameters.AddWithValue("@ZonaId", direccion.ZonaId);
                command.Parameters.AddWithValue("@Direccion", direccion.DireccionTexto);

                await connection.OpenAsync();

                await command.ExecuteNonQueryAsync();
            }
        }
    }
}

