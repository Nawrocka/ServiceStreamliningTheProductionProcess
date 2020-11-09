using ServiceStreamliningTheProductionProcess.Models;
using ServiceStreamliningTheProductionProcess.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceStreamliningTheProductionProcess.Services.Interfaces
{
    public interface ICityService
    {
        City GetCityByName(string cityName);
        OperationSuccesDTO<IList<City>> GetCities();
        OperationResultDTO AddCity(City city);
        OperationResultDTO DeleteCity(string cityName);
        OperationResultDTO UpdateCostOfWorkingHour(string cityName, double workingHourCost);
        OperationResultDTO UpdateTransportCost(string cityName, double transportCost);
    }
}