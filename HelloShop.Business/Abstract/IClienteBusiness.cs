using HelloShop.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloShop.Business.Abstract
{
    public interface IClienteBusiness
    {
        Task<IEnumerable<Cliente>> ObtenerClientes();
        Task<IEnumerable<Cliente>> ObtenerClientesPorTipoDocumento(int tipoDocumento);
        void Crear(Cliente cliente);
        Task<bool> GuardarCambios();
    }
}
