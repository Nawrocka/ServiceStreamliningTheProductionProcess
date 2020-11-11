using ServiceStreamliningTheProductionProcess.Context;
using ServiceStreamliningTheProductionProcess.Models;
using ServiceStreamliningTheProductionProcess.ModelsDTO;
using ServiceStreamliningTheProductionProcess.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceStreamliningTheProductionProcess.Services.Implemenatations
{
    public class ShowResultService : IShowResultService
    {
        //private readonly CalculatorContext context;
        private readonly ICityService cityService;
        //private readonly IModuleService moduleService;
        //CalculatorContext context,  IModuleService moduleService
        private readonly ICalculatorService calculatorService;
        private readonly ISearchHistoryService searchHistoryService;

        public ShowResultService(ICalculatorService calculatorService, ISearchHistoryService searchHistoryService, ICityService cityService)
        {
            //this.context = context;
            this.cityService = cityService;
            //this.moduleService = moduleService;
            this.calculatorService = calculatorService;
            this.searchHistoryService = searchHistoryService;
        }

        public ResultCostDTO PresentResult(string cityName, ModuleListDTO moduleListDTO)
        {

            var checkedInSearchHistory = searchHistoryService.GetSearchHistory(cityName, moduleListDTO);
            OperationSuccesDTO<ResultCostDTO> calculateCost;

            if (checkedInSearchHistory.InSearchHistory)
            {

                return new ResultCostDTO { Cost = checkedInSearchHistory.Cost, InSearchHistory = checkedInSearchHistory.InSearchHistory };
            }
            else
            {
                try
                {
                    calculateCost = (OperationSuccesDTO<ResultCostDTO>)calculatorService.CalculateCost(cityName, moduleListDTO);
                }
                catch (Exception)
                {
                    return new ResultCostDTO { Cost = -1, InSearchHistory = false };
                }

                SearchHistory searchHistory = new SearchHistory
                {
                    CityId = cityService.GetCityByName(cityName).Id,
                    ProductionCost = calculateCost.Result.Cost,
                    ModuleName1 = moduleListDTO.ModuleList.Count > 0 ? moduleListDTO.ModuleList[0] : string.Empty,
                    ModuleName2 = moduleListDTO.ModuleList.Count > 1 ? moduleListDTO.ModuleList[1] : string.Empty,
                    ModuleName3 = moduleListDTO.ModuleList.Count > 2 ? moduleListDTO.ModuleList[2] : string.Empty,
                    ModuleName4 = moduleListDTO.ModuleList.Count > 3 ? moduleListDTO.ModuleList[3] : string.Empty,
                };

                searchHistoryService.AddSearchHistory(searchHistory);
                return new ResultCostDTO { Cost = calculateCost.Result.Cost, InSearchHistory = false };
            }

        }
    }
}