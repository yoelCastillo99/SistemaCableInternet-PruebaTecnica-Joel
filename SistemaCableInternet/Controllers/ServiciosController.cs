
using Microsoft.AspNetCore.Mvc;
using SistemaCableInternet.BLL.Models;
using SistemaCableInternet.BLL.Services;

namespace SistemaCableInternet.Controllers
{
    public class ServiciosController : Controller
    {
        private readonly ServicioService _servicioService;

        public ServiciosController(ServicioService servicioService)
        {
            _servicioService = servicioService;
        }

        // GET: Servicios
        public async Task<IActionResult> Index(string? buscar, bool? activo)
        {
            var servicios = await _servicioService.ListarAsync(buscar, activo);

            ViewBag.Buscar = buscar;
            ViewBag.Activo = activo;

            return View(servicios);
        }

        // GET: Servicios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Servicios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Servicio servicio)
        {
            try
            {
                await _servicioService.InsertarAsync(servicio);

                TempData["Mensaje"] = "Servicio registrado correctamente.";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(servicio);
            }
        }

        // GET: Servicios/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var servicio = await _servicioService.ObtenerPorIdAsync(id);

            if (servicio == null)
                return NotFound();

            return View(servicio);
        }

        // POST: Servicios/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Servicio servicio)
        {
            try
            {
                await _servicioService.ActualizarAsync(servicio);

                TempData["Mensaje"] = "Servicio actualizado correctamente.";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(servicio);
            }
        }

        // POST: Servicios/CambiarEstado
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CambiarEstado(int id, bool activo)
        {
            try
            {
                await _servicioService.CambiarEstadoAsync(id, activo);

                TempData["Mensaje"] = activo
                    ? "Servicio activado correctamente."
                    : "Servicio desactivado correctamente.";
            }
            catch (Exception)
            {
                TempData["Error"] = "No fue posible cambiar el estado del servicio.";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}

