using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace teledoc_test.Contracts.Responses
{
    public class ResponseModel
    {
        public bool Success { get; set; }

        public IEnumerable<string> ErrorsMessages { get; set; }

    }
}
