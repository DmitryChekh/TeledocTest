using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace teledoc_test.Contracts.Responses
{
    public class FounderResponseModel : ResponseModel
    {
        public int FounderId { get; set; }
        public string ITN { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string MiddleName { get; set; }
    }
}
