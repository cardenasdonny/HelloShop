using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloShop.Models.Entities
{
    public class Cliente
    {
        public int ClienteId { get; set; }        
        public string Nombres { get; set; }        
        public string Email { get; set; }
        public string Documento { get; set; }
        public bool Estado { get; set; }
        public int TipoDocumentoId { get; set; }
        public virtual TipoDocumento TipoDocumento { get; set; }
    }
}
