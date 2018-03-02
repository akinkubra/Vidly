namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
               INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'aa077d1d-c822-411d-a87c-7cd5b0bac1bd', N'admin@vidly.com', 0, N'AHJkHvGo3tMu8AhUy2Vvp1PtpoDNC1WiOeCWpyryzikouQUXUEG8UpqOsmpx5zg2bA==', N'e25387db-df3e-43e5-9a23-dfe99e2373a1', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
               INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'e1596359-b772-40b3-986a-0e3aacb4c1d9', N'guest@vidly.com', 0, N'AEVx0/joh07p3tBA6fooOZUQ+LygqYKWcwY8eA1jGZpVYJ/5eemp4ZW7fXxJ3x2BQg==', N'2c8d95b2-e144-4a8e-8508-24a688d8503b', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
               INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'7100e622-fc51-49d3-80e8-914b57e93a50', N'CanManageMovie')
               INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'aa077d1d-c822-411d-a87c-7cd5b0bac1bd', N'7100e622-fc51-49d3-80e8-914b57e93a50')
               ");
        }

        public override void Down()
        {
        }
    }
}
