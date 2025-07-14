using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoReservaCanchasAPIsProgramacionIV.Migrations
{
    /// <inheritdoc />
    public partial class AddFacultadIdToAdministrador : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonaUdla_Facultad_FacultadId",
                table: "PersonaUdla");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonaUdla_Facultad_FacultadId",
                table: "PersonaUdla",
                column: "FacultadId",
                principalTable: "Facultad",
                principalColumn: "FacultadId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonaUdla_Facultad_FacultadId",
                table: "PersonaUdla");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonaUdla_Facultad_FacultadId",
                table: "PersonaUdla",
                column: "FacultadId",
                principalTable: "Facultad",
                principalColumn: "FacultadId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
