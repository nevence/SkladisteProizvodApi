using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record SkladisteDto(Guid Id, string NazivAdresa, int? Kapacitet, int Popunjeno);
}
