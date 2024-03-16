using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record SkladisteProizvodDto(Guid Id, string Naziv, string Kategorija, int Cena, string ImageURL, int Kolicina);
}
