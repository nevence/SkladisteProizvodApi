using Entities.Models;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ISkladisteRepository
    {
        Task<PagedList<Skladiste>> GetAllSkladistaAsync(SkladisteParameters skladisteParameters, bool trackChanges);
        Task<Skladiste> GetSkladisteAsync(Guid Id, bool trackChanges);
        void CreateSkladiste(Skladiste skladiste);
        Task<IEnumerable<Skladiste>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
        void DeleteSkladiste(Skladiste skladiste);
        
    }
}
