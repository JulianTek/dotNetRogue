using System.Collections.Generic;
using System.Threading.Tasks;
using dotNetRogue.Application.Models.DTOs;
using dotNetRogue.Domain.Models;

namespace dotNetRogue.Application.Interfaces
{
    public interface IEnemyRepository
    {
        /// <summary>
        /// Gets all enemies
        /// </summary>
        /// <returns>IEnumerable of all enemies</returns>
        public Task<IEnumerable<EnemyDto>> GetEnemies();

        /// <summary>
        /// Gets an enemy by its name
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The requested enemy or null if enemy cant be found</returns>
        public Task<EnemyDto> GetEnemyByName(int id);

        /// <summary>
        /// Creates a new enemy and adds it to the database
        /// </summary>
        /// <param name="enemy"></param>
        /// <returns>The created entity or null if enemy could not be created</returns>
        public Task<EnemyDto> Add(NewEnemyDto enemy);

        /// <summary>
        /// Deletes an enemy from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True if enemy is deleted sucessfully, false if enemy could not be deleted</returns>
        public Task<bool> Delete(int id);

        /// <summary>
        /// Updates a database record
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updatedEnemy"></param>
        /// <returns>The updated enemy object, null if enemy could not be found</returns>
        public Task<EnemyDto> Update(int id, Enemy updatedEnemy);
    }
}
