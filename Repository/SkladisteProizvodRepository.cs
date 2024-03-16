using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class SkladisteProizvodRepository : RepositoryBase<SkladisteProizvod>, ISkladisteProizvodRepository
    {
        public SkladisteProizvodRepository(RepositoryContext
            repositoryContext) : base(repositoryContext) { }

        public void AddProizvod(SkladisteProizvod skladisteProizvod)
        {
            Create(skladisteProizvod);
        }

        public void DeleteProizvod(SkladisteProizvod skladisteProizvod)
        {
            Delete(skladisteProizvod);
        }

        public async Task<PagedList<SkladisteProizvod>> GetAllProizvodiAsync(SkladisteProizvodParameters proizvodParameters, Guid skladisteId, bool trackChanges)
        {
            var skladisteProizvodi = await FindAll(trackChanges)
                .Where(s => s.SkladisteId == skladisteId)
                .Search(proizvodParameters.SearchTerm)
                .OrderBy(s => s.Proizvod.Naziv)
                .Skip((proizvodParameters.PageNumber - 1) * proizvodParameters.PageSize)
                .Take(proizvodParameters.PageSize)
                .Include(s => s.Proizvod)
                .ToListAsync();

            var count = await FindAll(trackChanges).CountAsync();
            return PagedList<SkladisteProizvod>.ToPagedList(skladisteProizvodi, count, proizvodParameters.PageNumber, proizvodParameters.PageSize);
                
        }
        public async Task<SkladisteProizvod> GetProizvodAsync(Guid proizvodId, Guid skladisteId, bool trackChanges)
        {
            return await FindByCondition(s => s.SkladisteId.Equals(skladisteId) && s.ProizvodId.Equals(proizvodId), trackChanges).SingleOrDefaultAsync();

        }
    }
}
