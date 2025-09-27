using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Pc2_Progra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inmuebles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Codigo = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Titulo = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Imagen = table.Column<string>(type: "TEXT", nullable: true),
                    Tipo = table.Column<string>(type: "TEXT", nullable: false),
                    Ciudad = table.Column<string>(type: "TEXT", nullable: false),
                    Direccion = table.Column<string>(type: "TEXT", nullable: false),
                    Dormitorios = table.Column<int>(type: "INTEGER", nullable: false),
                    Banos = table.Column<int>(type: "INTEGER", nullable: false),
                    MetrosCuadrados = table.Column<int>(type: "INTEGER", nullable: false),
                    Precio = table.Column<decimal>(type: "TEXT", nullable: false),
                    Activo = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inmuebles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    InmuebleId = table.Column<int>(type: "INTEGER", nullable: false),
                    UsuarioId = table.Column<string>(type: "TEXT", nullable: false),
                    FechaExpiracion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservas_Inmuebles_InmuebleId",
                        column: x => x.InmuebleId,
                        principalTable: "Inmuebles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Visitas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    InmuebleId = table.Column<int>(type: "INTEGER", nullable: false),
                    UsuarioId = table.Column<string>(type: "TEXT", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Estado = table.Column<string>(type: "TEXT", nullable: false),
                    Notas = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Visitas_Inmuebles_InmuebleId",
                        column: x => x.InmuebleId,
                        principalTable: "Inmuebles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Inmuebles",
                columns: new[] { "Id", "Activo", "Banos", "Ciudad", "Codigo", "Direccion", "Dormitorios", "Imagen", "MetrosCuadrados", "Precio", "Tipo", "Titulo" },
                values: new object[,]
                {
                    { 1, true, 2, "Lima", "DEP001", "Av. Principal 123", 3, null, 90, 120000m, "Departamento", "Departamento céntrico" },
                    { 2, true, 3, "Chiclayo", "CASA001", "Calle Sol 456", 4, null, 200, 250000m, "Casa", "Casa en la playa" },
                    { 3, true, 2, "Trujillo", "OFI001", "Av. Negocios 789", 0, null, 70, 95000m, "Oficina", "Oficina moderna" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inmuebles_Codigo",
                table: "Inmuebles",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_InmuebleId",
                table: "Reservas",
                column: "InmuebleId");

            migrationBuilder.CreateIndex(
                name: "IX_Visitas_InmuebleId",
                table: "Visitas",
                column: "InmuebleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "Visitas");

            migrationBuilder.DropTable(
                name: "Inmuebles");
        }
    }
}
