using AutoMapper;
using JobWebsiteAPI.Entities;
using JobWebsiteAPI.Models.AccountModels;
using JobWebsiteAPI.Models.ContractTypeModels;
using JobWebsiteAPI.Models.JobOffer;
using JobWebsiteAPI.Models.TagModels;
using System.Runtime.CompilerServices;

namespace JobWebsiteAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<RegisterAccountDto, Account>()
              .ForPath(a => a.Address.PostalCode, opt => opt.MapFrom(r => r.PostalCode))
              .ForPath(a => a.Address.City, opt => opt.MapFrom(r => r.City))
              .ForPath(a => a.Address.Street, opt => opt.MapFrom(r => r.Street))
              .ForPath(a => a.Address.ApartmentNumber, opt => opt.MapFrom(r => r.ApartmentNumber));

            CreateMap<RegisterPersonalAccountDto, PersonalAccount>()
                .IncludeBase<RegisterAccountDto, Account>();

            CreateMap<RegisterCompanyAccountDto, CompanyAccount>()
                .IncludeBase<RegisterAccountDto, Account>();

            CreateMap<CreateJobOfferDto, JobOffer>()
                .ForMember(c => c.ContractTypes, opt => opt.Ignore());
            CreateMap<JobOffer, GetJobOfferDto>()
                .ForMember(g => g.ContractTypeNames, opt => opt.MapFrom(j => j.ContractTypes.Select(c => c.Name).ToList()))
                .ForMember(g => g.TagNames, opt => opt.MapFrom(j => j.Tags.Select(t => t.Name).ToList()))
                .ForMember(g => g.CompanyName, opt => opt.MapFrom(j => j.Creator.CompanyName));
            CreateMap<Tag, GetTagDto>();
            CreateMap<ContractType, GetContractTypeDto>();
        }
    }
}
