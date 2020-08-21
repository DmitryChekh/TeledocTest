using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using teledoc_test.Contracts.Responses;
using teledoc_test.Models;

namespace teledoc_test.Services.Interfaces
{
    public interface IFounderDataService
    {
        public Task<FounderResponseModel> CreateFounder(string itn, string firstname, string lastname, string middlename);

        public Task<FounderResponseModel> GetFounder(int founderid);

        public Task<ResponseModel> UpdateFounder(FounderModel founderModel);

        public Task<ResponseModel> DeleteFounder(int founderid);

        public Task<EnumerableResponseModel> GetFoundersList(int count); 
    }
}
