using ServiceStreamliningTheProductionProcess.Models;
using ServiceStreamliningTheProductionProcess.ModelsDTO;
using ServiceStreamliningTheProductionProcess.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace ServiceStreamliningTheProductionProcess.Controllers
{
    public class SearchHistoriesController : ApiController
    {
        private readonly ISearchHistoryService searchHistoryService;

        public SearchHistoriesController(ISearchHistoryService searchHistoryService)
        {
            this.searchHistoryService = searchHistoryService;
        }

        [HttpPost]
        [Route("SearchHistories/AddSearchHistory")]
        [ResponseType(typeof(void))]
        public IHttpActionResult AddSearchHistory(SearchHistory searchHistory)
        {
            if (searchHistory == null)
            {
                return Content(HttpStatusCode.BadRequest, "Object searchHistory is null");
            }
            var response = searchHistoryService.AddSearchHistory(searchHistory);

            if (response.Equals("Success"))
            {
                return Content(HttpStatusCode.OK, response.Message);
            }

            return Content(HttpStatusCode.BadRequest, "Error");
        }
        
        [HttpGet]
        [Route("SearchHistories/GetSearchHistories")]
        public IHttpActionResult GetSearchHistories()
        {
            return Content<IList<SearchHistory>>(HttpStatusCode.OK, searchHistoryService.GetSearchHistories().Result);
        }        
    }
}
