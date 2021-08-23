﻿// <auto-generated />
using HelloShop.Models.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HelloShop.WEB.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.9");

            modelBuilder.Entity("HelloShop.Models.Entities.Cliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Documento")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("Estado")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<int>("TipoDocumentoId")
                        .HasColumnType("int");

                    b.HasKey("ClienteId");

                    b.HasIndex("TipoDocumentoId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("HelloShop.Models.Entities.TipoDocumento", b =>
                {
                    b.Property<int>("TipoDocumentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("longtext");

                    b.HasKey("TipoDocumentoId");

                    b.ToTable("TiposDocumento");
                });

            modelBuilder.Entity("HelloShop.Models.Entities.Cliente", b =>
                {
                    b.HasOne("HelloShop.Models.Entities.TipoDocumento", "TipoDocumento")
                        .WithMany("Clientes")
                        .HasForeignKey("TipoDocumentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoDocumento");
                });

            modelBuilder.Entity("HelloShop.Models.Entities.TipoDocumento", b =>
                {
                    b.Navigation("Clientes");
                });
#pragma warning restore 612, 618
        }
    }
}
