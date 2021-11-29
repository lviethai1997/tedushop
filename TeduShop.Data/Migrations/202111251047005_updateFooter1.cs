namespace TeduShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateFooter1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Footers", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Footers", "Status", c => c.Boolean(nullable: false));
        }
    }
}
