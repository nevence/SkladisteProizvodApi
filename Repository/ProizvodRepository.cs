using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Shared.DataTransferObjects;
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

        public async Task<IEnumerable<Proizvod>> GetAllProizvodiAsync(bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(p  => p.Naziv).ToListAsync();
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
