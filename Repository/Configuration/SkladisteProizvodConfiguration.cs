using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Configuration
{
    public class SkladisteProizvodConfiguration : IEntityTypeConfiguration<SkladisteProizvod>
    {
        public void Configure(EntityTypeBuilder<SkladisteProizvod> builder)
        { 
            builder.HasData(
                new SkladisteProizvod
                {
                    Id = Guid.NewGuid(),
                    SkladisteId = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                    ProizvodId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                    Kolicina = 50
                });
        }
    }
}
