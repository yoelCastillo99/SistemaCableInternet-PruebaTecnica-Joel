
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaCableInternet.BLL.Models;
using SistemaCableInternet.BLL.Services;

namespace SistemaCableInternet.Controllers
{
    public class DireccionesController : Controller
    {
        private readonly DireccionService _direccionService;
        private readonly ZonaService _zonaService;
        private readonly ContratoService _contratoService;

        public DireccionesController(
            DireccionService direccionService,
            ZonaService zonaService,
            ContratoService contratoService)
        {
            _direccionService = direccionService;
            _zonaService = zonaService;
            _contratoService = contratoService;
        }

        // Listar direcciones
        public async Task<IActionResult> Index(
            string? buscar,
            int? contratoId,
            int? zonaId)
        {
            var direcciones = await _direccionService.ListarAsync(
                buscar,
                contratoId,
                zonaId
            );

            ViewBag.Buscar = buscar;
            ViewBag.ContratoId = contratoId;
            ViewBag.ZonaId = zonaId;

            await CargarListasAsync();

            return View(direcciones);
        }

        // Mostrar formulario de registro
        public async Task<IActionResult> Create()
        {
            await CargarListasAsync();

            return View();
        }

        // Registrar dirección
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Direccion direccion)
        {
            try
            {
                await _direccionService.InsertarAsync(direccion);

                TempData["Mensaje"] =
                    "Dirección de instalación registrada correctamente.";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);

                await CargarListasAsync(
                    direccion.ContratoId,
                    direccion.ZonaId
                );

                return View(direccion);
            }
        }

        // Mostrar formulario de edición
        public async Task<IActionResult> Edit(int id)
        {
            var direccion = await _direccionService.ObtenerPorIdAsync(id);

            if (direccion == null)
            {
                return NotFound();
            }

            await CargarListasAsync(
                direccion.ContratoId,
                direccion.ZonaId
            );

            return View(direccion);
        }

        // Actualizar dirección
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Direccion direccion)
        {
            try
            {
                await _direccionService.ActualizarAsync(direccion);

                TempData["Mensaje"] =
                    "Dirección de instalación actualizada correctamente.";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);

                await CargarListasAsync(
                    direccion.ContratoId,
                    direccion.ZonaId
                );

                return View(direccion);
            }
        }

        // Cargar contratos y zonas para los formularios
        private async Task CargarListasAsync(
            int? contratoSeleccionado = null,
            int? zonaSeleccionada = null)
        {
            var contratos = await _contratoService.ListarAsync(
                null,
                "Activo"
            );

            ViewBag.Contratos = contratos.Select(c =>
                new SelectListItem
                {
                    Value = c.ContratoId.ToString(),
                    Text = $"Contrato #{c.ContratoId} - {c.Codigo} - {c.Cliente}",
                    Selected = c.ContratoId == contratoSeleccionado
                }).ToList();

            var zonas = await _zonaService.ListarAsync(null, true);

            ViewBag.Zonas = zonas.Select(z =>
                new SelectListItem
                {
                    Value = z.ZonaId.ToString(),
                    Text = z.Nombre,
                    Selected = z.ZonaId == zonaSeleccionada
                }).ToList();
        }
    }
}

