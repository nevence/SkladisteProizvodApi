using Entities.Models;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IProizvodRepository
    {
        Task<PagedList<Proizvod>> GetAllProizvodiAsync(ProizvodParameters proizvodParameters, bool trackChanges);
        Task<Proizvod> GetProizvodAsync(Guid Id, bool trackChanges);
        void CreateProizvod(Proizvod proizvod);
        Task<IEnumerable<Proizvod>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
        void DeleteProizvod(Proizvod proizvod);
    }
}
