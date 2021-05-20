using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotNetRogue.Application.Models.DTOs;
using dotNetRogue.Data;
using dotNetRogue.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotNetRogue.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeaponGeneratorController : ControllerBase
    {
        private readonly ApiDecoder _apiDecoder = new ApiDecoder();

        public async Task<ActionResult<WeaponDto>> Get()
        {
            var weapon = await _apiDecoder.GenerateWeaponDto();
            return Ok(weapon);
        }
    }
}
