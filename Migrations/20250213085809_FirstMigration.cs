using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace AssistsMx.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    ID_Departamento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre_Departamento = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.ID_Departamento);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    ID_Rol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre_Rol = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.ID_Rol);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Turnos",
                columns: table => new
                {
                    ID_Turno = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre_Turno = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Hora_Inicio = table.Column<TimeSpan>(type: "time(6)", nullable: false),
                    Hora_Fin = table.Column<TimeSpan>(type: "time(6)", nullable: false),
                    Descripcion = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turnos", x => x.ID_Turno);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    ID_Empleado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Departamento = table.Column<int>(type: "int", nullable: true),
                    Puesto = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Fecha_Contratacion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Telefono = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    ID_Turno = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.ID_Empleado);
                    table.ForeignKey(
                        name: "FK_Empleados_Departamentos_Departamento",
                        column: x => x.Departamento,
                        principalTable: "Departamentos",
                        principalColumn: "ID_Departamento");
                    table.ForeignKey(
                        name: "FK_Empleados_Turnos_ID_Turno",
                        column: x => x.ID_Turno,
                        principalTable: "Turnos",
                        principalColumn: "ID_Turno");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Asistencias",
                columns: table => new
                {
                    ID_Asistencia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ID_Empleado = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Hora_Entrada = table.Column<TimeSpan>(type: "time(6)", nullable: false),
                    Hora_Salida = table.Column<TimeSpan>(type: "time(6)", nullable: true),
                    Estado = table.Column<string>(type: "longtext", nullable: false),
                    EmpleadosID_Empleado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asistencias", x => x.ID_Asistencia);
                    table.ForeignKey(
                        name: "FK_Asistencias_Empleados_EmpleadosID_Empleado",
                        column: x => x.EmpleadosID_Empleado,
                        principalTable: "Empleados",
                        principalColumn: "ID_Empleado",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Permisos",
                columns: table => new
                {
                    ID_Permiso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ID_Empleado = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Motivo = table.Column<string>(type: "longtext", nullable: false),
                    Estado = table.Column<string>(type: "longtext", nullable: false),
                    EmpleadosID_Empleado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permisos", x => x.ID_Permiso);
                    table.ForeignKey(
                        name: "FK_Permisos_Empleados_EmpleadosID_Empleado",
                        column: x => x.EmpleadosID_Empleado,
                        principalTable: "Empleados",
                        principalColumn: "ID_Empleado",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    ID_Usuarios = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Usuario = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Contraseña = table.Column<string>(type: "longtext", nullable: false),
                    ID_Rol = table.Column<int>(type: "int", nullable: false),
                    ID_Empleado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.ID_Usuarios);
                    table.ForeignKey(
                        name: "FK_Usuarios_Empleados_ID_Empleado",
                        column: x => x.ID_Empleado,
                        principalTable: "Empleados",
                        principalColumn: "ID_Empleado",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Usuarios_Roles_ID_Rol",
                        column: x => x.ID_Rol,
                        principalTable: "Roles",
                        principalColumn: "ID_Rol",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Vacaciones",
                columns: table => new
                {
                    ID_Vacaciones = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ID_Empleado = table.Column<int>(type: "int", nullable: false),
                    Fecha_Inicio = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Fecha_Final = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Estado = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacaciones", x => x.ID_Vacaciones);
                    table.ForeignKey(
                        name: "FK_Vacaciones_Empleados_ID_Empleado",
                        column: x => x.ID_Empleado,
                        principalTable: "Empleados",
                        principalColumn: "ID_Empleado",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Asistencias_EmpleadosID_Empleado",
                table: "Asistencias",
                column: "EmpleadosID_Empleado");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_Departamento",
                table: "Empleados",
                column: "Departamento");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_ID_Turno",
                table: "Empleados",
                column: "ID_Turno");

            migrationBuilder.CreateIndex(
                name: "IX_Permisos_EmpleadosID_Empleado",
                table: "Permisos",
                column: "EmpleadosID_Empleado");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_ID_Empleado",
                table: "Usuarios",
                column: "ID_Empleado");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_ID_Rol",
                table: "Usuarios",
                column: "ID_Rol");

            migrationBuilder.CreateIndex(
                name: "IX_Vacaciones_ID_Empleado",
                table: "Vacaciones",
                column: "ID_Empleado");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Asistencias");

            migrationBuilder.DropTable(
                name: "Permisos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Vacaciones");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "Departamentos");

            migrationBuilder.DropTable(
                name: "Turnos");
        }
    }
}
