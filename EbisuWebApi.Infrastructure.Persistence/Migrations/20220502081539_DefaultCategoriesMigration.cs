using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EbisuWebApi.Infrastructure.Persistence.Migrations
{
    public partial class DefaultCategoriesMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Description", "ImageUrl", "IsDefault", "Name", "Type" },
                values: new object[] { 1, "Comida", "", true, "Comida", "Gasto" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Description", "ImageUrl", "IsDefault", "Name", "Type" },
                values: new object[] { 2, "Transporte", "", true, "Transporte", "Gasto" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Description", "ImageUrl", "IsDefault", "Name", "Type" },
                values: new object[] { 3, "Salario", "", true, "Salario", "Ingreso" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 3);
        }
    }
}
