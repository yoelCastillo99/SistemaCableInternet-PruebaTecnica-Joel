
using SistemaCableInternet.BLL.Models;

namespace SistemaCableInternet.BLL.Interfaces
{
    public interface IZonaRepository
    {
        Task<List<Zona>> ListarAsync(
            string? buscar = null,
            bool? activo = null
        );

        Task<Zona?> ObtenerPorIdAsync(int zonaId);

        Task<int> InsertarAsync(Zona zona);

        Task ActualizarAsync(Zona zona);

        Task CambiarEstadoAsync(int zonaId, bool activo);
    }
}

