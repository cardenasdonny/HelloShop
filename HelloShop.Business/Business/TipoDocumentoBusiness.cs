using HelloShop.Business.Abstract;
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
    public class TipoDocumentoBusiness : ITipoDocumentoBusiness
    {
        private readonly AppDbContext _context;

        public TipoDocumentoBusiness(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<TipoDocumento>> ObtenerTiposDocumento()
        {
            return await _context.TiposDocumento.ToListAsync();
        }
    }
}
