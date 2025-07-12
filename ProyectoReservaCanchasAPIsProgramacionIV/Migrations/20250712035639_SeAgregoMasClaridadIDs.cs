using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoReservaCanchasAPIsProgramacionIV.Migrations
{
    /// <inheritdoc />
    public partial class SeAgregoMasClaridadIDs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Facultad",
                newName: "FacultadId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Carrera",
                newName: "CarreraId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Campus",
                newName: "CampusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FacultadId",
                table: "Facultad",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CarreraId",
                table: "Carrera",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CampusId",
                table: "Campus",
                newName: "Id");
        }
    }
}
