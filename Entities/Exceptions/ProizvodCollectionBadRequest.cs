using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class ProizvodCollectionBadRequest : BadRequestException
    {
        public ProizvodCollectionBadRequest()
            :base("Kolekcija proizvoda poslata sa klijenta je null.")
        {
            
        }
    }
}
