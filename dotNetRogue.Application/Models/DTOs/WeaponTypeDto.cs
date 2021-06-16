using System;
using System.Collections.Generic;
using System.Text;
using dotNetRogue.Domain.Models;

namespace dotNetRogue.Application.Models.DTOs
{
    /// <summary>
    /// An object that safely transmits WeaponType data to the application layer
    /// </summary>
    public class WeaponTypeDto
    {
        /// <summary>
        /// Constructs a WeaponTypeDto from a WeaponType object
        /// </summary>
        /// <param name="type"></param>
        public WeaponTypeDto(WeaponType type)
        {
            Name = type.Name;
            Damage = type.Damage;
            DodgeChance = type.DodgeChance;
        }

        public string Name { get; private set; }
        public int Damage { get; private set; }
        public int DodgeChance { get; private set; }
    }
}
