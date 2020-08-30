using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace teledoc_test.Models
{
    public class CustomerTypeModel
    {
        [Key]
        public int TypeId { get; set; }
        public string Name { get; set; }

    }
}
