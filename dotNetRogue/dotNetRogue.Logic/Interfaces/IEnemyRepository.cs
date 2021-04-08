using System;
using System.Collections.Generic;
using System.Text;
using dotNetRogue.Logic.Models;

namespace dotNetRogue.Logic.Interfaces
{
    public interface IEnemyRepository
    {
        public IEnumerable<Enemy> GetEnemies();
        public Enemy GetEnemyByName(string name);
        public Enemy Add(Enemy enemy);
    }
}
