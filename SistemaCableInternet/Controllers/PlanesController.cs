
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaCableInternet.BLL.Models;
using SistemaCableInternet.BLL.Services;

namespace SistemaCableInternet.Controllers
{
    public class PlanesController : Controller
    {
        private readonly PlanService _planService;
        private readonly ServicioService _servicioService;

        public PlanesController(
            PlanService planService,
            ServicioService servicioService)
        {
            _planService = planService;
            _servicioService = servicioService;
        }

        // GET: Planes
        public async Task<IActionResult> Index(
            string? buscar,
            int? servicioId,
            bool? activo)
        {
            var planes = await _planService.ListarAsync(
                buscar, servicioId, activo);

            await CargarServiciosAsync();

            ViewBag.Buscar = buscar;
            ViewBag.ServicioId = servicioId;
            ViewBag.Activo = activo;

            return View(planes);
        }

        // GET: Planes/Create
        public async Task<IActionResult> Create()
        {
            await CargarServiciosAsync();
            return View();
        }

        // POST: Planes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Plan plan)
        {
            try
            {
                await _planService.InsertarAsync(plan);

                TempData["Mensaje"] = "Plan registrado correctamente.";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                await CargarServiciosAsync(plan.ServicioId);
                return View(plan);
            }
        }

        // GET: Planes/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var plan = await _planService.ObtenerPorIdAsync(id);

            if (plan == null)
                return NotFound();

            await CargarServiciosAsync(plan.ServicioId);

            return View(plan);
        }

        // POST: Planes/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Plan plan)
        {
            try
            {
                await _planService.ActualizarAsync(plan);

                TempData["Mensaje"] = "Plan actualizado correctamente.";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                await CargarServiciosAsync(plan.ServicioId);
                return View(plan);
            }
        }

        // POST: Planes/CambiarEstado
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CambiarEstado(
            int id,
            bool activo)
        {
            try
            {
                await _planService.CambiarEstadoAsync(id, activo);

                TempData["Mensaje"] = activo
                    ? "Plan activado correctamente."
                    : "Plan desactivado correctamente.";
            }
            catch (Exception)
            {
                TempData["Error"] =
                    "No fue posible cambiar el estado del plan.";
            }

            return RedirectToAction(nameof(Index));
        }

        // Cargar servicios para los formularios y filtros
        private async Task CargarServiciosAsync(int? seleccionado = null)
        {
            var servicios = await _servicioService.ListarAsync(
                activo: true);

            ViewBag.Servicios = new SelectList(
                servicios,
                "ServicioId",
                "Descripcion",
                seleccionado);
        }
    }
}

