using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class ProizvodService : IProizvodService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public ProizvodService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper) {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<ProizvodDto> CreateProizvodAsync(ProizvodForCreationDto proizvod)
        {
            var proizvodEntity = _mapper.Map<Proizvod>(proizvod);
            _repository.Proizvod.CreateProizvod(proizvodEntity);
           await _repository.SaveAsync();

            var proizvodToReturn = _mapper.Map<ProizvodDto>(proizvodEntity);
            return proizvodToReturn;
        }

        public async Task<(IEnumerable<ProizvodDto> proizvodi, string ids)> CreateProizvodCollectionAsync(IEnumerable<ProizvodForCreationDto> proizvodCollection)
        {
            if (proizvodCollection is null)
            {
                throw new ProizvodCollectionBadRequest();
            }
            var proizvodEntities = _mapper.Map<IEnumerable<Proizvod>>(proizvodCollection);
            foreach(var proizvod in proizvodEntities)
            {
                _repository.Proizvod.CreateProizvod(proizvod);
            }

           await _repository.SaveAsync();

            var proizvodCollectionToReturn = _mapper.Map<IEnumerable<ProizvodDto>>(proizvodEntities);
            var ids = string.Join(",", proizvodCollectionToReturn.Select(p => p.Id));

            return (proizvodi: proizvodCollectionToReturn, ids: ids);
        }

        public async Task DeleteProizvodAsync(Guid proizvodId, bool trackChanges)
        {
            var proizvod = await _repository.Proizvod.GetProizvodAsync(proizvodId, trackChanges);
            if(proizvod == null)
            {
                throw new ProizvodNotFoundException(proizvodId);
            }
            _repository.Proizvod.DeleteProizvod(proizvod);
            await _repository.SaveAsync();   
        }

        public async Task<IEnumerable<ProizvodDto>> GetAllProizvodiAsync(bool trackChanges)
        {
            var proizvodi = await _repository.Proizvod.GetAllProizvodiAsync(trackChanges);
            var proizvodiDto = _mapper.Map<IEnumerable<ProizvodDto>>(proizvodi);
            return proizvodiDto;
        }

        public async Task<IEnumerable<ProizvodDto>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges)
        {
            if (ids is null) throw new IdParametersBadRequestException();

            var proizvodi = await _repository.Proizvod.GetByIdsAsync(ids, trackChanges);
            if (ids.Count() != proizvodi.Count())
                throw new CollectionByIdsBadRequestException();

            var proizvodiDto = _mapper.Map<IEnumerable<ProizvodDto>>(proizvodi);
            return proizvodiDto;
        }

        public async Task<ProizvodDto> GetProizvodAsync(Guid id, bool trackChanges)
        {
            var proizvod = await _repository.Proizvod.GetProizvodAsync(id, trackChanges);
            if (proizvod is null)
                throw new ProizvodNotFoundException(id);
            var proizvodDto = _mapper.Map<ProizvodDto>(proizvod);
            return proizvodDto;

        }

        public async Task UpdateProizvodAsync(Guid proizvodId, ProizvodForUpdateDto proizvodForUpdate, bool trackChanges)
        {
            var proizvod = await _repository.Proizvod.GetProizvodAsync(proizvodId, trackChanges);
            if(proizvod is null)
            {
                throw new ProizvodNotFoundException(proizvodId);
            }

            _mapper.Map(proizvodForUpdate, proizvod);
            await _repository.SaveAsync();
        }
    }
}
