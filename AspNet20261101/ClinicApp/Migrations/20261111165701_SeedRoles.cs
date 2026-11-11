using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClinicApp.Migrations
{
    /// <inheritdoc />
    public partial class SeedRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "bea4cc39-d94b-446d-adf2-5ecf23960a0a", "bea4cc39-d94b-446d-adf2-5ecf23960a0a", "APP_ADMIN", "APP_ADMIN" },
                    { "bea4cc39-d94b-446d-adf2-5ecf23960a1a", "bea4cc39-d94b-446d-adf2-5ecf23960a1a", "DOCTOR", "DOCTOR" },
                    { "bea4cc39-d94b-446d-adf2-5ecf23960a2a", "bea4cc39-d94b-446d-adf2-5ecf23960a2a", "FRONT_OFFICE", "FRONT_OFFICE" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "bea4cc39-d94b-446d-adf2-5ecf23960a0a");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "bea4cc39-d94b-446d-adf2-5ecf23960a1a");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "bea4cc39-d94b-446d-adf2-5ecf23960a2a");
        }
    }
}
