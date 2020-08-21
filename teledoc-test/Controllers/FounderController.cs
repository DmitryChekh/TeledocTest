using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    public class FounderController : ControllerBase
    {

        private readonly IFounderDataService _founderDataService;

        public FounderController(IFounderDataService founderDataService)
        {
            _founderDataService = founderDataService;
        }


        [HttpPost("api/founder/create")]
        public async Task<IActionResult> FounderCreate([FromBody]CreateFounderRequest request)
        {
            if (request == null)
            {
                return BadRequest("Request model is not correct");
            }

            var response = await _founderDataService.CreateFounder(
                request.ITN,
                request.FirstName,
                request.LastName,
                request.MiddleName
                );

            if (!response.Success)
            {
                return BadRequest(response.ErrorsMessages);
            }

            return Ok(response);
        }

        [HttpPost("api/founder/get")]
        public async Task<IActionResult> GetFounder([FromBody] GetFounderRequest request)
        {

            var response = await _founderDataService.GetFounder(request.FounderId);

            if (!response.Success)
            {
                return BadRequest(response.ErrorsMessages);
            }

            return Ok(response);
        }


        [HttpPost("api/founder/update")]
        public async Task<IActionResult> UpdateCustomer([FromBody] UpdateFounderRequest request)
        {
            if (request == null)
            {
                return BadRequest("Request model is not correct");
            }

            FounderModel founderModel = new FounderModel
            {
                FounderId = request.FounderId,
                ITN = request.ITN,
                FirstName = request.FirstName,
                LastName = request.LastName,
                MiddleName = request.MiddleName
            };

            var response = await _founderDataService.UpdateFounder(founderModel);

            if (!response.Success)
            {
                return BadRequest(response.ErrorsMessages);
            }

            return Ok(response);
        }

        [HttpPost("api/founder/delete")]
        public async Task<IActionResult> DeleteFounder([FromBody] DeleteFounderRequest request)
        {

            var response = await _founderDataService.DeleteFounder(request.FounderId);

            if (!response.Success)
            {
                return BadRequest(response.ErrorsMessages);
            }

            return Ok(response);
        }


        [HttpPost("api/founder/get/list={count}")]
        public async Task<IActionResult> GetFounderList([FromRoute] int count = 0)
        {

            var response = await _founderDataService.GetFoundersList(count);

            if (!response.Success)
            {
                return BadRequest(response.ErrorsMessages);
            }

            return Ok(response);
        }


    }
}