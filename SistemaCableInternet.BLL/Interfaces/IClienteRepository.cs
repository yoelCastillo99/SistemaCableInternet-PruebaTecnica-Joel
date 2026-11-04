
using SistemaCableInternet.BLL.Models;

namespace SistemaCableInternet.BLL.Interfaces
{
    public interface IClienteRepository
    {
        Task<List<Cliente>> ListarAsync(
            string? buscar = null,
            bool? activo = null
        );

        Task<Cliente?> ObtenerPorIdAsync(int clienteId);

        Task<int> InsertarAsync(Cliente cliente);

        Task ActualizarAsync(Cliente cliente);

        Task CambiarEstadoAsync(int clienteId, bool activo);
    }
}
