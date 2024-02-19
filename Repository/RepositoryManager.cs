using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<ISkladisteProizvodRepository> _skladisteProizvodRepository;
        private readonly Lazy<ISkladisteRepository> _skladisteRepository;
        private readonly Lazy<IProizvodRepository> _proizvodRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _skladisteProizvodRepository = new Lazy<ISkladisteProizvodRepository>(() => 
            new SkladisteProizvodRepository(repositoryContext));
            _skladisteRepository = new Lazy<ISkladisteRepository>(() => new SkladisteRepository(repositoryContext));
            _proizvodRepository = new Lazy<IProizvodRepository>(() => new ProizvodRepository(repositoryContext));
        }
        public ISkladisteRepository Skladiste => _skladisteRepository.Value;

        public IProizvodRepository Proizvod => _proizvodRepository.Value;

        public ISkladisteProizvodRepository SkladisteProizvod => _skladisteProizvodRepository.Value;

        public void Save()
        {
            _repositoryContext.SaveChanges();
        }
    }
}
