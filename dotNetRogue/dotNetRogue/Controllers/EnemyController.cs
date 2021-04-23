﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotNetRogue.Logic.Interfaces;
using dotNetRogue.Logic.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotNetRogue.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnemyController : ControllerBase
    {
        public EnemyController(IEnemyRepository enemyRepository)
        {
            _enemyRepository = enemyRepository;
        }
        private readonly IEnemyRepository _enemyRepository;

        [HttpGet]
        public IEnumerable<Enemy> Get()
        {
            return _enemyRepository.GetEnemies();
        }

        [HttpPost]
        public IActionResult Post([FromBody]Enemy enemy)
        {
            _enemyRepository.Add(enemy);
            return Ok(enemy);
        }


        [HttpDelete("{name}")]
        public async Task<IActionResult> Delete(string name)
        {
            var result = await _enemyRepository.Delete(name);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
