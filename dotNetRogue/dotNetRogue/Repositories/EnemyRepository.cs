using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotNetRogue.Logic.Interfaces;
using dotNetRogue.Logic.Models;

namespace dotNetRogue.Repositories
{
    public class EnemyRepository : IEnemyRepository
    {
        public EnemyRepository(AppDbContext context)
        {
            _context = context;
        }

        private readonly AppDbContext _context;
        public IEnumerable<Enemy> GetEnemies()
        {
            return _context.Enemies;
        }

        public Enemy GetEnemyByName(string name)
        {
            return _context.Enemies.Find(name);
        }

        public Enemy Add(Enemy enemy)
        {
            _context.Add(enemy);
            _context.SaveChanges();
            return enemy;
        }
    }
}
