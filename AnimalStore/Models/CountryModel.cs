using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalStore.Models
{
    public class CountryModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string CountryName { get; set; }
        [MaxLength(30)]
        public string Capital { get; set; }
        [MaxLength(30)]
        public string Continent { get; set; }
        [MaxLength(30)]
        public string Climate { get; set; }
        [MaxLength(30)]
        public string Relief { get; set; }
    }
}
