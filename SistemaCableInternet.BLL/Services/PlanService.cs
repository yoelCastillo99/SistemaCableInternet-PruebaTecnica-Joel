
using SistemaCableInternet.BLL.Interfaces;
using SistemaCableInternet.BLL.Models;

namespace SistemaCableInternet.BLL.Services
{
    public class PlanService
    {
        private readonly IPlanRepository _planRepository;

        public PlanService(IPlanRepository planRepository)
        {
            _planRepository = planRepository;
        }

        public async Task<List<Plan>> ListarAsync(
            string? buscar = null,
            int? servicioId = null,
            bool? activo = null)
        {
            return await _planRepository.ListarAsync(
                buscar, servicioId, activo);
        }

        public async Task<Plan?> ObtenerPorIdAsync(int planId)
        {
            if (planId <= 0)
                throw new ArgumentException("El ID del plan no es válido.");

            return await _planRepository.ObtenerPorIdAsync(planId);
        }

        public async Task<int> InsertarAsync(Plan plan)
        {
            ValidarPlan(plan);

            return await _planRepository.InsertarAsync(plan);
        }

        public async Task ActualizarAsync(Plan plan)
        {
            if (plan.PlanId <= 0)
                throw new ArgumentException("El ID del plan no es válido.");

            ValidarPlan(plan);

            await _planRepository.ActualizarAsync(plan);
        }

        public async Task CambiarEstadoAsync(int planId, bool activo)
        {
            if (planId <= 0)
                throw new ArgumentException("El ID del plan no es válido.");

            await _planRepository.CambiarEstadoAsync(planId, activo);
        }

        private void ValidarPlan(Plan plan)
        {
            if (plan == null)
                throw new ArgumentNullException(nameof(plan));

            if (plan.ServicioId <= 0)
                throw new ArgumentException("Debe seleccionar un servicio.");

            if (string.IsNullOrWhiteSpace(plan.Nombre))
                throw new ArgumentException("El nombre del plan es obligatorio.");

            if (plan.Nombre.Trim().Length > 100)
                throw new ArgumentException("El nombre no puede superar los 100 caracteres.");

            if (plan.VelocidadMbps.HasValue && plan.VelocidadMbps.Value <= 0)
                throw new ArgumentException("La velocidad debe ser mayor que cero.");

            if (plan.Canales.HasValue && plan.Canales.Value <= 0)
                throw new ArgumentException("La cantidad de canales debe ser mayor que cero.");

            if (plan.VelocidadMbps.HasValue && plan.Canales.HasValue)
                throw new ArgumentException(
                    "Un plan no puede tener velocidad y canales al mismo tiempo.");

            if (!plan.VelocidadMbps.HasValue && !plan.Canales.HasValue)
                throw new ArgumentException(
                    "Debe ingresar una velocidad o una cantidad de canales.");
        }
    }
}

