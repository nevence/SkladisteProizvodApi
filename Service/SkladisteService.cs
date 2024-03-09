using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Repository;
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

        public async Task<(IEnumerable<SkladisteDto> skladista, MetaData metaData)> GetAllSkladistaAsync(SkladisteParameters skladisteParameters, bool trackChanges)
        {

            var skladista = await _repository.Skladiste.GetAllSkladistaAsync(skladisteParameters, trackChanges);
            var skladistaDto = _mapper.Map<IEnumerable<SkladisteDto>>(skladista);
            return (skladista: skladistaDto, metaData: skladista.MetaData);
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

        public async Task<IEnumerable<SkladisteDto>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges)
        {
            if (ids == null) throw new IdParametersBadRequestException();

            var skladista = await _repository.Skladiste.GetByIdsAsync(ids, trackChanges);    
            if(ids.Count() != skladista.Count())
                throw new CollectionByIdsBadRequestException();
            var skladistaDto = _mapper.Map<IEnumerable<SkladisteDto>>(skladista);   
            return skladistaDto;
        }

        public async Task<(IEnumerable<SkladisteDto> skladista, string ids)> CreateSkladisteCollectionAsync(IEnumerable<SkladisteForCreationDto> skladisteCollection)
        {
            if (skladisteCollection == null)
                throw new SkladisteCollectionBadRequest();

            var skladisteEntities = _mapper.Map<IEnumerable<Skladiste>>(skladisteCollection);
            foreach(var skladste in skladisteEntities)
            {
                _repository.Skladiste.CreateSkladiste(skladste);
            }

            await _repository.SaveAsync();

            var skladisteCollectionToReturn =
                _mapper.Map<IEnumerable<SkladisteDto>>(skladisteEntities);
            var ids = string.Join(",", skladisteCollectionToReturn.Select(s => s.Id));

            return(skladista: skladisteCollectionToReturn, ids:ids);
        }

        public async Task DeleteSkladisteAsync(Guid skladisteId, bool trackChanges)
        {
            var skladiste = await _repository.Skladiste.GetSkladisteAsync(skladisteId, trackChanges);
            if(skladiste is null)
            {
                throw new SkladisteNotFoundException(skladisteId);
            }

            _repository.Skladiste.DeleteSkladiste(skladiste);
            await _repository.SaveAsync();
        }

        public async Task UpdateSkladisteAsync(Guid skladisteId, SkladisteForUpdateDto skladisteForUpdate, bool trackChanges)
        {
            var skladiste = await _repository.Skladiste.GetSkladisteAsync(skladisteId, trackChanges);
            if(skladiste is null)
            {
                throw new SkladisteNotFoundException(skladisteId);
            }
            _mapper.Map(skladisteForUpdate, skladiste);
            await _repository.SaveAsync();  
        }
    }
}
