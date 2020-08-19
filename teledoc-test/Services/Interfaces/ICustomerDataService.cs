using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using teledoc_test.Contracts.Responses;
using teledoc_test.Models;

namespace teledoc_test.Services.Interfaces
{
    public interface ICustomerDataService
    {
        public Task<SimpleResponseModel> CreateCustomer(string itn, string name, int typeid);

        public Task<CustomerResponseModel> GetCustomer(int customerid);

        public Task<ResponseModel> UpdateCustomer(CustomerModel customerModel);

        public Task<ResponseModel> DeleteCustomer(int customerid);

        public Task<object> SetFounderToCustomer(int customerid, int founderid);

    }
}
