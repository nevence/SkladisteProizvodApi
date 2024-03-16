using Entities.Models;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ISkladisteProizvodRepository
    {
        Task<PagedList<SkladisteProizvod>> GetAllProizvodiAsync(SkladisteProizvodParameters proizvodParameters, Guid skladisteId, bool trackChanges);
        Task<SkladisteProizvod> GetProizvodAsync(Guid proizvodId, Guid skladisteId, bool trackChanges);
        void AddProizvod(SkladisteProizvod skladisteProizvod);
        void DeleteProizvod(SkladisteProizvod skladisteProizvod);
    }
}
