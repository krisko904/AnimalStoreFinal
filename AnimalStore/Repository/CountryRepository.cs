using AnimalStore.Data;
using AnimalStore.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalStore.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly AnimalStoreContext context;
        private readonly IMapper mapper;

        public CountryRepository(AnimalStoreContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<CountryModel>> GetAllCountriesAsync()
        {
            var records = await context.Countries.ToListAsync();
            return mapper.Map<List<CountryModel>>(records);
        }

        public async Task<CountryModel> GetCountryByIdAsync(int countryId)
        {
            var country = await context.Countries.FindAsync(countryId);
            return mapper.Map<CountryModel>(country);
        }

        public async Task<int> AddCountryAsync(CountryModel countryModel)
        {
            var country = new Countries()
            {
                CountryName = countryModel.CountryName,
                Capital = countryModel.Capital,
                Continent = countryModel.Continent,
                Climate = countryModel.Climate,
                Relief = countryModel.Relief
            };

            context.Countries.Add(country);
            await context.SaveChangesAsync();

            return country.Id;
        }

        public async Task UpdateCountryAsync(int countryId, CountryModel countryModel)
        {
            var country = new Countries()
            {
                Id = countryId,
                CountryName = countryModel.CountryName,
                Capital = countryModel.Capital,
                Continent = countryModel.Continent,
                Climate = countryModel.Climate,
                Relief = countryModel.Relief
            };

            context.Countries.Update(country);
            await context.SaveChangesAsync();
        }

        public async Task UpdateCountryPatchAsync(int countryId, JsonPatchDocument countryModel)
        {
            var country = await context.Countries.FindAsync(countryId);
            if (country != null)
            {
                countryModel.ApplyTo(country);
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteCountryAsync(int countryId)
        {
            var country = new Countries() { Id = countryId };

            context.Countries.Remove(country);

            await context.SaveChangesAsync();
        }
    }
}
