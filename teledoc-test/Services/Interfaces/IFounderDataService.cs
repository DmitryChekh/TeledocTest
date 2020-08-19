using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using teledoc_test.Models;

namespace teledoc_test.Services.Interfaces
{
    public interface IFounderDataService
    {
        public Task<object> CreateFounder(string itn, string name, string typeid);

        public Task<object> GetFounder(int customerid);

        public Task<object> UpdateFounder(FounderModel customerModel);

        public Task<object> DeleteFounder(int customerid);

    }
}
