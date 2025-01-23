using Microsoft.EntityFrameworkCore;
using ProductionControlSystem.Data;

namespace ProductionControlSystem.Tests
    {
    public class TestBase
        {
        protected ProductionDbContext GetInMemoryDbContext(string dbName)
            {
            var options = new DbContextOptionsBuilder<ProductionDbContext>()
                .UseInMemoryDatabase(dbName)
                .Options;

            return new ProductionDbContext(options);
            }
        }
    }

