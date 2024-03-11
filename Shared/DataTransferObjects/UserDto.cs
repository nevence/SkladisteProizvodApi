using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record UserDto
    {
        public string? Id { get; init; }
        public string? Ime { get; init; }
        public string? Prezime { get; init; }
        public string? UserName { get; init; }
        public string? Email { get; init; }
        public ICollection<string>? Roles { get; set; }
    }

}
