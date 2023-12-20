using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HaadEdu.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class table_name_changed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_Roles_RoleId",
                table: "Permissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Permissions",
                table: "Permissions");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "roles");

            migrationBuilder.RenameTable(
                name: "Permissions",
                newName: "permissions");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "users",
                newName: "username");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "users",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "users",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "users",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedTime",
                table: "users",
                newName: "updated_time");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "users",
                newName: "role_id");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "users",
                newName: "created_date");

            migrationBuilder.RenameIndex(
                name: "IX_Users_RoleId",
                table: "users",
                newName: "IX_users_role_id");

            migrationBuilder.RenameColumn(
                name: "Permissions",
                table: "roles",
                newName: "permissions");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "roles",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "roles",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedTime",
                table: "roles",
                newName: "updated_time");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "roles",
                newName: "created_date");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "permissions",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedTime",
                table: "permissions",
                newName: "updated_time");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "permissions",
                newName: "role_id");

            migrationBuilder.RenameColumn(
                name: "PermissionsCode",
                table: "permissions",
                newName: "permissions_code");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "permissions",
                newName: "created_date");

            migrationBuilder.RenameIndex(
                name: "IX_Permissions_RoleId",
                table: "permissions",
                newName: "IX_permissions_role_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_roles",
                table: "roles",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_permissions",
                table: "permissions",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_permissions_roles_role_id",
                table: "permissions",
                column: "role_id",
                principalTable: "roles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_users_roles_role_id",
                table: "users",
                column: "role_id",
                principalTable: "roles",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_permissions_roles_role_id",
                table: "permissions");

            migrationBuilder.DropForeignKey(
                name: "FK_users_roles_role_id",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_roles",
                table: "roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_permissions",
                table: "permissions");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "roles",
                newName: "Roles");

            migrationBuilder.RenameTable(
                name: "permissions",
                newName: "Permissions");

            migrationBuilder.RenameColumn(
                name: "username",
                table: "Users",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "Users",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Users",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_time",
                table: "Users",
                newName: "UpdatedTime");

            migrationBuilder.RenameColumn(
                name: "role_id",
                table: "Users",
                newName: "RoleId");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "Users",
                newName: "CreatedDate");

            migrationBuilder.RenameIndex(
                name: "IX_users_role_id",
                table: "Users",
                newName: "IX_Users_RoleId");

            migrationBuilder.RenameColumn(
                name: "permissions",
                table: "Roles",
                newName: "Permissions");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Roles",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Roles",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_time",
                table: "Roles",
                newName: "UpdatedTime");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "Roles",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Permissions",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_time",
                table: "Permissions",
                newName: "UpdatedTime");

            migrationBuilder.RenameColumn(
                name: "role_id",
                table: "Permissions",
                newName: "RoleId");

            migrationBuilder.RenameColumn(
                name: "permissions_code",
                table: "Permissions",
                newName: "PermissionsCode");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "Permissions",
                newName: "CreatedDate");

            migrationBuilder.RenameIndex(
                name: "IX_permissions_role_id",
                table: "Permissions",
                newName: "IX_Permissions_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Permissions",
                table: "Permissions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_Roles_RoleId",
                table: "Permissions",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id");
        }
    }
}
