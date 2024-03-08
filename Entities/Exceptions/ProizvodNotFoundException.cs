using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class ProizvodNotFoundException : NotFoundException
    {
        public ProizvodNotFoundException(Guid proizvodId)
            : base($"Proizvod sa id: {proizvodId} ne postoji u bazi podataka.")
        {
            
        }
    }
}
