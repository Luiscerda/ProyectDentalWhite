﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dental_White.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DOCTOR",
                columns: table => new
                {
                    Identificacion_Doctor = table.Column<string>(nullable: false),
                    Nombres = table.Column<string>(nullable: true),
                    Apellidos = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true),
                    FechaNacimiento = table.Column<string>(nullable: true),
                    Telefono2 = table.Column<string>(nullable: true),
                    Edad = table.Column<int>(nullable: false),
                    Direccion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DOCTOR", x => x.Identificacion_Doctor);
                });

            migrationBuilder.CreateTable(
                name: "HORA",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Horario = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HORA", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PACIENTE",
                columns: table => new
                {
                    Identificacion_Paciente = table.Column<string>(nullable: false),
                    Nombres = table.Column<string>(nullable: false),
                    Apellidos = table.Column<string>(nullable: false),
                    Telefono = table.Column<string>(nullable: false),
                    FechaNacimiento = table.Column<string>(nullable: false),
                    TipoId = table.Column<string>(nullable: false),
                    Direccion = table.Column<string>(nullable: true),
                    Edad = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PACIENTE", x => x.Identificacion_Paciente);
                });

            migrationBuilder.CreateTable(
                name: "TRATAMIENTO",
                columns: table => new
                {
                    Codigo_Tratamiento = table.Column<string>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    Costo = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRATAMIENTO", x => x.Codigo_Tratamiento);
                });

            migrationBuilder.CreateTable(
                name: "CITA",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Identificacion_Paciente = table.Column<string>(nullable: true),
                    PacienteIdentificacion_Paciente = table.Column<string>(nullable: true),
                    Identificacion_Doctor = table.Column<string>(nullable: true),
                    DoctorIdentificacion_Doctor = table.Column<string>(nullable: true),
                    Id_Cita = table.Column<int>(nullable: false),
                    HoraId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CITA", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CITA_DOCTOR_DoctorIdentificacion_Doctor",
                        column: x => x.DoctorIdentificacion_Doctor,
                        principalTable: "DOCTOR",
                        principalColumn: "Identificacion_Doctor",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CITA_HORA_HoraId",
                        column: x => x.HoraId,
                        principalTable: "HORA",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CITA_PACIENTE_PacienteIdentificacion_Paciente",
                        column: x => x.PacienteIdentificacion_Paciente,
                        principalTable: "PACIENTE",
                        principalColumn: "Identificacion_Paciente",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CITA_DoctorIdentificacion_Doctor",
                table: "CITA",
                column: "DoctorIdentificacion_Doctor");

            migrationBuilder.CreateIndex(
                name: "IX_CITA_HoraId",
                table: "CITA",
                column: "HoraId");

            migrationBuilder.CreateIndex(
                name: "IX_CITA_PacienteIdentificacion_Paciente",
                table: "CITA",
                column: "PacienteIdentificacion_Paciente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CITA");

            migrationBuilder.DropTable(
                name: "TRATAMIENTO");

            migrationBuilder.DropTable(
                name: "DOCTOR");

            migrationBuilder.DropTable(
                name: "HORA");

            migrationBuilder.DropTable(
                name: "PACIENTE");
        }
    }
}
