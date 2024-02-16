using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Skladiste
    {
        [Column("SkladisteId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Naziv skladista je obavezno polje.")]
        [MaxLength(100, ErrorMessage ="Maksimalna duzina naziva je 100 karaktera.")]
        public string? Naziv { get; set; }

        [Required(ErrorMessage ="Adresa skladista je obavezno polje.")]
        [MaxLength(100, ErrorMessage ="Maksimalna duzina adrese je 100 karaktera")]
        public string? Adresa {  get; set; }

        [Required(ErrorMessage ="Kapacitet skladista je obavezno polje.")]
        public int? Kapacitet { get; set; }

        public int Popunjeno { get; set; } = 0;

        public ICollection<Proizvod>? Proizvodi {  get; set; }

    }
}
