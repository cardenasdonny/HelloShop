using HelloShop.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloShop.DAL
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoDocumento>().HasData(
               new TipoDocumento
               {
                   TipoDocumentoId = 1,
                   Nombre = "TI"
               },
               new TipoDocumento
               {
                   TipoDocumentoId = 2,
                   Nombre = "CC"
               },
               new TipoDocumento
               {
                   TipoDocumentoId = 3,
                   Nombre = "CE"
               }
            );

            //CLIENTES

            modelBuilder.Entity<Cliente>().HasData(

                new Cliente { 
                    ClienteId = 1,
                    Nombres = "Cliente generado",
                    Email = "generado@generado.com",
                    Estado = true,
                    Documento = "123456789",
                    TipoDocumentoId = 1                
                },
                new Cliente
                {
                    ClienteId = 2,
                    Nombres = "Cliente generado 2",
                    Email = "generado2@generado.com",
                    Estado = true,
                    Documento = "987654321",
                    TipoDocumentoId = 2
                },
                new Cliente
                {
                    ClienteId = 3,
                    Nombres = "Cliente generado 3",
                    Email = "generado3@generado.com",
                    Estado = true,
                    Documento = "88990022",
                    TipoDocumentoId = 3
            });
        }
    }
}
