using JobWebsiteAPI.Models;
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
            var id = await _jobOfferService.CreateJobOfferDto(dto);
            return Created($"api/joboffer/{id}",null);
        }
    }
}
