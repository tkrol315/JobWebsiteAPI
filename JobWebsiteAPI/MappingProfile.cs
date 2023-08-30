using AutoMapper;
using JobWebsiteAPI.Entities;
using JobWebsiteAPI.Models;
using System.Runtime.CompilerServices;

namespace JobWebsiteAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterPersonalAccountDto, PersonalAccount>()
                .ForPath(a => a.Address.PostalCode, opt => opt.MapFrom(r => r.PostalCode))
                .ForPath(a => a.Address.City, opt => opt.MapFrom(r => r.City))
                .ForPath(a => a.Address.Street, opt => opt.MapFrom(r => r.Street))
                .ForPath(a => a.Address.ApartmentNumber, opt => opt.MapFrom(r => r.ApartmentNumber));
            CreateMap<RegisterCompanyAccountDto, CompanyAccount>()
              .ForPath(a => a.Address.PostalCode, opt => opt.MapFrom(r => r.PostalCode))
              .ForPath(a => a.Address.City, opt => opt.MapFrom(r => r.City))
              .ForPath(a => a.Address.Street, opt => opt.MapFrom(r => r.Street))
              .ForPath(a => a.Address.ApartmentNumber, opt => opt.MapFrom(r => r.ApartmentNumber));
        }
    }
}
