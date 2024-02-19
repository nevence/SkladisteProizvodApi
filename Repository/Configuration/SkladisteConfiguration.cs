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
    public class SkladisteConfiguration : IEntityTypeConfiguration<Skladiste>
    {
        public void Configure(EntityTypeBuilder<Skladiste> builder)
        {
            builder.HasData(
                new Skladiste
                {
                    Id = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                    Naziv = "Gigatron Nis",
                    Adresa = "Knjazevacka 16",
                    Kapacitet = 5000,
                    Popunjeno = 50
                },

                new Skladiste
                {
                    Id = new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
                    Naziv = "Gigatron Kragujevac",
                    Adresa = "Nikole Pasica 10",
                    Kapacitet = 4200
                }

                );
        }
    }
}
