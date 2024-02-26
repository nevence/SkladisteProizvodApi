using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryManager
    {
        ISkladisteRepository Skladiste {  get; }
        IProizvodRepository Proizvod { get; }
        ISkladisteProizvodRepository SkladisteProizvod { get; }
        Task SaveAsync();
    }
}
