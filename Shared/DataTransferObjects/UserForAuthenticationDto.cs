using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record UserForAuthenticationDto
    {
        [Required(ErrorMessage = "Ovo polje je obavezno")]
        public string? UserName { get; init; }
        [Required(ErrorMessage = "Ovo polje je obavezno")]
        public string? Password { get; init; }
    }
}
