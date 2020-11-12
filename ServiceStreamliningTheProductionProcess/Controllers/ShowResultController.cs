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
    public class ShowResultController : ApiController
    {
        private readonly IShowResultService showResultService;

        public ShowResultController(IShowResultService showResultService)
        {
            this.showResultService = showResultService;
        }

        [HttpPost]
        [Route("ShowResult/GetCost")]
        [ResponseType(typeof(ResultCostDTO))]
        public IHttpActionResult GetCost(ShowResultDTO showResultDTO)
        {            
            var result = showResultService.PresentResult(showResultDTO.CityName, showResultDTO.ModuleListDTO);

            if(result.Cost == -1)
            {
                return Content(HttpStatusCode.ExpectationFailed, "Error,propably bad module name");
            }
            else
            {
                return Content<ResultCostDTO>(HttpStatusCode.OK, result);
            }
        }
    }
}
