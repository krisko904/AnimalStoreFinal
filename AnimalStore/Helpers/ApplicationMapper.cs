using AnimalStore.Data;
using AnimalStore.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalStore.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Animals, AnimalModel>().ReverseMap();
            CreateMap<Countries, CountryModel>().ReverseMap();
            CreateMap<Orders, OrderModel>().ReverseMap();
        }
    }
}
