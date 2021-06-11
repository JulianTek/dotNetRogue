using System.ComponentModel.DataAnnotations;

namespace dotNetRogue.Domain.Models
{
    public class Enemy
    {
        [Key]
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Speed { get; set; }
        public int GoldOnKill { get; set; }
    }
}
