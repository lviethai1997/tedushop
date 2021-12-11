using System.Net;
using System.Net.Http;
using System.Web.Mvc;
using TeduShop.Service;
using TeduShop.Web.Infrastructure.Core;

namespace TeduShop.Web.Api
{
    
    [RoutePrefix("Api/Statistic")]
    public class StatisticController : ApiControllerBase
    {
         IStatisticService _statisticService;

        public StatisticController(IErrorService errorService, IStatisticService statisticService) : base(errorService)
        {
            this._statisticService = statisticService;
        }

        [Route("getRevenues")]
        [HttpGet]
        [AllowAnonymous]
        public HttpResponseMessage GetRevenuesStatistic(HttpRequestMessage request, string fromDate,string toDate)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _statisticService.getRevenuesStatistic(fromDate, toDate);
                HttpResponseMessage responseMessage = request.CreateResponse(HttpStatusCode.OK, model);
                return responseMessage;
            });
        }
    }
}