using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record ProizvodForManipulationDto
    {

        [Required(ErrorMessage = "Naziv proizvoda je obavezno polje.")]
        [MaxLength(100, ErrorMessage = "Maksimalna duzina naziva je 100 karaktera.")]
        public string? Naziv { get; init; }

        [Required(ErrorMessage = "Kategorija proizvda je obavezno polje.")]
        [MaxLength(100, ErrorMessage = "Maksimalna duzina kategorije je 100 karaktera")]
        public string? Kategorija { get; init; }

        [Required(ErrorMessage = "Cena proizvoda je obavezno polje.")]
        public int? Cena { get; init; }
    }
}

