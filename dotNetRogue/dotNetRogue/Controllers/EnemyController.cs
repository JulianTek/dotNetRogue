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

        public IEnumerable<Enemy> Get()
        {
            return _enemyRepository.GetEnemies();
        }
    }
}
