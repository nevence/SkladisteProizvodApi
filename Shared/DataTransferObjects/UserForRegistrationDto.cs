using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record UserForRegistrationDto
    {
        [Required(ErrorMessage = "Ovo polje je obavezno")]
        public string? Ime { get; init; }

        [Required(ErrorMessage = "Ovo polje je obavezno")]
        public string? Prezime { get; init; }

        [Required(ErrorMessage = "Ovo polje je obavezno")]
        public string? UserName { get; init;}

        [Required(ErrorMessage = "Ovo polje je obavezno")]
        public string? Password { get; init; }

        [Required(ErrorMessage = "Ovo polje je obavezno")]
        [EmailAddress(ErrorMessage = "Unesite validnu email adresu.")]
        public string? Email { get; init; }

        [Required(ErrorMessage = "Ovo polje je obavezno")]
        public ICollection<string>? Roles {  get; init; }    
        }
}
