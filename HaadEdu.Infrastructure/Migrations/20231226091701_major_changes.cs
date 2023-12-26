using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HaadEdu.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class major_changes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_permissions_roles_role_id",
                table: "permissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_permissions",
                table: "permissions");

            migrationBuilder.DropIndex(
                name: "IX_permissions_role_id",
                table: "permissions");

            migrationBuilder.DropColumn(
                name: "permissions",
                table: "roles");

            migrationBuilder.RenameTable(
                name: "permissions",
                newName: "role_permissions");

            migrationBuilder.RenameColumn(
                name: "permissions_code",
                table: "role_permissions",
                newName: "permissions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_role_permissions",
                table: "role_permissions",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_role_permissions_role_id",
                table: "role_permissions",
                column: "role_id");

            migrationBuilder.AddForeignKey(
                name: "FK_role_permissions_roles_role_id",
                table: "role_permissions",
                column: "role_id",
                principalTable: "roles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_role_permissions_roles_role_id",
                table: "role_permissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_role_permissions",
                table: "role_permissions");

            migrationBuilder.DropIndex(
                name: "IX_role_permissions_role_id",
                table: "role_permissions");

            migrationBuilder.RenameTable(
                name: "role_permissions",
                newName: "permissions");

            migrationBuilder.RenameColumn(
                name: "permissions",
                table: "permissions",
                newName: "permissions_code");

            migrationBuilder.AddColumn<int[]>(
                name: "permissions",
                table: "roles",
                type: "integer[]",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_permissions",
                table: "permissions",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_permissions_role_id",
                table: "permissions",
                column: "role_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_permissions_roles_role_id",
                table: "permissions",
                column: "role_id",
                principalTable: "roles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
