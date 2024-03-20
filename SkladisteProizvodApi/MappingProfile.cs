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
            CreateMap<Proizvod, SkladisteProizvodDto>()
                .ForMember(dest => dest.Naziv, opt => opt.MapFrom(src => src.Naziv))
                .ForMember(dest => dest.Kategorija, opt => opt.MapFrom(src => src.Kategorija))
                .ForMember(dest => dest.Cena, opt => opt.MapFrom(src => src.Cena))
                .ForMember(dest => dest.ImageURL, opt => opt.MapFrom(src => src.ImageURL));
            CreateMap<SkladisteProizvod, SkladisteProizvodDto>()
                 .ForMember(dto => dto.Id, opt => opt.MapFrom(sp => sp.ProizvodId))
                 .ForMember(dto => dto.Kolicina, opt => opt.MapFrom(sp => sp.Kolicina))
                 .ForMember(dto => dto.Naziv, opt => opt.MapFrom(sp => sp.Proizvod.Naziv))
                 .ForMember(dto => dto.Kategorija, opt => opt.MapFrom(sp => sp.Proizvod.Kategorija))
                 .ForMember(dto => dto.Cena, opt => opt.MapFrom(sp => sp.Proizvod.Cena))
                 .ForMember(dto => dto.ImageURL, opt => opt.MapFrom(sp => sp.Proizvod.ImageURL));

            CreateMap<SkladisteProizvodForCreationDto, SkladisteProizvod>()
                .ForMember(dest => dest.Kolicina, opt => opt.MapFrom(src => 0));

            CreateMap<SkladisteProizvodForDeliveryDto, SkladisteProizvod>()
     .ForMember(dest => dest.Kolicina,
                opt => opt.MapFrom(src => src.Kolicina > src.Kolicina ? 0 : src.Kolicina - src.Kolicina));

            CreateMap<SkladisteProizvodForOrderDto, SkladisteProizvod>()
                .ForMember(dest => dest.Kolicina, opt => opt.MapFrom((src, dest) => dest.Kolicina + src.Kolicina));


        }
    }
}
