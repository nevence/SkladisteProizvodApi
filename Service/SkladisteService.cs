using Contracts;
using Entities.Models;
using Repository;
using Service.Contracts;
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

        public SkladisteService(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public IEnumerable<Skladiste> GetAllSkladista(bool trackChanges)
        {
            try
            {
                var skladista = _repository.Skladiste.GetAllSkladista(trackChanges);
                return skladista;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Doslo je do greske u {nameof(GetAllSkladista)} service metodi {ex}");
                throw;
            }
        }
    }
}
