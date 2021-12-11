using System.Collections.Generic;
using TeduShop.Common.ViewModel;
using TeduShop.Data.Repositories;

namespace TeduShop.Service
{
    public interface IStatisticService
    {
        IEnumerable<RevenuesStatisticViewModel> getRevenuesStatistic(string fromDate, string toDate);
    }

    public class StatisticService : IStatisticService
    {
        private IOrderRepository _orderRepository;

        public StatisticService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public IEnumerable<RevenuesStatisticViewModel> getRevenuesStatistic(string fromDate, string toDate)
        {
            return _orderRepository.getRevenuesStatistic(fromDate, toDate);
        }
    }
}