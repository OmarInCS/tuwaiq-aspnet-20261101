using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore.Migrations
{
    /// <inheritdoc />
    public partial class DoctorSpecialities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "HireDate",
                table: "Doctors",
                type: "TEXT",
                nullable: false,
                defaultValueSql: "date('now', 'localtime')",
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AddColumn<int>(
                name: "SpecialityCode",
                table: "Doctors",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Specialities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialities", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_SpecialityCode",
                table: "Doctors",
                column: "SpecialityCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Specialities_SpecialityCode",
                table: "Doctors",
                column: "SpecialityCode",
                principalTable: "Specialities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Specialities_SpecialityCode",
                table: "Doctors");

            migrationBuilder.DropTable(
                name: "Specialities");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_SpecialityCode",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "SpecialityCode",
                table: "Doctors");

            migrationBuilder.AlterColumn<DateTime>(
                name: "HireDate",
                table: "Doctors",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValueSql: "date('now', 'localtime')");
        }
    }
}
