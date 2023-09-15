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
        Task<int> CreateJobOffer(CreateJobOfferDto dto);
        Task<IEnumerable<GetJobOfferDto>> GetAll();
        Task<GetJobOfferDto> GetById(int id);
        Task Remove(int id);
        Task Update(int id, UpdateJobOfferDto dto);
        Task Apply(int id);
    }
    public class JobOfferService : IJobOfferService 
    {
        private readonly JobWebsiteDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IUserContextService _userContextService;
        private readonly ILogger _logger;
        public JobOfferService(JobWebsiteDbContext dbContext, IMapper mapper, IUserContextService userContextService, ILogger<JobOfferService> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _userContextService = userContextService;
            _logger = logger;
        }
        public async Task<int> CreateJobOffer(CreateJobOfferDto dto)
        {
            var jobOffer = _mapper.Map<JobOffer>(dto);
            jobOffer.CreatorId = int.Parse(_userContextService.User.FindFirstValue(ClaimTypes.NameIdentifier));
            await _dbContext.JobOffers.AddAsync(jobOffer);
            await _dbContext.SaveChangesAsync();
            _logger.LogInformation($"Job offer with id: {jobOffer.Id} created");
            return jobOffer.Id;
        }

        public async Task<IEnumerable<GetJobOfferDto>> GetAll()
        {
            var jobOffers = await _dbContext.JobOffers.Include(j => j.Tags).Include(j => j.Creator).Include(j => j.ContractTypes).ToListAsync();
            return _mapper.Map<List<GetJobOfferDto>>(jobOffers);
        }
        public async Task<GetJobOfferDto> GetById(int id)
        {
            var jobOffer = await _dbContext.JobOffers.Include(j => j.Tags).Include(j => j.Creator).Include(j => j.ContractTypes).FirstOrDefaultAsync(j => j.Id == id);
            if (jobOffer is null)
                throw new NotFoundException("Job offer not found");
            return _mapper.Map<GetJobOfferDto>(jobOffer);
        }

        public async Task Remove(int id)
        {
            var jobOffer = await _dbContext.JobOffers.FirstOrDefaultAsync(j => j.Id == id);
            if (jobOffer is null)
                throw new NotFoundException("Job offer not found");
            _dbContext.JobOffers.Remove(jobOffer);
            await _dbContext.SaveChangesAsync();
            _logger.LogInformation($"Job offer with id: {id} removed");
        }

        public async Task Update(int id , UpdateJobOfferDto dto)
        {
            var jobOffer = await _dbContext.JobOffers.FirstOrDefaultAsync(j => j.Id == id);
            if(jobOffer is null)
                throw new NotFoundException("Job offer not found");
            jobOffer.GrossSalary = dto.GrossSalary;
            jobOffer.HoursPerMonth = dto.HoursPerMonth;
            jobOffer.Description = dto.Description;
            await _dbContext.SaveChangesAsync();
            _logger.LogInformation($"Job offer with id: {id} updated");
        }
        public async Task Apply(int id)
        {
            var jobOffer = await _dbContext.JobOffers.Include(j => j.AccountsThatAplied).FirstOrDefaultAsync(j => j.Id == id);
            if (jobOffer is null)
                throw new NotFoundException("Job offer not found");
            var account = await _dbContext.Accounts.Include(a => a.AccountType)
                .FirstOrDefaultAsync(u => u.Id == int.Parse(_userContextService.User.FindFirstValue(ClaimTypes.NameIdentifier)));
            if (account is null)
                throw new NotFoundException("Account not found");
            var accountAlreadyApplied = jobOffer.AccountsThatAplied.Find(a => a.Id == account.Id);
            if (accountAlreadyApplied is not null)
                throw new BadRequestException("You alredy applied to this job offer");
            jobOffer.AccountsThatAplied.Add((PersonalAccount)account);
            await _dbContext.SaveChangesAsync();
            _logger.LogInformation($"Account with id: {account.Id} applied to job offer with id: {jobOffer.Id}");
        }
    }
}
