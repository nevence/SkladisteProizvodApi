using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProizvodRepository : RepositoryBase<Proizvod>, IProizvodRepository
    {
        public ProizvodRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public void CreateProizvod(Proizvod proizvod)
        {
            Create(proizvod);
        }

        public void DeleteProizvod(Proizvod proizvod) => Delete(proizvod);  

        public async Task<PagedList<Proizvod>> GetAllProizvodiAsync(ProizvodParameters proizvodParameters, bool trackChanges)
        {
            var proizvodi = await FindAll(trackChanges)
                .Search(proizvodParameters.SearchTerm)
                .OrderBy(p  => p.Naziv)
                .Skip((proizvodParameters.PageNumber - 1) * proizvodParameters.PageSize)
                .Take(proizvodParameters.PageSize)
                .ToListAsync();

            var count = await FindAll(trackChanges).CountAsync();
            return PagedList<Proizvod>.ToPagedList(proizvodi, count, proizvodParameters.PageNumber, proizvodParameters.PageSize);
        }

        public async Task<IEnumerable<Proizvod>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges)
        {
            return await FindByCondition(x => ids.Contains(x.Id), trackChanges).ToListAsync();
        }

        public async Task<Proizvod> GetProizvodAsync(Guid Id, bool trackChanges)
        {
            return await FindByCondition(p => p.Id.Equals(Id), trackChanges).SingleOrDefaultAsync();
        }
    }
}
