using System.Collections.Generic;
using System.Data.SqlClient;
using TeduShop.Common.ViewModel;
using TeduShop.Data.Infrastructure;
using TeduShop.Model.Models;

namespace TeduShop.Data.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        IEnumerable<RevenuesStatisticViewModel> getRevenuesStatistic(string formDate, string toDate);
    }

    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<RevenuesStatisticViewModel> getRevenuesStatistic(string formDate, string toDate)
        {
            var parameter = new SqlParameter[]{
                new SqlParameter("@fromDate",formDate),
                new SqlParameter("@toDate",toDate)
            };
            return DbContext.Database.SqlQuery<RevenuesStatisticViewModel>("GetStatisticRevenues @fromDate,@toDate", parameter);
        }
    }
}