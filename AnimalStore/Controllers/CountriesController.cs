using AnimalStore.Models;
using AnimalStore.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryRepository countryRepository;

        public CountriesController(ICountryRepository countryRepository)
        {
            this.countryRepository = countryRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllCountries()
        {
            var countries = await countryRepository.GetAllCountriesAsync();
            return Ok(countries);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCountryById([FromRoute] int id)
        {
            var country = await countryRepository.GetCountryByIdAsync(id);
            if (country == null)
            {
                return NotFound();
            }
            return Ok(country);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddNewCountry([FromBody] CountryModel countryModel)
        {
            var id = await countryRepository.AddCountryAsync(countryModel);
            return CreatedAtAction(nameof(GetCountryById), new { id = id, controller = "countries" }, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCountry([FromBody] CountryModel countryModel, [FromRoute] int id)
        {
            await countryRepository.UpdateCountryAsync(id, countryModel);
            return Ok();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateCountryPatch([FromBody] JsonPatchDocument countryModel, [FromRoute] int id)
        {
            await countryRepository.UpdateCountryPatchAsync(id, countryModel);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry([FromRoute] int id)
        {
            await countryRepository.DeleteCountryAsync(id);
            return Ok();
        }
    }
}
