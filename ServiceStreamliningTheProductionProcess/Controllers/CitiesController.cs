using ServiceStreamliningTheProductionProcess.Models;
using ServiceStreamliningTheProductionProcess.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;
using HttpDeleteAttribute = System.Web.Http.HttpDeleteAttribute;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using HttpPutAttribute = System.Web.Http.HttpPutAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;

namespace ServiceStreamliningTheProductionProcess.Controllers
{
    public class CitiesController : ApiController
    {
        private readonly ICityService cityService;

        public CitiesController(ICityService cityService)
        {
            this.cityService = cityService;
        }

        [HttpGet]
        [Route("Cities/GetCities")]
        public IHttpActionResult GetCities() //there could be if(list == null)
        {
            return Content(HttpStatusCode.OK, cityService.GetCities().Result);
        }

        [HttpGet]
        [Route("Cities/GetCityByName/{name}")]
        [ResponseType(typeof(City))]
        public IHttpActionResult GetCityByName(string cityName)
        {
            City city = cityService.GetCityByName(cityName);

            if (city == null)
            {
                return NotFound();
            }

            return Content<City>(HttpStatusCode.OK, city);
        }

        [HttpPut]
        [Route("Cities/UpdateTransportCost")]
        public IHttpActionResult UpdateTransportCost(City city)
        {
            var response = cityService.UpdateTransportCost(city.Name, city.TransportCost);

            if (response.Message.Equals("Success"))
            {
                return Content(HttpStatusCode.OK, response.Message);
            }

            return Content(HttpStatusCode.BadRequest, response.Message);
        }

        [HttpPut]
        [Route("Cities/UpdateTransportCost")]
        public IHttpActionResult UpdateCostOfWorkingHour(City city)
        {
            var response = cityService.UpdateCostOfWorkingHour(city.Name, city.CostOfWorkingHour);

            if(response.Message.Equals("Success"))
            {
                return Content(HttpStatusCode.OK, response.Message);
            }

            return Content(HttpStatusCode.BadRequest, response.Message);
        }

        [HttpPost]
        [Route("Cities/AddCity")]
        [ResponseType(typeof(void))]
        public IHttpActionResult AddCity(City city)
        {
            if(city == null)
            {
                return Content(HttpStatusCode.BadRequest, "Object city is null");
            }

            var response = cityService.AddCity(city);

            if (response.Message.Equals("Success"))
            {
                return Content(HttpStatusCode.OK, response.Message);
            }

            return Content(HttpStatusCode.BadRequest, "Error");
        }

        [HttpDelete]
        [Route("Cities/DeleteCity/{name}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteCity(string name) //There is validation of city == null so next time meybe do different logic here
        {
            City city = cityService.GetCityByName(name);

            if (city == null)
            {
                return Content(HttpStatusCode.BadRequest, "City name is null");
            }

            var response = cityService.DeleteCity(city.Name);

            if(response.Equals("Success"))
            {
                return Content(HttpStatusCode.OK, response.Message);
            }

            return Content(HttpStatusCode.BadRequest, "Error");
        }
    }
}
