using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class KolicinaBadRequestException : BadRequestException
    {
        public KolicinaBadRequestException(int kolicina) : base($"Uneli ste nevazecu kolicinu od: {kolicina} komada. Prevazilazite broj komada na lageru, ili kapacitet skladista.")
        {
        }
    }
}
