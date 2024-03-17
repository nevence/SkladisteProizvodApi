using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record SkladisteProizvodForManipulataionDto
    {
        [Required(ErrorMessage = "Ovo je obavezno polje.")]
        public Guid SkladisteId { get; init; }
        [Required(ErrorMessage = "Ovo je obavezno polje.")]
        public Guid ProizvodId { get; init; }
    }
}
