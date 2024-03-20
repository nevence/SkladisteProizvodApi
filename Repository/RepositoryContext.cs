using Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Repository.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryContext : IdentityDbContext<User>
    {
        public RepositoryContext(DbContextOptions options)
            : base(options) {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new SkladisteConfiguration());
            modelBuilder.ApplyConfiguration(new ProizvodConfiguration());
            modelBuilder.ApplyConfiguration(new SkladisteProizvodConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());

            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e=> e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

        public DbSet<Skladiste> Skladista { get; set; }
        public DbSet<Proizvod> Proizvodi { get; set; }
        public DbSet<SkladisteProizvod> SkladisteProizvodi { get; set; }

       

    }
}
