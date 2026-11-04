
using Microsoft.AspNetCore.Mvc;
using SistemaCableInternet.BLL.Models;
using SistemaCableInternet.BLL.Services;

namespace SistemaCableInternet.Controllers
{
    public class ZonasController : Controller
    {
        private readonly ZonaService _zonaService;

        public ZonasController(ZonaService zonaService)
        {
            _zonaService = zonaService;
        }

        // Listar zonas
        public async Task<IActionResult> Index(string? buscar, bool? activo)
        {
            var zonas = await _zonaService.ListarAsync(buscar, activo);

            ViewBag.Buscar = buscar;
            ViewBag.Activo = activo;

            return View(zonas);
        }

        // Mostrar formulario de registro
        public IActionResult Create()
        {
            return View();
        }

        // Registrar zona
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Zona zona)
        {
            try
            {
                await _zonaService.InsertarAsync(zona);

                TempData["Mensaje"] = "Zona registrada correctamente.";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);

                return View(zona);
            }
        }

        // Mostrar formulario de edición
        public async Task<IActionResult> Edit(int id)
        {
            var zona = await _zonaService.ObtenerPorIdAsync(id);

            if (zona == null)
            {
                return NotFound();
            }

            return View(zona);
        }

        // Actualizar zona
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Zona zona)
        {
            try
            {
                await _zonaService.ActualizarAsync(zona);

                TempData["Mensaje"] = "Zona actualizada correctamente.";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);

                return View(zona);
            }
        }

        // Activar o desactivar zona
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CambiarEstado(int id, bool activo)
        {
            try
            {
                await _zonaService.CambiarEstadoAsync(id, activo);

                TempData["Mensaje"] = "Estado de la zona actualizado correctamente.";
            }
            catch (Exception)
            {
                TempData["Error"] = "No fue posible cambiar el estado de la zona.";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}

