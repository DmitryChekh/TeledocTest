using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace teledoc_test.Models
{
    public class CustomerModel
    {
        [Key]
        public int CustomderId { get; set; }
        public string ITN { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastUpdate { get; set; }
        public int TypeId { get; set; }
    }
}
