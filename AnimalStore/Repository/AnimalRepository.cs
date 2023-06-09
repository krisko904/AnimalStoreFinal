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
    public class AnimalRepository : IAnimalRepository
    {
        private readonly AnimalStoreContext context;
        private readonly IMapper mapper;

        public AnimalRepository(AnimalStoreContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<AnimalModel>> GetAllAnimalsAsync()
        {
            var records = await context.Animals.ToListAsync();
            return mapper.Map<List<AnimalModel>>(records);
        }

        public async Task<AnimalModel> GetAnimalByIdAsync(int animalId) 
        {
            var animal = await context.Animals.FindAsync(animalId);
            return mapper.Map<AnimalModel>(animal);
        }

        public async Task<int> AddAnimalAsync(AnimalModel animalModel)
        {
            var animal = new Animals()
            {
                Type = animalModel.Type,
                Species = animalModel.Species,
                Color = animalModel.Color,
                LifeExpectancy = animalModel.LifeExpectancy,
                Sound = animalModel.Sound,
                Food = animalModel.Food
            };

            context.Animals.Add(animal);
            await context.SaveChangesAsync();

            return animal.Id;
        }

        public async Task UpdateAnimalAsync(int animalId, AnimalModel animalModel)
        {
            var animal = new Animals()
            {
                Id = animalId,
                Type = animalModel.Type,
                Species = animalModel.Species,
                Color = animalModel.Color,
                LifeExpectancy = animalModel.LifeExpectancy,
                Sound = animalModel.Sound,
                Food = animalModel.Food
            };

            context.Animals.Update(animal);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAnimalPatchAsync(int animalId, JsonPatchDocument animalModel)
        {
            var animal = await context.Animals.FindAsync(animalId);
            if (animal != null)
            {
                animalModel.ApplyTo(animal);
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteAnimalAsync(int animalId)
        {
            var animal = new Animals() { Id = animalId};

            context.Animals.Remove(animal);

            await context.SaveChangesAsync();
        }
    }
}
