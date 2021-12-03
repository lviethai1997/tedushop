namespace TeduShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatePages : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pages", "Alias", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pages", "Alias");
        }
    }
}
