using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeduShop.Common;
using TeduShop.Model.Models;
using TeduShop.Service;
using TeduShop.Web.Infrastructure.Core;
using TeduShop.Web.Models;

namespace TeduShop.Web.Controllers
{
    public class ProductController : Controller
    {
        IProductCategoriesService _productCategoriesService;
        ICommonService _commonService;
        IProductService _productService;


        public ProductController(IProductCategoriesService productCategoriesService, ICommonService commonService, IProductService productService)
        {
            this._productCategoriesService = productCategoriesService;
            this._commonService = commonService;
            this._productService = productService;
        }
        // GET: Product
        public ActionResult ProductInCategory(int id, int page = 1)
        {
            int pageSize = int.Parse(ConfigHelper.GetByKey("PageSize"));
            int totalRow = 0;
            var GetProductByCategoryId = _productService.GetProductByCategoryIdPaging(id, page, pageSize, out totalRow);
            var productViewmodel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(GetProductByCategoryId);
            int totalPage = (int)Math.Ceiling((double)totalRow / pageSize);

            var category = _productCategoriesService.GetById(id);
            ViewBag.ProductInCategory = Mapper.Map<ProductCategory, ProductCategoryViewModel>(category);
            var paginationSet = new PaginationSet<ProductViewModel>()
            {
                Items = productViewmodel,
                MaxPage = int.Parse(ConfigHelper.GetByKey("MaxPage")),
                Page = page,
                TotalCount = totalRow,
                TotalPage = totalPage,
            };

            return View(paginationSet);
        }

        public ActionResult GetProductDetail(int id)
        {
            var GetProductById = _productService.GetById(id);
            var productViewmodel = Mapper.Map<Product, ProductViewModel>(GetProductById);
            return View(productViewmodel);
        }
    }
}