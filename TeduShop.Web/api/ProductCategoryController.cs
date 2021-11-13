using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TeduShop.Model.Models;
using TeduShop.Service;
using TeduShop.Web.Infrastructure.Core;
using TeduShop.Web.Infrastructure.Extenstion;
using TeduShop.Web.Models;

namespace TeduShop.Web.Api
{
    [RoutePrefix("Api/productCategory")]
    public class ProductCategoryController : ApiControllerBase
    {
        private IProductCategoriesService _productCategoriesService;

        public ProductCategoryController(IErrorService errorService, IProductCategoriesService productCategoriesService) : base(errorService)
        {
            this._productCategoriesService = productCategoriesService;
        }

        [Route("GetAll")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage requestMessage, string keyWord, int page, int pageSize = 20)
        {
            return CreateHttpResponse(requestMessage, () =>
             {
                 int totalRow = 0;

                 var model = _productCategoriesService.GetAll(keyWord);
                 totalRow = model.Count();

                 var query = model.OrderByDescending(x => x.CreatedDate).Skip(page * pageSize).Take(pageSize);
                 var responseData = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(query);
                 var paginationSet = new PaginationSet<ProductCategoryViewModel>()
                 {
                     Items = responseData,
                     Page = page,
                     TotalCount = totalRow,
                     TotalPage = (int)Math.Ceiling((decimal)totalRow / pageSize)
                 };
                 var response = requestMessage.CreateResponse(HttpStatusCode.OK, paginationSet);

                 return response;
             });
        }

        [Route("GetById/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetById(HttpRequestMessage requestMessage, int id)
        {
            return CreateHttpResponse(requestMessage, () =>
            {
                var model = _productCategoriesService.GetById(id);
                var responseData = Mapper.Map<ProductCategory, ProductCategoryViewModel>(model);
                var response = requestMessage.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }

        [Route("getAllParent")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage requestMessage)
        {
            return CreateHttpResponse(requestMessage, () =>
            {
                var model = _productCategoriesService.GetAll();
                var responseData = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(model);
                var response = requestMessage.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }

        [Route("Create")]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage Create(HttpRequestMessage request, ProductCategoryViewModel productCategoryViewModel)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var newProductCategory = new ProductCategory();
             
                    newProductCategory.UpdateProductCategory(productCategoryViewModel);

                    _productCategoriesService.Add(newProductCategory);
                    _productCategoriesService.SaveChanges();

                    var responseData = Mapper.Map<ProductCategory, ProductCategoryViewModel>(newProductCategory);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }

        [Route("Update")]
        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage Update(HttpRequestMessage request, ProductCategoryViewModel productCategoryViewModel)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var dbProductCategory = _productCategoriesService.GetById(productCategoryViewModel.ID);
                    productCategoryViewModel.UpdatedDate = DateTime.Now;
                    dbProductCategory.UpdateProductCategory(productCategoryViewModel);

                    _productCategoriesService.Update(dbProductCategory);
                    _productCategoriesService.SaveChanges();

                    var responseData = Mapper.Map<ProductCategory, ProductCategoryViewModel>(dbProductCategory);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }
    }
}