using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface ISkladisteService
    {
        IEnumerable<Skladiste> GetAllSkladista(bool trackChanges);
    }
}
