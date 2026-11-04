
using Microsoft.Data.SqlClient;
using SistemaCableInternet.BLL.Interfaces;
using SistemaCableInternet.BLL.Models;
using System.Data;

namespace SistemaCableInternet.DAL.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly string _connectionString;

        public ClienteRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        // LISTAR CLIENTES
        public async Task<List<Cliente>> ListarAsync(
            string? buscar = null,
            bool? activo = null)
        {
            var clientes = new List<Cliente>();

            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand(
                "dbo.usp_Cliente_Listar", connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@Buscar", SqlDbType.NVarChar, 150)
                .Value = string.IsNullOrWhiteSpace(buscar)
                    ? DBNull.Value
                    : buscar.Trim();

            command.Parameters.Add("@Activo", SqlDbType.Bit)
                .Value = activo.HasValue
                    ? activo.Value
                    : DBNull.Value;

            await connection.OpenAsync();

            using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                clientes.Add(MapearCliente(reader));
            }

            return clientes;
        }

        // OBTENER CLIENTE POR ID
        public async Task<Cliente?> ObtenerPorIdAsync(int clienteId)
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand(
                "dbo.usp_Cliente_ObtenerPorId", connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@ClienteId", SqlDbType.Int)
                .Value = clienteId;

            await connection.OpenAsync();

            using var reader = await command.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                return MapearCliente(reader);
            }

            return null;
        }

        // INSERTAR CLIENTE
        public async Task<int> InsertarAsync(Cliente cliente)
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand(
                "dbo.usp_Cliente_Insertar", connection);

            command.CommandType = CommandType.StoredProcedure;

            AgregarParametrosCliente(command, cliente);

            await connection.OpenAsync();

            var resultado = await command.ExecuteScalarAsync();

            return Convert.ToInt32(resultado);
        }

        // ACTUALIZAR CLIENTE
        public async Task ActualizarAsync(Cliente cliente)
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand(
                "dbo.usp_Cliente_Actualizar", connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@ClienteId", SqlDbType.Int)
                .Value = cliente.ClienteId;

            AgregarParametrosCliente(command, cliente);

            await connection.OpenAsync();

            await command.ExecuteNonQueryAsync();
        }

        // CAMBIAR ESTADO DEL CLIENTE
        public async Task CambiarEstadoAsync(int clienteId, bool activo)
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand(
                "dbo.usp_Cliente_CambiarEstado", connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@ClienteId", SqlDbType.Int)
                .Value = clienteId;

            command.Parameters.Add("@Activo", SqlDbType.Bit)
                .Value = activo;

            await connection.OpenAsync();

            await command.ExecuteNonQueryAsync();
        }

        // AGREGAR PARAMETROS PARA INSERTAR Y ACTUALIZAR
        private static void AgregarParametrosCliente(
            SqlCommand command,
            Cliente cliente)
        {
            command.Parameters.Add("@Codigo", SqlDbType.VarChar, 20)
                .Value = cliente.Codigo.Trim();

            command.Parameters.Add("@Nombre", SqlDbType.NVarChar, 150)
                .Value = cliente.Nombre.Trim();

            command.Parameters.Add("@FechaAlta", SqlDbType.Date)
                .Value = cliente.FechaAlta.Date;

            command.Parameters.Add("@Direccion", SqlDbType.NVarChar, 250)
                .Value = cliente.Direccion.Trim();

            command.Parameters.Add("@Correo", SqlDbType.NVarChar, 254)
                .Value = string.IsNullOrWhiteSpace(cliente.Correo)
                    ? DBNull.Value
                    : cliente.Correo.Trim();

            command.Parameters.Add("@Telefono", SqlDbType.VarChar, 30)
                .Value = string.IsNullOrWhiteSpace(cliente.Telefono)
                    ? DBNull.Value
                    : cliente.Telefono.Trim();
        }

        // CONVERTIR RESULTADO SQL A OBJETO CLIENTE
        private static Cliente MapearCliente(SqlDataReader reader)
        {
            return new Cliente
            {
                ClienteId = reader.GetInt32(
                    reader.GetOrdinal("ClienteId")),

                Codigo = reader.GetString(
                    reader.GetOrdinal("Codigo")),

                Nombre = reader.GetString(
                    reader.GetOrdinal("Nombre")),

                FechaAlta = reader.GetDateTime(
                    reader.GetOrdinal("FechaAlta")),

                Direccion = reader.GetString(
                    reader.GetOrdinal("Direccion")),

                Correo = reader.IsDBNull(
                    reader.GetOrdinal("Correo"))
                    ? null
                    : reader.GetString(reader.GetOrdinal("Correo")),

                Telefono = reader.IsDBNull(
                    reader.GetOrdinal("Telefono"))
                    ? null
                    : reader.GetString(reader.GetOrdinal("Telefono")),

                Activo = reader.GetBoolean(
                    reader.GetOrdinal("Activo"))
            };
        }
    }
}

