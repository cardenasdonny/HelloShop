using HelloShop.Business.Abstract;
using HelloShop.Business.Dtos.Usuarios;
using HelloShop.Models.Entities;
using HelloShop.WEB.Helpers;
using Microsoft.AspNetCore.Identity;
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
        private readonly SignInManager<Usuario> _signInManager;

        public UsuariosController(IUsuarioBusiness usuarioBusiness, SignInManager<Usuario> signInManager)
        {
            _usuarioBusiness = usuarioBusiness;
            _signInManager = signInManager;
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

                        if (usuarioId == null)
                            return Json(new { isValid = false, tipoError = "danger", error = "Error al crear el usuario" });

                        if (usuarioId.Equals("ErrorPassword"))
                            return Json(new { isValid = false, tipoError = "danger", error = "Error de password" });
                        
                        return Json(new { isValid = true, operacion = "crear" });
                    }
                    catch (Exception)
                    {

                        return Json(new { isValid = false, tipoError = "danger", error = "Error al crear el usuario" });
                    }
                }
            }
            return Json(new { isValid = false, tipoError = "warning", error = "Debe diligenciar los campos requeridos", html = Helper.RenderRazorViewToString(this, "Crear", registrarUsuario) });


            
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (ModelState.IsValid)
            {
                var resultado = await _signInManager.PasswordSignInAsync(loginDto.Email, loginDto.Password, loginDto.RecordarMe, false);
                if (resultado.Succeeded)
                    return RedirectToAction("Dashboard","Admin");


            }


            return View();
        }
    }
}
