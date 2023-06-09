using AnimalStore.Models;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalStore.Repository
{
    public interface ICountryRepository
    {
        Task<List<CountryModel>> GetAllCountriesAsync();
        Task<CountryModel> GetCountryByIdAsync(int countryId);
        Task<int> AddCountryAsync(CountryModel countryModel);
        Task UpdateCountryAsync(int countryId, CountryModel countryModel);
        Task UpdateCountryPatchAsync(int countryId, JsonPatchDocument countryModel);
        Task DeleteCountryAsync(int countryId);
    }
}
