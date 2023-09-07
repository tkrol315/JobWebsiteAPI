using AutoMapper;
using JobWebsiteAPI.Entities;
using JobWebsiteAPI.Exceptions;
using JobWebsiteAPI.Models.TagModels;
using Microsoft.EntityFrameworkCore;

namespace JobWebsiteAPI.Services
{
    public interface ITagService
    {
        Task<int> CreateAddToJobOffer(int jobOfferId, CreateTagDto dto);
        Task RemoveFromJobOffer(int jobOfferId, int tagId);
        Task<IEnumerable<GetTagDto>> GetAll();
        Task<GetTagDto> GetById(int id);
        Task Remove(int id);
    }
    public class TagService : ITagService
    {
        private readonly JobWebsiteDbContext _dbContext;
        private readonly IMapper _mapper;
        public TagService(JobWebsiteDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<int> CreateAddToJobOffer(int jobOfferId, CreateTagDto dto)
        {
            var job = await _dbContext.JobOffers.Include(j => j.Tags).FirstOrDefaultAsync(j => j.Id == jobOfferId);
            if (job is null)
                throw new NotFoundException("Job offer not found");
            var tag = await _dbContext.Tags.FirstOrDefaultAsync(t => t.Name.ToLower() ==  dto.Name.ToLower());
            if (tag is null) 
                tag = new Tag() { Name = dto.Name };
            else if (job.Tags.Any(t => t.Id == tag.Id))
                throw new BadRequestException("Offer already contains this tag");
            job.Tags.Add(tag);
            await _dbContext.SaveChangesAsync();
            return tag.Id;
        }
        public async Task RemoveFromJobOffer(int jobOfferId, int tagId)
        {
            var jobOffer = await _dbContext.JobOffers.Include(j => j.Tags).FirstOrDefaultAsync(j => j.Id == jobOfferId);
            if (jobOffer is null)
                throw new NotFoundException("Job offer not found");
            var tag = jobOffer.Tags.Find(t => t.Id == tagId);
            if (tag is null)
                throw new NotFoundException("Tag not found");
            jobOffer.Tags.Remove(tag);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<IEnumerable<GetTagDto>> GetAll()
        {
            var tags = await _dbContext.Tags.ToListAsync();
            var tagDtos = _mapper.Map<List<GetTagDto>>(tags);
            return tagDtos;
        }
        public async Task<GetTagDto> GetById(int id)
        {
            var tag = await _dbContext.Tags.FirstOrDefaultAsync(t => t.Id == id);
            return _mapper.Map<GetTagDto>(tag);
        }
        public async Task Remove(int id)
        {
            var tag = await _dbContext.Tags.FirstOrDefaultAsync(t => t.Id == id);
            if (tag is null)
                throw new NotFoundException("Tag not found");
            _dbContext.Tags.Remove(tag);
            await _dbContext.SaveChangesAsync();
        }
    }
}
