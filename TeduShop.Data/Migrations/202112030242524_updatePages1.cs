namespace TeduShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatePages1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Pages", "Alias", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Pages", "Content", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pages", "Content", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.Pages", "Alias", c => c.String(nullable: false));
        }
    }
}
