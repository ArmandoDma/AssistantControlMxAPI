﻿// <auto-generated />
using System;
using AssistsMx.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AssistsMx.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250213090659_SecondMigration")]
    partial class SecondMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("AssistsMx.Models.Asistencia", b =>
                {
                    b.Property<int>("ID_Asistencia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("EmpleadosID_Empleado")
                        .HasColumnType("int");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime(6)");

                    b.Property<TimeSpan>("Hora_Entrada")
                        .HasColumnType("time(6)");

                    b.Property<TimeSpan?>("Hora_Salida")
                        .HasColumnType("time(6)");

                    b.Property<int>("ID_Empleado")
                        .HasColumnType("int");

                    b.HasKey("ID_Asistencia");

                    b.HasIndex("EmpleadosID_Empleado");

                    b.ToTable("Asistencias");
                });

            modelBuilder.Entity("AssistsMx.Models.Departamentos", b =>
                {
                    b.Property<int>("ID_Departamento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nombre_Departamento")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("ID_Departamento");

                    b.ToTable("Departamentos");
                });

            modelBuilder.Entity("AssistsMx.Models.Empleados", b =>
                {
                    b.Property<int>("ID_Empleado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("Departamento")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("Fecha_Contratacion")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("ID_Turno")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Puesto")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.HasKey("ID_Empleado");

                    b.HasIndex("Departamento");

                    b.HasIndex("ID_Turno");

                    b.ToTable("Empleados");
                });

            modelBuilder.Entity("AssistsMx.Models.Permisos", b =>
                {
                    b.Property<int>("ID_Permiso")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("EmpleadosID_Empleado")
                        .HasColumnType("int");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("ID_Empleado")
                        .HasColumnType("int");

                    b.Property<string>("Motivo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ID_Permiso");

                    b.HasIndex("EmpleadosID_Empleado");

                    b.ToTable("Permisos");
                });

            modelBuilder.Entity("AssistsMx.Models.Roles", b =>
                {
                    b.Property<int>("ID_Rol")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nombre_Rol")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("ID_Rol");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("AssistsMx.Models.Turnos", b =>
                {
                    b.Property<int>("ID_Turno")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Hora_Fin")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Hora_Inicio")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nombre_Turno")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("ID_Turno");

                    b.ToTable("Turnos");
                });

            modelBuilder.Entity("AssistsMx.Models.Usuarios", b =>
                {
                    b.Property<int>("ID_Usuarios")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Contraseña")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ID_Empleado")
                        .HasColumnType("int");

                    b.Property<int>("ID_Rol")
                        .HasColumnType("int");

                    b.Property<string>("Usuario")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("ID_Usuarios");

                    b.HasIndex("ID_Empleado");

                    b.HasIndex("ID_Rol");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("AssistsMx.Models.Vacaciones", b =>
                {
                    b.Property<int>("ID_Vacaciones")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Fecha_Final")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Fecha_Inicio")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("ID_Empleado")
                        .HasColumnType("int");

                    b.HasKey("ID_Vacaciones");

                    b.HasIndex("ID_Empleado");

                    b.ToTable("Vacaciones");
                });

            modelBuilder.Entity("AssistsMx.Models.Asistencia", b =>
                {
                    b.HasOne("AssistsMx.Models.Empleados", "Empleados")
                        .WithMany()
                        .HasForeignKey("EmpleadosID_Empleado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empleados");
                });

            modelBuilder.Entity("AssistsMx.Models.Empleados", b =>
                {
                    b.HasOne("AssistsMx.Models.Departamentos", "Departamentos")
                        .WithMany("Empleados")
                        .HasForeignKey("Departamento");

                    b.HasOne("AssistsMx.Models.Turnos", "Turno")
                        .WithMany("Empleados")
                        .HasForeignKey("ID_Turno");

                    b.Navigation("Departamentos");

                    b.Navigation("Turno");
                });

            modelBuilder.Entity("AssistsMx.Models.Permisos", b =>
                {
                    b.HasOne("AssistsMx.Models.Empleados", "Empleados")
                        .WithMany()
                        .HasForeignKey("EmpleadosID_Empleado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empleados");
                });

            modelBuilder.Entity("AssistsMx.Models.Usuarios", b =>
                {
                    b.HasOne("AssistsMx.Models.Empleados", "Empleados")
                        .WithMany()
                        .HasForeignKey("ID_Empleado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AssistsMx.Models.Roles", "Rol")
                        .WithMany()
                        .HasForeignKey("ID_Rol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empleados");

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("AssistsMx.Models.Vacaciones", b =>
                {
                    b.HasOne("AssistsMx.Models.Empleados", "Empleados")
                        .WithMany()
                        .HasForeignKey("ID_Empleado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empleados");
                });

            modelBuilder.Entity("AssistsMx.Models.Departamentos", b =>
                {
                    b.Navigation("Empleados");
                });

            modelBuilder.Entity("AssistsMx.Models.Turnos", b =>
                {
                    b.Navigation("Empleados");
                });
#pragma warning restore 612, 618
        }
    }
}
