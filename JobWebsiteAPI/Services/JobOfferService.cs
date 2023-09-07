using AutoMapper;
using JobWebsiteAPI.Entities;
using JobWebsiteAPI.Exceptions;
using JobWebsiteAPI.Models.JobOffer;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace JobWebsiteAPI.Services
{
    public interface IJobOfferService
    {
        Task<int> CreateJobOfferDto(CreateJobOfferDto dto);
        Task<IEnumerable<GetJobOfferDto>> GetAll();
        Task<GetJobOfferDto> GetById(int id);
        Task Remove(int id);
        Task Update(int id, UpdateJobOfferDto dto);
    }
    public class JobOfferService : IJobOfferService 
    {
        private readonly JobWebsiteDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IUserContextService _userContextService;
        public JobOfferService(JobWebsiteDbContext dbContext, IMapper mapper, IUserContextService userContextService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _userContextService = userContextService;
        }
        public async Task<int> CreateJobOfferDto(CreateJobOfferDto dto)
        {
            var jobOffer = _mapper.Map<JobOffer>(dto);
            jobOffer.CreatorId = int.Parse(_userContextService.User.FindFirstValue(ClaimTypes.NameIdentifier));
            await _dbContext.JobOffers.AddAsync(jobOffer);
            await _dbContext.SaveChangesAsync();
            return jobOffer.Id;
        }

        public async Task<IEnumerable<GetJobOfferDto>> GetAll()
        {
            var jobs = await _dbContext.JobOffers.Include(j => j.Tags).Include(j => j.Creator).Include(j => j.ContractTypes).ToListAsync();
            return _mapper.Map<List<GetJobOfferDto>>(jobs);
        }
        public async Task<GetJobOfferDto> GetById(int id)
        {
            var job = await _dbContext.JobOffers.Include(j => j.Tags).Include(j => j.Creator).Include(j => j.ContractTypes).FirstOrDefaultAsync(j => j.Id == id);
            if (job is null)
                throw new NotFoundException("Job offer not found");
            return _mapper.Map<GetJobOfferDto>(job);
        }

        public async Task Remove(int id)
        {
            var job =await _dbContext.JobOffers.FirstOrDefaultAsync(j => j.Id == id);
            if (job is null)
                throw new NotFoundException("Job offer not found");
            _dbContext.JobOffers.Remove(job);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(int id , UpdateJobOfferDto dto)
        {
            var job = await _dbContext.JobOffers.FirstOrDefaultAsync(j => j.Id == id);
            if(job is null)
                throw new NotFoundException("Job offer not found");
            job.GrossSalary = dto.GrossSalary;
            job.HoursPerMonth = dto.HoursPerMonth;
            job.Description = dto.Description;
            await _dbContext.SaveChangesAsync();
        }
    }
}
