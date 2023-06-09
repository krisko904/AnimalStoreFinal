using AnimalStore.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalStore.Data
{
    public class AnimalStoreContext : IdentityDbContext<UserModel>
    {
        public AnimalStoreContext(DbContextOptions<AnimalStoreContext> options)
            : base(options)
        {

        }

        public DbSet<Animals> Animals { get; set; }
        public DbSet<Countries> Countries { get; set; }
        public DbSet<Orders> Orders { get; set; }
    }
}
