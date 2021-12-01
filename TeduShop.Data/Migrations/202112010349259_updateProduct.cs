namespace TeduShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "Size", c => c.String());
            AddColumn("dbo.Products", "SellOut", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "SellOut");
            DropColumn("dbo.Products", "Size");
            DropColumn("dbo.Products", "Quantity");
        }
    }
}
