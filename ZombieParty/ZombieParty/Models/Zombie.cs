using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZombieParty.Models
{
    public class Zombie
    {
        [Key]
        public int Id { get; set; }
        [MinLength(5)]
        [MaxLength(20)]
        public string Name { get; set; }
        [Display(Name = "Zombie Type")]
        [ForeignKey("ZombieType")]

        
        public int ZombieTypeId { get; set; }
        [ValidateNever]
        public ZombieType? ZombieType { get; set; }
        [Range(1,20, ErrorMessage = "{0} requires a value between {1} and {2}.")]
        public int Point { get; set; }
        [MaxLength(255)]
        public string ShortDesc { get; set; }
        [ValidateNever]
        public List<HuntingLog> HuntingLogs { get; set; }
        
    }
}
