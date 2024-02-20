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
        IEnumerable<SkladisteDto> GetAllSkladista(bool trackChanges);
        SkladisteDto GetSkladista(Guid skladisteId, bool trackChanges);
    }
}
