using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloShop.Models.Entities
{
    public class TipoDocumento
    {
        public int TipoDocumentoId { get; set; }
        public string Nombre { get; set; }

        public virtual List<Cliente> Clientes { get; set; }
    }
}
