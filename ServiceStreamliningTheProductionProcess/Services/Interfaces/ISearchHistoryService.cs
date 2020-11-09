using ServiceStreamliningTheProductionProcess.Models;
using ServiceStreamliningTheProductionProcess.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceStreamliningTheProductionProcess.Services.Interfaces
{
    public interface ISearchHistoryService
    {
        ResultCostDTO GetSearchHistory(string cityName, ModuleListDTO moduleListDTO);
        OperationSuccesDTO<IList<SearchHistory>> GetSearchHistories();
        OperationResultDTO AddSearchHistory(SearchHistory searchHistory);
    }
}