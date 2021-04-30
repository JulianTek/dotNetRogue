using System;
using System.Collections.Generic;
using System.Text;
using dotNetRogue.Domain.Models;

namespace dotNetRogue.Application.Models.DTOs
{
    /// <summary>
    /// An object that safely transmits Effect data to the application layer
    /// </summary>
    public class EffectDto
    {
        /// <summary>
        /// Constructs an EffectDto from an Effect object
        /// </summary>
        /// <param name="effect"></param>
        public EffectDto(Effect effect)
        {
            EffectName = effect.EffectName;
            WeaponNameFix = effect.WeaponNameFix;
            BonusDamage = effect.BonusDamage;
            BonusHealing = effect.BonusHealing;
            ExtraHits = effect.ExtraHits;
        }
        public string EffectName { get; private set; }
        public string WeaponNameFix { get; private set; }
        public int BonusDamage { get; private set; }
        public int BonusHealing { get; private set; }
        public int ExtraHits { get; private set; }
    }
}
