
using SistemaCableInternet.BLL.Interfaces;
using SistemaCableInternet.BLL.Models;

namespace SistemaCableInternet.BLL.Services
{
    public class TarifaService
    {
        private readonly ITarifaRepository _tarifaRepository;

        public TarifaService(ITarifaRepository tarifaRepository)
        {
            _tarifaRepository = tarifaRepository;
        }

        public async Task<List<Tarifa>> ListarAsync(
            int? planId = null,
            int? zonaId = null)
        {
            return await _tarifaRepository.ListarAsync(
                planId,
                zonaId
            );
        }

        public async Task<Tarifa?> ObtenerPorIdAsync(int tarifaId)
        {
            if (tarifaId <= 0)
                throw new ArgumentException("El ID de la tarifa no es válido.");

            return await _tarifaRepository.ObtenerPorIdAsync(tarifaId);
        }
    }
}

