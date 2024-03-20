using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class ForeignKeyConstraintBadRequestException : BadRequestException
    {
        public ForeignKeyConstraintBadRequestException(Guid id) : base($"Ne mozete obrisati entitet sa id-jem: {id} jer se na njega referišu drugi entiteti")
        {
        }
    }
}
