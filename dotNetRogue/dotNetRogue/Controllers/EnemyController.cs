using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotNetRogue.Application.Interfaces;
using dotNetRogue.Application.Models.DTOs;
using dotNetRogue.Domain.Models;
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
        public async Task<ActionResult<IEnumerable<EnemyDto>>> Get()
        {
            var enemies = await _enemyRepository.GetEnemies();
            if (enemies.ToList().Count == 0)
            {
                return NoContent();
            }

            return Ok(enemies);
        }

        [HttpPost]
        public async Task<ActionResult<EnemyDto>> Post([FromBody]NewEnemyDto enemy)
        {
            var result = await _enemyRepository.Add(enemy);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(enemy);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _enemyRepository.Delete(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<EnemyDto>> Put(int id, [FromBody] Enemy enemy)
        {
            var result = await _enemyRepository.Update(id, enemy);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
            }

    }
}
