using AutoMapper;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using TeduShop.Common;
using TeduShop.Model.Models;
using TeduShop.Service;
using TeduShop.Web.Infrastructure.Core;
using TeduShop.Web.Models;

namespace TeduShop.Web.Controllers
{
    public class ProductController : Controller
    {
        private IProductCategoriesService _productCategoriesService;
        private ICommonService _commonService;
        private IProductService _productService;

        public ProductController(IProductCategoriesService productCategoriesService, ICommonService commonService, IProductService productService)
        {
            this._productCategoriesService = productCategoriesService;
            this._commonService = commonService;
            this._productService = productService;
        }

        // GET: Product
        public ActionResult ProductInCategory(int id, int page = 1, string sort = "")
        {
            int pageSize = int.Parse(ConfigHelper.GetByKey("PageSize"));
            int totalRow = 0;
            var GetProductByCategoryId = _productService.GetProductByCategoryIdPaging(id, page, pageSize, sort, out totalRow);
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

        public ActionResult Search(string keyword, int page = 1, string sort = "")
        {
            int pageSize = int.Parse(ConfigHelper.GetByKey("PageSize"));
            int totalRow = 0;
            var GetProductByCategoryId = _productService.GetProductByCategoryKeyWordPaging(keyword, page, pageSize, sort, out totalRow);
            var productViewmodel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(GetProductByCategoryId);
            int totalPage = (int)Math.Ceiling((double)totalRow / pageSize);

            ViewBag.keyword = keyword;
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

            var relatedProduct = _productService.GetRatedProducts(id, 5);
            ViewBag.relatedProduct = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(relatedProduct);

            var bestSeller = _productService.GetBestSeller(id, 5);
            ViewBag.bestSeller = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(bestSeller);

            List<string> listImages = new JavaScriptSerializer().Deserialize<List<string>>(productViewmodel.MoreImage);
            ViewBag.MoreImages = listImages;

            return View(productViewmodel);
        }

        public JsonResult GetListProductByName(string keyword)
        {
            var model = _productService.GetListProductByName(keyword);
            var ViewModel = model;
            return Json(new
            {
                data = ViewModel,
            }, JsonRequestBehavior.AllowGet);
        }
    }
}