using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class SkladisteProizvodExistsBadRequestException : BadRequestException
    {
        public SkladisteProizvodExistsBadRequestException(Guid skladisteId, Guid proizvodId) : base($"Proizvod sa Id-jem {proizvodId} je vec u opticaju u skladistu sa Id-jem {skladisteId}")
        {
        }
    }
}
