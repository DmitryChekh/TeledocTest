using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace teledoc_test.Models
{
    public class FounderModel
    { 
        [Key]
        public int Id { get; set; }
        public int ITN { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastUpdate { get; set; }

    }
}
