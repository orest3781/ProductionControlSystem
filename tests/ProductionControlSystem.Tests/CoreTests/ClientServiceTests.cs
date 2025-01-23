using ProductionControlSystem.Core.Models;
using ProductionControlSystem.Data.Services;
using Xunit;

namespace ProductionControlSystem.Tests.CoreTests
    {
    public class ClientServiceTests : TestBase
        {
        [Fact]
        public async void AddClientAsync_PersistsClient()
            {
            // Arrange
            var dbContext = GetInMemoryDbContext("ClientServiceTests_AddClient");
            var service = new ClientService(dbContext);

            var newClient = new Client
                {
                ClientCode = "C0001",
                Name = "Acme Corporation",
                Address = "123 Industrial Road",
                TurnaroundHours = 48
                };

            // Act
            await service.AddClientAsync(newClient);
            var fetchedClient = await service.GetClientByIdAsync(newClient.Id);

            // Assert
            Assert.NotNull(fetchedClient);
            Assert.Equal("C0001", fetchedClient?.ClientCode);
            }
        }
    }

