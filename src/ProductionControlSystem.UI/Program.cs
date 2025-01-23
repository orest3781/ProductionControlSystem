using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProductionControlSystem.Data;
using ProductionControlSystem.Data.Services;
using System;

namespace ProductionControlSystem.UI
    {
    internal class Program
        {
        public static void Main(string[] args)
            {
            // Configure services (DI) before launching Avalonia
            var services = ConfigureServices();
            // Provide the services to a static reference or your own DI container
            ServiceLocator.Configure(services);

            BuildAvaloniaApp()
                .StartWithClassicDesktopLifetime(args);
            }

        private static IServiceProvider ConfigureServices()
            {
            var serviceCollection = new ServiceCollection();

            // Configure EF Core with SQLite
            serviceCollection.AddDbContext<ProductionDbContext>(options =>
                options.UseSqlite("Data Source=production.db"));

            // Register data services
            serviceCollection.AddScoped<ClientService>();
            // ... Add more as needed

            return serviceCollection.BuildServiceProvider();
            }

        public static AppBuilder BuildAvaloniaApp()
            {
            return AppBuilder.Configure<App>()
                             .UsePlatformDetect()
                             .LogToTrace();
            }
        }
    }
