using Entities.Models;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface ISkladisteService
    {
        Task<IEnumerable<SkladisteDto>> GetAllSkladistaAsync(bool trackChanges);
        Task<SkladisteDto> GetSkladistaAsync(Guid skladisteId, bool trackChanges);
        Task<SkladisteDto> CreateSkladisteAsync(SkladisteForCreationDto skladiste);
        Task<IEnumerable<SkladisteDto>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
        Task<(IEnumerable<SkladisteDto> skladista, string ids)> CreateSkladisteCollectionAsync
            (IEnumerable<SkladisteForCreationDto> skladisteCollection);
    }
}
