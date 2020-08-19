using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace teledoc_test.Contracts.Requests
{
    public class DeleteFounderRequest
    {
        [Required(ErrorMessage = "ID is required")]
        public int FounderId { get; set; }

    }
}
