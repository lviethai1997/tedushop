using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;
using TeduShop.Model.Models;
using TeduShop.Service;
using TeduShop.Web.Infrastructure.Core;
using TeduShop.Web.Infrastructure.Extenstion;
using TeduShop.Web.Models;

namespace TeduShop.Web.api
{
    [RoutePrefix("Api/PostCategoy")]
    public class PostCategoyController : ApiControllerBase
    {
        private IPostCategories _postCategories;

        public PostCategoyController(IErrorService errorService, IPostCategories postCategories) : base(errorService)
        {
            this._postCategories = postCategories;
        }

        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage httpRequest)
        {
            return CreateHttpResponse(httpRequest, () =>
            {
                var listCategory = _postCategories.GetAll().ToList();
                var listCategoryViewModel = Mapper.Map<List<PostCategoryViewModel>>(listCategory);

                HttpResponseMessage response = httpRequest.CreateResponse(HttpStatusCode.OK, listCategoryViewModel);
                return response;
            });
        }

        [Route("Add")]
        public HttpResponseMessage Post(HttpRequestMessage httpRequest, PostCategoryViewModel postCategoryVM)
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
                    PostCategory newpostCategory = new PostCategory();
                    newpostCategory.UpdatePostCategory(postCategoryVM);
                    var category = _postCategories.Add(newpostCategory);
                    _postCategories.SaveChanges();

                    responseMessage = httpRequest.CreateResponse(System.Net.HttpStatusCode.Created, category);
                }
                return responseMessage;
            });
        }

        [Route("Update")]
        public HttpResponseMessage Put(HttpRequestMessage httpRequest, PostCategoryViewModel postCategoryVM)
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
                    var postCategoryDB = _postCategories.GetById(postCategoryVM.ID);
                    postCategoryDB.UpdatePostCategory(postCategoryVM);
                    _postCategories.Update(postCategoryDB);
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