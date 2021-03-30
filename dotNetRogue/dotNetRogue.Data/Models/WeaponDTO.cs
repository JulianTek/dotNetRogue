using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNetRogue.Data.Models
{
    public class WeaponDTO
    {
        public WeaponDTO(string name, WeaponTypeDTO type, Dictionary<string, int> stats, WeaponRarityDTO rarity, List<EffectDTO> effects, int sellValue)
        {
            Name = name;
            Type = type;
            Stats = stats;
            Rarity = rarity;
            Effects = effects;
            SellValue = sellValue;
        }

        public string Name { get; private set; }
        public WeaponTypeDTO Type { get; private set; }
        public Dictionary<string, int> Stats { get; private set; }
        public WeaponRarityDTO Rarity { get; private set; }
        public List<EffectDTO> Effects { get; private set; }
        public int SellValue { get; private set; }
    }
}
