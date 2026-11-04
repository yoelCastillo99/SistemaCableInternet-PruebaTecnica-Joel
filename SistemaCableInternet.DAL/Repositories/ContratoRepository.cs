
using Microsoft.Data.SqlClient;
using SistemaCableInternet.BLL.Interfaces;
using SistemaCableInternet.BLL.Models;
using System.Data;

namespace SistemaCableInternet.DAL.Repositories
{
    public class ContratoRepository : IContratoRepository
    {
        private readonly string _connectionString;

        public ContratoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        // LISTAR CONTRATOS
        public async Task<List<Contrato>> ListarAsync(
            string? buscar = null,
            string? estado = null)
        {
            var contratos = new List<Contrato>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(
                    "usp_Contrato_Listar", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@Buscar", SqlDbType.NVarChar, 100)
                        .Value = string.IsNullOrWhiteSpace(buscar)
                            ? DBNull.Value
                            : buscar;

                    command.Parameters.Add("@Estado", SqlDbType.VarChar, 12)
                        .Value = string.IsNullOrWhiteSpace(estado)
                            ? DBNull.Value
                            : estado;

                    await connection.OpenAsync();

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            contratos.Add(new Contrato
                            {
                                ContratoId = reader.GetInt32(reader.GetOrdinal("ContratoId")),
                                ClienteId = reader.GetInt32(reader.GetOrdinal("ClienteId")),
                                Codigo = reader.GetString(reader.GetOrdinal("Codigo")),
                                Cliente = reader.GetString(reader.GetOrdinal("Cliente")),
                                FechaInicio = reader.GetDateTime(reader.GetOrdinal("FechaInicio")),
                                FechaFin = reader.IsDBNull(reader.GetOrdinal("FechaFin"))
                                    ? null
                                    : reader.GetDateTime(reader.GetOrdinal("FechaFin")),
                                DiaPago = reader.GetByte(reader.GetOrdinal("DiaPago")),
                                Estado = reader.GetString(reader.GetOrdinal("Estado"))
                            });
                        }
                    }
                }
            }

            return contratos;
        }

        // OBTENER CONTRATO POR ID
        public async Task<Contrato?> ObtenerPorIdAsync(int contratoId)
        {
            Contrato? contrato = null;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(
                    "usp_Contrato_ObtenerPorId", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@ContratoId", SqlDbType.Int)
                        .Value = contratoId;

                    await connection.OpenAsync();

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            contrato = new Contrato
                            {
                                ContratoId = reader.GetInt32(reader.GetOrdinal("ContratoId")),
                                ClienteId = reader.GetInt32(reader.GetOrdinal("ClienteId")),
                                Codigo = reader.GetString(reader.GetOrdinal("Codigo")),
                                Cliente = reader.GetString(reader.GetOrdinal("Cliente")),
                                FechaInicio = reader.GetDateTime(reader.GetOrdinal("FechaInicio")),
                                FechaFin = reader.IsDBNull(reader.GetOrdinal("FechaFin"))
                                    ? null
                                    : reader.GetDateTime(reader.GetOrdinal("FechaFin")),
                                DiaPago = reader.GetByte(reader.GetOrdinal("DiaPago")),
                                Estado = reader.GetString(reader.GetOrdinal("Estado"))
                            };
                        }
                    }
                }
            }

            return contrato;
        }

        // INSERTAR CONTRATO
        public async Task<int> InsertarAsync(Contrato contrato)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(
                    "usp_Contrato_Insertar", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@ClienteId", SqlDbType.Int)
                        .Value = contrato.ClienteId;

                    command.Parameters.Add("@FechaInicio", SqlDbType.Date)
                        .Value = contrato.FechaInicio;

                    command.Parameters.Add("@FechaFin", SqlDbType.Date)
                        .Value = (object?)contrato.FechaFin ?? DBNull.Value;

                    command.Parameters.Add("@DiaPago", SqlDbType.TinyInt)
                        .Value = contrato.DiaPago;

                    await connection.OpenAsync();

                    object? resultado = await command.ExecuteScalarAsync();

                    return Convert.ToInt32(resultado);
                }
            }
        }

        // ACTUALIZAR CONTRATO
        public async Task ActualizarAsync(Contrato contrato)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(
                    "usp_Contrato_Actualizar", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@ContratoId", SqlDbType.Int)
                        .Value = contrato.ContratoId;

                    command.Parameters.Add("@ClienteId", SqlDbType.Int)
                        .Value = contrato.ClienteId;

                    command.Parameters.Add("@FechaInicio", SqlDbType.Date)
                        .Value = contrato.FechaInicio;

                    command.Parameters.Add("@FechaFin", SqlDbType.Date)
                        .Value = (object?)contrato.FechaFin ?? DBNull.Value;

                    command.Parameters.Add("@DiaPago", SqlDbType.TinyInt)
                        .Value = contrato.DiaPago;

                    await connection.OpenAsync();

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        // CAMBIAR ESTADO
        public async Task CambiarEstadoAsync(int contratoId, string estado)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(
                    "usp_Contrato_CambiarEstado", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@ContratoId", SqlDbType.Int)
                        .Value = contratoId;

                    command.Parameters.Add("@Estado", SqlDbType.VarChar, 12)
                        .Value = estado;

                    await connection.OpenAsync();

                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}

