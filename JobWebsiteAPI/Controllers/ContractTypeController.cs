using JobWebsiteAPI.Models.ContractTypeModels;
using JobWebsiteAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace JobWebsiteAPI.Controllers
{
    [ApiController]
    public class ContractTypeController : ControllerBase
    {
        private readonly IContractTypeSerivce _contractTypeService;
        public ContractTypeController(IContractTypeSerivce contractTypeSerivce)
        {
            _contractTypeService = contractTypeSerivce;
        }
        [HttpPost("api/joboffer/{jobOfferId}/contracttype")]
        public async Task<ActionResult> CreateAddToJobOffer([FromRoute] int jobOfferId, [FromBody] CreateContractTypeDto dto)
        {
            var id = await _contractTypeService.CreateAddToJobOffer(jobOfferId, dto);
            return Created($"api/joboffer/{jobOfferId}/contracttype/{id}", null);
        }
        [HttpDelete("api/joboffer/{jobOfferId}/contracttype/{id}")]
        public async Task<ActionResult> RemoveFromJobOffer([FromRoute] int jobOfferId, [FromRoute] int id)
        {
            await _contractTypeService.RemoveFromJobOffer(jobOfferId, id);
            return NoContent();
        }
        [HttpGet("api/contracttype")]
        public async Task<ActionResult<IEnumerable<GetContractTypeDto>>> GetAll()
        {
            var contractTypes = await _contractTypeService.GetAll();
            return Ok(contractTypes);
        }
        [HttpGet("api/contracttype/{id}")]
        public async Task<ActionResult<GetContractTypeDto>> GetById([FromRoute] int id)
        {
            var contractType = await _contractTypeService.GetById(id);
            return Ok(contractType);
        }
        [HttpDelete("api/contracttype/{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            await _contractTypeService.Remove(id);
            return NoContent();
        }
    }
}
