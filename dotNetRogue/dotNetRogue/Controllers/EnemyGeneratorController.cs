using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotNetRogue.Application.Interfaces;
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

        public Enemy Get()
        {
            var enemies = _enemyRepository.GetEnemies().ToList();
            return enemies[_rnd.Next(0, enemies.Count)];
        }
    }
}
