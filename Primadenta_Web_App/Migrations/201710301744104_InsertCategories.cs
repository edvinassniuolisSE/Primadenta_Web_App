namespace Primadenta_Web_App.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class InsertCategories : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO [dbo].[ProductCategories] ([Name]) VALUES ('�viesoje kiet�jantys kompozitai')");
        }

        public override void Down()
        {
        }
    }
}
