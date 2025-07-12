using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoReservaCanchasAPIsProgramacionIV.Migrations
{
    /// <inheritdoc />
    public partial class EliminarImplementos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReservaImplemento");

            migrationBuilder.DropTable(
                name: "Implemento");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Implemento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CantidadDisponible = table.Column<int>(type: "int", nullable: false),
                    CantidadTotal = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Implemento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReservaImplemento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImplementoId = table.Column<int>(type: "int", nullable: false),
                    ReservaId = table.Column<int>(type: "int", nullable: false),
                    CantidadSolicitada = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservaImplemento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReservaImplemento_Implemento_ImplementoId",
                        column: x => x.ImplementoId,
                        principalTable: "Implemento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservaImplemento_Reservas_ReservaId",
                        column: x => x.ReservaId,
                        principalTable: "Reservas",
                        principalColumn: "ReservaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReservaImplemento_ImplementoId",
                table: "ReservaImplemento",
                column: "ImplementoId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservaImplemento_ReservaId",
                table: "ReservaImplemento",
                column: "ReservaId");
        }
    }
}
