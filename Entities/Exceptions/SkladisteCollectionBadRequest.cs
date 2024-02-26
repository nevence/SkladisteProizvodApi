using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class SkladisteCollectionBadRequest : BadRequestException
    {
        public SkladisteCollectionBadRequest()
            :base("Kolekcija skladista poslata sa klijenta je null.")
        {
            
        }
    }
}
