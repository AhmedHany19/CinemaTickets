using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaTickets.Migrations
{
    public partial class AddAdminUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [security].[Users] ([Id], [FirstName], [LastName], [ProfilePicture], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'89d758e3-10cb-4d32-ba1b-02c8b009b3fe', N'Admin', N'Admin', NULL, N'Admin', N'ADMIN', N'Admin@test.com', N'ADMIN@TEST.COM', 1, N'AQAAAAEAACcQAAAAEIV5lUV8zpVBp18bCogJwg5+MBI2Cfd0gmY+A0CunrnM+ABLTiM06eOv4/INsGq+wQ==', N'YSHXX7PJ6VUC2VTWIJWWN3QXSJFRSZBN', N'5abde7fb-11a9-4c61-99e7-a280126d2ebe', NULL, 0, NULL, 1, 0)\r\n");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [security].[Users] WHERE Id='89d758e3-10cb-4d32-ba1b-02c8b009b3fe'");
        }
    }
}
