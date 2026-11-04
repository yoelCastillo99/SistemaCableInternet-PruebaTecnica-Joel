
using SistemaCableInternet.BLL.Models;

namespace SistemaCableInternet.BLL.Interfaces
{
    public interface ITarifaRepository
    {
        Task<List<Tarifa>> ListarAsync(
            int? planId = null,
            int? zonaId = null
        );

        Task<Tarifa?> ObtenerPorIdAsync(int tarifaId);
    }
}

