using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotNetRogue.Application.Database;
using dotNetRogue.Application.Interfaces;
using dotNetRogue.Application.Models.DTOs;
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
        public IEnumerable<EnemyDto> GetEnemies()
        {
            var enemyDtos = new List<EnemyDto>();
            var enemies = _context.Enemies.ToList();

            foreach (var enemy in enemies)
            {
                enemyDtos.Add(new EnemyDto(enemy));
            }

            return enemyDtos;
        }

        public async Task<EnemyDto> GetEnemyByName(string name)
        {
            var enemy = await _context.Enemies.FindAsync(name);

            return enemy != null ? new EnemyDto(enemy) : null;
        }

        public async Task<EnemyDto> Add(Enemy enemy)
        {
            await _context.Enemies.AddAsync(enemy);
            await _context.SaveChangesAsync();
            return new EnemyDto(enemy);
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

        public async Task<EnemyDto> Update(Enemy updatedEnemy)
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
                return new EnemyDto(updatedEnemy);
            }

            return null;
        }
    }
}
