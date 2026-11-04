
using SistemaCableInternet.BLL.Interfaces;
using SistemaCableInternet.BLL.Models;

namespace SistemaCableInternet.BLL.Services
{
    public class DireccionService
    {
        private readonly IDireccionRepository _direccionRepository;

        public DireccionService(IDireccionRepository direccionRepository)
        {
            _direccionRepository = direccionRepository;
        }

        // Listar direcciones
        public async Task<List<Direccion>> ListarAsync(
            string? buscar = null,
            int? contratoId = null,
            int? zonaId = null)
        {
            return await _direccionRepository.ListarAsync(
                buscar,
                contratoId,
                zonaId
            );
        }

        // Obtener dirección por ID
        public async Task<Direccion?> ObtenerPorIdAsync(int direccionId)
        {
            if (direccionId <= 0)
            {
                throw new Exception("El identificador de la dirección no es válido.");
            }

            return await _direccionRepository.ObtenerPorIdAsync(direccionId);
        }

        // Registrar dirección
        public async Task<int> InsertarAsync(Direccion direccion)
        {
            ValidarDireccion(direccion);

            if (direccion.ContratoId <= 0)
            {
                throw new Exception("Debe seleccionar un contrato.");
            }

            if (direccion.ZonaId <= 0)
            {
                throw new Exception("Debe seleccionar una zona.");
            }

            return await _direccionRepository.InsertarAsync(direccion);
        }

        // Actualizar dirección
        public async Task ActualizarAsync(Direccion direccion)
        {
            if (direccion == null || direccion.DireccionId <= 0)
            {
                throw new Exception("El identificador de la dirección no es válido.");
            }

            ValidarDireccion(direccion);

            if (direccion.ContratoId <= 0)
            {
                throw new Exception("Debe seleccionar un contrato.");
            }

            if (direccion.ZonaId <= 0)
            {
                throw new Exception("Debe seleccionar una zona.");
            }

            var existente = await _direccionRepository.ObtenerPorIdAsync(
                direccion.DireccionId
            );

            if (existente == null)
            {
                throw new Exception("La dirección que intenta actualizar no existe.");
            }

            await _direccionRepository.ActualizarAsync(direccion);
        }

        // Validaciones generales
        private void ValidarDireccion(Direccion direccion)
        {
            if (direccion == null)
            {
                throw new Exception("La información de la dirección es obligatoria.");
            }

            if (string.IsNullOrWhiteSpace(direccion.DireccionTexto))
            {
                throw new Exception("La dirección física es obligatoria.");
            }

            direccion.DireccionTexto = direccion.DireccionTexto.Trim();

            if (direccion.DireccionTexto.Length > 500)
            {
                throw new Exception("La dirección no puede superar los 500 caracteres.");
            }
        }
    }
}

