namespace Primadenta_Web_App.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'21f632f7-dbf0-4771-b3f3-f75adefe761f', N'guest@primadenta.com', 0, N'ADxEZgm30zh5iWQbXaWenvbsGUm0NTaaW3Sgk9f/oyhZwVW7N7igfZZtojJlaRhTFg==', N'4545685d-1ce2-4a1e-a702-0bd4a038b782', NULL, 0, 0, NULL, 1, 0, N'guest@primadenta.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'3aeb2b18-2695-499e-8898-2c6d51d9106f', N'inga.numaviciene@gmail.com', 0, N'AFGQdo+vUUE1pLBrkTOKHAa10/yUlx+55KecG5H1JvBfyj9deDCW8pDL8DFcTTzT6A==', N'3a2b4bf4-0cdb-4cda-844a-921849492c37', NULL, 0, 0, NULL, 1, 0, N'inga.numaviciene@gmail.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'7c0a7c7c-e22d-4eb4-9c53-a4b20ea44aad', N'Admin')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'3aeb2b18-2695-499e-8898-2c6d51d9106f', N'7c0a7c7c-e22d-4eb4-9c53-a4b20ea44aad')

");
        }

        public override void Down()
        {
        }
    }
}
