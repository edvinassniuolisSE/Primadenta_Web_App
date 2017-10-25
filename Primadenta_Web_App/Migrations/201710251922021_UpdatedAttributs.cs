namespace Primadenta_Web_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedAttributs : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Companies", "IX_CompanyName");
            DropIndex("dbo.ProductCategories", "IX_CategoryName");
            AlterColumn("dbo.Companies", "Name", c => c.String(nullable: false, maxLength: 40));
            AlterColumn("dbo.ProductCategories", "Name", c => c.String(nullable: false, maxLength: 150));
            CreateIndex("dbo.Companies", "Name", unique: true, name: "IX_CompanyName");
            CreateIndex("dbo.ProductCategories", "Name", unique: true, name: "IX_CategoryName");
        }
        
        public override void Down()
        {
            DropIndex("dbo.ProductCategories", "IX_CategoryName");
            DropIndex("dbo.Companies", "IX_CompanyName");
            AlterColumn("dbo.ProductCategories", "Name", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Companies", "Name", c => c.String(nullable: false, maxLength: 20));
            CreateIndex("dbo.ProductCategories", "Name", unique: true, name: "IX_CategoryName");
            CreateIndex("dbo.Companies", "Name", unique: true, name: "IX_CompanyName");
        }
    }
}
