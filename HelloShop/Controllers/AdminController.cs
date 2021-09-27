using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloShop.WEB.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        
        public IActionResult Dashboard()
        {
            return View();
        }
        public IActionResult NoAutorizado()
        {
            return View();
        }
    }
}
