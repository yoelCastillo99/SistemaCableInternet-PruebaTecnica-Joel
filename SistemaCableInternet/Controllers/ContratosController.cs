
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaCableInternet.BLL.Models;
using SistemaCableInternet.BLL.Services;

namespace SistemaCableInternet.Controllers
{
    public class ContratosController : Controller
    {
        private readonly ContratoService _contratoService;
        private readonly ClienteService _clienteService;

        public ContratosController(
            ContratoService contratoService,
            ClienteService clienteService)
        {
            _contratoService = contratoService;
            _clienteService = clienteService;
        }

        // LISTAR CONTRATOS
        public async Task<IActionResult> Index(string? buscar, string? estado)
        {
            var contratos = await _contratoService.ListarAsync(buscar, estado);

            ViewBag.Buscar = buscar;
            ViewBag.Estado = estado;

            return View(contratos);
        }

        // MOSTRAR FORMULARIO DE REGISTRO
        public async Task<IActionResult> Create()
        {
            await CargarClientesAsync();

            return View();
        }

        // REGISTRAR CONTRATO
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Contrato contrato)
        {
            try
            {
                await _contratoService.InsertarAsync(contrato);

                TempData["Mensaje"] = "Contrato registrado correctamente.";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);

                await CargarClientesAsync(contrato.ClienteId);

                return View(contrato);
            }
        }

        // MOSTRAR FORMULARIO DE EDICIÓN
        public async Task<IActionResult> Edit(int id)
        {
            var contrato = await _contratoService.ObtenerPorIdAsync(id);

            if (contrato == null)
            {
                return NotFound();
            }

            await CargarClientesAsync(contrato.ClienteId);

            return View(contrato);
        }

        // ACTUALIZAR CONTRATO
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Contrato contrato)
        {
            try
            {
                await _contratoService.ActualizarAsync(contrato);

                TempData["Mensaje"] = "Contrato actualizado correctamente.";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);

                await CargarClientesAsync(contrato.ClienteId);

                return View(contrato);
            }
        }

        // CAMBIAR ESTADO
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CambiarEstado(int id, string estado)
        {
            try
            {
                await _contratoService.CambiarEstadoAsync(id, estado);

                TempData["Mensaje"] =
                    "Estado del contrato actualizado correctamente.";
            }
            catch (Exception)
            {
                TempData["Error"] =
                    "No fue posible cambiar el estado del contrato.";
            }

            return RedirectToAction(nameof(Index));
        }

        // CARGAR CLIENTES ACTIVOS EN EL COMBOBOX
        private async Task CargarClientesAsync(int? seleccionado = null)
        {
            var clientes = await _clienteService.ListarAsync(activo: true);

            ViewBag.Clientes = new SelectList(
                clientes,
                "ClienteId",
                "Nombre",
                seleccionado
            );
        }
    }
}

