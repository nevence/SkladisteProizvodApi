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

        public IEnumerable<SkladisteDto> GetAllSkladista(bool trackChanges)
        {

            var skladista = _repository.Skladiste.GetAllSkladista(trackChanges);
            var skladistaDto = _mapper.Map<IEnumerable<SkladisteDto>>(skladista);
            return skladistaDto;
        }

        public SkladisteDto GetSkladista(Guid skladisteId, bool trackChanges) 
        { 
            var skladiste = _repository.Skladiste.GetSkladiste(skladisteId, trackChanges);
            if (skladiste is null)
                throw new SkladisteNotFoundException(skladisteId);
            var skladisteDto = _mapper.Map<SkladisteDto>(skladiste);
            return skladisteDto;
        }
    }
}
