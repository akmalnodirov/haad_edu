using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HaadEdu.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class role_permission_permissions_column_name_changed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "permissions",
                table: "role_permissions",
                newName: "permission");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "permission",
                table: "role_permissions",
                newName: "permissions");
        }
    }
}
