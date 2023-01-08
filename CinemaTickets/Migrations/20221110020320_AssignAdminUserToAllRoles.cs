using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaTickets.Migrations
{
    public partial class AssignAdminUserToAllRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [security].[UserRoles] (UserId,RoleId) SELECT '89d758e3-10cb-4d32-ba1b-02c8b009b3fe', Id FROM [security].[Roles]");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [security].[UserRoles] WHERE UserId='89d758e3-10cb-4d32-ba1b-02c8b009b3fe'");
        }
    }
}
