using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotNetRogue.Application.Database;
using dotNetRogue.Application.Interfaces;
using dotNetRogue.Application.Models.DTOs;
using dotNetRogue.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace dotNetRogue.Application.Repositories
{
    public class EnemyRepository : IEnemyRepository
    {
        public EnemyRepository(IAppDbContext context)
        {
            _context = context;
        }

        private readonly IAppDbContext _context;
        public async Task<IEnumerable<EnemyDto>> GetEnemies()
        {
            return await _context.Enemies.Select(enemy => new EnemyDto(enemy)).ToListAsync();
        }

        public async Task<EnemyDto> GetEnemyByName(int id)
        {
            var enemy = await _context.Enemies.FindAsync(id);

            return enemy != null ? new EnemyDto(enemy) : null;
        }

        public async Task<EnemyDto> Add(NewEnemyDto enemy)
        {
            var newEnemy = new Enemy()
            {
                Name = enemy.Name,
                Health = enemy.Health,
                Attack = enemy.Attack,
                Defense = enemy.Defense,
                Speed = enemy.Speed,
                GoldOnKill = enemy.GoldOnKill
            };
            try
            {
                await _context.Enemies.AddAsync(newEnemy);
            }
            catch
            {
                return null;
            }
            await _context.SaveChangesAsync();
            return new EnemyDto(newEnemy);
        }

        public async Task<bool> Delete(int id)
        {
            var enemy = await _context.Enemies.FindAsync(id);

            if (enemy == null)
            {
                return false;
            }
            _context.Enemies.Remove(enemy);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<EnemyDto> Update(int id, Enemy updatedEnemy)
        {
            var enemyToUpdate = await _context.Enemies.FindAsync(id);
            if (enemyToUpdate == null) return null;

            enemyToUpdate.Name = updatedEnemy.Name;
            enemyToUpdate.Health = updatedEnemy.Health;
            enemyToUpdate.Attack = updatedEnemy.Attack;
            enemyToUpdate.Defense = updatedEnemy.Attack;
            enemyToUpdate.Speed = updatedEnemy.Speed;
            enemyToUpdate.GoldOnKill = updatedEnemy.GoldOnKill;

            await _context.SaveChangesAsync();
            return new EnemyDto(updatedEnemy);

        }
    }
}
