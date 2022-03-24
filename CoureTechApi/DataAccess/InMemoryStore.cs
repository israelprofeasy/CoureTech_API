using CoureTechApi.Models;
using System.Collections.Generic;

namespace CoureTechApi.DataAccess
{
    public class InMemoryStore
    {
        public static List<Country> Countries { get; set; } = new List<Country>();
        public static List<CountryDetails> CountryDetails { get; set; } = new List<CountryDetails>();
    }
}
