using HelloShop.Business.Dtos.Clientes;
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
        Task<IEnumerable<ClienteDetalleGestionarDto>> ObtenerClientes();
        Task<IEnumerable<Cliente>> ObtenerClientesPorTipoDocumento(int tipoDocumento);
        Task<Cliente> ObtenerClientePorId(int? id);
        void Crear(RegistroClienteDto registroClienteDto);
        void Editar(Cliente cliente);
        Task<bool> GuardarCambios();
    }
}
