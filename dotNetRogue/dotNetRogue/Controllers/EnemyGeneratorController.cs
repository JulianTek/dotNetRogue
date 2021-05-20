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
    public class EnemyGeneratorController : ControllerBase
    {
        public EnemyGeneratorController(IEnemyRepository enemyRepository)
        {
            _enemyRepository = enemyRepository;
        }

        private readonly IEnemyRepository _enemyRepository;
        private readonly Random _rnd = new Random();

        public async Task<ActionResult<EnemyDto>> Get()
        {
            var enemies = await _enemyRepository.GetEnemies();
            var enemy = enemies.ToList()[_rnd.Next(0, enemies.ToList().Count)];
            return Ok(enemy);
        }
    }
}
