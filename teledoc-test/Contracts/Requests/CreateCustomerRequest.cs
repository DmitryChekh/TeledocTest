using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace teledoc_test.Contracts.Requests
{
    public class CreateCustomerRequest
    {
        public string ITN { get; set; }
        public string Name { get; set; }
        public int TypeId { get; set; }
    }
}
