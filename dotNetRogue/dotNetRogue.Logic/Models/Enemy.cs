using System.ComponentModel.DataAnnotations;

namespace dotNetRogue.Logic.Models
{
    public class Enemy
    {
        [Key]
        public string Name { get; set; }
        public int Health { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Speed { get; set; }
        public int GoldOnKill { get; set; }
    }
}
