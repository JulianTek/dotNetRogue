using System.ComponentModel.DataAnnotations;

namespace dotNetRogue.Domain.Models
{
    public class Enemy
    {
        [Key]
        [Required]
        public string Name { get; set; }
        [Required]
        public int Health { get; set; }
        [Required]
        public int Attack { get; set; }
        [Required]
        public int Defense { get; set; }
        [Required]
        public int Speed { get; set; }
        [Required]
        public int GoldOnKill { get; set; }
    }
}
