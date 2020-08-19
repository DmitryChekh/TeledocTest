using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace teledoc_test.Contracts.Responses
{
    public class CustomerResponseModel : ResponseModel
    {
        public int CustomerId { get; set; }
        public string ITN { get; set; }
        public string Name { get; set; }

    }


}
