using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Extensions
{
    public static class RepositoryProizvodExtensions
    {
        public static IQueryable<Proizvod> Search(this IQueryable<Proizvod> proizvodi, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return proizvodi;

            var lowerCaseTerm = searchTerm.Trim().ToLower();
            return proizvodi.Where(s => s.Naziv.ToLower().Contains(lowerCaseTerm));
        }
    }
}

