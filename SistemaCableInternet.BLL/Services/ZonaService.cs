
using SistemaCableInternet.BLL.Interfaces;
using SistemaCableInternet.BLL.Models;

namespace SistemaCableInternet.BLL.Services
{
    public class ZonaService
    {
        private readonly IZonaRepository _zonaRepository;

        public ZonaService(IZonaRepository zonaRepository)
        {
            _zonaRepository = zonaRepository;
        }

        public async Task<List<Zona>> ListarAsync(
            string? buscar = null,
            bool? activo = null)
        {
            return await _zonaRepository.ListarAsync(buscar, activo);
        }

        public async Task<Zona?> ObtenerPorIdAsync(int zonaId)
        {
            if (zonaId <= 0)
            {
                throw new Exception("El identificador de la zona no es válido.");
            }

            return await _zonaRepository.ObtenerPorIdAsync(zonaId);
        }

        public async Task<int> InsertarAsync(Zona zona)
        {
            ValidarZona(zona);

            return await _zonaRepository.InsertarAsync(zona);
        }

        public async Task ActualizarAsync(Zona zona)
        {
            if (zona.ZonaId <= 0)
            {
                throw new Exception("El identificador de la zona no es válido.");
            }

            ValidarZona(zona);

            var zonaExistente = await _zonaRepository.ObtenerPorIdAsync(zona.ZonaId);

            if (zonaExistente == null)
            {
                throw new Exception("La zona que intenta actualizar no existe.");
            }

            await _zonaRepository.ActualizarAsync(zona);
        }

        public async Task CambiarEstadoAsync(int zonaId, bool activo)
        {
            if (zonaId <= 0)
            {
                throw new Exception("El identificador de la zona no es válido.");
            }

            var zonaExistente = await _zonaRepository.ObtenerPorIdAsync(zonaId);

            if (zonaExistente == null)
            {
                throw new Exception("La zona que intenta modificar no existe.");
            }

            await _zonaRepository.CambiarEstadoAsync(zonaId, activo);
        }

        private void ValidarZona(Zona zona)
        {
            if (zona == null)
            {
                throw new Exception("La información de la zona es obligatoria.");
            }

            if (string.IsNullOrWhiteSpace(zona.Nombre))
            {
                throw new Exception("El nombre de la zona es obligatorio.");
            }

            zona.Nombre = zona.Nombre.Trim();

            if (zona.Nombre.Length > 200)
            {
                throw new Exception("El nombre de la zona no puede superar los 200 caracteres.");
            }
        }
    }
}
