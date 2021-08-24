using HelloShop.Models.DAL;
using HelloShop.WEB.Models.Abstract;
using HelloShop.WEB.Models.Business;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloShop.WEB.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IClienteBusiness _clienteBusiness;

        public ClientesController(IClienteBusiness clienteBusiness)
        {
            _clienteBusiness = clienteBusiness;
        }
        public async Task<IActionResult> Index()
        {
            _clienteBusiness.
            return View(await _clienteBusiness.ObtenerClientes());
        }
    }
}
