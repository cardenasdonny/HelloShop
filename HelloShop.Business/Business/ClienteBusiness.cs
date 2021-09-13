using HelloShop.Business.Abstract;
using HelloShop.Business.Dtos.Clientes;
using HelloShop.DAL;
using HelloShop.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloShop.Business.Business
{
    public class ClienteBusiness : IClienteBusiness
    {
        private readonly AppDbContext _context;

        public ClienteBusiness(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ClienteDetalleGestionarDto>> ObtenerClientes()
        {
            List<ClienteDetalleGestionarDto> listaClienteDetalleGestionarDto = new();

            var clientes = await _context.Clientes.Include(x => x.TipoDocumento).ToListAsync();
            clientes.ForEach(c => 
            {
                ClienteDetalleGestionarDto clienteDetalleGestionarDto = new()
                {
                    ClienteId = c.ClienteId,
                    Nombres = c.Nombres,
                    Email = c.Email,
                    Documento = c.Documento,
                    Estado = ObtenerEstado(c.Estado),
                    TipoDocumento = c.TipoDocumento.Nombre
                };
                listaClienteDetalleGestionarDto.Add(clienteDetalleGestionarDto);
            });
            return listaClienteDetalleGestionarDto;

        }

        private string ObtenerEstado(bool estado)
        {
            if (estado)
                return "Activo";
            else
                return "Deshabilitado";
        }


        public async Task<IEnumerable<Cliente>> ObtenerClientesPorTipoDocumento(int tipoDocumento)
        {
            return await _context.Clientes.Include(x => x.TipoDocumento).Where(x => x.TipoDocumentoId == tipoDocumento).ToListAsync();
        }

        public async Task<Cliente> ObtenerClientePorId(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            return await _context.Clientes.Include(x => x.TipoDocumento).FirstOrDefaultAsync(x => x.ClienteId == id);
        }

        public void Crear (RegistroClienteDto registroClienteDto)
        {
            if (registroClienteDto == null)
                throw new ArgumentNullException(nameof(registroClienteDto));
            registroClienteDto.Estado = true;

            Cliente cliente = new()
            {
                ClienteId = registroClienteDto.ClienteId,
                Nombres = registroClienteDto.Nombres,
                Documento = registroClienteDto.Documento,
                Email = registroClienteDto.Email,
                Estado = registroClienteDto.Estado,
                TipoDocumentoId = registroClienteDto.TipoDocumentoId
            };

            _context.Add(cliente);
        }
        public void Editar(Cliente cliente)
        {
            if (cliente == null)
                throw new ArgumentNullException(nameof(cliente));      
            _context.Update(cliente);
        }
        public async Task<bool> GuardarCambios()
        {
            return await _context.SaveChangesAsync() > 0;
        }

    }
}
