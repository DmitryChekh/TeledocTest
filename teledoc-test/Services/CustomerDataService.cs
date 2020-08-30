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

        public async Task<CustomerResponseModel> CreateCustomer(string itn, string name, int typeid, int[] founder)
        {
            if(await isFounderExist(founder))
            {
                var existingCustomer = await _dataContext.Customers.FirstOrDefaultAsync(c => c.ITN == itn || c.Name == name);

                if (existingCustomer != null)
                {
                    return new CustomerResponseModel { Success = false, ErrorsMessages = new[] { "Customer already exists " } };
                }

                var checkCustomerTypeId = await _dataContext.CustomerTypes.FirstOrDefaultAsync(c => c.TypeId == typeid);

                if (checkCustomerTypeId == null)
                {
                    return new CustomerResponseModel { Success = false, ErrorsMessages = new[] { "Invalid type of customer" } };
                }


                if (typeid == 1 && founder.Length > 1)
                {
                    return new CustomerResponseModel { Success = false, ErrorsMessages = new[] { "Customer can has only one founder" } };
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



                if (addedCustomer.State != EntityState.Added)
                {
                    return new CustomerResponseModel { Success = false, ErrorsMessages = new[] { "Something wrong. Customer isn't added" } };
                }

                await _dataContext.SaveChangesAsync();

                var customerResponseModel = new CustomerResponseModel
                {
                    CustomerId = customer.CustomerId,
                    ITN = customer.ITN,
                    Name = customer.Name,
                    Type = checkCustomerTypeId.TypeId
                };

                if (founder != null)
                {
                    var result = await SetFounderToCustomer(customer.CustomerId, founder);
                    customerResponseModel.Success = result.Success;
                    customerResponseModel.ErrorsMessages = result.ErrorsMessages;
                    customerResponseModel.Founders = result.Founders;

                    return customerResponseModel;
                }

                customerResponseModel.Success = true;

                return customerResponseModel;
            }

            return new CustomerResponseModel { Success = false, ErrorsMessages = new[] { "Invalid founders" } };
        }

        public async Task<ResponseModel> DeleteCustomer(int customerid)
        {
            var existingCustomer = await _dataContext.Customers.Include(x => x.CustomerFounder).FirstOrDefaultAsync(c => c.CustomerId == customerid);

            if (existingCustomer == null)
            {
                return new ResponseModel { Success = false, ErrorsMessages = new[] { "Invalid id" } };
            }

            var deleteCustomer = _dataContext.Customers.Remove(existingCustomer);

            if (existingCustomer.CustomerFounder != null)
            {
                foreach (var customerfounder in existingCustomer.CustomerFounder)
                {
                    var deleteLink = _dataContext.CustomerFounder.Remove(customerfounder);
                }
            }

            await _dataContext.SaveChangesAsync();

            return new ResponseModel { Success = true };

        }

        public async Task<CustomerResponseModel> GetCustomer(int customerid)
        {
            var existingCustomer = await _dataContext.Customers.FirstOrDefaultAsync(c => c.CustomerId == customerid);

            if (existingCustomer == null)
            {
                return new CustomerResponseModel { Success = false, ErrorsMessages = new[] { "Customer doesn't exist" } };
            }

            return new CustomerResponseModel { CustomerId = existingCustomer.CustomerId, ITN = existingCustomer.ITN, Name = existingCustomer.Name, Success = true };

        }


        public async Task<EnumerableResponseModel> GetCustomerList(int count = 0)
        {
            if (count == 0)
            {
                var customerList = await _dataContext.Customers.Select(x => new CustomerResponseModel
                {
                    CustomerId = x.CustomerId,
                    Name = x.Name,
                    ITN = x.ITN,
                    Type = x.TypeId,
                    Founders = x.CustomerFounder.Select(x => x.FounderId).ToList(),
                    Success = false
                }).ToListAsync();


                if (customerList == null)
                {
                    return new EnumerableResponseModel { Success = false, ErrorsMessages = new[] { "Customer list is empty" } };
                }

                return new EnumerableResponseModel { Data = customerList, Success = true };
            }

            else
            {
                var customerList = await _dataContext.Customers
                        .Select(x => new CustomerResponseModel
                        {
                            CustomerId = x.CustomerId,
                            Name = x.Name,
                            ITN = x.ITN,
                            Founders = x.CustomerFounder.Select(x => x.FounderId).ToList(),
                            Success = false
                        }).Take(count).ToListAsync();

                if (customerList == null)
                {
                    return new EnumerableResponseModel { Success = false, ErrorsMessages = new[] { "Customer list is empty" } };
                }

                return new EnumerableResponseModel { Data = customerList, Success = true };
            }
        }

        public async Task<CustomerFoundersResponseModel> SetFounderToCustomer(int customerid, int[] founderid)
        {
            List<int> founderList = new List<int>();
            foreach (var founder in founderid)
            {

                    var relation = await _dataContext.CustomerFounder.FirstOrDefaultAsync(x => x.CustomerId == customerid
                        && x.FounderId == founder);

                    if (relation != null)
                    {
                        return new CustomerFoundersResponseModel { Success = false, ErrorsMessages = new[] { "This relation is exist" } };
                    }

                    var newRelation = await _dataContext.CustomerFounder.AddAsync(new CustomerFounderModel
                    {
                        CustomerId = customerid,
                        FounderId = founder,
                    });

                    founderList.Add(founder);
            }


            await _dataContext.SaveChangesAsync();

            return new CustomerFoundersResponseModel { Success = true, Founders = founderList };
        }

        public async Task<ResponseModel> UpdateCustomer(int id, string itn, string name, int[] founderid)
        {
            if(await isFounderExist(founderid))
            {
                var entity = await _dataContext.Customers.Include(x => x.CustomerFounder).FirstOrDefaultAsync(c => c.CustomerId == id);

                if (entity != null)
                {
                    entity.ITN = itn;
                    entity.Name = name;
                    entity.LastUpdate = DateTime.Now;

                    await _dataContext.SaveChangesAsync();

                    var response = new CustomerResponseModel
                    {
                        CustomerId = id,
                        ITN = itn,
                        Name = name,
                        Type = entity.TypeId,
                        Founders = entity.CustomerFounder.Select(x => x.FounderId).ToList(),
                        Success = true
                    };

                    if (entity.CustomerFounder != null)
                    {
                        var responseFounders = await ChangeCustomerFounder(id, founderid, entity.CustomerFounder);

                        response.Founders = responseFounders.Founders;

                        return response;
                    }
                    return response;
                }
                else
                {
                    return new ResponseModel { Success = false, ErrorsMessages = new[] { "Invalid customer" } };
                }
            }
            else
            {
                return new ResponseModel { Success = false, ErrorsMessages = new[] { "Invalid founders" } };
            }
            
        }




        public async Task<bool> isFounderExist(int[] founders)
        {
            List<int> entities = new List<int>();

            foreach (var founderid in founders)
            {
                var entity = await _dataContext.Founders.FirstOrDefaultAsync(x => x.FounderId == founderid);

                if (entity == null)
                {
                    return false;
                }
            }
            return true;
        }


        public async Task<CustomerFoundersResponseModel> ChangeCustomerFounder(int customerid, int[] founderid, List<CustomerFounderModel> customerFounders)
        {
            List<int> nextFounders = new List<int>();
            List<int> prevFounders = new List<int>();

            foreach (var founder in customerFounders)
            {
                prevFounders.Add(founder.FounderId);
            }

            foreach (var founder in founderid)
            {
                nextFounders.Add(founder);
            }

            var deleteFounders = prevFounders.Except(nextFounders);
            var addFounders = nextFounders.Except(prevFounders);

            foreach (var founder in deleteFounders)
            {
                var deleteFounder = await _dataContext.CustomerFounder.FirstOrDefaultAsync(x => x.CustomerId == customerid && x.FounderId == founder);

                _dataContext.Remove(deleteFounder);
            }

            foreach (var founder in addFounders)
            {

                var addFounder = new CustomerFounderModel
                {
                    CustomerId = customerid,
                    FounderId = founder
                };

                await _dataContext.AddAsync(addFounder);
            }

            await _dataContext.SaveChangesAsync();
            var resultFounders = await _dataContext.CustomerFounder.Where(x => x.CustomerId == customerid).
                Select(x => x.FounderId).ToListAsync();

            return new CustomerFoundersResponseModel { Founders = resultFounders, Success = true };
        }
    }
}
