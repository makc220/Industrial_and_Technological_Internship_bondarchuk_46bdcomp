using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechVision.Migrations
{
    /// <inheritdoc />
    public partial class AddAdminAvatar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AvatarContentType",
                table: "AdminUsers",
                type: "TEXT",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "AvatarImage",
                table: "AdminUsers",
                type: "BLOB",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvatarContentType",
                table: "AdminUsers");

            migrationBuilder.DropColumn(
                name: "AvatarImage",
                table: "AdminUsers");
        }
    }
}
