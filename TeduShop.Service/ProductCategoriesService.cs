using System.Collections.Generic;
using TeduShop.Data.Infrastructure;
using TeduShop.Data.Repositories;
using TeduShop.Model.Models;

namespace TeduShop.Service
{
    public interface IProductCategoriesService
    {
        void Add(ProductCategory productCategory);

        void Update(ProductCategory productCategory);

        void Delete(int id);

        ProductCategory GetById(int id);

        IEnumerable<ProductCategory> GetAll();

        IEnumerable<ProductCategory> GetAll(string keyword);

        IEnumerable<ProductCategory> GetByPaging(int page, int pageSize, out int totalRow);

        IEnumerable<ProductCategory> GetByTagPaging(string Tag, int page, int pageSize, out int totalRow);

        IEnumerable<ProductCategory> GetByParentId(int parentId);
        void SaveChanges();
    }

    public class ProductCategoriesService : IProductCategoriesService
    {
        private IProductCategoryRepository _productCategoryRepository;
        private IUnitOfWork _unitOfWork;

        public ProductCategoriesService(IProductCategoryRepository productCategoryRepository, IUnitOfWork unitOfWork)
        {
            this._productCategoryRepository = productCategoryRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Add(ProductCategory productCategory)
        {
            _productCategoryRepository.Add(productCategory);
        }

        public void Delete(int id)
        {
            _productCategoryRepository.Delete(id);
        }

        public IEnumerable<ProductCategory> GetAll()
        {
            return _productCategoryRepository.GetAll();
        }

        public ProductCategory GetById(int id)
        {
            return _productCategoryRepository.GetSingleById(id);
        }

        public IEnumerable<ProductCategory> GetByPaging(int page, int pageSize, out int totalRow)
        {
            return _productCategoryRepository.GetMultiPaging(x => x.Status, out totalRow, page, pageSize);
        }

        public IEnumerable<ProductCategory> GetByTagPaging(string Tag, int page, int pageSize, out int totalRow)
        {
            return _productCategoryRepository.GetMultiPaging(x => x.Status, out totalRow, page, pageSize);
        }

        public void Update(ProductCategory productCategory)
        {
            _productCategoryRepository.Update(productCategory);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public IEnumerable<ProductCategory> GetByParentId(int parentId)
        {
            return _productCategoryRepository.GetMulti(x => x.Status && x.ParentID == parentId);
        }

        public IEnumerable<ProductCategory> GetAll(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
            {
                return _productCategoryRepository.GetAll();
            }
            else
            {
                return _productCategoryRepository.GetMulti(x => x.Name.Contains(keyword));
            }
        }
    }
}