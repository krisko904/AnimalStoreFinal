using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalStore.Models
{
    public class UserModel : IdentityUser
    {
        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(30)]
        public string LastName { get; set; }
        [MaxLength(30)]
        public string HomeCountry { get; set; }
        public int Age { get; set; }
        [MaxLength(6)]
        public string Gender { get; set; }
    }
}
