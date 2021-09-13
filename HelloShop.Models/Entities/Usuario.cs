using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloShop.Models.Entities
{
    public class Usuario: IdentityUser
    {
        public bool Estado { get; set; }
    }
}
