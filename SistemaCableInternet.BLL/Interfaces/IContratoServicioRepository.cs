
using SistemaCableInternet.BLL.Models;

namespace SistemaCableInternet.BLL.Interfaces
{
    public interface IContratoServicioRepository
    {
        Task<List<ContratoServicio>> ListarAsync(
            int? contratoId = null,
            int? clienteId = null,
            string? estado = null);

        Task<ContratoServicio?> ObtenerPorIdAsync(
            int contratoServicioId);

        Task<int> InsertarAsync(
            ContratoServicio contratoServicio);

        Task ActualizarAsync(
            ContratoServicio contratoServicio);

        Task CambiarEstadoAsync(
            int contratoServicioId,
            string estado);
    }
}


