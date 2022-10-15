using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CongReports.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Publicador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Apellido = table.Column<string>(type: "TEXT", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FechaBautismo = table.Column<DateTime>(type: "TEXT", nullable: true),
                    EsUngido = table.Column<bool>(type: "INTEGER", nullable: false),
                    EsAnciano = table.Column<bool>(type: "INTEGER", nullable: false),
                    EsSiervoMinisterial = table.Column<bool>(type: "INTEGER", nullable: false),
                    EsPrecursor = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publicador", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Publicador");
        }
    }
}
