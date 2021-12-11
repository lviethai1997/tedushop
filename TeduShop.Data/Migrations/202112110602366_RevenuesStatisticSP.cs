namespace TeduShop.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class RevenuesStatisticSP : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure("GetStatisticRevenues",
                p => new
                {
                    fromDate = p.String(),
                    toDate = p.String()
                }
                ,
                @"select ord.CreateDate,sum(ordd.Quantity*ordd.Price) as Revenues
                ,sum((ordd.Quantity*ordd.Price)-(ordd.Quantity*pro.OriginalPrice)) as Benefit
                from Orders ord,OrderDetails ordd,Products pro
                where ord.ID=ordd.OrderID and ordd.ProductID=pro.ID
                and ord.CreateDate <= cast(@toDate as date) and ord.CreateDate >= CAST(@fromDate as date)
                group by ord.CreateDate"
                );
        }

        public override void Down()
        {
            DropStoredProcedure("dbo.GetStatisticRevenues");
        }
    }
}