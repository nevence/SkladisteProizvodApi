using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Extensions
{
    public static class RepositorySkladisteExtensions
    {
        public static IQueryable<Skladiste> Search(this IQueryable<Skladiste> skladista, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return skladista;

            var lowerCaseTerm = searchTerm.Trim().ToLower();
            return skladista.Where(s => s.Naziv.ToLower().Contains(lowerCaseTerm));
        }
    }
}
