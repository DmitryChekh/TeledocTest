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
    public class FounderDataService : IFounderDataService
    {
        private readonly DataContext _dataContext;

        public FounderDataService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<ResponseModel> CreateFounder(string itn, string firstname, string lastname, string middlename)
        {
            var existingFounder = await _dataContext.Founders.FirstOrDefaultAsync(x => x.ITN == itn);

            if(existingFounder != null)
            {
                return new ResponseModel { Success = false, ErrorsMessages = new[] { "Founder with this ITN already exist." } };
            }

            var founder = new FounderModel
            {
                ITN = itn,
                FirstName = firstname,
                LastName = lastname,
                MiddleName = middlename,
                Created = DateTime.Now,
                LastUpdate = DateTime.Now
            };

            var addedFounder = await _dataContext.AddAsync(founder);

            if(addedFounder.State != EntityState.Added)
            {
                return new ResponseModel { Success = false, ErrorsMessages = new[] { "Something wrong" } };
            }

            await _dataContext.SaveChangesAsync();

            return new ResponseModel { Success = true };

        }

        public async Task<ResponseModel> DeleteFounder(int founderid)
        {
            var existingFounder = await _dataContext.Founders.FirstOrDefaultAsync(c => c.FounderId == founderid);

            if (existingFounder == null)
            {
                return new ResponseModel { Success = false, ErrorsMessages = new[] { "Invalid id" } };
            }

            var deleteFounder = _dataContext.Founders.Remove(existingFounder);
            await _dataContext.SaveChangesAsync();

            return new ResponseModel { Success = true };
        }

        public async Task<FounderResponseModel> GetFounder(int founderid)
        {
            var existingFounder = await _dataContext.Founders.FirstOrDefaultAsync(c => c.FounderId == founderid);

            if (existingFounder == null)
            {
                return new FounderResponseModel { Success = false, ErrorsMessages = new[] { "Founder doesn't exist" } };
            }

            return new FounderResponseModel
            { 
                CustomerId = existingFounder.FounderId, 
                ITN = existingFounder.ITN, 
                FirstName = existingFounder.FirstName, 
                LastName = existingFounder.LastName,
                MiddleName = existingFounder.MiddleName,
                Success = true 
            };
        }

        public async Task<ResponseModel> UpdateFounder(FounderModel founderModel)
        {
            var entity = await _dataContext.Founders.FirstOrDefaultAsync(c => c.FounderId == founderModel.FounderId);

            if (entity != null)
            {
                entity.ITN = founderModel.ITN;
                entity.FirstName = founderModel.FirstName;
                entity.LastName = founderModel.LastName;
                entity.MiddleName = founderModel.MiddleName;
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
