using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNetRogue.Data.Models
{
    public class WeaponRarityDTO
    {
        public WeaponRarityDTO()
        {

        }
        public WeaponRarityDTO(string name, int appearChance, double statModMul, int amountOfEffects)
        {
            RarityName = name;
            AppearChance = appearChance;
            StatModMul = statModMul;
            AmountOfEffects = amountOfEffects;
        }
        [Key]
        public string RarityName { get; private set; }
        public int AppearChance { get; private set; }
        public double StatModMul { get; private set; }
        public int AmountOfEffects { get; private set; }
    }
}
