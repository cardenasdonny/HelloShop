using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloShop.Models.Models
{
    public class Cliente
    {
        public int ClienteId { get; set;  }
        public string Nombres { get; set; }
        public string Email { get; set; }
        public int TipoDocumentoId { get; set; }
        public string Documento { get; set; }
    }
}
