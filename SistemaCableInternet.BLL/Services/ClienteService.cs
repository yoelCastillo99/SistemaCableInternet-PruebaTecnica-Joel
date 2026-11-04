
using SistemaCableInternet.BLL.Interfaces;
using SistemaCableInternet.BLL.Models;

namespace SistemaCableInternet.BLL.Services
{
    public class ClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        // LISTAR CLIENTES
        public async Task<List<Cliente>> ListarAsync(
            string? buscar = null,
            bool? activo = null)
        {
            return await _clienteRepository.ListarAsync(buscar, activo);
        }

        // OBTENER CLIENTE POR ID
        public async Task<Cliente?> ObtenerPorIdAsync(int clienteId)
        {
            if (clienteId <= 0)
                throw new ArgumentException("El ID del cliente no es válido.");

            return await _clienteRepository.ObtenerPorIdAsync(clienteId);
        }

        // INSERTAR CLIENTE
        public async Task<int> InsertarAsync(Cliente cliente)
        {
            ValidarCliente(cliente);

            return await _clienteRepository.InsertarAsync(cliente);
        }

        // ACTUALIZAR CLIENTE
        public async Task ActualizarAsync(Cliente cliente)
        {
            if (cliente.ClienteId <= 0)
                throw new ArgumentException("El ID del cliente no es válido.");

            ValidarCliente(cliente);

            await _clienteRepository.ActualizarAsync(cliente);
        }

        // CAMBIAR ESTADO
        public async Task CambiarEstadoAsync(int clienteId, bool activo)
        {
            if (clienteId <= 0)
                throw new ArgumentException("El ID del cliente no es válido.");

            await _clienteRepository.CambiarEstadoAsync(clienteId, activo);
        }

        // VALIDACIONES DE NEGOCIO
        private static void ValidarCliente(Cliente cliente)
        {
            if (cliente == null)
                throw new ArgumentNullException(nameof(cliente));

            if (string.IsNullOrWhiteSpace(cliente.Codigo))
                throw new ArgumentException("El código es obligatorio.");

            if (cliente.Codigo.Trim().Length > 20)
                throw new ArgumentException("El código no puede superar 20 caracteres.");

            if (string.IsNullOrWhiteSpace(cliente.Nombre))
                throw new ArgumentException("El nombre es obligatorio.");

            if (cliente.Nombre.Trim().Length > 150)
                throw new ArgumentException("El nombre no puede superar 150 caracteres.");

            if (cliente.FechaAlta == default)
                throw new ArgumentException("La fecha de alta es obligatoria.");

            if (string.IsNullOrWhiteSpace(cliente.Direccion))
                throw new ArgumentException("La dirección es obligatoria.");

            if (cliente.Direccion.Trim().Length > 250)
                throw new ArgumentException("La dirección no puede superar 250 caracteres.");

            if (cliente.Correo?.Length > 254)
                throw new ArgumentException("El correo no puede superar 254 caracteres.");

            if (cliente.Telefono?.Length > 30)
                throw new ArgumentException("El teléfono no puede superar 30 caracteres.");
        }
    }
}

