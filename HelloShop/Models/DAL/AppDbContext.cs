using HelloShop.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloShop.Models.DAL
{
    public class AppDbContext:DbContext
    {
        //opciones como la cadena de conexión
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        //DbSet o representación de nuestras tablas
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<TipoDocumento> TiposDocumento { get; set; }
    }
}
