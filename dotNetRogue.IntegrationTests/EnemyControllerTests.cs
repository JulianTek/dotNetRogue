using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using dotNetRogue.Domain.Models;
using Xunit;

namespace dotNetRogue.IntegrationTests
{
    public class EnemyControllerTests
    {
        private readonly  PresentationWebAppFactory<Startup> _factory;
        public EnemyControllerTests()
        {
            _factory = new PresentationWebAppFactory<Startup>();
        }

        [Theory]
        [InlineData("Jester", 20, 20, 20, 20, 20)]
        public async Task CreateEnemy_ValidInput_Returns_200(string name, int health, int attack, int defense, int speed, int goldOnKill)
        {
            var client = _factory.CreateClient();
            var enemy = new Enemy()
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
    }
}
