using System.Collections.Generic;
using System.Threading.Tasks;
using dotNetRogue.Application.Database;
using dotNetRogue.Application.Interfaces;
using dotNetRogue.Domain.Models;

namespace dotNetRogue.Application.Repositories
{
    public class EnemyRepository : IEnemyRepository
    {
        public EnemyRepository(IAppDbContext context)
        {
            _context = context;
        }

        private readonly IAppDbContext _context;
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
            await _context.Enemies.AddAsync(enemy);
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
