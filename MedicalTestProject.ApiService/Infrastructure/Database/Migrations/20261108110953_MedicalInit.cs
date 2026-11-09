using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MedicalTestProject.ApiService.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class MedicalInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "medical");

            migrationBuilder.CreateTable(
                name: "diseases",
                schema: "medical",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_diseases", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "doctors",
                schema: "medical",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    first_name = table.Column<string>(type: "text", nullable: false),
                    middle_name = table.Column<string>(type: "text", nullable: false),
                    last_name = table.Column<string>(type: "text", nullable: true),
                    birth_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doctors", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "patients",
                schema: "medical",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    first_name = table.Column<string>(type: "text", nullable: false),
                    middle_name = table.Column<string>(type: "text", nullable: false),
                    last_name = table.Column<string>(type: "text", nullable: true),
                    birth_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patients", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "specializations",
                schema: "medical",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_specializations", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "patients_diseases",
                schema: "medical",
                columns: table => new
                {
                    patient_id = table.Column<int>(type: "integer", nullable: false),
                    disease_id = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patients_diseases", x => new { x.patient_id, x.disease_id });
                    table.ForeignKey(
                        name: "FK_patients_diseases_diseases_disease_id",
                        column: x => x.disease_id,
                        principalSchema: "medical",
                        principalTable: "diseases",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_patients_diseases_patients_patient_id",
                        column: x => x.patient_id,
                        principalSchema: "medical",
                        principalTable: "patients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "doctors_specializations",
                schema: "medical",
                columns: table => new
                {
                    doctor_id = table.Column<int>(type: "integer", nullable: false),
                    specialization_id = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doctors_specializations", x => new { x.doctor_id, x.specialization_id });
                    table.ForeignKey(
                        name: "FK_doctors_specializations_doctors_doctor_id",
                        column: x => x.doctor_id,
                        principalSchema: "medical",
                        principalTable: "doctors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_doctors_specializations_specializations_specialization_id",
                        column: x => x.specialization_id,
                        principalSchema: "medical",
                        principalTable: "specializations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_doctors_specializations_specialization_id",
                schema: "medical",
                table: "doctors_specializations",
                column: "specialization_id");

            migrationBuilder.CreateIndex(
                name: "IX_patients_diseases_disease_id",
                schema: "medical",
                table: "patients_diseases",
                column: "disease_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "doctors_specializations",
                schema: "medical");

            migrationBuilder.DropTable(
                name: "patients_diseases",
                schema: "medical");

            migrationBuilder.DropTable(
                name: "doctors",
                schema: "medical");

            migrationBuilder.DropTable(
                name: "specializations",
                schema: "medical");

            migrationBuilder.DropTable(
                name: "diseases",
                schema: "medical");

            migrationBuilder.DropTable(
                name: "patients",
                schema: "medical");
        }
    }
}
