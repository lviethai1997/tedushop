namespace TeduShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCustommerId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "CustommerId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Orders", "CustommerId");
            AddForeignKey("dbo.Orders", "CustommerId", "dbo.ApplicationUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "CustommerId", "dbo.ApplicationUsers");
            DropIndex("dbo.Orders", new[] { "CustommerId" });
            DropColumn("dbo.Orders", "CustommerId");
        }
    }
}
