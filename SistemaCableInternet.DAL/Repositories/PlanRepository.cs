
using Microsoft.Data.SqlClient;
using SistemaCableInternet.BLL.Interfaces;
using SistemaCableInternet.BLL.Models;
using System.Data;

namespace SistemaCableInternet.DAL.Repositories
{
    public class PlanRepository : IPlanRepository
    {
        private readonly string _connectionString;

        public PlanRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<Plan>> ListarAsync(
            string? buscar = null,
            int? servicioId = null,
            bool? activo = null)
        {
            var planes = new List<Plan>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = new SqlCommand(
                "usp_Plan_Listar", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@Buscar", SqlDbType.NVarChar, 100)
                    .Value = string.IsNullOrWhiteSpace(buscar)
                        ? DBNull.Value : buscar;

                command.Parameters.Add("@ServicioId", SqlDbType.Int)
                    .Value = servicioId.HasValue
                        ? servicioId.Value : DBNull.Value;

                command.Parameters.Add("@Activo", SqlDbType.Bit)
                    .Value = activo.HasValue
                        ? activo.Value : DBNull.Value;

                await connection.OpenAsync();

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        planes.Add(new Plan
                        {
                            PlanId = Convert.ToInt32(reader["PlanId"]),
                            ServicioId = Convert.ToInt32(reader["ServicioId"]),
                            Servicio = reader["Servicio"].ToString(),
                            Nombre = reader["Nombre"].ToString()!,
                            VelocidadMbps = reader["VelocidadMbps"] == DBNull.Value
                                ? null
                                : Convert.ToInt32(reader["VelocidadMbps"]),
                            Canales = reader["Canales"] == DBNull.Value
                                ? null
                                : Convert.ToInt32(reader["Canales"]),
                            Activo = Convert.ToBoolean(reader["Activo"])
                        });
                    }
                }
            }

            return planes;
        }

        public async Task<Plan?> ObtenerPorIdAsync(int planId)
        {
            Plan? plan = null;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = new SqlCommand(
                "usp_Plan_ObtenerPorId", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@PlanId", SqlDbType.Int)
                    .Value = planId;

                await connection.OpenAsync();

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        plan = new Plan
                        {
                            PlanId = Convert.ToInt32(reader["PlanId"]),
                            ServicioId = Convert.ToInt32(reader["ServicioId"]),
                            Nombre = reader["Nombre"].ToString()!,
                            VelocidadMbps = reader["VelocidadMbps"] == DBNull.Value
                                ? null
                                : Convert.ToInt32(reader["VelocidadMbps"]),
                            Canales = reader["Canales"] == DBNull.Value
                                ? null
                                : Convert.ToInt32(reader["Canales"]),
                            Activo = Convert.ToBoolean(reader["Activo"])
                        };
                    }
                }
            }

            return plan;
        }

        public async Task<int> InsertarAsync(Plan plan)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = new SqlCommand(
                "usp_Plan_Insertar", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@ServicioId", SqlDbType.Int)
                    .Value = plan.ServicioId;

                command.Parameters.Add("@Nombre", SqlDbType.NVarChar, 100)
                    .Value = plan.Nombre;

                command.Parameters.Add("@VelocidadMbps", SqlDbType.Int)
                    .Value = plan.VelocidadMbps.HasValue
                        ? plan.VelocidadMbps.Value : DBNull.Value;

                command.Parameters.Add("@Canales", SqlDbType.Int)
                    .Value = plan.Canales.HasValue
                        ? plan.Canales.Value : DBNull.Value;

                await connection.OpenAsync();

                object? resultado = await command.ExecuteScalarAsync();

                return Convert.ToInt32(resultado);
            }
        }

        public async Task ActualizarAsync(Plan plan)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = new SqlCommand(
                "usp_Plan_Actualizar", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@PlanId", SqlDbType.Int)
                    .Value = plan.PlanId;

                command.Parameters.Add("@ServicioId", SqlDbType.Int)
                    .Value = plan.ServicioId;

                command.Parameters.Add("@Nombre", SqlDbType.NVarChar, 100)
                    .Value = plan.Nombre;

                command.Parameters.Add("@VelocidadMbps", SqlDbType.Int)
                    .Value = plan.VelocidadMbps.HasValue
                        ? plan.VelocidadMbps.Value : DBNull.Value;

                command.Parameters.Add("@Canales", SqlDbType.Int)
                    .Value = plan.Canales.HasValue
                        ? plan.Canales.Value : DBNull.Value;

                await connection.OpenAsync();

                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task CambiarEstadoAsync(int planId, bool activo)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = new SqlCommand(
                "usp_Plan_CambiarEstado", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@PlanId", SqlDbType.Int)
                    .Value = planId;

                command.Parameters.Add("@Activo", SqlDbType.Bit)
                    .Value = activo;

                await connection.OpenAsync();

                await command.ExecuteNonQueryAsync();
            }
        }
    }
}

