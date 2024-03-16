using AutoMapper;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Shared.DataTransferObjects;

namespace SkladisteProizvodApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<Skladiste, SkladisteDto>()
                .ForCtorParam("NazivAdresa",
                opt => opt.MapFrom(x => string.Join(' ', x.Naziv, x.Adresa)));

            CreateMap<SkladisteForCreationDto, Skladiste>();
            CreateMap<Proizvod, ProizvodDto>();
            CreateMap<ProizvodForCreationDto, Proizvod>();
            CreateMap<SkladisteForUpdateDto, Skladiste>();
            CreateMap<ProizvodForUpdateDto, Proizvod>();
            CreateMap<UserForRegistrationDto, User>();
            CreateMap<UserForUpdateDto, User>();
            CreateMap<User, UserDto>();
            CreateMap<SkladisteProizvod, SkladisteProizvodDto>()
                .IncludeMembers(sp => sp.Proizvod)
                .ForMember(dto => dto.Kolicina, opt => opt.MapFrom(sp => sp.Kolicina))
                .ForMember(dto => dto.Naziv, opt => opt.MapFrom(sp => sp.Proizvod.Naziv))
                .ForMember(dto => dto.Kategorija, opt => opt.MapFrom(sp => sp.Proizvod.Kategorija))
                .ForMember(dto => dto.Cena, opt => opt.MapFrom(sp => sp.Proizvod.Cena))
                .ForMember(dto => dto.ImageURL, opt => opt.MapFrom(sp => sp.Proizvod.ImageURL));
               


        }
    }
}
