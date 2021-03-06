using Microsoft.EntityFrameworkCore.Migrations;

namespace HelloShop.DAL.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TiposDocumento",
                columns: table => new
                {
                    TipoDocumentoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposDocumento", x => x.TipoDocumentoId);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Documento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    TipoDocumentoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                    table.ForeignKey(
                        name: "FK_Clientes_TiposDocumento_TipoDocumentoId",
                        column: x => x.TipoDocumentoId,
                        principalTable: "TiposDocumento",
                        principalColumn: "TipoDocumentoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TiposDocumento",
                columns: new[] { "TipoDocumentoId", "Nombre" },
                values: new object[] { 1, "TI" });

            migrationBuilder.InsertData(
                table: "TiposDocumento",
                columns: new[] { "TipoDocumentoId", "Nombre" },
                values: new object[] { 2, "CC" });

            migrationBuilder.InsertData(
                table: "TiposDocumento",
                columns: new[] { "TipoDocumentoId", "Nombre" },
                values: new object[] { 3, "CE" });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "ClienteId", "Documento", "Email", "Estado", "Nombres", "TipoDocumentoId" },
                values: new object[] { 1, "123456789", "generado@generado.com", true, "Cliente generado", 1 });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "ClienteId", "Documento", "Email", "Estado", "Nombres", "TipoDocumentoId" },
                values: new object[] { 2, "987654321", "generado2@generado.com", true, "Cliente generado 2", 2 });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "ClienteId", "Documento", "Email", "Estado", "Nombres", "TipoDocumentoId" },
                values: new object[] { 3, "88990022", "generado3@generado.com", true, "Cliente generado 3", 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_TipoDocumentoId",
                table: "Clientes",
                column: "TipoDocumentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "TiposDocumento");
        }
    }
}
