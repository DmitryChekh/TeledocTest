using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using teledoc_test.Contracts.Requests;
using teledoc_test.Models;
using teledoc_test.Services.Interfaces;

namespace teledoc_test.Controllers
{
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerDataService _customerDataServce;

        public CustomerController(ICustomerDataService customerDataService)
        {
            _customerDataServce = customerDataService;
        }

        [HttpPost("api/customer/create")]
        public async Task<IActionResult> CreateCustomer([FromBody]CreateCustomerRequest request)
        {
            if (request == null)
            {
                return BadRequest("Request model is not correct");
            }


            var response = await _customerDataServce.CreateCustomer(
                request.ITN,
                request.Name,
                request.TypeId,
                request.foundersId
                );

            if(!response.Success)
            {
                return BadRequest(response.ErrorsMessages);
            }

            return Ok(response);
        }

        [HttpPost("api/customer/get")]
        public async Task<IActionResult> GetCustomer([FromBody] GetCustomerRequest request)
        {
            if (request == null)
            {
                return BadRequest("Request model is not correct");
            }

            var response = await _customerDataServce.GetCustomer(request.CustomerId);

            if (!response.Success)
            {
                return BadRequest(response.ErrorsMessages);
            }

            return Ok(response);
        }


        [HttpPost("api/customer/delete")]
        public async Task<IActionResult> DeleteCustomer([FromBody] DeleteCustomerRequest request)
        {
            if (request == null)
            {
                return BadRequest("Request model is not correct");
            }

            var response = await _customerDataServce.DeleteCustomer(request.CustomerId);

            if (!response.Success)
            {
                return BadRequest(response.ErrorsMessages);
            }

            return Ok(response);
        }


        [HttpPost("api/customer/update")]
        public async Task<IActionResult> UpdateCustomer([FromBody] UpdateCustomerRequest request)
        {
            if (request == null)
            {
                return BadRequest("Request model is not correct");
            }


            var response = await _customerDataServce.UpdateCustomer(request.CustomerId, request.ITN, request.Name, request.Founders);

            if (!response.Success)
            {
                return BadRequest(response.ErrorsMessages);
            }

            return Ok(response);
        }


        [HttpPost("api/customer/get/list={count}")]
        public async Task<IActionResult> GetFounderList([FromRoute] int count = 0)
        {

            var response = await _customerDataServce.GetCustomerList(count);

            if (!response.Success)
            {
                return BadRequest(response.ErrorsMessages);
            }

            return Ok(response);
        }
    }
}