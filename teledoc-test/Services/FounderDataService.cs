using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using teledoc_test.Models;
using teledoc_test.Models.Data;
using teledoc_test.Services.Interfaces;

namespace teledoc_test.Services
{
    public class FounderDataService : IFounderDataService
    {
        private readonly DataContext dataContext;

        public Task<object> CreateFounder(string itn, string name, string typeid)
        {
            throw new NotImplementedException();
        }

        public Task<object> DeleteFounder(int customerid)
        {
            throw new NotImplementedException();
        }

        public Task<object> GetFounder(int customerid)
        {
            throw new NotImplementedException();
        }

        public Task<object> UpdateFounder(FounderModel customerModel)
        {
            throw new NotImplementedException();
        }
    }
}
