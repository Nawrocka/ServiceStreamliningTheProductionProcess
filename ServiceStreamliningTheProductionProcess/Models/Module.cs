using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ServiceStreamliningTheProductionProcess.Models
{
    public class Module
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public double Price { get; set; } //in case of larger calulation I'd use decimal type
        public double AssemblyTime { get; set; }        
        public double Weight { get; set; }
        [StringLength(300)]
        public string Description { get; set; }
        public virtual SearchHistory SearchHistory { get; set; }
    }
}