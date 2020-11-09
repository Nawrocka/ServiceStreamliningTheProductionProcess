using ServiceStreamliningTheProductionProcess.Context;
using ServiceStreamliningTheProductionProcess.Models;
using ServiceStreamliningTheProductionProcess.ModelsDTO;
using ServiceStreamliningTheProductionProcess.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using System.Web.Services.Description;

namespace ServiceStreamliningTheProductionProcess.Services.Implemenatations
{
    public class CityService : ICityService
    {
        private readonly CalculatorContext context;
        public CityService(CalculatorContext context)
        {
            this.context = context;
        }
        public OperationResultDTO AddCity(City city) //why does it parse OperationResultDTO to OperatinSuccessDTO<Module>...?!
        {
            context.City.Add(city);
            context.SaveChanges();
            return new OperationSuccesDTO<Module> { Message = "Success" };
        }

        public OperationResultDTO DeleteCity(string cityName)
        {
            var deletingCity = GetCityByName(cityName);

            if (deletingCity ==null)
            {
                return new OperationErrorDTO { Code = 404, Message = $"City with name: {cityName} doesn't exist" };
            }
            
            context.City.Remove(deletingCity);
            context.SaveChanges();
            return new OperationSuccesDTO<Module> { Message ="Success"};
        }

        public OperationSuccesDTO<IList<City>> GetCities()
        {
            List<City> cities = context.City.ToList();
            return new OperationSuccesDTO<IList<City>> { Message = "Sucess", Result = cities };
        }

        public City GetCityByName(string cityName)
        {
            return context.City.Where(city => city.Name == cityName).FirstOrDefault();
        }

        public OperationResultDTO UpdateCostOfWorkingHour(string cityName, double workingHourCost)
        {
            City updatingCity = context.City.Where(city => city.Name == cityName).FirstOrDefault();

            if (updatingCity == null)
            {
                return new OperationErrorDTO { Code = 404, Message = $"City with name: {cityName} doesn't exist" };
            }

            updatingCity.CostOfWorkingHour = workingHourCost;
            context.SaveChanges();
            return new OperationSuccesDTO<Module> { Message = "Success" };
        }

        public OperationResultDTO UpdateTransportCost(string cityName, double transportCost)
        {
            City updatingCity = context.City.Where(city => city.Name == cityName).FirstOrDefault();

            if(updatingCity == null)
            {
                return new OperationErrorDTO { Code = 404, Message = $"City with name: {cityName} doesn't exist" };
            }

            updatingCity.TransportCost = transportCost;
            context.SaveChanges();
            return new OperationSuccesDTO<Module> { Message = "Success" };
        }
    }
}