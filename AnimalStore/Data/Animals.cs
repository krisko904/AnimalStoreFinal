using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AnimalStore.Data
{
    public class Animals
    {
        public int Id { get; set; }
        [MaxLength(20)]
        public string Type { get; set; }
        [Required]
        [MaxLength(20)]
        public string Species { get; set; }
        [MaxLength(20)]
        public string Color { get; set; }
        [MaxLength(20)]
        public string LifeExpectancy { get; set; }
        [MaxLength(10)]
        public string Sound { get; set; }
        [MaxLength(10)]
        public string Food { get; set; }
    }
}
