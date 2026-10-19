using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace ZombieParty.Models
{
    public class HuntingLog
    {
        public int Id { get; set; }
        [MinLength(5)]
        [MaxLength(25)]
        public string Titre { get; set; }
        [MaxLength(255)]
        public string Description { get; set; }
        [ValidateNever]
        public List<Zombie> Zombies { get; set; }

    }
}
