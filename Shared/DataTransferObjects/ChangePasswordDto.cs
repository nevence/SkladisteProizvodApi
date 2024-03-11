using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record ChangePasswordDto
    {
        [Required(ErrorMessage ="Ovo polje je obavezno")]
        public string? CurrentPassword { get; init; }
        [Required(ErrorMessage = "Ovo polje je obavezno")]
        public string? NewPassword { get; init; }
    }

}
