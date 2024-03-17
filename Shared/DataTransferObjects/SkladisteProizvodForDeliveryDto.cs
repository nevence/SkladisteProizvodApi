using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record SkladisteProizvodForDeliveryDto : SkladisteProizvodForManipulataionDto
    {
        [Required(ErrorMessage = "Ovo polje je obavezno.")]
        [Range(1, int.MaxValue, ErrorMessage = "Kolicina mora biti veca od 0.")]
        public int Kolicina { get; init; }
    }
}
