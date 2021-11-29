using AutoMapper;
using System.Collections.Generic;
using System.Web.Mvc;
using TeduShop.Data.Infrastructure;
using TeduShop.Model.Models;
using TeduShop.Service;
using TeduShop.Web.Models;

namespace TeduShop.Web.Controllers
{
    public class HomeController : Controller
    {
        IProductCategoriesService _productCategoriesService;
        ICommonService _commonService;
        IProductService _productService;


        public HomeController(IProductCategoriesService productCategoriesService, ICommonService commonService,IProductService productService)
        {
            this._productCategoriesService = productCategoriesService;
            this._commonService = commonService;
            this._productService = productService;
        }

        public ActionResult Index()
        {
            var homeviewModel = new HomeViewModel();
            var GetProductsSale = _productService.GetTopSaleProducts(4);
            var GetProductsNew = _productService.GetTopNewProducts(8);
            var productSaleViewmodel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(GetProductsSale);
            var productNewViewmodel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(GetProductsNew);

            homeviewModel.productsNew = productNewViewmodel;
            homeviewModel.productsSale = productSaleViewmodel;

            return View(homeviewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [ChildActionOnly]
        public ActionResult Footer()
        {
            var footerModel = _commonService.GetFooter();
            var footerViewModel = Mapper.Map<Footer, FooterViewModel>(footerModel);
            return PartialView(footerViewModel);
        }

        [ChildActionOnly]
        public ActionResult Header()
        {
            var model = _productCategoriesService.GetAll();
            var listProductCategoryViewModel = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(model);
            return PartialView(listProductCategoryViewModel);
        }
    }
}