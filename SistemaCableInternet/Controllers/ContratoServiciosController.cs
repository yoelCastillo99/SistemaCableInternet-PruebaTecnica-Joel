
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaCableInternet.BLL.Models;
using SistemaCableInternet.BLL.Services;

namespace SistemaCableInternet.Controllers
{
    public class ContratoServiciosController : Controller
    {
        private readonly ContratoServicioService _contratoServicioService;
        private readonly ContratoService _contratoService;
        private readonly DireccionService _direccionService;
        private readonly ServicioService _servicioService;
        private readonly PlanService _planService;
        private readonly TarifaService _tarifaService;
        private readonly ZonaService _zonaService;

        public ContratoServiciosController(
            ContratoServicioService contratoServicioService,
            ContratoService contratoService,
            DireccionService direccionService,
            ServicioService servicioService,
            PlanService planService,
            TarifaService tarifaService,
            ZonaService zonaService)
        {
            _contratoServicioService = contratoServicioService;
            _contratoService = contratoService;
            _direccionService = direccionService;
            _servicioService = servicioService;
            _planService = planService;
            _tarifaService = tarifaService;
            _zonaService = zonaService;
        }

        // LISTAR
        public async Task<IActionResult> Index(
            int? contratoId,
            int? clienteId,
            string? estado)
        {
            var lista = await _contratoServicioService.ListarAsync(
                contratoId,
                clienteId,
                estado);

            ViewBag.Estado = estado;
            ViewBag.ContratoId = contratoId;

            return View(lista);
        }

        // MOSTRAR FORMULARIO
        public async Task<IActionResult> Create()
        {
            await CargarCombosAsync();

            return View(new ContratoServicio
            {
                FechaAlta = DateTime.Today,
                Estado = "Activo"
            });
        }

        // REGISTRAR
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            ContratoServicio contratoServicio)
        {
            try
            {
                await _contratoServicioService.InsertarAsync(
                    contratoServicio);

                TempData["Mensaje"] =
                    "Servicio contratado correctamente.";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);

                await CargarCombosAsync(
                    contratoServicio.ContratoId,
                    contratoServicio.DireccionId,
                    contratoServicio.ServicioId,
                    contratoServicio.PlanId,
                    contratoServicio.TarifaId);

                return View(contratoServicio);
            }
        }

        // EDITAR
        public async Task<IActionResult> Edit(int id)
        {
            var registro =
                await _contratoServicioService.ObtenerPorIdAsync(id);

            if (registro == null)
                return NotFound();

            await CargarCombosAsync(
                registro.ContratoId,
                registro.DireccionId,
                registro.ServicioId,
                registro.PlanId,
                registro.TarifaId);

            return View(registro);
        }

        // ACTUALIZAR
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            ContratoServicio contratoServicio)
        {
            try
            {
                await _contratoServicioService.ActualizarAsync(
                    contratoServicio);

                TempData["Mensaje"] =
                    "Servicio contratado actualizado correctamente.";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);

                await CargarCombosAsync(
                    contratoServicio.ContratoId,
                    contratoServicio.DireccionId,
                    contratoServicio.ServicioId,
                    contratoServicio.PlanId,
                    contratoServicio.TarifaId);

                return View(contratoServicio);
            }
        }

        // CAMBIAR ESTADO
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CambiarEstado(
            int id,
            string estado)
        {
            try
            {
                await _contratoServicioService.CambiarEstadoAsync(
                    id,
                    estado);

                TempData["Mensaje"] =
                    "Estado actualizado correctamente.";
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }

            return RedirectToAction(nameof(Index));
        }

        // CONSULTAR DIRECCIONES POR CONTRATO
        [HttpGet]
        public async Task<IActionResult> ObtenerDirecciones(int contratoId)
        {
            var direcciones = await _direccionService.ListarAsync(
                contratoId: contratoId);

            return Json(direcciones.Select(d => new
            {
                id = d.DireccionId,
                texto = d.DireccionTexto,
                zonaId = d.ZonaId
            }));
        }

        // CONSULTAR PLANES POR SERVICIO
        [HttpGet]
        public async Task<IActionResult> ObtenerPlanes(int servicioId)
        {
            var planes = await _planService.ListarAsync(
                servicioId: servicioId,
                activo: true);

            return Json(planes.Select(p => new
            {
                id = p.PlanId,
                nombre = p.Nombre
            }));
        }

        // CONSULTAR TARIFAS POR PLAN Y ZONA
        [HttpGet]
        public async Task<IActionResult> ObtenerTarifas(
            int planId,
            int zonaId)
        {
            var tarifas = await _tarifaService.ListarAsync(
                planId,
                zonaId);

            return Json(tarifas.Select(t => new
            {
                id = t.TarifaId,
                precio = t.PrecioMensual,
                nombre = t.NombrePlan,
                vigenciaDesde = t.VigenciaDesde.ToString("yyyy-MM-dd"),
                vigenciaHasta = t.VigenciaHasta?.ToString("yyyy-MM-dd")
            }));
        }

        // CARGAR COMBOS
        private async Task CargarCombosAsync(
            int? contratoSeleccionado = null,
            int? direccionSeleccionada = null,
            int? servicioSeleccionado = null,
            int? planSeleccionado = null,
            int? tarifaSeleccionada = null)
        {
            var contratos = await _contratoService.ListarAsync(
                estado: "Activo");

            var servicios = await _servicioService.ListarAsync(
                activo: true);

            var direcciones = contratoSeleccionado.HasValue
                ? await _direccionService.ListarAsync(
                    contratoId: contratoSeleccionado)
                : new List<Direccion>();

            var planes = servicioSeleccionado.HasValue
                ? await _planService.ListarAsync(
                    servicioId: servicioSeleccionado,
                    activo: true)
                : new List<Plan>();

            var direccionActual = direcciones.FirstOrDefault(
                d => d.DireccionId == direccionSeleccionada);

            var tarifas = direccionActual != null &&
                          planSeleccionado.HasValue
                ? await _tarifaService.ListarAsync(
                    planSeleccionado,
                    direccionActual.ZonaId)
                : new List<Tarifa>();

            ViewBag.Contratos = new SelectList(
                contratos,
                "ContratoId",
                "ContratoId",
                contratoSeleccionado);

            ViewBag.Servicios = new SelectList(
                servicios,
                "ServicioId",
                "Descripcion",
                servicioSeleccionado);

            ViewBag.Direcciones = new SelectList(
                direcciones,
                "DireccionId",
                "DireccionTexto",
                direccionSeleccionada);

            ViewBag.Planes = new SelectList(
                planes,
                "PlanId",
                "Nombre",
                planSeleccionado);

            ViewBag.Tarifas = new SelectList(
                tarifas,
                "TarifaId",
                "PrecioMensual",
                tarifaSeleccionada);
        }
    }
}
