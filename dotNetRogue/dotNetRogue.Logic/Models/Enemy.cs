using System.ComponentModel.DataAnnotations;

namespace dotNetRogue.Logic.Models
{
    public class Enemy
    {
        public Enemy()
        {
            
        }

        public Enemy(string name, int health, int attack, int defense, int speed, int goldOnKill)
        {
            Name = name;
            Health = health;
            Attack = attack;
            Defense = defense;
            Speed = speed;
            GoldOnKill = goldOnKill;
        }

        [Key]
        public string Name { get; private set; }
        public int Health { get; private set; }
        public int Attack { get; private set; }
        public int Defense { get; private set; }
        public int Speed { get; private set; }
        public int GoldOnKill { get; private set; }
    }
}
