using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class SkladisteProizvod
    {
        public Guid Id { get; set; }    

        [ForeignKey(nameof(Skladiste))]
        public Guid SkladisteId { get; set; }
        public Skladiste? Skladiste { get; set; }

        [ForeignKey(nameof(Proizvod))]
        public Guid ProizvodId { get; set; }
        public Proizvod? Proizvod { get; set; }

        public int Kolicina { get; set; }   

    }
}
