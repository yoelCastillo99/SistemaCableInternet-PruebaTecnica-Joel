
using Microsoft.Data.SqlClient;
using SistemaCableInternet.BLL.Interfaces;
using SistemaCableInternet.BLL.Models;
using System.Data;

namespace SistemaCableInternet.DAL.Repositories
{
    public class TarifaRepository : ITarifaRepository
    {
        private readonly string _connectionString;

        public TarifaRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        // LISTAR TARIFAS VIGENTES
        public async Task<List<Tarifa>> ListarAsync(
            int? planId = null,
            int? zonaId = null)
        {
            var lista = new List<Tarifa>();

            using var connection = new SqlConnection(_connectionString);

            using var command = new SqlCommand(
                "usp_Tarifa_Listar", connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@PlanId", SqlDbType.Int).Value =
                planId.HasValue ? planId.Value : DBNull.Value;

            command.Parameters.Add("@ZonaId", SqlDbType.Int).Value =
                zonaId.HasValue ? zonaId.Value : DBNull.Value;

            await connection.OpenAsync();

            using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                lista.Add(MapearTarifa(reader));
            }

            return lista;
        }

        // OBTENER TARIFA POR ID
        public async Task<Tarifa?> ObtenerPorIdAsync(int tarifaId)
        {
            using var connection = new SqlConnection(_connectionString);

            using var command = new SqlCommand(
                "usp_Tarifa_ObtenerPorId", connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@TarifaId", SqlDbType.Int).Value =
                tarifaId;

            await connection.OpenAsync();

            using var reader = await command.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                return MapearTarifa(reader);
            }

            return null;
        }

        // MAPEAR RESULTADOS
        private static Tarifa MapearTarifa(SqlDataReader reader)
        {
            return new Tarifa
            {
                TarifaId = reader.GetInt32(
                    reader.GetOrdinal("TarifaId")),

                PlanId = reader.GetInt32(
                    reader.GetOrdinal("PlanId")),

                NombrePlan = reader["NombrePlan"]?.ToString(),

                ZonaId = reader.GetInt32(
                    reader.GetOrdinal("ZonaId")),

                NombreZona = reader["NombreZona"]?.ToString(),

                PrecioMensual = reader.GetDecimal(
                    reader.GetOrdinal("PrecioMensual")),

                VigenciaDesde = reader.GetDateTime(
                    reader.GetOrdinal("VigenciaDesde")),

                VigenciaHasta = reader.IsDBNull(
                    reader.GetOrdinal("VigenciaHasta"))
                    ? null
                    : reader.GetDateTime(
                        reader.GetOrdinal("VigenciaHasta"))
            };
        }
    }
}

