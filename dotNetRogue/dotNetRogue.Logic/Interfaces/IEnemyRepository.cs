using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using dotNetRogue.Logic.Models;

namespace dotNetRogue.Logic.Interfaces
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
