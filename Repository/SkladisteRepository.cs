using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class SkladisteRepository : RepositoryBase<Skladiste>, ISkladisteRepository
    {
        public SkladisteRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public IEnumerable<Skladiste> GetAllSkladista(bool trackChanges) =>
            FindAll(trackChanges).OrderBy(s => s.Naziv).ToList();

        public Skladiste GetSkladiste(Guid skladisteId, bool trackChanges) =>
            FindByCondition(s => s.Id.Equals(skladisteId), trackChanges).SingleOrDefault();
        
    }
}
