using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoReservaCanchasAPIsProgramacionIV.Migrations
{
    /// <inheritdoc />
    public partial class RelacionCampusEliminarReservas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calendario_Reservas_ReservaId",
                table: "Calendario");

            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropIndex(
                name: "IX_Calendario_ReservaId",
                table: "Calendario");

            migrationBuilder.DropColumn(
                name: "ReservaId",
                table: "Calendario");

            migrationBuilder.RenameColumn(
                name: "FechaInicio",
                table: "Calendario",
                newName: "FechaHoraInicio");

            migrationBuilder.RenameColumn(
                name: "FechaFin",
                table: "Calendario",
                newName: "FechaHoraFin");

            migrationBuilder.AddColumn<int>(
                name: "CampusId",
                table: "Cancha",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "NotasDetallada",
                table: "Calendario",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "Estado",
                table: "Calendario",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<int>(
                name: "PersonaUdlaId",
                table: "Calendario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cancha_CampusId",
                table: "Cancha",
                column: "CampusId");

            migrationBuilder.CreateIndex(
                name: "IX_Calendario_PersonaUdlaId",
                table: "Calendario",
                column: "PersonaUdlaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Calendario_PersonaUdla_PersonaUdlaId",
                table: "Calendario",
                column: "PersonaUdlaId",
                principalTable: "PersonaUdla",
                principalColumn: "BannerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cancha_Campus_CampusId",
                table: "Cancha",
                column: "CampusId",
                principalTable: "Campus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calendario_PersonaUdla_PersonaUdlaId",
                table: "Calendario");

            migrationBuilder.DropForeignKey(
                name: "FK_Cancha_Campus_CampusId",
                table: "Cancha");

            migrationBuilder.DropIndex(
                name: "IX_Cancha_CampusId",
                table: "Cancha");

            migrationBuilder.DropIndex(
                name: "IX_Calendario_PersonaUdlaId",
                table: "Calendario");

            migrationBuilder.DropColumn(
                name: "CampusId",
                table: "Cancha");

            migrationBuilder.DropColumn(
                name: "PersonaUdlaId",
                table: "Calendario");

            migrationBuilder.RenameColumn(
                name: "FechaHoraInicio",
                table: "Calendario",
                newName: "FechaInicio");

            migrationBuilder.RenameColumn(
                name: "FechaHoraFin",
                table: "Calendario",
                newName: "FechaFin");

            migrationBuilder.AlterColumn<string>(
                name: "NotasDetallada",
                table: "Calendario",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Estado",
                table: "Calendario",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "ReservaId",
                table: "Calendario",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    ReservaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CanchaId = table.Column<int>(type: "int", nullable: false),
                    PersonaUdlaId = table.Column<int>(type: "int", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.ReservaId);
                    table.ForeignKey(
                        name: "FK_Reservas_Cancha_CanchaId",
                        column: x => x.CanchaId,
                        principalTable: "Cancha",
                        principalColumn: "CanchaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservas_PersonaUdla_PersonaUdlaId",
                        column: x => x.PersonaUdlaId,
                        principalTable: "PersonaUdla",
                        principalColumn: "BannerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Calendario_ReservaId",
                table: "Calendario",
                column: "ReservaId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_CanchaId",
                table: "Reservas",
                column: "CanchaId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_PersonaUdlaId",
                table: "Reservas",
                column: "PersonaUdlaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Calendario_Reservas_ReservaId",
                table: "Calendario",
                column: "ReservaId",
                principalTable: "Reservas",
                principalColumn: "ReservaId");
        }
    }
}
