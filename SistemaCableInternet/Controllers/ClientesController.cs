
using Microsoft.AspNetCore.Mvc;
using SistemaCableInternet.BLL.Models;
using SistemaCableInternet.BLL.Services;

namespace SistemaCableInternet.Controllers
{
    public class ClientesController : Controller
    {
        private readonly ClienteService _clienteService;

        public ClientesController(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        // GET: Clientes
        // Listar y buscar clientes
        public async Task<IActionResult> Index(string? buscar, bool? activo)
        {
            try
            {
                var clientes = await _clienteService.ListarAsync(buscar, activo);

                ViewBag.Buscar = buscar;
                ViewBag.Activo = activo;

                return View(clientes);
            }
            catch (Exception)
            {
                TempData["Error"] = "No fue posible consultar los clientes.";
                return View(new List<Cliente>());
            }
        }

        // GET: Clientes/Create
        // Mostrar formulario de registro
        [HttpGet]
        public IActionResult Create()
        {
            var cliente = new Cliente
            {
                FechaAlta = DateTime.Today,
                Activo = true
            };

            return View(cliente);
        }

        // POST: Clientes/Create
        // Registrar cliente
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Cliente cliente)
        {
            try
            {
                cliente.Activo = true;

                int clienteId = await _clienteService.InsertarAsync(cliente);

                TempData["Mensaje"] =
                    $"Cliente registrado correctamente. ID: {clienteId}";

                return RedirectToAction(nameof(Index));
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(cliente);
            }
            catch (Exception)
            {
                ModelState.AddModelError(
                    string.Empty,
                    "Ocurrió un error al registrar el cliente. Verifica que el código no esté duplicado."
                );

                return View(cliente);
            }
        }

        // GET: Clientes/Edit/5
        // Mostrar formulario de edición
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var cliente = await _clienteService.ObtenerPorIdAsync(id);

                if (cliente == null)
                {
                    return NotFound();
                }

                return View(cliente);
            }
            catch (Exception)
            {
                TempData["Error"] = "No fue posible consultar el cliente.";
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Clientes/Edit/5
        // Actualizar cliente
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Cliente cliente)
        {
            if (id != cliente.ClienteId)
            {
                return BadRequest();
            }

            try
            {
                await _clienteService.ActualizarAsync(cliente);

                TempData["Mensaje"] = "Cliente actualizado correctamente.";

                return RedirectToAction(nameof(Index));
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(cliente);
            }
            catch (Exception)
            {
                ModelState.AddModelError(
                    string.Empty,
                    "No fue posible actualizar el cliente. Verifica que el código no esté duplicado."
                );

                return View(cliente);
            }
        }

        // POST: Clientes/CambiarEstado
        // Activar o desactivar cliente
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CambiarEstado(int id, bool activo)
        {
            try
            {
                await _clienteService.CambiarEstadoAsync(id, activo);

                TempData["Mensaje"] = activo
                    ? "Cliente activado correctamente."
                    : "Cliente desactivado correctamente.";
            }
            catch (Exception)
            {
                TempData["Error"] = "No fue posible cambiar el estado del cliente.";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}

