using AutoMapper;
using System.Collections.Generic;
using System.Web.Mvc;
using TeduShop.Model.Models;
using TeduShop.Service;
using TeduShop.Web.Models;

namespace TeduShop.Web.Controllers
{
    public class HomeController : Controller
    {
        private IProductCategoriesService _productCategoriesService;
        private ICommonService _commonService;
        private IProductService _productService;

        public HomeController(IProductCategoriesService productCategoriesService, ICommonService commonService, IProductService productService)
        {
            this._productCategoriesService = productCategoriesService;
            this._commonService = commonService;
            this._productService = productService;
        }

        //[OutputCache(Duration = 60,Location =System.Web.UI.OutputCacheLocation.Server)]
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

        [ChildActionOnly]
        [OutputCache(Duration =3600)]
        public ActionResult Footer()
        {
            var footerModel = _commonService.GetFooter();
            var footerViewModel = Mapper.Map<Footer, FooterViewModel>(footerModel);
            return PartialView(footerViewModel);
        }

        [ChildActionOnly]
        [OutputCache(Duration = 3600,Location =System.Web.UI.OutputCacheLocation.Client)]
        public ActionResult Header()
        {
            var model = _productCategoriesService.GetAll();
            var listProductCategoryViewModel = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(model);
            return PartialView(listProductCategoryViewModel);
        }
    }
}