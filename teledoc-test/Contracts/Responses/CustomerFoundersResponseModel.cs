using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace teledoc_test.Contracts.Responses
{
    public class CustomerFoundersResponseModel : ResponseModel
    {
        public List<int> Founders { get; set; }
    }
}
