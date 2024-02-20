using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class SkladisteNotFoundException : NotFoundException
    {
        public SkladisteNotFoundException(Guid skladisteId)
            : base($"Skladiste sa id: {skladisteId} ne postoji u bazi podataka.")
        {

        }
    }
}
