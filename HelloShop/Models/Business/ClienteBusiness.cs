using HelloShop.Models.DAL;
using HelloShop.Models.Entities;
using HelloShop.WEB.Models.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloShop.WEB.Models.Business
{
    public class ClienteBusiness:IClienteBusiness
    {
        private readonly AppDbContext _context;

        public ClienteBusiness(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cliente>> ObtenerClientes()
        {
            return await _context.Clientes.Include(x => x.TipoDocumento).ToListAsync();
        }

        public async Task<IEnumerable<Cliente>> ObtenerClientesPorTipoDocumento(int tipoDocumento)
        {
            return await _context.Clientes.Include(x => x.TipoDocumento).Where(x=>x.TipoDocumentoId== tipoDocumento).ToListAsync();
        }

        public void Algo()
        {
            var a = "a";
        }


    }
}
