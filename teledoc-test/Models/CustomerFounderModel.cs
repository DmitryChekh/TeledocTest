using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace teledoc_test.Models
{
    public class CustomerFounderModel
    {
        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int FounderId { get; set; }
    }
}
