using AutoMapper;
using Contracts;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<ISkladisteService> _skladisteService;
        private readonly Lazy<IProizvodService> _proizvodService;
        private readonly Lazy<ISkladisteProizvodService> _skladisteProizvodService;

        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper) { 
            _skladisteService = new Lazy<ISkladisteService>(() =>
            new SkladisteService(repositoryManager, logger, mapper ));

            _proizvodService = new Lazy<IProizvodService>(() =>
            new ProizvodService(repositoryManager,logger, mapper ));

            _skladisteProizvodService = new Lazy<ISkladisteProizvodService>(() =>
            new SkladisteProizvodService(repositoryManager, logger, mapper));
        }

        public ISkladisteService SkladisteService => _skladisteService.Value;

        public IProizvodService ProizvodService => _proizvodService.Value;
        public ISkladisteProizvodService SkladisteProizvodService => _skladisteProizvodService.Value;
    }
}
