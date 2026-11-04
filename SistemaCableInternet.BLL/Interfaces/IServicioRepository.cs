using SistemaCableInternet.BLL.Models;

namespace SistemaCableInternet.BLL.Interfaces
{
    public interface IServicioRepository
    {
        Task<List<Servicio>> ListarAsync(
            string? buscar = null,
            bool? activo = null);

        Task<Servicio?> ObtenerPorIdAsync(int servicioId);

        Task<int> InsertarAsync(Servicio servicio);

        Task ActualizarAsync(Servicio servicio);

        Task CambiarEstadoAsync(int servicioId, bool activo);
    }
}
