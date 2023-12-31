﻿using JobWebsiteAPI.Models.JobOffer;
using JobWebsiteAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobWebsiteAPI.Controllers
{
    [ApiController]
    [Route("api/joboffer")]
    public class JobOfferController : ControllerBase
    {
        private readonly IJobOfferService _jobOfferService;
        public JobOfferController(IJobOfferService jobOfferService)
        {
            _jobOfferService = jobOfferService;
        }
       
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateJobOfferDto dto)
        {
            var id = await _jobOfferService.CreateJobOffer(dto);
            return Created($"api/joboffer/{id}",null);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetJobOfferDto>>> GetAll()
        {
            var jobs = await _jobOfferService.GetAll();
            return Ok(jobs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetJobOfferDto>> GetById([FromRoute] int id)
        {
            var job = await _jobOfferService.GetById(id);
            return Ok(job);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Remove([FromRoute] int id)
        {
            await _jobOfferService.Remove(id);
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Udpate([FromRoute] int id, [FromBody] UpdateJobOfferDto dto)
        {
            await _jobOfferService.Update(id, dto);
            return NoContent();
        }
        [Authorize(Roles = "PersonalAccount")]
        [HttpPost("{id}")]
        public async Task<ActionResult> Apply([FromRoute] int id)
        {
            await _jobOfferService.Apply(id);
            return NoContent();
        }
    }
}
