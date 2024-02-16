using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Proizvod
    {
        [Column("ProizvodId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Naziv proizvoda je obavezno polje.")]
        [MaxLength(100, ErrorMessage = "Maksimalna duzina naziva je 100 karaktera.")]
        public string? Naziv { get; set; }

        [Required(ErrorMessage = "Kategorija proizvda je obavezno polje.")]
        [MaxLength(100, ErrorMessage = "Maksimalna duzina kategorije je 100 karaktera")]
        public string? Kategorija { get; set; }

        [Required(ErrorMessage = "Cena proizvoda je obavezno polje.")]
        public int? Cena { get; set; }

        public string ImageURL { get; set; } = "/images/placeholder.png";
    }
}
