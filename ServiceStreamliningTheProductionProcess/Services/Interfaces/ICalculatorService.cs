using ServiceStreamliningTheProductionProcess.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceStreamliningTheProductionProcess.Services.Interfaces
{
    public interface ICalculatorService
    {
        OperationResultDTO CalculateCost(string cityName, ModuleListDTO moduleListDTO);

    }
}