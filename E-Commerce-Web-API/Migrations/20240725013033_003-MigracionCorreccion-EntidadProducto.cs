using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce_Web_API.Migrations
{
    /// <inheritdoc />
    public partial class _003MigracionCorreccionEntidadProducto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdsImages",
                table: "Productos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdsImages",
                table: "Productos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
