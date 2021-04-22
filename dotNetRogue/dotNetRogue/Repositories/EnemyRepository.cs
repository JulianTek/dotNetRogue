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

        public async Task<Enemy> Add(Enemy enemy)
        {
           await _context.AddAsync(enemy);
            await _context.SaveChangesAsync();
            return enemy;
        }

        public async Task<Enemy> Update(Enemy updatedEnemy)
        {
            var enemyToUpdate = await _context.Enemies.FindAsync(updatedEnemy.Name);
            if (enemyToUpdate != null)
            {
                enemyToUpdate.Name = updatedEnemy.Name;
                enemyToUpdate.Health = updatedEnemy.Health;
                enemyToUpdate.Attack = updatedEnemy.Attack;
                enemyToUpdate.Defense = updatedEnemy.Attack;
                enemyToUpdate.Speed = updatedEnemy.Speed;
                enemyToUpdate.GoldOnKill = updatedEnemy.GoldOnKill;

                await _context.SaveChangesAsync();
                return updatedEnemy;
            }

            return null;
        }
    }
}
