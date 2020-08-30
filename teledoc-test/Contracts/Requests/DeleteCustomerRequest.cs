using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace teledoc_test.Contracts.Requests
{
    public class DeleteCustomerRequest
    {
        [Required(ErrorMessage = "ID is required")]
        public int CustomerId { get; set; }
    }
}
