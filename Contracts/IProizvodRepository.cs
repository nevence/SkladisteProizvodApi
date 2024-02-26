using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IProizvodRepository
    {
        Task<IEnumerable<Proizvod>> GetAllProizvodiAsync(bool trackChanges);
        Task<Proizvod> GetProizvodAsync(Guid Id, bool trackChanges);
        void CreateProizvod(Proizvod proizvod);
        Task<IEnumerable<Proizvod>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
    }
}
