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
    public class ProizvodConfiguration : IEntityTypeConfiguration<Proizvod>
    {
        public void Configure(EntityTypeBuilder<Proizvod> builder)
        {
            builder.HasData(
                new Proizvod
                {
                    Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                    Naziv = "Samsung Galaxy S24",
                    Cena = 128000,
                    Kategorija = "Mobilni telefon"
                    
                },

                   new Proizvod
                   {
                       Id = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                       Naziv = "Xiaomi Note 13 Pro",
                       Cena = 88000,
                       Kategorija = "Mobilni telefon"

                   }
                ); 
        }
    }
}
