using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ServiceStreamliningTheProductionProcess.Models
{
    public class City
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        [Range(0, 999.99, ErrorMessage = "Delivery costs cannot exceed {1} $.")] 
        public double TransportCost { get; set; }
        public double CostOfWorkingHour { get; set; }
        public virtual SearchHistory SearchHistory { get; set; }
    }
}