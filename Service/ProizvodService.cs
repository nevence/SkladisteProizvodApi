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
    }
}
