using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Student_Management_systems.Models;

namespace Student_Management_systems.Models
{
    public class GeneralViewModel
    {
        public IEnumerable<AttentenceModels> AttentenceModels { get; set; }
        public IEnumerable<ClassModels> ClassModels { get; set; }

    }
}