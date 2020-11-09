using ServiceStreamliningTheProductionProcess.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceStreamliningTheProductionProcess.Services.Interfaces
{
    public interface IShowResultService
    {
        ResultCostDTO PresentResult(string cityName, ModuleListDTO moduleListDTO);
    }
}