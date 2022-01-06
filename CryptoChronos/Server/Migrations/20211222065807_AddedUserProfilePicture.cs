using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WatchNFT.Server.Migrations
{
    public partial class AddedUserProfilePicture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfilePictureUri",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleClaims_RoleId",
                table: "UserRoleClaims",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoleClaims_Roles_RoleId",
                table: "UserRoleClaims",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRoleClaims_Roles_RoleId",
                table: "UserRoleClaims");

            migrationBuilder.DropIndex(
                name: "IX_UserRoleClaims_RoleId",
                table: "UserRoleClaims");

            migrationBuilder.DropColumn(
                name: "ProfilePictureUri",
                table: "Users");
        }
    }
}
