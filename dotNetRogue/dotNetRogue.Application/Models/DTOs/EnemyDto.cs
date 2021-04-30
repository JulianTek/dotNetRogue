using System;
using System.Collections.Generic;
using System.Text;
using dotNetRogue.Domain.Models;

namespace dotNetRogue.Application.Models.DTOs
{
    /// <summary>
    /// An object that safely transmits Enemy data to the application layer
    /// </summary>
    public class EnemyDto
    {
        /// <summary>
        /// Constructs an EnemyDto from an Enemy object
        /// </summary>
        /// <param name="enemy"></param>
        public EnemyDto(Enemy enemy)
        {
            Name = enemy.Name;
            Health = enemy.Health;
            Attack = enemy.Attack;
            Defense = enemy.Defense;
            Speed = enemy.Speed;
            GoldOnKill = enemy.GoldOnKill;
        }
        public string Name { get; set; }
        public int Health { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Speed { get; set; }
        public int GoldOnKill { get; set; }
    }
}
