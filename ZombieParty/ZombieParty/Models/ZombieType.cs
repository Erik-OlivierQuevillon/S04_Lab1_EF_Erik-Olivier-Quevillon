using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ZombieParty.Models
{
    public class ZombieType
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Type Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} has to be filled.")]
        [MinLength(5)]
        [MaxLength(10)]
        public string TypeName { get; set; }
        [Range(2,5, ErrorMessage = "{0} requires a value between {1} and {2}.")]
        public int Point {  get; set; }
        [ValidateNever]
        public List<Zombie> Zombies { get; set; }
    }
}
