using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotNetRogue.Logic.Models;
using dotNetRogue.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace dotNetRogue.Tests
{
    public class EnemyRepositoryTests
    {
        private readonly DbContextOptions<AppDbContext> _dbContextOptions;

        public EnemyRepositoryTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase("dotNetRogueLocal_EnemyTests").Options;
        }

        [Theory]
        [InlineData(2)]
        public async Task GettingAllEnemyTypes_ReturnsList(int expectedCount)
        {
            await using var dbContext = new AppDbContext(_dbContextOptions);
            await dbContext.Database.EnsureDeletedAsync();

            dbContext.Enemies.AddRange(new List<Enemy>()
            {
                new Enemy()
                {
                    Name = "Fiend",
                    Health = 100,
                    Attack = 10,
                    Defense = 10,
                    Speed = 20,
                    GoldOnKill = 40
                },
                new Enemy()
                {
                    Name = "Demon",
                    Health = 300,
                    Attack = 20,
                    Defense = 30,
                    Speed = 50,
                    GoldOnKill = 30
                }
            });
            await dbContext.SaveChangesAsync();
            var repository = new EnemyRepository(dbContext);

            var result = repository.GetEnemies().ToList();

            Assert.Equal(expectedCount, result.Count);
        }

        [Theory]
        [InlineData("Luchador", 50, 20, 20, 100, 30)]
        public async Task GettingEnemyByName_ValidInput_ReturnsEntity(string name, int health, int attack, int defense,
            int speed, int goldOnKill)
        {
            await using var dbContext = new AppDbContext(_dbContextOptions);
            await dbContext.Database.EnsureDeletedAsync();

            await dbContext.AddAsync(new Enemy()
            {
                Name = name,
                Health = health,
                Attack = attack,
                Defense = defense,
                Speed = speed,
                GoldOnKill = goldOnKill
            });
            await dbContext.SaveChangesAsync();
            var repository = new EnemyRepository(dbContext);

            var result = await repository.GetEnemyByName(name);

            Assert.NotNull(result);
            Assert.Equal(name, result.Name);
            Assert.Equal(health, result.Health);
            Assert.Equal(attack, result.Attack);
            Assert.Equal(defense, result.Defense);
            Assert.Equal(speed, result.Speed);
            Assert.Equal(goldOnKill, result.GoldOnKill);
        }

        [Theory]
        [InlineData("Luchador", 50, 20, 20, 100, 30)]
        public async Task GettingEnemyByName_InvalidInput_ReturnsNull(string name, int health, int attack, int defense,
            int speed, int goldOnKill)
        {
            await using var dbContext = new AppDbContext(_dbContextOptions);
            await dbContext.Database.EnsureDeletedAsync();

            await dbContext.AddAsync(new Enemy()
            {
                Name = name,
                Health = health,
                Attack = attack,
                Defense = defense,
                Speed = speed,
                GoldOnKill = goldOnKill
            });
            await dbContext.SaveChangesAsync();
            var repository = new EnemyRepository(dbContext);

            var result = await repository.GetEnemyByName("Luchadore");

            Assert.Null(result);
        }

        [Theory]
        [InlineData("Luchador", 50, 20, 20, 100, 30)]
        public async Task CreatingEnemy_ValidInput_ReturnsEntity(string name, int health, int attack, int defense,
            int speed, int goldOnKill)
        {
            await using var dbContext = new AppDbContext(_dbContextOptions);
            await dbContext.Database.EnsureDeletedAsync();

            await dbContext.SaveChangesAsync();
            var repository = new EnemyRepository(dbContext);

            var result = await repository.Add(new Enemy()
            {
                Name = name,
                Health = health,
                Attack = attack,
                Defense = defense,
                Speed = speed,
                GoldOnKill = goldOnKill
            });

            Assert.NotNull(result);
            Assert.Equal(name, result.Name);
            Assert.Equal(health, result.Health);
            Assert.Equal(attack, result.Attack);
            Assert.Equal(defense, result.Defense);
            Assert.Equal(speed, result.Speed);
            Assert.Equal(goldOnKill, result.GoldOnKill);
        }

        [Theory]
        [InlineData("Luchador", 50, 20, 20, 100, 30)]
        public async Task DeletingEnemy_ValidInput_ReturnsTrue(string name, int health, int attack, int defense,
            int speed, int goldOnKill)
        {
            await using var dbContext = new AppDbContext(_dbContextOptions);
            await dbContext.Database.EnsureDeletedAsync();
            await dbContext.AddAsync(new Enemy()
            {
                Name = name,
                Health = health,
                Attack = attack,
                Defense = defense,
                Speed = speed,
                GoldOnKill = goldOnKill
            });
            await dbContext.SaveChangesAsync();
            var repository = new EnemyRepository(dbContext);

            var result = await repository.Delete("Luchadore");

            Assert.False(result);
        }

        [Theory]
        [InlineData("Luchador", 50, 20, 20, 100, 30)]
        public async Task UpdatingEnemy_ValidInput_ReturnsEntity(string name, int health, int attack, int defense,
            int speed, int goldOnKill)
        {
            await using var dbContext = new AppDbContext(_dbContextOptions);
            await dbContext.Database.EnsureDeletedAsync();
            await dbContext.AddAsync(new Enemy()
            {
                Name = name,
                Health = health,
                Attack = attack,
                Defense = defense,
                Speed = speed,
                GoldOnKill = goldOnKill
            });
            var updatedEnemy = new Enemy()
            {
                Name = name,
                Health = health + 1,
                Attack = attack + 2,
                Defense = defense + 3,
                Speed = speed + 4,
                GoldOnKill = goldOnKill + 5
            };
            await dbContext.SaveChangesAsync();
            var repository = new EnemyRepository(dbContext);

            var result = await repository.Update(updatedEnemy);

            Assert.NotNull(result);
            Assert.Equal(name, result.Name);
            Assert.NotEqual(health, result.Health);
            Assert.NotEqual(attack, result.Attack);
            Assert.NotEqual(defense, result.Defense);
            Assert.NotEqual(speed, result.Speed);
            Assert.NotEqual(goldOnKill, result.GoldOnKill);
            Assert.Equal(health + 1, result.Health);
            Assert.Equal(attack + 2, result.Attack);
            Assert.Equal(defense + 3, result.Defense);
            Assert.Equal(speed + 4, result.Speed);
            Assert.Equal(goldOnKill + 5, result.GoldOnKill);
        }
        [Theory]
        [InlineData("Luchador", 50, 20, 20, 100, 30)]
        public async Task UpdatingEnemy_InvalidInput_ReturnsNull(string name, int health, int attack, int defense,
            int speed, int goldOnKill)
        {
            await using var dbContext = new AppDbContext(_dbContextOptions);
            await dbContext.Database.EnsureDeletedAsync();
            await dbContext.AddAsync(new Enemy()
            {
                Name = name,
                Health = health,
                Attack = attack,
                Defense = defense,
                Speed = speed,
                GoldOnKill = goldOnKill
            });
            var updatedEnemy = new Enemy()
            {
                Name = "Luchadore",
                Health = health + 1,
                Attack = attack + 2,
                Defense = defense + 3,
                Speed = speed + 4,
                GoldOnKill = goldOnKill + 5
            };
            await dbContext.SaveChangesAsync();
            var repository = new EnemyRepository(dbContext);

            var result = await repository.Update(updatedEnemy);

            Assert.Null(result);
        }
    }
}
