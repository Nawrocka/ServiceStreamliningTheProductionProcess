using ServiceStreamliningTheProductionProcess.Context;
using ServiceStreamliningTheProductionProcess.ModelsDTO;
using ServiceStreamliningTheProductionProcess.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceStreamliningTheProductionProcess.Services.Implemenatations
{
    public class CalculatorService : ICalculatorService
    {
        private readonly CalculatorContext context;
        private readonly ICityService cityService;
        private readonly IModuleService moduleService;

        public CalculatorService (CalculatorContext context, ICityService cityService, IModuleService moduleService)
        {
            this.context = context;
            this.cityService = cityService;
            this.moduleService = moduleService;
        }

        public OperationResultDTO CalculateCost(string cityName, ModuleListDTO moduleListDTO)
        {
            var city = cityService.GetCityByName(cityName);

            if (city == null)
            {
                return new OperationErrorDTO { Code = 404, Message = $"City with name: {cityName} doesn't exist" };
            }

            var modulesCost = city.TransportCost;

            foreach (var moduleName in moduleListDTO.ModuleList)
            {
                var module = moduleService.GetModuleByName(moduleName);

                if (module == null)
                {
                    return new OperationErrorDTO { Code = 404, Message = $"Module with name: {moduleName} doesn't exist" };
                }

                modulesCost = modulesCost + module.Price + (module.AssemblyTime * city.CostOfWorkingHour);
            }

            modulesCost = modulesCost * 1.3; // 30% of added costs

            return new OperationSuccesDTO<ResultCostDTO>
            {
                Message = "Success",
                Result = new ResultCostDTO { Cost = modulesCost, InSearchHistory = false }
            };
        }
    }
}