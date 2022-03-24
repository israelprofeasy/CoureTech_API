using CoureTechApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoureTechApi.DataAccess
{
    public class InMemoryRepository : IInMemoryRepository
    {
        public Task<bool> AddCountry(List<Country> country)
        {
            int numberOfRowsBefore = RowCount().Item1;
            foreach (var countryRow in country)
                InMemoryStore.Countries.Add(countryRow);
            int numberOfRowsAfter = RowCount().Item1;
            if (numberOfRowsAfter <= numberOfRowsBefore)
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }

        public Task<bool> AddCountryDetails(List<CountryDetails> countryDetails)
        {
            int numberOfRowsBefore = RowCount().Item2;

            foreach (var countryDetailsRow in countryDetails)
                InMemoryStore.CountryDetails.Add(countryDetailsRow);

            int numberOfRowsAfter = RowCount().Item2;

            if (numberOfRowsAfter <= numberOfRowsBefore)
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }

        public Task<(Country, List<CountryDetails>)> RetreiveDetails(int countryCode)
        {
            var country = InMemoryStore.Countries.Where(x => x.CountryCode == countryCode).FirstOrDefault();

            var countryDetails = InMemoryStore.CountryDetails.Where(x => x.CountryId == country.Id).ToList();

            return Task.FromResult((country, countryDetails));
        }

        public Tuple<int, int> RowCount()
        {
            var countryCount = InMemoryStore.Countries.Count;
            var countryDetailCount = InMemoryStore.CountryDetails.Count;
            return Tuple.Create(countryCount, countryDetailCount);
        }


    }
}
