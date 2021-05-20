using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using dotNetRogue.Domain.Models;

namespace dotNetRogue.Application.Models.DTOs
{
    /// <summary>
    /// An object that safely transmits Enemy data to the application layer
    /// </summary>
    public class EnemyDto
    {
        public EnemyDto()
        { }

        /// <summary>
        /// Constructs an EnemyDto from an Enemy object
        /// </summary>
        /// <param name="enemy"></param>
        public EnemyDto(Enemy enemy)
        {
            Id = enemy.Id;
            Name = enemy.Name;
            Health = enemy.Health;
            Attack = enemy.Attack;
            Defense = enemy.Defense;
            Speed = enemy.Speed;
            GoldOnKill = enemy.GoldOnKill;
        }
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("health")]
        public int Health { get; set; }
        [JsonPropertyName("attack")]
        public int Attack { get; set; }
        [JsonPropertyName("defense")]
        public int Defense { get; set; }
        [JsonPropertyName("speed")]
        public int Speed { get; set; }
        [JsonPropertyName("gold_on_kill")]
        public int GoldOnKill { get; set; }
    }
}
