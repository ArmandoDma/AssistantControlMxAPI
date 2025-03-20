using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssistsMx.Migrations
{
    /// <inheritdoc />
    public partial class changedAsisModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asistencias_Empleados_EmpleadosID_Empleado",
                table: "Asistencias");

            migrationBuilder.DropIndex(
                name: "IX_Asistencias_EmpleadosID_Empleado",
                table: "Asistencias");

            migrationBuilder.DropColumn(
                name: "EmpleadosID_Empleado",
                table: "Asistencias");

            migrationBuilder.CreateIndex(
                name: "IX_Asistencias_ID_Empleado",
                table: "Asistencias",
                column: "ID_Empleado");

            migrationBuilder.AddForeignKey(
                name: "FK_Asistencias_Empleados_ID_Empleado",
                table: "Asistencias",
                column: "ID_Empleado",
                principalTable: "Empleados",
                principalColumn: "ID_Empleado",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asistencias_Empleados_ID_Empleado",
                table: "Asistencias");

            migrationBuilder.DropIndex(
                name: "IX_Asistencias_ID_Empleado",
                table: "Asistencias");

            migrationBuilder.AddColumn<int>(
                name: "EmpleadosID_Empleado",
                table: "Asistencias",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Asistencias_EmpleadosID_Empleado",
                table: "Asistencias",
                column: "EmpleadosID_Empleado");

            migrationBuilder.AddForeignKey(
                name: "FK_Asistencias_Empleados_EmpleadosID_Empleado",
                table: "Asistencias",
                column: "EmpleadosID_Empleado",
                principalTable: "Empleados",
                principalColumn: "ID_Empleado",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
