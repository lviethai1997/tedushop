using System.Collections.Generic;
using System.Linq;
using TeduShop.Data.Infrastructure;
using TeduShop.Model.Models;

namespace TeduShop.Data.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<Product> GetProductByCategoryId(int categoryId, int page, int pageSize, out int totalRow)
        {
            var query = from product in DbContext.Products
                        join category in DbContext.ProductCategories
                        on product.CategoryID equals category.ID
                        where product.CategoryID == categoryId && product.Status
                        select product;
            totalRow = query.Count();
            query = query.Skip((page - 1) * pageSize).Take(pageSize);
            return query;
        }

        public IEnumerable<Product> GetProductByTag(string tag, int page, int pageSize, out int totalRow)
        {
            var query = from product in DbContext.Products
                        join tagg in DbContext.ProductTags
                        on product.ID equals tagg.ProductID
                        where tagg.TagID == tag && product.Status
                        select product;
            totalRow = query.Count();
            query = query.Skip((page - 1) * pageSize).Take(pageSize);
            return query;
        }
    }

    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> GetProductByCategoryId(int categoryId, int page, int pageSize, out int totalRow);

        IEnumerable<Product> GetProductByTag(string tag, int page, int pageSize, out int totalRow);
    }
}