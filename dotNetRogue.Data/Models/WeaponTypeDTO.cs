using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNetRogue.Data.Models
{
    public class WeaponTypeDTO
    {
        public WeaponTypeDTO(string name, int damage, int dodgeChance)
        {
            Name = name;
            Damage = damage;
            DodgeChance = dodgeChance;
        }

        public WeaponTypeDTO()
        {

        }

        [Key]
        public string Name { get; private set; }
        public int Damage { get; private set; }
        public int DodgeChance { get; private set; }
    }
}
