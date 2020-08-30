using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using teledoc_test.Contracts.Requests;
using teledoc_test.Contracts.Responses;
using teledoc_test.Models;

namespace teledoc_test.Services.Interfaces
{
    public interface ICustomerDataService
    {
        public Task<CustomerResponseModel> CreateCustomer(string itn, string name, int typeid, int[] founderid);

        public Task<CustomerResponseModel> GetCustomer(int customerid);

      //  public Task<ResponseModel> UpdateCustomer(UpdateCustomerRequest request);

        public Task<ResponseModel> UpdateCustomer(int customerid, string itn, string name, int[] founderid);

        public Task<ResponseModel> DeleteCustomer(int customerid);

        public Task<CustomerFoundersResponseModel> SetFounderToCustomer(int customerid, int[] founderid);

        public Task<EnumerableResponseModel> GetCustomerList(int count);

        public Task<bool> isFounderExist(int[] id);

        public Task<CustomerFoundersResponseModel> ChangeCustomerFounder(int customerid, int[] founderid, List<CustomerFounderModel> customerFounders);

    }
}
