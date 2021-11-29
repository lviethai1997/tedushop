using System.Collections.Generic;
using System.Linq;
using TeduShop.Common;
using TeduShop.Data.Infrastructure;
using TeduShop.Data.Repositories;
using TeduShop.Model.Models;

namespace TeduShop.Service
{
    public interface IProductService
    {
        Product Add(Product product);

        void Update(Product product);

        void Delete(int id);

        Product GetById(int id);

        IEnumerable<Product> GetAll();

        IEnumerable<Product> GetAll(string keyword);

        IEnumerable<Product> GetTopSaleProducts(int top);

        IEnumerable<Product> GetTopNewProducts(int top);

        IEnumerable<Product> GetAllPaging(int page, int pageSize, out int rowNumber);

        IEnumerable<Product> GetAllByTagPaging(string tag, int page, int pageSize, out int rowNumber);

        IEnumerable<Product> GetProductByCategoryId(int categoryId, int page, int pageSize, out int totalRowl);

        IEnumerable<Product> GetProductByCategoryId(int categoryId);

        IEnumerable<Product> GetProductByCategoryIdPaging(int categoryId,int page,int pageSize,out int totalRow);

        void SaveChanges();
    }

    public class ProductService : IProductService
    {
        private IUnitOfWork _unitOfWork;
        private IProductRepository _productRepository;
        private ITagRepository _tagRepository;
        private IProductTagRepository _productTagRepository;

        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork, IProductTagRepository productTagRepository, ITagRepository tagRepository)
        {
            this._productRepository = productRepository;
            this._productTagRepository = productTagRepository;
            this._tagRepository = tagRepository;
            this._unitOfWork = unitOfWork;
        }

        public Product Add(Product product)
        {
            var productAdd = _productRepository.Add(product);
            if (!string.IsNullOrEmpty(product.Tags))
            {
                string[] tags = product.Tags.Split(',');

                for (var i = 0; i < tags.Length; i++)
                {
                    var tagID = StringHelper.ToUnsignString(tags[i]);
                    if (_tagRepository.Count(x => x.ID == tagID.Trim()) == 0)
                    {
                        Tag tag = new Tag();
                        tag.ID = tagID;
                        tag.Name = tags[i];
                        tag.Type = CommonConstants.ProductTag;
                        _tagRepository.Add(tag);
                    }

                    ProductTag productTag = new ProductTag();
                    productTag.ProductID = product.ID;
                    productTag.TagID = tagID;
                    _productTagRepository.Add(productTag);
                }
            }
            return productAdd;
        }

        public void Delete(int id)
        {
            _productRepository.Delete(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _productRepository.GetAll(new string[] { "ProductCategory" });
        }

        public IEnumerable<Product> GetAll(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
            {
                return _productRepository.GetAll();
            }
            else
            {
                return _productRepository.GetMulti(x => x.Name.Contains(keyword));
            }
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
            if (!string.IsNullOrEmpty(product.Tags))
            {
                string[] tags = product.Tags.Split(',');

                for (var i = 0; i < tags.Length; i++)
                {
                    var tagID = StringHelper.ToUnsignString(tags[i]);
                    if (_tagRepository.Count(x => x.ID == tagID.Trim()) == 0)
                    {
                        Tag tag = new Tag();
                        tag.ID = tagID;
                        tag.Name = tags[i];
                        tag.Type = CommonConstants.ProductTag;
                        _tagRepository.Add(tag);
                    }
                    _productTagRepository.DeleteMulti(x => x.ProductID == product.ID);
                    ProductTag productTag = new ProductTag();
                    productTag.ProductID = product.ID;
                    productTag.TagID = tagID;
                    _productTagRepository.Add(productTag);
                }
            }
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public IEnumerable<Product> GetProductByCategoryId(int categoryId, int page, int pageSize, out int totalRowl)
        {
            return _productRepository.GetProductByCategoryId(categoryId, page, pageSize, out totalRowl);
        }

        public IEnumerable<Product> GetTopSaleProducts(int top)
        {
            return _productRepository.GetMulti(x => x.Promotion > 0 && x.Status == true).OrderByDescending(x => x.UpdatedDate).Take(top);
        }

        public IEnumerable<Product> GetTopNewProducts(int top)
        {
            return _productRepository.GetMulti(x => x.HotFlag == true && x.Status == true).OrderByDescending(x => x.CreatedDate).Take(top);
        }

        public IEnumerable<Product> GetProductByCategoryId(int categoryId)
        {
            return _productRepository.GetMulti(x => x.Status == true && x.CategoryID == categoryId).OrderByDescending(x => x.CreatedDate);
        }

        public IEnumerable<Product> GetProductByCategoryIdPaging(int categoryId, int page, int pageSize, out int totalRow)
        {
            var query = _productRepository.GetMulti(x => x.Status==true && x.CategoryID == categoryId).OrderByDescending(x=>x.CreatedDate);
            totalRow = query.Count();

            return query.Skip((page - 1)*pageSize).Take(pageSize);

        }
    }
}