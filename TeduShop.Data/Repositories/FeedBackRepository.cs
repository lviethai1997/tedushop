using TeduShop.Data.Infrastructure;
using TeduShop.Model.Models;

namespace TeduShop.Data.Repositories
{
    public interface IFeedBackRepository : IRepository<FeedBack>
    {
    }

    public class FeedBackRepository : RepositoryBase<FeedBack>, IFeedBackRepository
    {
        public FeedBackRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}