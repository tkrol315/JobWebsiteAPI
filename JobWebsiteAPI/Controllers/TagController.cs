using JobWebsiteAPI.Models.TagModels;
using JobWebsiteAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace JobWebsiteAPI.Controllers
{
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly ITagService _tagService;
        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }
        [HttpPost("api/joboffer/{jobOfferId}/tag")]
        public async Task<ActionResult> CreateAddToJobOffer([FromRoute] int jobOfferId, [FromBody] CreateTagDto dto)
        {
            var tagId = await _tagService.CreateAddToJobOffer(jobOfferId, dto);
            return Created($"api/joboffer/{jobOfferId}/tag/{tagId}",null);
        }
        [HttpDelete("api/joboffer/{jobOfferId}/tag/{tagId}")]
        public async Task<ActionResult> RemoveFromJobOffer([FromRoute] int jobOfferId, [FromRoute] int tagId)
        {
            await _tagService.RemoveFromJobOffer(jobOfferId, tagId);
            return NoContent();
        }
        [HttpGet("api/tag")]
        public async Task<ActionResult<IEnumerable<CreateTagDto>>> GetAll()
        {
            var tags = await _tagService.GetAll();
            return Ok(tags);
        }
        [HttpGet("api/tag/{id}")]
        public async Task<ActionResult<GetTagDto>> GetById([FromRoute] int id)
        {
            var tag = await _tagService.GetById(id);
            return Ok(tag);
        }
        [HttpDelete("api/tag/{id}")]
        public async Task<ActionResult> Remove([FromRoute] int id)
        {
            await _tagService.Remove(id);
            return NoContent();
        }
    }
}
