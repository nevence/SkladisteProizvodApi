using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record SkladisteForManipulationDto
    {
        [Required(ErrorMessage = "Naziv skladista je obavezno polje.")]
        [MaxLength(100, ErrorMessage = "Maksimalna duzina naziva je 100 karaktera.")]
        public string? Naziv { get; init; }

        [Required(ErrorMessage = "Adresa skladista je obavezno polje.")]
        [MaxLength(100, ErrorMessage = "Maksimalna duzina adrese je 100 karaktera")]
        public string? Adresa { get; init; }

        [Required(ErrorMessage = "Kapacitet skladista je obavezno polje.")]
        public int? Kapacitet { get; init; }
    }
}
