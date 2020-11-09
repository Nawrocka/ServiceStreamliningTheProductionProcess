using ServiceStreamliningTheProductionProcess.Models;
using ServiceStreamliningTheProductionProcess.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceStreamliningTheProductionProcess.Services.Interfaces
{
    public interface IModuleService
    {
        Module GetModuleByName(string moduleName);
        OperationSuccesDTO<List<Module>> GetModules();
        OperationSuccesDTO<Module> AddModule(Module module);
        OperationSuccesDTO<Module> UpdateModule(Module module);
        OperationSuccesDTO<Module> DeleteModule(string name);
        
    }
}