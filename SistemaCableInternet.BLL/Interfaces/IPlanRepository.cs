using SistemaCableInternet.BLL.Models;

namespace SistemaCableInternet.BLL.Interfaces
{
    public interface IPlanRepository
    {
        Task<List<Plan>> ListarAsync(
            string? buscar = null,
            int? servicioId = null,
            bool? activo = null);

        Task<Plan?> ObtenerPorIdAsync(int planId);

        Task<int> InsertarAsync(Plan plan);

        Task ActualizarAsync(Plan plan);

        Task CambiarEstadoAsync(int planId, bool activo);
    }
}
