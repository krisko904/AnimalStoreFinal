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
    public class AnimalsController : ControllerBase
    {
        private readonly IAnimalRepository animalRepository;

        public AnimalsController(IAnimalRepository animalRepository)
        {
            this.animalRepository = animalRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllAnimals()
        {
            var animals = await animalRepository.GetAllAnimalsAsync();
            return Ok(animals);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAnimalById([FromRoute]int id)
        {
            var animal = await animalRepository.GetAnimalByIdAsync(id);
            if (animal == null)
            {
                return NotFound();
            }
            return Ok(animal);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddNewAnimal([FromBody]AnimalModel animalModel)
        {
            var id = await animalRepository.AddAnimalAsync(animalModel);
            return CreatedAtAction(nameof(GetAnimalById), new {id = id, controller = "animals"}, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAnimal([FromBody] AnimalModel animalModel, [FromRoute] int id)
        {
            await animalRepository.UpdateAnimalAsync(id, animalModel);
            return Ok();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateAnimalPatch([FromBody] JsonPatchDocument animalModel, [FromRoute] int id)
        {
            await animalRepository.UpdateAnimalPatchAsync(id, animalModel);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnimal([FromRoute] int id)
        {
            await animalRepository.DeleteAnimalAsync(id);
            return Ok();
        }
    }
}
