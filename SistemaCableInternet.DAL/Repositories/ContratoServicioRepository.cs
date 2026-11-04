

using Microsoft.Data.SqlClient;
using SistemaCableInternet.BLL.Interfaces;
using SistemaCableInternet.BLL.Models;
using System.Data;

namespace SistemaCableInternet.DAL.Repositories
{
    public class ContratoServicioRepository : IContratoServicioRepository
    {
        private readonly string _connectionString;

        public ContratoServicioRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        // LISTAR
        public async Task<List<ContratoServicio>> ListarAsync(
            int? contratoId = null,
            int? clienteId = null,
            string? estado = null)
        {
            var lista = new List<ContratoServicio>();

            using var connection = new SqlConnection(_connectionString);

            using var command = new SqlCommand(
                "usp_ContratoServicio_Listar", connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@ContratoId", SqlDbType.Int).Value =
                (object?)contratoId ?? DBNull.Value;

            command.Parameters.Add("@ClienteId", SqlDbType.Int).Value =
                (object?)clienteId ?? DBNull.Value;

            command.Parameters.Add("@Estado", SqlDbType.VarChar, 12).Value =
                (object?)estado ?? DBNull.Value;

            await connection.OpenAsync();

            using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                lista.Add(Mapear(reader));
            }

            return lista;
        }

        // OBTENER POR ID
        public async Task<ContratoServicio?> ObtenerPorIdAsync(
            int contratoServicioId)
        {
            using var connection = new SqlConnection(_connectionString);

            using var command = new SqlCommand(
                "usp_ContratoServicio_ObtenerPorId", connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@ContratoServicioId", SqlDbType.Int)
                .Value = contratoServicioId;

            await connection.OpenAsync();

            using var reader = await command.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                return Mapear(reader);
            }

            return null;
        }

        // INSERTAR
        public async Task<int> InsertarAsync(ContratoServicio contratoServicio)
        {
            using var connection = new SqlConnection(_connectionString);

            using var command = new SqlCommand(
                "usp_ContratoServicio_Insertar", connection);

            command.CommandType = CommandType.StoredProcedure;

            AgregarParametros(command, contratoServicio);

            await connection.OpenAsync();

            var resultado = await command.ExecuteScalarAsync();

            return Convert.ToInt32(resultado);
        }

        // ACTUALIZAR
        public async Task ActualizarAsync(ContratoServicio contratoServicio)
        {
            using var connection = new SqlConnection(_connectionString);

            using var command = new SqlCommand(
                "usp_ContratoServicio_Actualizar", connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@ContratoServicioId", SqlDbType.Int)
                .Value = contratoServicio.ContratoServicioId;

            AgregarParametros(command, contratoServicio);

            await connection.OpenAsync();

            await command.ExecuteNonQueryAsync();
        }

        // CAMBIAR ESTADO
        public async Task CambiarEstadoAsync(
            int contratoServicioId,
            string estado)
        {
            using var connection = new SqlConnection(_connectionString);

            using var command = new SqlCommand(
                "usp_ContratoServicio_CambiarEstado", connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@ContratoServicioId", SqlDbType.Int)
                .Value = contratoServicioId;

            command.Parameters.Add("@Estado", SqlDbType.VarChar, 12)
                .Value = estado;

            await connection.OpenAsync();

            await command.ExecuteNonQueryAsync();
        }

        // PARAMETROS COMPARTIDOS
        private static void AgregarParametros(
            SqlCommand command,
            ContratoServicio cs)
        {
            command.Parameters.Add("@ContratoId", SqlDbType.Int)
                .Value = cs.ContratoId;

            command.Parameters.Add("@PlanId", SqlDbType.Int)
                .Value = cs.PlanId;

            command.Parameters.Add("@ServicioId", SqlDbType.Int)
                .Value = cs.ServicioId;

            command.Parameters.Add("@DireccionId", SqlDbType.Int)
                .Value = cs.DireccionId;

            command.Parameters.Add("@TarifaId", SqlDbType.Int)
                .Value = cs.TarifaId;

            command.Parameters.Add("@FechaAlta", SqlDbType.Date)
                .Value = cs.FechaAlta.Date;
        }

        // MAPEAR RESULTADOS
        private static ContratoServicio Mapear(SqlDataReader reader)
        {
            return new ContratoServicio
            {
                ContratoServicioId = reader.GetInt32(
                    reader.GetOrdinal("ContratoServicioId")),

                ContratoId = reader.GetInt32(
                    reader.GetOrdinal("ContratoId")),

                ClienteId = reader.GetInt32(
                    reader.GetOrdinal("ClienteId")),

                CodigoCliente = reader["CodigoCliente"].ToString(),

                NombreCliente = reader["NombreCliente"].ToString(),

                PlanId = reader.GetInt32(
                    reader.GetOrdinal("PlanId")),

                NombrePlan = reader["NombrePlan"].ToString(),

                ServicioId = reader.GetInt32(
                    reader.GetOrdinal("ServicioId")),

                Servicio = reader["Servicio"].ToString(),

                DireccionId = reader.GetInt32(
                    reader.GetOrdinal("DireccionId")),

                Direccion = reader["Direccion"].ToString(),

                ZonaId = reader.GetInt32(
                    reader.GetOrdinal("ZonaId")),

                Zona = reader["Zona"].ToString(),

                TarifaId = reader.GetInt32(
                    reader.GetOrdinal("TarifaId")),

                PrecioMensual = reader.GetDecimal(
                    reader.GetOrdinal("PrecioMensual")),

                PrecioPactado = reader.GetDecimal(
                    reader.GetOrdinal("PrecioPactado")),

                VelocidadActualMbps = reader.IsDBNull(
                    reader.GetOrdinal("VelocidadActualMbps"))
                    ? null
                    : reader.GetInt16(
                        reader.GetOrdinal("VelocidadActualMbps")),

                FechaAlta = reader.GetDateTime(
                    reader.GetOrdinal("FechaAlta")),

                FechaBaja = reader.IsDBNull(
                    reader.GetOrdinal("FechaBaja"))
                    ? null
                    : reader.GetDateTime(
                        reader.GetOrdinal("FechaBaja")),

                Estado = reader["Estado"].ToString()!
            };
        }
    }
}


