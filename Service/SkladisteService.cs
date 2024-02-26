using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Repository;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class SkladisteService : ISkladisteService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public SkladisteService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SkladisteDto>> GetAllSkladistaAsync(bool trackChanges)
        {

            var skladista = await _repository.Skladiste.GetAllSkladistaAsync(trackChanges);
            var skladistaDto = _mapper.Map<IEnumerable<SkladisteDto>>(skladista);
            return skladistaDto;
        }

        public async Task<SkladisteDto> GetSkladistaAsync(Guid skladisteId, bool trackChanges) 
        { 
            var skladiste =  await _repository.Skladiste.GetSkladisteAsync(skladisteId, trackChanges);
            if (skladiste is null)
                throw new SkladisteNotFoundException(skladisteId);
            var skladisteDto = _mapper.Map<SkladisteDto>(skladiste);
            return skladisteDto;
        }

        public async Task<SkladisteDto> CreateSkladisteAsync(SkladisteForCreationDto skladiste)
        {
            var skladisteEntity = _mapper.Map<Skladiste>(skladiste);
            _repository.Skladiste.CreateSkladiste(skladisteEntity);
            await _repository.SaveAsync();

            var skladisteToReturn = _mapper.Map<SkladisteDto>(skladisteEntity);
            return skladisteToReturn;
        }
    }
}
