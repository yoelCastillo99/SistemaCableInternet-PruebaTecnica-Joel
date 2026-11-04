
using SistemaCableInternet.BLL.Interfaces;
using SistemaCableInternet.BLL.Models;

namespace SistemaCableInternet.BLL.Services
{
    public class ServicioService
    {
        private readonly IServicioRepository _servicioRepository;

        public ServicioService(IServicioRepository servicioRepository)
        {
            _servicioRepository = servicioRepository;
        }

        public async Task<List<Servicio>> ListarAsync(
            string? buscar = null,
            bool? activo = null)
        {
            return await _servicioRepository.ListarAsync(buscar, activo);
        }

        public async Task<Servicio?> ObtenerPorIdAsync(int servicioId)
        {
            if (servicioId <= 0)
                throw new ArgumentException("El ID del servicio no es válido.");

            return await _servicioRepository.ObtenerPorIdAsync(servicioId);
        }

        public async Task<int> InsertarAsync(Servicio servicio)
        {
            ValidarServicio(servicio);

            return await _servicioRepository.InsertarAsync(servicio);
        }

        public async Task ActualizarAsync(Servicio servicio)
        {
            if (servicio.ServicioId <= 0)
                throw new ArgumentException("El ID del servicio no es válido.");

            ValidarServicio(servicio);

            await _servicioRepository.ActualizarAsync(servicio);
        }

        public async Task CambiarEstadoAsync(int servicioId, bool activo)
        {
            if (servicioId <= 0)
                throw new ArgumentException("El ID del servicio no es válido.");

            await _servicioRepository.CambiarEstadoAsync(servicioId, activo);
        }

        private void ValidarServicio(Servicio servicio)
        {
            if (servicio == null)
                throw new ArgumentNullException(nameof(servicio));

            if (string.IsNullOrWhiteSpace(servicio.Descripcion))
                throw new ArgumentException("La descripción del servicio es obligatoria.");

            if (servicio.Descripcion.Trim().Length > 100)
                throw new ArgumentException("La descripción no puede superar los 100 caracteres.");
        }
    }
}

