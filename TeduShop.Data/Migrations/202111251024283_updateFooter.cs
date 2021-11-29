namespace TeduShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateFooter : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Footers", "Content", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Footers", "Content", c => c.String(nullable: false, maxLength: 256));
        }
    }
}
