using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CongReports.Migrations.Informes
{
    public partial class Second : Migration
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

            migrationBuilder.CreateTable(
                name: "Informe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PublicadorId = table.Column<int>(type: "INTEGER", nullable: false),
                    Publicaciones = table.Column<int>(type: "INTEGER", nullable: true),
                    Videos = table.Column<int>(type: "INTEGER", nullable: true),
                    Horas = table.Column<int>(type: "INTEGER", nullable: false),
                    Revisitas = table.Column<int>(type: "INTEGER", nullable: true),
                    Estudios = table.Column<int>(type: "INTEGER", nullable: true),
                    Notas = table.Column<string>(type: "TEXT", nullable: true),
                    PrecursorAuxiliar = table.Column<bool>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Informe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Informe_Publicador_PublicadorId",
                        column: x => x.PublicadorId,
                        principalTable: "Publicador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Informe_PublicadorId",
                table: "Informe",
                column: "PublicadorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Informe");

            migrationBuilder.DropTable(
                name: "Publicador");
        }
    }
}
