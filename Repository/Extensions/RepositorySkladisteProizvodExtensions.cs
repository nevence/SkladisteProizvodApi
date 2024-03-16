using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Extensions
{
    public static class RepositorySkladisteProizvodExtensions
    {
        public static IQueryable<SkladisteProizvod> Search(this IQueryable<SkladisteProizvod> skladisteProizvodi, string searchTerm)
        {
            if(string.IsNullOrWhiteSpace(searchTerm))
            {
                return skladisteProizvodi;
            }

            var lowerCaseTerm = searchTerm.Trim().ToLower();
            return skladisteProizvodi
                .Where(s => s.Proizvod.Naziv.ToLower().Contains(lowerCaseTerm));
        }
    }
}
