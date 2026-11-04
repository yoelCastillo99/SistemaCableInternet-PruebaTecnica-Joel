
using SistemaCableInternet.BLL.Interfaces;
using SistemaCableInternet.BLL.Models;

namespace SistemaCableInternet.BLL.Services
{
    public class ContratoService
    {
        private readonly IContratoRepository _contratoRepository;

        public ContratoService(IContratoRepository contratoRepository)
        {
            _contratoRepository = contratoRepository;
        }

        // LISTAR CONTRATOS
        public async Task<List<Contrato>> ListarAsync(
            string? buscar = null,
            string? estado = null)
        {
            return await _contratoRepository.ListarAsync(buscar, estado);
        }

        // OBTENER CONTRATO POR ID
        public async Task<Contrato?> ObtenerPorIdAsync(int contratoId)
        {
            if (contratoId <= 0)
            {
                throw new Exception("El identificador del contrato no es válido.");
            }

            return await _contratoRepository.ObtenerPorIdAsync(contratoId);
        }

        // INSERTAR CONTRATO
        public async Task<int> InsertarAsync(Contrato contrato)
        {
            ValidarContrato(contrato);

            return await _contratoRepository.InsertarAsync(contrato);
        }

        // ACTUALIZAR CONTRATO
        public async Task ActualizarAsync(Contrato contrato)
        {
            if (contrato.ContratoId <= 0)
            {
                throw new Exception("El identificador del contrato no es válido.");
            }

            ValidarContrato(contrato);

            await _contratoRepository.ActualizarAsync(contrato);
        }

        // CAMBIAR ESTADO
        public async Task CambiarEstadoAsync(int contratoId, string estado)
        {
            if (contratoId <= 0)
            {
                throw new Exception("El identificador del contrato no es válido.");
            }

            if (string.IsNullOrWhiteSpace(estado))
            {
                throw new Exception("Debe seleccionar un estado.");
            }

            string[] estadosPermitidos =
            {
                "Activo",
                "Suspendido",
                "Finalizado"
            };

            if (!estadosPermitidos.Contains(estado))
            {
                throw new Exception("El estado seleccionado no es válido.");
            }

            await _contratoRepository.CambiarEstadoAsync(contratoId, estado);
        }

        // VALIDACIONES GENERALES
        private void ValidarContrato(Contrato contrato)
        {
            if (contrato == null)
            {
                throw new Exception("La información del contrato es obligatoria.");
            }

            if (contrato.ClienteId <= 0)
            {
                throw new Exception("Debe seleccionar un cliente.");
            }

            if (contrato.FechaInicio == default)
            {
                throw new Exception("Debe ingresar la fecha de inicio.");
            }

            if (contrato.FechaFin.HasValue &&
                contrato.FechaFin.Value.Date < contrato.FechaInicio.Date)
            {
                throw new Exception(
                    "La fecha de finalización no puede ser anterior a la fecha de inicio."
                );
            }

            if (contrato.DiaPago < 1 || contrato.DiaPago > 31)
            {
                throw new Exception(
                    "El día de pago debe estar entre 1 y 31."
                );
            }
        }
    }
}

