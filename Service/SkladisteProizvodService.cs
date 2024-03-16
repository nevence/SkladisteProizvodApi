using AutoMapper;
using Contracts;
using Entities.Exceptions;
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

        public async Task<(IEnumerable<SkladisteProizvodDto> skladisteProizvodi, MetaData metaData)> GetAllProizvodiAsync(SkladisteProizvodParameters proizvodParameters, Guid skladisteId, bool trackChanges)
        {
            var proizvodi = await _repository.SkladisteProizvod.GetAllProizvodiAsync(proizvodParameters, skladisteId, trackChanges);
            var proizvodiDto = _mapper.Map<IEnumerable<SkladisteProizvodDto>>(proizvodi);

            return(skladisteProizvodi:  proizvodiDto, metaData: proizvodi.MetaData);
        }

        public async Task<SkladisteProizvodDto> GetProizvodAsync(Guid proizvodId, Guid skladisteId, bool trackChanges)
        {
            var proizvod = await _repository.SkladisteProizvod.GetProizvodAsync(proizvodId, skladisteId, trackChanges);
            if(proizvod is null)
            {
                throw new ProizvodNotFoundException(proizvodId);
            }
            var proizvodDto = _mapper.Map<SkladisteProizvodDto>(proizvod);
            return proizvodDto;
        }
    }
}
