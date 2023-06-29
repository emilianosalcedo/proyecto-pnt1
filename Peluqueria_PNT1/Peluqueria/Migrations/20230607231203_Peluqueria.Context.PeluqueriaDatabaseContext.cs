using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Peluqueria.Migrations
{
    public partial class PeluqueriaContextPeluqueriaDatabaseContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
              name: "Usuarios",
              columns: table => new
              {
                  Id = table.Column<int>(nullable: false)
                      .Annotation("SqlServer:Identity", "1, 1"),
                  Nombre = table.Column<string>(nullable: true),
                  Apellido = table.Column<string>(nullable: true),
                  Email = table.Column<string>(nullable: true),
                  DNI = table.Column<string>(nullable: true),
                  Direccion = table.Column<string>(nullable: true),
                  Telefono = table.Column<string>(nullable: true),
                  Contrasenia = table.Column<string>(nullable: true),
                  Rol = table.Column<int>(nullable: false)
              },
              constraints: table =>
              {
                  table.PrimaryKey("PK_Usuarios", x => x.Id);
              });
            migrationBuilder.CreateTable(
                name: "Servicio",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<int>(nullable: false),
                    Precio = table.Column<double>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true),
                    Duracion = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Turno",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaHora = table.Column<DateTime>(nullable: false),
                    Atendido = table.Column<bool>(nullable: false),
                    ServicioId = table.Column<int>(nullable: false),
                    ClienteId = table.Column<int>(nullable: false),  
                    PeluqueroId = table.Column<int>(nullable:false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turno", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Turno_Usuarios_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Turno_Servicio_ServicioId",
                        column: x => x.ServicioId,
                        principalTable: "Servicio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Turno_ClienteId",
                table: "Turno",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Turno_ServicioId",
                table: "Turno",
                column: "ServicioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropTable(
               name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Turno");

            migrationBuilder.DropTable(
                name: "Servicio");
        }
    }
}
