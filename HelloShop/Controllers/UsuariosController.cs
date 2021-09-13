using HelloShop.Business.Abstract;
using HelloShop.Business.Dtos.Usuarios;
using HelloShop.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloShop.WEB.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IUsuarioBusiness _usuarioBusiness;

        public UsuariosController(IUsuarioBusiness usuarioBusiness)
        {
            _usuarioBusiness = usuarioBusiness;
        }
        public IActionResult Index()
        {
            ViewBag.Titulo = "Gestión de Usuarios";
            List<Usuario> usuarios = new();
            return View(usuarios);
        }
        public IActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Crear(RegistrarUsuarioDto registrarUsuario)
        {

            if (ModelState.IsValid)
            {
                //comprobar su existe el usuario con ese correo
                var email = await _usuarioBusiness.ObtenerUsuarioDtoPorEmail(registrarUsuario.Email);
                if (email == null)
                {
                    try
                    {
                        var usuarioId = await _usuarioBusiness.Crear(registrarUsuario);
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }


            return View(registrarUsuario);
        }
    }
}
