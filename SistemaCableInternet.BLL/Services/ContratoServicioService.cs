
using SistemaCableInternet.BLL.Interfaces;
using SistemaCableInternet.BLL.Models;

namespace SistemaCableInternet.BLL.Services
{
    public class ContratoServicioService
    {
        private readonly IContratoServicioRepository _repository;

        public ContratoServicioService(
            IContratoServicioRepository repository)
        {
            _repository = repository;
        }

        // LISTAR
        public async Task<List<ContratoServicio>> ListarAsync(
            int? contratoId = null,
            int? clienteId = null,
            string? estado = null)
        {
            if (!string.IsNullOrWhiteSpace(estado) &&
                !new[] { "Activo", "Suspendido", "Finalizado" }
                    .Contains(estado))
            {
                throw new Exception("El estado indicado no es válido.");
            }

            return await _repository.ListarAsync(
                contratoId,
                clienteId,
                estado
            );
        }

        // OBTENER POR ID
        public async Task<ContratoServicio?> ObtenerPorIdAsync(
            int contratoServicioId)
        {
            if (contratoServicioId <= 0)
            {
                throw new Exception(
                    "El identificador del servicio no es válido.");
            }

            return await _repository.ObtenerPorIdAsync(
                contratoServicioId);
        }

        // INSERTAR
        public async Task<int> InsertarAsync(
            ContratoServicio contratoServicio)
        {
            ValidarDatos(contratoServicio);

            if (contratoServicio.ContratoId <= 0)
                throw new Exception("Debe seleccionar un contrato.");

            if (contratoServicio.PlanId <= 0)
                throw new Exception("Debe seleccionar un plan.");

            if (contratoServicio.ServicioId <= 0)
                throw new Exception("Debe seleccionar un servicio.");

            if (contratoServicio.DireccionId <= 0)
                throw new Exception("Debe seleccionar una dirección.");

            if (contratoServicio.TarifaId <= 0)
                throw new Exception("Debe seleccionar una tarifa.");

            return await _repository.InsertarAsync(contratoServicio);
        }

        // ACTUALIZAR
        public async Task ActualizarAsync(
            ContratoServicio contratoServicio)
        {
            if (contratoServicio == null ||
                contratoServicio.ContratoServicioId <= 0)
            {
                throw new Exception(
                    "El identificador del servicio no es válido.");
            }

            ValidarDatos(contratoServicio);

            if (contratoServicio.ContratoId <= 0 ||
                contratoServicio.PlanId <= 0 ||
                contratoServicio.ServicioId <= 0 ||
                contratoServicio.DireccionId <= 0 ||
                contratoServicio.TarifaId <= 0)
            {
                throw new Exception(
                    "Debe completar todos los datos de la asignación.");
            }

            var existente = await _repository.ObtenerPorIdAsync(
                contratoServicio.ContratoServicioId);

            if (existente == null)
            {
                throw new Exception(
                    "El servicio contratado no existe.");
            }

            await _repository.ActualizarAsync(contratoServicio);
        }

        // CAMBIAR ESTADO
        public async Task CambiarEstadoAsync(
            int contratoServicioId,
            string estado)
        {
            if (contratoServicioId <= 0)
            {
                throw new Exception(
                    "El identificador del servicio no es válido.");
            }

            if (!new[] { "Activo", "Suspendido", "Finalizado" }
                .Contains(estado))
            {
                throw new Exception("El estado indicado no es válido.");
            }

            var existente = await _repository.ObtenerPorIdAsync(
                contratoServicioId);

            if (existente == null)
            {
                throw new Exception(
                    "El servicio contratado no existe.");
            }

            await _repository.CambiarEstadoAsync(
                contratoServicioId,
                estado);
        }

        // VALIDACIONES GENERALES
        private void ValidarDatos(ContratoServicio contratoServicio)
        {
            if (contratoServicio == null)
            {
                throw new Exception(
                    "La información del servicio es obligatoria.");
            }

            if (contratoServicio.FechaAlta == default)
            {
                throw new Exception(
                    "Debe indicar la fecha de alta.");
            }
        }
    }
}

