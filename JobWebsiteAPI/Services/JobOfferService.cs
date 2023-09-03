using AutoMapper;
using JobWebsiteAPI.Entities;
using JobWebsiteAPI.Exceptions;
using JobWebsiteAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace JobWebsiteAPI.Services
{
    public interface IJobOfferService
    {
        Task<int> CreateJobOfferDto(CreateJobOfferDto dto);
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
            var contractTypes = await _dbContext.ContractTypes
                .Where(c => dto.ContractTypes.Any(ct => c.Id == ct)).ToListAsync();
            jobOffer.ContractTypes = contractTypes;
            jobOffer.CreatorId = int.Parse(_userContextService.User.FindFirstValue(ClaimTypes.NameIdentifier));
            await _dbContext.JobOffers.AddAsync(jobOffer);
            await _dbContext.SaveChangesAsync();
            return jobOffer.Id;
        }
    }
}
