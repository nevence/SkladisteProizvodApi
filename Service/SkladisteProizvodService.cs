using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class SkladisteProizvodService : ISkladisteProizvodService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public SkladisteProizvodService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<SkladisteProizvodDto> AddProizvodAsync(SkladisteProizvodForCreationDto skladisteProizvod)
        {
            var proizvod = await _repository.SkladisteProizvod.GetProizvodAsync(skladisteProizvod.ProizvodId, skladisteProizvod.SkladisteId, trackChanges: false);
            if (proizvod != null)
            {
                throw new SkladisteProizvodExistsBadRequestException(skladisteProizvod.SkladisteId, skladisteProizvod.ProizvodId);
            }
            var proizvodEntity = _mapper.Map<SkladisteProizvod>(skladisteProizvod);
            _repository.SkladisteProizvod.AddProizvod(proizvodEntity);
            await _repository.SaveAsync();

            var proizvodToReturn = _mapper.Map<SkladisteProizvodDto>(proizvodEntity);
            return proizvodToReturn;
        }

        public async Task DeliverProizvodAsync(SkladisteProizvodForDeliveryDto skladisteProizvod, bool trackChanges)
        {
            var proizvod = await _repository.SkladisteProizvod.GetProizvodAsync(skladisteProizvod.ProizvodId, skladisteProizvod.SkladisteId, trackChanges);
            if (proizvod is null)
            {
                throw new ProizvodNotFoundException(skladisteProizvod.ProizvodId);
            }
            var skladiste = await _repository.Skladiste.GetSkladisteAsync(skladisteProizvod.SkladisteId, trackChanges: false);
            if (skladiste is null)
            {
                throw new SkladisteNotFoundException(skladisteProizvod.SkladisteId);
            }
            if (proizvod.Kolicina < skladisteProizvod.Kolicina)
            {
                throw new KolicinaBadRequestException(skladisteProizvod.Kolicina);
            }

            _mapper.Map(skladisteProizvod, proizvod);
            await SubtractPopunjenoAsync(skladisteProizvod.SkladisteId, skladisteProizvod.Kolicina);
            await _repository.SaveAsync();


        }

        public async Task<(IEnumerable<SkladisteProizvodDto> skladisteProizvodi, MetaData metaData)> GetAllProizvodiAsync(SkladisteProizvodParameters proizvodParameters, Guid skladisteId, bool trackChanges)
        {
            var proizvodi = await _repository.SkladisteProizvod.GetAllProizvodiAsync(proizvodParameters, skladisteId, trackChanges);
            var proizvodiDto = new List<SkladisteProizvodDto>();
            foreach (var item in proizvodi)
            {
                var proizvodDto = _mapper.Map<SkladisteProizvodDto>(item);
                proizvodiDto.Add(proizvodDto);
            }

            return(skladisteProizvodi:  proizvodiDto, metaData: proizvodi.MetaData);
        }

        public async Task<SkladisteProizvodDto> GetProizvodAsync(Guid proizvodId, Guid skladisteId, bool trackChanges)
        {
            var proizvod = await _repository.SkladisteProizvod.GetProizvodAsync(proizvodId, skladisteId, trackChanges);
            if(proizvod is null)
            {
                throw new ProizvodNotFoundException(proizvodId);
            }
            Console.WriteLine($"Id: {proizvod.Id}, ProizvodId: {proizvod.ProizvodId}, SkladisteId: {proizvod.SkladisteId}, Kolicina: {proizvod.Kolicina}");

            var proizvodDto = _mapper.Map<SkladisteProizvodDto>(proizvod);
            return proizvodDto;
        }

        public async Task OrderProizvodAsync(SkladisteProizvodForOrderDto skladisteProizvod, bool trackChanges)
        {
            var proizvod = await _repository.SkladisteProizvod.GetProizvodAsync(skladisteProizvod.ProizvodId, skladisteProizvod.SkladisteId, trackChanges);
            if (proizvod is null)
            {
                throw new ProizvodNotFoundException(skladisteProizvod.ProizvodId);
            }
            var skladiste = await _repository.Skladiste.GetSkladisteAsync(skladisteProizvod.SkladisteId, trackChanges: false);
            if (skladiste is null)
            {
                throw new SkladisteNotFoundException(skladisteProizvod.SkladisteId);
            }
            if ((skladisteProizvod.Kolicina + skladiste.Popunjeno) > skladiste.Kapacitet)
            {
                throw new KolicinaBadRequestException(skladisteProizvod.Kolicina);
            }

            _mapper.Map(skladisteProizvod, proizvod);
            await AddPopunjenoAsync(skladisteProizvod.SkladisteId, skladisteProizvod.Kolicina);
            await _repository.SaveAsync();
        }

        public async Task RemoveProizvodAsync(Guid proizvodId, Guid skladisteId, bool trackChanges)
        {
            var proizvod = await _repository.SkladisteProizvod.GetProizvodAsync(proizvodId, skladisteId, trackChanges);
            if(proizvod is null)
            {
                throw new ProizvodNotFoundException(proizvodId);    
            }

            _repository.SkladisteProizvod.DeleteProizvod(proizvod);
            await SubtractPopunjenoAsync(skladisteId, proizvod.Kolicina);
            await _repository.SaveAsync();
        }

        public async Task AddPopunjenoAsync(Guid skladisteId, int Kolicina)
        {
            var skladiste = await _repository.Skladiste.GetSkladisteAsync(skladisteId, trackChanges: false);
            skladiste.Popunjeno += Kolicina;
        }

        public async Task SubtractPopunjenoAsync(Guid skladisteId, int Kolicina)
        {
            var skladiste = await _repository.Skladiste.GetSkladisteAsync(skladisteId, trackChanges: false);
            skladiste.Popunjeno -= Kolicina;
        }
    }
}
