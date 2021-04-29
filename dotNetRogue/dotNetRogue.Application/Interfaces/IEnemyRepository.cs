using System.Collections.Generic;
using System.Threading.Tasks;
using dotNetRogue.Domain.Models;

namespace dotNetRogue.Application.Interfaces
{
    public interface IEnemyRepository
    {
        public IEnumerable<Enemy> GetEnemies();
        public Task<Enemy> GetEnemyByName(string name);
        public Task<Enemy> Add(Enemy enemy);
        public Task<bool> Delete(string name);
        public Task<Enemy> Update(Enemy updatedEnemy);
    }
}
