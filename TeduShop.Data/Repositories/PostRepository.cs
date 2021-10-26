using System.Collections.Generic;
using System.Linq;
using TeduShop.Data.Infrastructure;
using TeduShop.Model.Models;

namespace TeduShop.Data.Repositories
{
    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        public PostRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<Post> GetAllByTag(string tag, int page, int pageSize, out int totalRow)
        {
            var query = from p in DbContext.PostTags
                        join pt in DbContext.Posts on p.PostID equals pt.ID
                        where p.TagID == tag && pt.Status
                        select pt;
            totalRow = query.Count();
            query = query.Skip((page - 1) * pageSize).Take(pageSize);
            return query;
        }

        public IEnumerable<Post> GetPostByCategoryId(int parentId, int page, int pageSize, out int totalRow)
        {
            var query = from pc in DbContext.PostCategories
                        join p in DbContext.Posts on pc.ID equals p.CategoryID
                        where p.CategoryID == parentId && p.Status
                        select p;
            totalRow = query.Count();
            query = query.Skip((page - 1) * pageSize).Take(pageSize);
            return query;
        }
    }

    public interface IPostRepository : IRepository<Post>
    {
        IEnumerable<Post> GetAllByTag(string tag, int page, int pageSize, out int totalRow);

        IEnumerable<Post> GetPostByCategoryId(int parentId, int page, int pageSize, out int totalRow);
    }
}