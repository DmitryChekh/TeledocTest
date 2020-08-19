using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace teledoc_test.Contracts.Requests
{
    public class CreateCustomerRequest
    {
        [Required(ErrorMessage = "ITN is required")]
        public string ITN { get; set; }
        public string Name { get; set; }
        public int TypeId { get; set; }
    }
}
