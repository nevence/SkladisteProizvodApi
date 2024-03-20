using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Repository.Extensions;
using Shared.RequestFeatures;
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

        public async Task<PagedList<Skladiste>> GetAllSkladistaAsync(SkladisteParameters skladisteParameters, bool trackChanges)
        {
            var skladista =await FindAll(trackChanges)
                .Search(skladisteParameters.SearchTerm)
                .OrderBy(s => s.Naziv)
                .Skip((skladisteParameters.PageNumber - 1) *  skladisteParameters.PageSize)
                .Take(skladisteParameters.PageSize)
                .ToListAsync();

            var count = await FindAll(trackChanges).CountAsync();

            return PagedList<Skladiste>.ToPagedList(skladista, count, skladisteParameters.PageNumber, skladisteParameters.PageSize);
        }

        public async Task<Skladiste> GetSkladisteAsync(Guid skladisteId, bool trackChanges) =>
           await FindByCondition(s => s.Id.Equals(skladisteId), trackChanges).SingleOrDefaultAsync();


        public void CreateSkladiste(Skladiste skladiste) => Create(skladiste);

        public async Task<IEnumerable<Skladiste>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges)
        {
            return await FindByCondition(x=> ids.Contains(x.Id), trackChanges).ToListAsync();
        }

        public void DeleteSkladiste(Skladiste skladiste) => Delete(skladiste);  
       

        public void Update(Skladiste skladiste) => Update(skladiste);
    }
}
