using System;
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
        private readonly Random _rnd = new Random();

        public Enemy Get()
        {
            var enemies = _enemyRepository.GetEnemies().ToList();
            return enemies[_rnd.Next(0, enemies.Count)];
        }
    }
}
