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
using TeduShop.Web.Models;

namespace TeduShop.Web.Api
{
    [RoutePrefix("api/productCategory")]
    public class ProductCategoryController : ApiControllerBase
    {
        IProductCategoriesService _productCategoriesService;

      public ProductCategoryController(IErrorService errorService,IProductCategoriesService productCategoriesService) : base(errorService)
        {
            this._productCategoriesService = productCategoriesService;
        }

        [Route("GetAll")]
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
    }
}
