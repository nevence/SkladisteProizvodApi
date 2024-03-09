using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IProizvodService
    {
        Task<(IEnumerable<ProizvodDto> proizvodi, MetaData metaData)> GetAllProizvodiAsync(ProizvodParameters proizvodParameters, bool trackChanges);
        Task<ProizvodDto> GetProizvodAsync(Guid id, bool trackChanges);
        Task<ProizvodDto> CreateProizvodAsync(ProizvodForCreationDto proizvod);
        Task<IEnumerable<ProizvodDto>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
        Task<(IEnumerable<ProizvodDto> proizvodi, string ids)> CreateProizvodCollectionAsync
            (IEnumerable<ProizvodForCreationDto> proizvodCollection);
        Task DeleteProizvodAsync (Guid proizvodId, bool trackChanges);
        Task UpdateProizvodAsync(Guid proizvodId, ProizvodForUpdateDto proizvodForUpdate, bool trackChanges);
    }
}
