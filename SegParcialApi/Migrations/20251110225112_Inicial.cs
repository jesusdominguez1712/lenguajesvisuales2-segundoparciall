using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SegParcialApi.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    CI = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FotoCasa1 = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    FotoCasa2 = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    FotoCasa3 = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.CI);
                });

            migrationBuilder.CreateTable(
                name: "LogsApi",
                columns: table => new
                {
                    IdLog = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipoLog = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestBody = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResponseBody = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlEndpoint = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MetodoHttp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DireccionIp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Detalle = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogsApi", x => x.IdLog);
                });

            migrationBuilder.CreateTable(
                name: "ArchivosClientes",
                columns: table => new
                {
                    IdArchivo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CICliente = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NombreArchivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlArchivo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArchivosClientes", x => x.IdArchivo);
                    table.ForeignKey(
                        name: "FK_ArchivosClientes_Clientes_CICliente",
                        column: x => x.CICliente,
                        principalTable: "Clientes",
                        principalColumn: "CI",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArchivosClientes_CICliente",
                table: "ArchivosClientes",
                column: "CICliente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArchivosClientes");

            migrationBuilder.DropTable(
                name: "LogsApi");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
