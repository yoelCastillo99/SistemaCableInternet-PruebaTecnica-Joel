
using SistemaCableInternet.BLL.Models;

namespace SistemaCableInternet.BLL.Interfaces
{
    public interface IDireccionRepository
    {
        Task<List<Direccion>> ListarAsync(
            string? buscar = null,
            int? contratoId = null,
            int? zonaId = null
        );

        Task<Direccion?> ObtenerPorIdAsync(int direccionId);

        Task<int> InsertarAsync(Direccion direccion);

        Task ActualizarAsync(Direccion direccion);
    }
}

