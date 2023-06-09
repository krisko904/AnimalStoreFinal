using AnimalStore.Models;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimalStore.Repository
{
    public interface IAnimalRepository
    {
        Task<List<AnimalModel>> GetAllAnimalsAsync();
        Task<AnimalModel> GetAnimalByIdAsync(int animalId);
        Task<int> AddAnimalAsync(AnimalModel animalModel);
        Task UpdateAnimalAsync(int animalId, AnimalModel animalModel);
        Task UpdateAnimalPatchAsync(int animalId, JsonPatchDocument animalModel);
        Task DeleteAnimalAsync(int animalId);
    }
}
