using AutoMapper;
using JobWebsiteAPI.Entities;
using JobWebsiteAPI.Exceptions;
using JobWebsiteAPI.Models.ContractTypeModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace JobWebsiteAPI.Services
{
    public interface IContractTypeSerivce 
    {
        Task<int> CreateAddToJobOffer(int jobOfferId, CreateContractTypeDto dto);
        Task RemoveFromJobOffer(int jobOfferId, int id);
        Task<IEnumerable<GetContractTypeDto>> GetAll();
        Task<GetContractTypeDto> GetById(int id);
        Task Delete(int id);
    }
    public class ContractTypeService : IContractTypeSerivce
    {
        private readonly JobWebsiteDbContext _dbContext;
        private readonly IMapper _mapper;
        public ContractTypeService(JobWebsiteDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<int> CreateAddToJobOffer(int jobOfferId, CreateContractTypeDto dto)
        {
            var jobOffer = await  _dbContext.JobOffers.Include(j => j.ContractTypes).FirstOrDefaultAsync(j => j.Id == jobOfferId);
            if (jobOffer is null)
                throw new NotFoundException("Job offer not found");
            var contractType = await _dbContext.ContractTypes.FirstOrDefaultAsync(c => c.Name.ToLower() == dto.Name.ToLower());
            if (contractType is null)
                contractType = new ContractType() { Name = dto.Name };
            else if (jobOffer.ContractTypes.Any(c => c.Id == contractType.Id))
                throw new BadRequestException("Job offer already contains this contract type");
            jobOffer.ContractTypes.Add(contractType);
            await _dbContext.SaveChangesAsync();
            return contractType.Id;
        }
        public async Task RemoveFromJobOffer(int jobOfferId, int id)
        {
            var jobOffer = await _dbContext.JobOffers.Include(j => j.ContractTypes).FirstOrDefaultAsync(j => j.Id == jobOfferId);
            if (jobOffer is null)
                throw new NotFoundException("Job offer not found");
            var contractType = jobOffer.ContractTypes.Find(c => c.Id == id);
            if (contractType is null)
                throw new NotFoundException("Contract type not found");
            jobOffer.ContractTypes.Remove(contractType);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<IEnumerable<GetContractTypeDto>> GetAll()
        {
            var contractTypes = await _dbContext.ContractTypes.ToListAsync();
            return _mapper.Map<List<GetContractTypeDto>>(contractTypes);
        }
        public async Task<GetContractTypeDto> GetById(int id)
        {
            var contractType = await _dbContext.ContractTypes.FirstOrDefaultAsync(c => c.Id ==id);
            if (contractType is null)
                throw new NotFoundException("Contract type not found");
            return _mapper.Map<GetContractTypeDto>(contractType);
        }
        public async Task Delete(int id)
        {
            var contractType = await _dbContext.ContractTypes.FirstOrDefaultAsync(c => c.Id == id);
            if (contractType is null)
                throw new NotFoundException("Contract type not found");
            _dbContext.ContractTypes.Remove(contractType);
            await _dbContext.SaveChangesAsync();
        }
    }
}
