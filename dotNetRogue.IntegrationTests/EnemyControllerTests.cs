using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using dotNetRogue.Application.Database;
using dotNetRogue.Application.Models.DTOs;
using dotNetRogue.Domain.Models;
using dotNetRogue.IntegrationTests.Common;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace dotNetRogue.IntegrationTests
{
    public class EnemyControllerTests : IntegrationTestBase
    {
        public EnemyControllerTests(PresentationWebAppFactory<Startup> factory):base(factory)
        { }

        [Theory]
        [InlineData("Jester", 20, 20, 20, 20, 20)]
        public async Task CreateEnemy_ValidInput_Returns_200(string name, int health, int attack, int defense, int speed, int goldOnKill)
        {
            var client = CreateHttpClient();
            var enemy = new NewEnemyDto()
            {
                Name = name,
                Health = health,
                Attack = attack,
                Defense = defense,
                Speed = speed,
                GoldOnKill = goldOnKill
            };

            var response = await client.PostAsJsonAsync("/enemy", enemy);
            
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Theory]
        [InlineData(null, 20, 20, 20, 20, 20)]
        [InlineData("Rocker", 0, 20, 20, 20, 20)]
        [InlineData("Gimp", 20, 0, 20, 20, 20)]
        [InlineData("Executioner", 20, 20, 0, 20, 20)]
        [InlineData("Clown", 20, 20, 20, 0, 20)]
        [InlineData("Acrobat", 20, 20, 20, 20, 0)]
        public async Task CreateEnemy_BadRequest_ReturnsBadRequest(string name, int health, int attack, int defense,
            int speed, int goldOnKill)
        {
            var client = CreateHttpClient();

            var enemy = new NewEnemyDto()
            {
                Name = name,
                Health = health,
                Attack = attack,
                Defense = defense,
                Speed = speed,
                GoldOnKill = goldOnKill
            };

            var response = await client.PostAsJsonAsync("/enemy", enemy);
            
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Theory]
        [InlineData("Lawyer", 20, 20, 20, 20, 20)]
        public async Task GettingEnemies_WithList_ReturnsList(string name, int health, int attack, int defense,
            int speed, int goldOnKill)
        {
            var client = CreateHttpClient();
            var dbContext = GetDbContext();
            var entity = await dbContext.Enemies.AddAsync(new Enemy()
            {
                Name = name,
                Health = health,
                Attack = attack,
                Defense = defense,
                Speed = speed,
                GoldOnKill = goldOnKill
            });
            await dbContext.SaveChangesAsync();

            var response = await client.GetAsync("/enemy");
            var result = await response.DeserializeAsJsonAsync<IEnumerable<EnemyDto>>();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task GettingList_WithNoList_ReturnsNoContent()
        {
            await EmptyDatabase();
            var client = CreateHttpClient();

            var response = await client.GetAsync("/enemy");

            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }

        [Theory]
        [InlineData("Lawyer", 20, 20, 20, 20, 20, "Prosecutor", 30)]
        public async Task UpdateEnemy_ValidId_ReturnsEntity(string name, int health, int attack, int defense, int speed, int goldOnKill, string newName, int newHealth)
        {
            var client = CreateHttpClient();
            var dbContext = GetDbContext();
            var entity = await dbContext.Enemies.AddAsync(new Enemy()
            {
                Name = name,
                Health = health,
                Attack = attack,
                Defense = defense,
                Speed = speed,
                GoldOnKill = goldOnKill
            });
            var newEnemy = new Enemy()
            {
                Name = newName,
                Health = newHealth,
                Attack = attack,
                Defense = defense,
                Speed = speed,
                GoldOnKill = goldOnKill
            };
            await dbContext.SaveChangesAsync();

            var response = await client.PutAsJsonAsync($"/enemy/{entity.Entity.Id}", newEnemy);
            var newEntity = await response.DeserializeAsJsonAsync<EnemyDto>();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(newEntity);
            Assert.NotEqual(newEntity.Name, entity.Entity.Name);
            Assert.NotEqual(newEntity.Health, entity.Entity.Health);
        }
    }
}
