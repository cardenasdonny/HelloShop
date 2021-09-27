using HelloShop.Business.Dtos.Clientes;
using HelloShop.Business.Dtos.Roles;
using HelloShop.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloShop.WEB.Controllers
{
    public class RolesController : Controller
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RolesController(UserManager<Usuario> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Index()
        {
            ViewBag.Titulo = "Roles";
            var roles = await _roleManager.Roles.ToListAsync();
            return View(roles);
        }
        public IActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Crear(RolRegistroDto rolRegistroDto)
        {
            var resultado = await _roleManager.CreateAsync(new IdentityRole(rolRegistroDto.Rol));
            if(resultado.Succeeded)
                return Json(new { isValid = true, operacion = "crear" });
            return View();
        }
    }
}
