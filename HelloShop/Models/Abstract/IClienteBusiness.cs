using HelloShop.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloShop.WEB.Models.Abstract
{
    public interface IClienteBusiness
    {
        Task<IEnumerable<Cliente>> ObtenerClientes();
        Task<IEnumerable<Cliente>> ObtenerClientesPorTipoDocumento(int tipoDocumento);
    }
}
