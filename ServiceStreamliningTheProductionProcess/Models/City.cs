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
        public float DeliveryCosts { get; set; }
        public float HourlyWage { get; set; }
        public ICollection<SearchHistory> SearchHistories { get; set; }
    }
}