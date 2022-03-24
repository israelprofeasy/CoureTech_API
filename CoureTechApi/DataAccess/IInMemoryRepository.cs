using CoureTechApi.Models;
using CoureTechApi.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoureTechApi.DataAccess
{
    public interface IInMemoryRepository
    {
        Task<bool> AddCountry(List<Country> country);
        Task<bool> AddCountryDetails(List<CountryDetails> countryDetails);
        Task<(Country, List<CountryDetails>)> RetreiveDetails(int countryCode);
        Tuple<int,int> RowCount();

    }
}
