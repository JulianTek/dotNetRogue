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

        public async Task<Enemy> GetEnemyByName(string name)
        {
            var enemy = await _context.Enemies.FindAsync(name);

            return enemy ?? null;
        }

        public async Task<Enemy> Add(Enemy enemy)
        {   
            await _context.AddAsync(enemy);
            await _context.SaveChangesAsync();
            return enemy;
        }

        public async Task<bool> Delete(string name)
        {
            var enemy = await _context.Enemies.FindAsync(name);

            if (enemy == null)
            {
                return false;
            }
            _context.Enemies.Remove(enemy);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
