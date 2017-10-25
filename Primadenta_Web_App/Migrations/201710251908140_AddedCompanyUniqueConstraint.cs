namespace Primadenta_Web_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCompanyUniqueConstraint : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Companies", "Name", c => c.String(nullable: false, maxLength: 20));
            CreateIndex("dbo.Companies", "Name", unique: true, name: "IX_CompanyName");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Companies", "IX_CompanyName");
            AlterColumn("dbo.Companies", "Name", c => c.String(nullable: false));
        }
    }
}
