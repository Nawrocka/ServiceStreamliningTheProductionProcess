using ServiceStreamliningTheProductionProcess.Context;
using ServiceStreamliningTheProductionProcess.Models;
using ServiceStreamliningTheProductionProcess.ModelsDTO;
using ServiceStreamliningTheProductionProcess.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.History;
using System.Linq;
using System.Web;
using System.Security.AccessControl;

namespace ServiceStreamliningTheProductionProcess.Services.Implemenatations
{
    public class SearchHistoryService : ISearchHistoryService
    {
        private readonly CalculatorContext context;
        private readonly ICityService cityService;
        private readonly IModuleService moduleService;
        public SearchHistoryService(CalculatorContext context, ICityService cityService, IModuleService moduleService)
        {
            this.context = context;
            this.cityService = cityService;
            this.moduleService = moduleService;
        }
        public OperationResultDTO AddSearchHistory(SearchHistory searchHistory)
        {           
            context.SearchHistory.Add(searchHistory);
            context.SaveChanges();

            return new OperationSuccesDTO<Module> { Message = "Seuccess" };
        }

        public OperationSuccesDTO<IList<SearchHistory>> GetSearchHistories()
        {
            List<SearchHistory> searchHistories = context.SearchHistory.ToList();
            return new OperationSuccesDTO<IList<SearchHistory>> { Result = searchHistories };
        }

        public ResultCostDTO GetSearchHistory(string cityName, ModuleListDTO moduleListDTO)
        {
            var city = cityService.GetCityByName(cityName);

            if(city == null)
            {
                return new ResultCostDTO { InSearchHistory = false };
            }

            List<SearchHistory> searchHistoryListByName = context.SearchHistory.Where(row => row.CityId == city.Id).ToList();

            if(searchHistoryListByName == null)
            {
                return new ResultCostDTO { InSearchHistory = false };
            }

            int counterModule = 0;

            foreach (SearchHistory searchHistory in searchHistoryListByName)
            {
                counterModule = 0;

                foreach (var mod in moduleListDTO.ModuleList)
                {
                    if (searchHistory.ModuleName1 == mod ||
                        searchHistory.ModuleName2 == mod ||
                        searchHistory.ModuleName3 == mod ||
                        searchHistory.ModuleName4 == mod)
                    {
                        counterModule++;
                    }
                    else { break; }
                }

                if (moduleListDTO.ModuleList.Count() == ModuleHasValue(searchHistory) && moduleListDTO.ModuleList.Count() == counterModule)
                {
                    return new ResultCostDTO
                    {
                        InSearchHistory = true,
                        Cost = searchHistory.ProductionCost
                    };
                }
            }

            return new ResultCostDTO { InSearchHistory = false };
        }

        private int ModuleHasValue(SearchHistory SearchHistory)
        {
            int counter = 0;
            if (!(SearchHistory.ModuleName1 == string.Empty))
                counter++;
            if (!(SearchHistory.ModuleName2 == string.Empty))
                counter++;
            if (!(SearchHistory.ModuleName3 == string.Empty))
                counter++;
            if (!(SearchHistory.ModuleName4 == string.Empty))
                counter++;
            return counter;
        }
    }
}