using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotNetRogue.Data;
using dotNetRogue.Data.Models;
using dotNetRogue.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotNetRogue.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeaponController : ControllerBase
    {
        private readonly ApiDecoder _apiDecoder = new ApiDecoder();

        public async Task<IEnumerable<WeaponDTO>> Get()
        {
            var weapons = new List<WeaponDTO>();

            for (int i = 0; i < 5; i++)
            {
                weapons.Add(await _apiDecoder.GenerateWeaponDto());
            }

            return weapons;
        }
    }
}
