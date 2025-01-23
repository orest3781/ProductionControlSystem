using Microsoft.Extensions.DependencyInjection;
using System;

namespace ProductionControlSystem.UI
    {
    public static class ServiceLocator
        {
        private static IServiceProvider? _serviceProvider;

        public static void Configure(IServiceProvider serviceProvider)
            {
            _serviceProvider = serviceProvider;
            }

        public static T Resolve<T>() where T : notnull
            {
            if (_serviceProvider == null)
                throw new InvalidOperationException("ServiceProvider not configured.");

            return _serviceProvider.GetRequiredService<T>();
            }
        }
    }

