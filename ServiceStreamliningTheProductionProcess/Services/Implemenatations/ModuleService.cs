using ServiceStreamliningTheProductionProcess.Context;
using ServiceStreamliningTheProductionProcess.Models;
using ServiceStreamliningTheProductionProcess.ModelsDTO;
using ServiceStreamliningTheProductionProcess.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.DynamicData;

namespace ServiceStreamliningTheProductionProcess.Services.Implemenatations
{
    public class ModuleService : IModuleService
    {
        private readonly CalculatorContext context;
        public ModuleService (CalculatorContext context)
        {
            this.context = context;
        }
        public OperationSuccesDTO<Module> AddModule(Module module)
        {
            context.Module.Add(module);
            context.SaveChanges();
            return new OperationSuccesDTO<Module> { Message = "Success" };
        }

        public OperationSuccesDTO<Module> DeleteModule(string name)  //look again if it is really working.
        {
            context.Module.Remove(GetModuleByName(name));
            context.SaveChanges();
            return new OperationSuccesDTO<Module> { Message = "Success" };
        }

        public Module GetModuleByName(string moduleName)
        {
            return context.Module.Where(module => module.Name == moduleName).FirstOrDefault();             
        }

        public OperationSuccesDTO<List<Module>> GetModules()
        {
            List<Module> modules = context.Module.ToList();
            return new OperationSuccesDTO<List<Module>> { Message = "Success", Result = modules};
        }
         
        public OperationSuccesDTO<Module> UpdateModule(Module module)
        {
            var updatingModule = context.Module.Where(contextModule => contextModule.Name == module.Name).FirstOrDefault();
            updatingModule.Id = module.Id;
            updatingModule.Name = module.Name;
            updatingModule.Price = module.Price;
            updatingModule.SearchHistory = module.SearchHistory;
            updatingModule.Code = module.Code;
            updatingModule.Description = module.Description;
            updatingModule.AssemblyTime = module.AssemblyTime;

            context.SaveChanges();

            return new OperationSuccesDTO<Module> { Message = "Success" };

        }
    }
}