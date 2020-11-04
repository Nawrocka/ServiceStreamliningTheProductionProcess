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
        public City City { get; set; }
        public int ModuleId { get; set; }
        public Module Module { get; set; }
        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateOfLastSearching { get; set; }

    }
}