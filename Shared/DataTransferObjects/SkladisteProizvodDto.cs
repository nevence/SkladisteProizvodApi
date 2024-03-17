using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record SkladisteProizvodDto
    {
        public Guid Id { get; init; }
        public string Naziv { get; init; }
        public string Kategorija { get; init; }
        public int Cena { get; init; }
        public string ImageURL { get; init; }
        public int Kolicina { get; init; }
    }
}
