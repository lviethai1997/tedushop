using System.Collections.Generic;
using TeduShop.Data.Infrastructure;
using TeduShop.Data.Repositories;
using TeduShop.Model.Models;

namespace TeduShop.Service
{
    public interface IProductService
    {
        void Add(Product product);

        void Update(Product product);

        void Delete(int id);

        Product GetById(int id);

        IEnumerable<Product> GetAll();

        IEnumerable<Product> GetAllPaging(int page, int pageSize, out int rowNumber);

        IEnumerable<Product> GetAllByTagPaging(string tag, int page, int pageSize, out int rowNumber);

        IEnumerable<Product> GetProductByCategoryId(int categoryId, int page, int pageSize, out int totalRowl);
    }

    public class ProductService : IProductService
    {
        private IUnitOfWork _unitOfWork;
        private IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            this._productRepository = productRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Add(Product product)
        {
            _productRepository.Add(product);
        }

        public void Delete(int id)
        {
            _productRepository.Delete(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _productRepository.GetAll(new string[] { "ProductCategory" });
        }

        public IEnumerable<Product> GetAllByTagPaging(string tag, int page, int pageSize, out int rowNumber)
        {
            return _productRepository.GetProductByTag(tag, page, pageSize, out rowNumber);
        }

        public IEnumerable<Product> GetAllPaging(int page, int pageSize, out int rowNumber)
        {
            return _productRepository.GetMultiPaging(x => x.Status, out rowNumber, page, pageSize);
        }

        public Product GetById(int id)
        {
            return _productRepository.GetSingleById(id);
        }

        public void Update(Product product)
        {
            _productRepository.Update(product);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public IEnumerable<Product> GetProductByCategoryId(int categoryId, int page, int pageSize, out int totalRowl)
        {
            return _productRepository.GetProductByCategoryId(categoryId, page, pageSize, out totalRowl);
        }
    }
}