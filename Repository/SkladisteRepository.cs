using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
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

        public async Task<IEnumerable<Skladiste>> GetAllSkladistaAsync(bool trackChanges) =>
            await FindAll(trackChanges).OrderBy(s => s.Naziv).ToListAsync();

        public async Task<Skladiste> GetSkladisteAsync(Guid skladisteId, bool trackChanges) =>
           await FindByCondition(s => s.Id.Equals(skladisteId), trackChanges).SingleOrDefaultAsync();

        public void CreateSkladiste(Skladiste skladiste) => Create(skladiste);

        public async Task<IEnumerable<Skladiste>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges)
        {
            return await FindByCondition(x=> ids.Contains(x.Id), trackChanges).ToListAsync();
        }

        public void DeleteSkladiste(Skladiste skladiste) => Delete(skladiste);  
       
    }
}
