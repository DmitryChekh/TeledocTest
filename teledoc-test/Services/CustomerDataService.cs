using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using teledoc_test.Contracts.Responses;
using teledoc_test.Models;
using teledoc_test.Models.Data;
using teledoc_test.Services.Interfaces;

namespace teledoc_test.Services
{
    public class CustomerDataService : ICustomerDataService
    {
        private readonly DataContext _dataContext;

        public CustomerDataService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<ResponseModel> CreateCustomer(string itn, string name, int typeid)
        {
            var existingCustomer = await _dataContext.Customers.FirstOrDefaultAsync(c => c.ITN == itn || c.Name == name);

            if(existingCustomer != null)
            {
                return new ResponseModel { Success = false, ErrorsMessages = new[] { "Customer already exists " } };
            }

            var checkCustomerId = await _dataContext.CustomerTypes.FirstOrDefaultAsync(c => c.TypeId == typeid);

            if(checkCustomerId == null)
            {
                return new ResponseModel { Success = false, ErrorsMessages = new[] { "Invalid type of customer" } };
            }

            var customer = new CustomerModel
            {
                ITN = itn,
                Name = name,
                TypeId = typeid,
                Created = DateTime.Now,
                LastUpdate = DateTime.Now,
            };

            var addedCustomer = await _dataContext.Customers.AddAsync(customer);

            if(addedCustomer.State != EntityState.Added)
            {
                return new ResponseModel { Success = false, ErrorsMessages = new[] { "Something wrong. Customer isn't added" } };
            }

            await _dataContext.SaveChangesAsync();

            return new ResponseModel { Success = true };


        }

        public async Task<ResponseModel> DeleteCustomer(int customerid)
        {
            var existingCustomer = await _dataContext.Customers.FirstOrDefaultAsync(c => c.CustomderId == customerid);

            if (existingCustomer == null)
            {
                return new ResponseModel { Success = false, ErrorsMessages = new[] { "Invalid id" } };
            }

            var deleteCustomer = _dataContext.Customers.Remove(existingCustomer);
            await _dataContext.SaveChangesAsync();

            return new ResponseModel { Success = true };
           
        }

        public async Task<CustomerResponseModel> GetCustomer(int customerid)
        {
            var existingCustomer = await _dataContext.Customers.FirstOrDefaultAsync(c => c.CustomderId == customerid);

            if(existingCustomer == null)
            {
                return new CustomerResponseModel { Success = false, ErrorsMessages = new[] { "Customer doesn't exist" } };
            }

            return new CustomerResponseModel { CustomerId = existingCustomer.CustomderId, ITN = existingCustomer.ITN, Name = existingCustomer.Name, Success = true};
            
        }

        public Task<object> SetFounderToCustomer(int customerid, int founderid)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel> UpdateCustomer(CustomerModel customerModel)
        {
            var entity = await _dataContext.Customers.FirstOrDefaultAsync(c => c.CustomderId == customerModel.CustomderId);

            if (entity != null)
            {
                entity.ITN = customerModel.ITN;
                entity.Name = customerModel.Name;
                entity.LastUpdate = DateTime.Now;

                await _dataContext.SaveChangesAsync();
                return new ResponseModel { Success = true };
            } 
            else
            {
                return new ResponseModel { Success = true, ErrorsMessages = new[] { "Invalid customer" } };
            }
        }
    }
}
