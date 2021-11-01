using System.Net.Http;
using System.Web.Mvc;
using TeduShop.Model.Models;
using TeduShop.Service;
using TeduShop.Web.Infrastructure.Core;

namespace TeduShop.Web.api
{
    [RoutePrefix("api/postCategory")]
    public class PostCategoyController : ApiControllerBase
    {
        private IPostCategories _postCategories;

        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage httpRequest)
        {
            return CreateHttpResponse(httpRequest, () =>
            {
                HttpResponseMessage responseMessage = null;
                if (ModelState.IsValid)
                {
                    httpRequest.CreateErrorResponse(System.Net.HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var list = _postCategories.GetAll();

                    responseMessage = httpRequest.CreateResponse(list);
                }
                return responseMessage;
            });
        }

        public PostCategoyController(IErrorService errorService, IPostCategories postCategories) : base(errorService)
        {
            this._postCategories = postCategories;
        }

        public HttpResponseMessage Post(HttpRequestMessage httpRequest, PostCategory postCategory)
        {
            return CreateHttpResponse(httpRequest, () =>
            {
                HttpResponseMessage responseMessage = null;
                if (ModelState.IsValid)
                {
                    httpRequest.CreateErrorResponse(System.Net.HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var category = _postCategories.Add(postCategory);
                    _postCategories.SaveChanges();

                    responseMessage = httpRequest.CreateResponse(System.Net.HttpStatusCode.Created, category);
                }
                return responseMessage;
            });
        }

        public HttpResponseMessage Put(HttpRequestMessage httpRequest, PostCategory postCategory)
        {
            return CreateHttpResponse(httpRequest, () =>
            {
                HttpResponseMessage responseMessage = null;
                if (ModelState.IsValid)
                {
                    httpRequest.CreateErrorResponse(System.Net.HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    _postCategories.Update(postCategory);
                    _postCategories.SaveChanges();

                    responseMessage = httpRequest.CreateResponse(System.Net.HttpStatusCode.OK);
                }
                return responseMessage;
            });
        }

        public HttpResponseMessage Delete(HttpRequestMessage httpRequest, int id)
        {
            return CreateHttpResponse(httpRequest, () =>
            {
                HttpResponseMessage responseMessage = null;
                if (ModelState.IsValid)
                {
                    httpRequest.CreateErrorResponse(System.Net.HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    _postCategories.Delete(id);
                    _postCategories.SaveChanges();

                    responseMessage = httpRequest.CreateResponse(System.Net.HttpStatusCode.OK);
                }
                return responseMessage;
            });
        }
    }
}