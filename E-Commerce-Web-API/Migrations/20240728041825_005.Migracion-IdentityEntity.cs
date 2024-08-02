using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce_Web_API.Migrations
{
    /// <inheritdoc />
    public partial class _005MigracionIdentityEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Usuario_IdUsuario",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_RolesLocales_IdRol",
                table: "Usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario");

            migrationBuilder.RenameTable(
                name: "Usuario",
                newName: "Usuarios");

            migrationBuilder.RenameIndex(
                name: "IX_Usuario_IdRol",
                table: "Usuarios",
                newName: "IX_Usuarios_IdRol");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Usuarios_IdUsuario",
                table: "AspNetUsers",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_RolesLocales_IdRol",
                table: "Usuarios",
                column: "IdRol",
                principalTable: "RolesLocales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Usuarios_IdUsuario",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_RolesLocales_IdRol",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.RenameTable(
                name: "Usuarios",
                newName: "Usuario");

            migrationBuilder.RenameIndex(
                name: "IX_Usuarios_IdRol",
                table: "Usuario",
                newName: "IX_Usuario_IdRol");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Usuario_IdUsuario",
                table: "AspNetUsers",
                column: "IdUsuario",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_RolesLocales_IdRol",
                table: "Usuario",
                column: "IdRol",
                principalTable: "RolesLocales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
