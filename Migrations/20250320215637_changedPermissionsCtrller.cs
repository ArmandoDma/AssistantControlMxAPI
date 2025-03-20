using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssistsMx.Migrations
{
    /// <inheritdoc />
    public partial class changedPermissionsCtrller : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permisos_Empleados_EmpleadoID_Empleado",
                table: "Permisos");

            migrationBuilder.DropIndex(
                name: "IX_Permisos_EmpleadoID_Empleado",
                table: "Permisos");

            migrationBuilder.DropColumn(
                name: "EmpleadoID_Empleado",
                table: "Permisos");

            migrationBuilder.CreateIndex(
                name: "IX_Permisos_ID_Empleado",
                table: "Permisos",
                column: "ID_Empleado");

            migrationBuilder.AddForeignKey(
                name: "FK_Permisos_Empleados_ID_Empleado",
                table: "Permisos",
                column: "ID_Empleado",
                principalTable: "Empleados",
                principalColumn: "ID_Empleado",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permisos_Empleados_ID_Empleado",
                table: "Permisos");

            migrationBuilder.DropIndex(
                name: "IX_Permisos_ID_Empleado",
                table: "Permisos");

            migrationBuilder.AddColumn<int>(
                name: "EmpleadoID_Empleado",
                table: "Permisos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Permisos_EmpleadoID_Empleado",
                table: "Permisos",
                column: "EmpleadoID_Empleado");

            migrationBuilder.AddForeignKey(
                name: "FK_Permisos_Empleados_EmpleadoID_Empleado",
                table: "Permisos",
                column: "EmpleadoID_Empleado",
                principalTable: "Empleados",
                principalColumn: "ID_Empleado",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
