using HelloShop.Business.Abstract;
using HelloShop.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloShop.WEB.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IClienteBusiness _clienteBusiness;
        private readonly ITipoDocumentoBusiness _tipoDocumentoBusiness;

        public ClientesController(IClienteBusiness clienteBusiness, ITipoDocumentoBusiness tipoDocumentoBusiness)
        {
            _clienteBusiness = clienteBusiness;
            _tipoDocumentoBusiness = tipoDocumentoBusiness;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.Titulo = "Gestión de Clientes";
            return View(await _clienteBusiness.ObtenerClientes());
        }
        [HttpGet]
        public async Task<IActionResult> Crear()
        {
            ViewBag.Titulo = "Crear cliente";
            ViewBag.TiposDocumento = new SelectList(await _tipoDocumentoBusiness.ObtenerTiposDocumento(), "TipoDocumentoId", "Nombre");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _clienteBusiness.Crear(cliente);
                    var guardar = await _clienteBusiness.GuardarCambios();
                    if (guardar)
                    {
                        TempData["Accion"] = "Guardar";
                        TempData["Mensaje"] = $"Se creó el cliente: {cliente.Nombres}";
                        return RedirectToAction("Index");
                    }

                }
                catch (Exception)
                {

                    throw;
                }
            }
            TempData["Accion"] = "Validacion";
            TempData["Mensaje"] = "Debe llenar los campos requeridos";
            ViewBag.TiposDocumento = new SelectList(await _tipoDocumentoBusiness.ObtenerTiposDocumento(), "TipoDocumentoId", "Nombre");
            return View(cliente);
        }

        public async Task<IActionResult> Detalle(int ? id)
        {
            if (id != null)
            {
                try
                {
                    var cliente = await _clienteBusiness.ObtenerClientePorId(id);
                    if (cliente != null)
                    {
                        return View(cliente);

                    }
                    return NotFound();

                }
                catch (Exception)
                {

                    throw;
                }

            }
            return NotFound();
        }

    }
}
