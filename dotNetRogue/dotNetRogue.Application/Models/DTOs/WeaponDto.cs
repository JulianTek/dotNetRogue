using System;
using System.Collections.Generic;
using System.Text;
using dotNetRogue.Domain.Models;

namespace dotNetRogue.Application.Models.DTOs
{
    /// <summary>
    /// An object that safely transmits Weapon data to the application layer
    /// </summary>
    public class WeaponDto
    {
        /// <summary>
        /// Constructs a WeaponDto from a Weapon
        /// </summary>
        /// <param name="weapon"></param>
        public WeaponDto(Weapon weapon)

        {
            var effects = new List<EffectDto>();

            Name = weapon.Name;
            Type = new WeaponTypeDto(weapon.Type);
            Stats = weapon.Stats;
            Rarity = new WeaponRarityDto(weapon.Rarity);
            foreach (var effect in weapon.Effects)
            {
                effects.Add(new EffectDto(effect));
            }
            Effects = effects;
            SellValue = weapon.SellValue;
        }

        public string Name { get; private set; }
        public WeaponTypeDto Type { get; private set; }
        public Dictionary<string, int> Stats { get; private set; }
        public WeaponRarityDto Rarity { get; private set; }
        public List<EffectDto> Effects { get; private set; }
        public int SellValue { get; private set; }
    }
}
