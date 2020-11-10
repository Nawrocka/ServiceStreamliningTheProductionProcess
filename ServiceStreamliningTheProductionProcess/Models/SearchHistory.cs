using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ServiceStreamliningTheProductionProcess.Models
{
    public class SearchHistory
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public string ModuleName1 { get; set; }
        public string ModuleName2 { get; set; }
        public string ModuleName3 { get; set; }
        public string ModuleName4 { get; set; }
        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        //public DateTime DateOfLastSearching { get; set; }
        public double ProductionCost { get; set; }
    }
}