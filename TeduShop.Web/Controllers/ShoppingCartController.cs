using AutoMapper;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using TeduShop.Common;
using TeduShop.Data.Infrastructure;
using TeduShop.Model.Models;
using TeduShop.Service;
using TeduShop.Web.App_Start;
using TeduShop.Web.Infrastructure.Extenstion;
using TeduShop.Web.Models;

namespace TeduShop.Web.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
        private IProductService _productService;
        private IOrderService _orderService;
        private ApplicationUserManager _userManager;
        private IUnitOfWork _unitOfWork;

        public ShoppingCartController(IUnitOfWork unitOfWork, IProductService productService, IOrderService orderService, ApplicationUserManager userManager)
        {
            this._orderService = orderService;
            this._productService = productService;
            this._userManager = userManager;
            this._unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            if (Session[Common.CommonConstants.SesstionCart] == null)
            {
                Session[Common.CommonConstants.SesstionCart] = new List<ShoppingCartViewModel>();
            }

            return View();
        }

        public JsonResult GetAll()
        {
            if (Session[Common.CommonConstants.SesstionCart] == null)
            {
                Session[Common.CommonConstants.SesstionCart] = new List<ShoppingCartViewModel>();
            }

            var cart = (List<ShoppingCartViewModel>)Session[Common.CommonConstants.SesstionCart];
            return Json(new
            {
                data = cart,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Add(int productId)
        {
            var cart = (List<ShoppingCartViewModel>)Session[Common.CommonConstants.SesstionCart];
            if (cart == null)
            {
                cart = new List<ShoppingCartViewModel>();
            }

            if (cart.Any(x => x.ProductId == productId))
            {
                foreach (var item in cart)
                {
                    if (item.ProductId == productId)
                    {
                        item.Quantity += 1;
                    }
                }
            }
            else
            {
                ShoppingCartViewModel newItem = new ShoppingCartViewModel();
                newItem.ProductId = productId;
                var product = _productService.GetById(productId);
                newItem.Product = Mapper.Map<Product, ProductViewModel>(product);
                newItem.Product.Quantity = 1;
                cart.Add(newItem);
            }

            Session[Common.CommonConstants.SesstionCart] = cart;
            return Json(new
            {
                status = true
            });
        }

        [HttpPost]
        public JsonResult getLoginUser()
        {
            if (Request.IsAuthenticated)
            {
                var userId = User.Identity.GetUserId();
                var user = _userManager.FindById(userId);
                return Json(new
                {
                    data = user,
                    status = true
                });
            }
            else
            {
                return Json(new
                {
                    status = false
                });
            }
        }

        [HttpPost]
        public JsonResult Update(string cartData)
        {
            var cartViewModel = (List<ShoppingCartViewModel>)Session[Common.CommonConstants.SesstionCart];
            var cartSS = new JavaScriptSerializer().Deserialize<List<ShoppingCartViewModel>>(cartData);
            foreach (var item in cartSS)
            {
                foreach (var jitem in cartViewModel)
                {
                    if (item.ProductId == jitem.ProductId)
                    {
                        jitem.Quantity = item.Quantity;
                    }
                }
            }

            Session[Common.CommonConstants.SesstionCart] = cartSS;

            return Json(new
            {
                status = true
            });
        }

        [HttpPost]
        public JsonResult DeleteAll()
        {
            Session[Common.CommonConstants.SesstionCart] = new List<ShoppingCartViewModel>();
            return Json(new
            {
                status = true
            });
        }

        [HttpPost]
        public JsonResult DeleteItem(int productId)
        {
            var cartViewModel = (List<ShoppingCartViewModel>)Session[Common.CommonConstants.SesstionCart];
            if (cartViewModel != null)
            {
                cartViewModel.RemoveAll(x => x.ProductId == productId);
                Session[Common.CommonConstants.SesstionCart] = cartViewModel;
                return Json(new
                {
                    status = true
                });
            }
            return Json(new
            {
                status = false
            });
        }

        [HttpPost]
        public JsonResult CreateUserOrder(string orderViewModel)
        {
            var order = new JavaScriptSerializer().Deserialize<OrderViewModel>(orderViewModel);
            var orderNew = new Order();
            orderNew.UpdateOrder(order);

            if (Request.IsAuthenticated)
            {
                orderNew.CustommerId = User.Identity.GetUserId();
            }

            var cart = (List<ShoppingCartViewModel>)Session[CommonConstants.SesstionCart];
            List<OrderDetail> orderDetails = new List<OrderDetail>();

            foreach (var item in cart)
            {
                var detail = new OrderDetail();
                detail.ProductID = item.ProductId;
                detail.Quantity = item.Quantity;
                orderDetails.Add(detail);
            }

            var ins = _orderService.Create(orderNew, orderDetails);
            return Json(new
            {
                status = true
            });
        }
    }
}