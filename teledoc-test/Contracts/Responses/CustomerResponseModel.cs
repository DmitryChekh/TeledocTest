using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using teledoc_test.Models;

namespace teledoc_test.Contracts.Responses
{
    public class CustomerResponseModel : ResponseModel
    {
        public int CustomerId { get; set; }
        public string ITN { get; set; }
        public string Name { get; set; }
        
        public int Type { get; set; }
        public List<int> Founders { get; set; }
    }


}
