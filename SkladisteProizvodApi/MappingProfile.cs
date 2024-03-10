using AutoMapper;
using Entities.Models;
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
        }
    }
}
