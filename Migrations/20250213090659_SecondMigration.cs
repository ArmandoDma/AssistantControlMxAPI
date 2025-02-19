using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssistsMx.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Hora_Inicio",
                table: "Turnos",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time(6)");

            migrationBuilder.AlterColumn<string>(
                name: "Hora_Fin",
                table: "Turnos",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time(6)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "Hora_Inicio",
                table: "Turnos",
                type: "time(6)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "Hora_Fin",
                table: "Turnos",
                type: "time(6)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");
        }
    }
}
