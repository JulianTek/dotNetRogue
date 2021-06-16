using System;
using System.Collections.Generic;
using System.Text;
using dotNetRogue.Domain.Models;

namespace dotNetRogue.Application.Models.DTOs
{
    /// <summary>
    /// An object to safely transmit WeaponRarity data to the application layer
    /// </summary>
    public class WeaponRarityDto
    {
        /// <summary>
        /// Construts a WeaponRarityDto from a WeaponRarity object
        /// </summary>
        /// <param name="rarity"></param>
        public WeaponRarityDto(WeaponRarity rarity)
        {
            RarityName = rarity.RarityName;
            AppearChance = rarity.AppearChance;
            StatModMul = rarity.StatModMul;
            AmountOfEffects = rarity.AmountOfEffects;
        }

        public string RarityName { get; private set; }
        public int AppearChance { get; private set; }
        public double StatModMul { get; private set; }
        public int AmountOfEffects { get; private set; }
    }
}
