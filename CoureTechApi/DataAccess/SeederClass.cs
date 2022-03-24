using CoureTechApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoureTechApi.DataAccess
{
    public class SeederClass
    {
        private readonly IInMemoryRepository _repo;
        public SeederClass(IInMemoryRepository repo)
        {
            _repo = repo;
        }
        public Task SeedMe()
        {
            try
            {
                var countryData = System.IO.File.ReadAllText("DataAccess/CountrySeed.json");
                var countryDetailsData = System.IO.File.ReadAllText("DataAccess/CountryDetailsSeed.json");
                var countries = JsonConvert.DeserializeObject<List<Country>>(countryData);
                var countryDetails = JsonConvert.DeserializeObject<List<CountryDetails>>(countryDetailsData);
                var res1 = _repo.AddCountry(countries);

                if (res1.Result)
                {
                    var res2 = _repo.AddCountryDetails(countryDetails);

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return Task.CompletedTask;
        }
    }
}
