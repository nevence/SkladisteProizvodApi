using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
            : base(options) {
        }

        public DbSet<Skladiste> Skladista { get; set; }
        public DbSet<Proizvod> Proizvodi { get; set; }
        public DbSet<SkladisteProizvod> SkladisteProizvodi { get; set; }

       

    }
}
