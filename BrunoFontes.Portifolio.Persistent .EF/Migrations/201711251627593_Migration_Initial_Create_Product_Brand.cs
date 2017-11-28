namespace BrunoFontes.Portifolio.Persistent.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration_Initial_Create_Product_Brand : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        BrandId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Brands", t => t.BrandId)
                .Index(t => t.BrandId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "BrandId", "dbo.Brands");
            DropIndex("dbo.Products", new[] { "BrandId" });
            DropTable("dbo.Products");
            DropTable("dbo.Brands");
        }
    }
}
