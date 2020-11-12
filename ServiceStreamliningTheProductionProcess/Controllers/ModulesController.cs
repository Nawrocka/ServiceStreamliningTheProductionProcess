using ServiceStreamliningTheProductionProcess.Models;
using ServiceStreamliningTheProductionProcess.Services.Implemenatations;
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
    public class ModulesController : ApiController
    {
        private readonly IModuleService moduleService;
        public ModulesController(IModuleService moduleService)
        {
            this.moduleService = moduleService;
        }

        [HttpPost]
        [Route("/Modules/AddModule")]
        [ResponseType(typeof(void))]
        public IHttpActionResult AddModule(Module module)
        {
            if(module == null)
            {
                return Content(HttpStatusCode.BadRequest, "Object module is null");
            }

            var response = moduleService.AddModule(module);

            if (response.Message.Equals("Success"))
            {
                return Content(HttpStatusCode.OK, response.Message);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, "Error");
            }
            
        }

        [HttpDelete]
        [Route("/Modules/Delete/{name}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteModule(string name)
        {
            if(name == null)
            {
                return Content(HttpStatusCode.BadRequest, "Module name is null");
            }

            var response = moduleService.DeleteModule(name);

            if(response.Message.Equals("Success"))
            {
                return Content(HttpStatusCode.OK, response.Message);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, "Error");
            }
        }

        [HttpGet]
        [Route("/Modules/GetModuleByName/{name}")]
        [ResponseType(typeof(Module))]
        public IHttpActionResult GetModuleByName(string moduleName)
        {
            Module module = moduleService.GetModuleByName(moduleName);

            if(module == null)
            {
                return NotFound();
            }

            return Content<Module>(HttpStatusCode.OK, module);
        }

        [HttpGet]
        [Route("/Modules/GetModules")]
        public IHttpActionResult GetModules()
        {
            var modules = moduleService.GetModules();

            //if(modules.Message == "Success")
            //{
                return Content<IList<Module>>(HttpStatusCode.OK, modules.Result);
            //}
            //else 
            //{ 
            //    return Content(HttpStatusCode.BadRequest, "Error"); 
            //}
            
        }

        [HttpPut]
        [Route("/Modules/UpdateModule")]
        public IHttpActionResult UpdateModule(Module module)
        {
            var response = moduleService.UpdateModule(module);

            if(response.Equals("Success"))
            {
                return Content(HttpStatusCode.OK, response.Message);
            }

            return Content(HttpStatusCode.BadRequest, "Error");
        }
    }
}
